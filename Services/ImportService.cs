using ModernCRM.Data;
using ModernCRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ModernCRM.Services
{
    public class ImportService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly AgentService _agentService;

        public ImportService(ApplicationDbContext dbContext, AgentService agentService)
        {
            _dbContext = dbContext;
            _agentService = agentService;
        }

        /// <summary>
        /// Excel dosyasından müşteri verilerini içe aktarır
        /// </summary>
        /// <param name="filePath">Excel dosyasının yolu</param>
        /// <returns>İçe aktarılan müşteri sayısı ve hata mesajları</returns>
        public async Task<Tuple<int, List<string>>> ImportCustomersFromExcelAsync(string filePath)
        {
            var errorMessages = new List<string>();
            int importCount = 0;

            try
            {
                // Dosya kontrolü
                if (string.IsNullOrEmpty(filePath))
                {
                    errorMessages.Add("Dosya yolu belirtilmedi.");
                    return new Tuple<int, List<string>>(importCount, errorMessages);
                }

                if (!File.Exists(filePath))
                {
                    errorMessages.Add("Belirtilen dosya bulunamadı.");
                    return new Tuple<int, List<string>>(importCount, errorMessages);
                }

                // EPPlus lisans ayarı
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    // İlk çalışma sayfasını al
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension?.Rows ?? 0;

                    if (rowCount <= 1)
                    {
                        errorMessages.Add("Excel dosyası boş veya sadece başlık satırı içeriyor.");
                        return new Tuple<int, List<string>>(importCount, errorMessages);
                    }

                    // Başlık satırını geç, 2. satırdan başla
                    for (int row = 2; row <= rowCount; row++)
                    {
                        try
                        {
                            // Excel'den veri oku
                            var fullName = worksheet.Cells[row, 1].Value?.ToString()?.Trim();
                            var company = worksheet.Cells[row, 2].Value?.ToString()?.Trim();
                            var phone = worksheet.Cells[row, 3].Value?.ToString()?.Trim();
                            var email = worksheet.Cells[row, 4].Value?.ToString()?.Trim();
                            var address = worksheet.Cells[row, 5].Value?.ToString()?.Trim();
                            var notes = worksheet.Cells[row, 6].Value?.ToString()?.Trim();

                            // Zorunlu alanları kontrol et
                            if (string.IsNullOrEmpty(fullName))
                            {
                                errorMessages.Add($"Satır {row}: Ad Soyad alanı boş olamaz.");
                                continue;
                            }

                            if (string.IsNullOrEmpty(phone) && string.IsNullOrEmpty(email))
                            {
                                errorMessages.Add($"Satır {row}: Telefon veya E-posta alanlarından en az biri doldurulmalıdır.");
                                continue;
                            }

                            // Mevcut müşteriyi kontrol et
                            var existingCustomer = await FindExistingCustomerAsync(phone, email);

                            if (existingCustomer != null)
                            {
                                // Mevcut müşteriyi güncelle
                                existingCustomer.Name = fullName;
                                if (!string.IsNullOrEmpty(company)) existingCustomer.Company = company;
                                if (!string.IsNullOrEmpty(phone)) existingCustomer.Phone = phone;
                                if (!string.IsNullOrEmpty(email)) existingCustomer.Email = email;
                                if (!string.IsNullOrEmpty(address)) existingCustomer.Address = address;
                                if (!string.IsNullOrEmpty(notes)) existingCustomer.Notes = notes;
                                existingCustomer.LastContactDate = DateTime.Now;

                                await _dbContext.SaveChangesAsync();
                                importCount++;
                            }
                            else
                            {
                                // Yeni müşteri ekle
                                var newCustomer = new Customer
                                {
                                    Name = fullName,
                                    Company = company ?? "",
                                    Phone = phone ?? "",
                                    Email = email ?? "",
                                    Address = address ?? "",
                                    Notes = notes ?? "",
                                    CreatedAt = DateTime.Now,
                                    LastContactDate = DateTime.Now
                                };

                                await _dbContext.Customers.AddAsync(newCustomer);
                                await _dbContext.SaveChangesAsync();
                                importCount++;
                            }
                        }
                        catch (Exception ex)
                        {
                            errorMessages.Add($"Satır {row}: İşlem hatası: {ex.Message}");
                        }
                    }
                }

                return new Tuple<int, List<string>>(importCount, errorMessages);
            }
            catch (Exception ex)
            {
                errorMessages.Add($"İçe aktarma işlemi sırasında bir hata oluştu: {ex.Message}");
                return new Tuple<int, List<string>>(importCount, errorMessages);
            }
        }
        
        /// <summary>
        /// Telefon veya e-posta ile mevcut müşteri arar
        /// </summary>
        private async Task<Customer?> FindExistingCustomerAsync(string? phone, string? email)
        {
            if (string.IsNullOrEmpty(phone) && string.IsNullOrEmpty(email))
                return null;

            var customer = await _dbContext.Customers
                .Where(c => (!string.IsNullOrEmpty(phone) && c.Phone == phone) || 
                           (!string.IsNullOrEmpty(email) && c.Email == email))
                .FirstOrDefaultAsync();

            return customer;
        }
        
        /// <summary>
        /// Atanmamış müşterileri aktif agentlara rastgele dağıtır
        /// </summary>
        /// <returns>Atanan müşteri sayısı, agent sayısı ve hata mesajları</returns>
        public async Task<Tuple<int, int, List<string>>> AssignCustomersToAgentsRandomlyAsync()
        {
            var errorMessages = new List<string>();
            int assignedCount = 0;
            int agentCount = 0;

            try
            {
                // Aktif agentları al
                var activeAgents = await _dbContext.Agents
                    .Where(a => a.IsActive)
                    .ToListAsync();

                if (activeAgents.Count == 0)
                {
                    errorMessages.Add("Atama için aktif agent bulunamadı.");
                    return new Tuple<int, int, List<string>>(assignedCount, agentCount, errorMessages);
                }

                // Henüz bir agenta atanmamış müşterileri bul
                var unassignedCustomers = await _dbContext.Customers
                    .Where(c => !_dbContext.CustomerAgents.Any(ca => ca.CustomerId == c.Id && ca.IsActive))
                    .ToListAsync();

                if (unassignedCustomers.Count == 0)
                {
                    errorMessages.Add("Atanacak müşteri bulunamadı. Tüm müşteriler zaten atanmış olabilir.");
                    return new Tuple<int, int, List<string>>(assignedCount, agentCount, errorMessages);
                }

                // Rastgele atama için Random nesnesi
                var random = new Random();
                agentCount = activeAgents.Count;

                // Her müşteriyi rastgele bir agenta ata
                foreach (var customer in unassignedCustomers)
                {
                    // Rastgele bir agent seç
                    var randomIndex = random.Next(0, activeAgents.Count);
                    var selectedAgent = activeAgents[randomIndex];

                    // Müşteri-Agent ilişkisi oluştur
                    var customerAgent = new CustomerAgent
                    {
                        CustomerId = customer.Id,
                        AgentId = selectedAgent.Id,
                        AssignedDate = DateTime.Now,
                        LastCallDate = null,
                        Status = CallStatus.NotCalled,
                        Notes = "Otomatik atama",
                        IsActive = true
                    };

                    await _dbContext.CustomerAgents.AddAsync(customerAgent);
                    assignedCount++;
                }

                await _dbContext.SaveChangesAsync();
                return new Tuple<int, int, List<string>>(assignedCount, agentCount, errorMessages);
            }
            catch (Exception ex)
            {
                errorMessages.Add($"Müşteri atama işlemi sırasında bir hata oluştu: {ex.Message}");
                return new Tuple<int, int, List<string>>(assignedCount, agentCount, errorMessages);
            }
        }
    }
} 