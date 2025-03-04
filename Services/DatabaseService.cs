using ModernCRM.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace ModernCRM.Services
{
    public class DatabaseService
    {
        private readonly ApplicationDbContext _dbContext;
        
        public DatabaseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task InitializeDatabaseAsync()
        {
            try
            {
                // Veritabanı bağlantısını kontrol et
                bool canConnect = await CheckConnectionAsync();
                
                if (canConnect)
                {
                    // Veritabanını oluştur veya güncelle
                    await _dbContext.Database.EnsureCreatedAsync();
                    Console.WriteLine("Veritabanı başarıyla oluşturuldu veya güncellendi.");
                }
                else
                {
                    // Veritabanı oluşturulmamış olabilir, oluşturmayı dene
                    if (TryCreateDatabase())
                    {
                        Console.WriteLine("Veritabanı başarıyla oluşturuldu.");
                    }
                    else
                    {
                        throw new Exception("MySQL veritabanına bağlantı kurulamadı. Lütfen MySQL'in çalıştığından ve bağlantı ayarlarının doğru olduğundan emin olun.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Veritabanı oluşturulurken hata oluştu: {ex.Message}");
                throw;
            }
        }
        
        // MySQL bağlantısını kontrol et (asenkron)
        private async Task<bool> CheckConnectionAsync()
        {
            try
            {
                // Bağlantıyı kontrol et
                return await _dbContext.Database.CanConnectAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Veritabanı bağlantısı kontrol edilirken hata oluştu: {ex.Message}");
                return false;
            }
        }

        // MySQL bağlantısını kontrol et (senkron)
        public bool CheckDatabaseConnection()
        {
            try
            {
                // Bağlantıyı kontrol et
                var result = _dbContext.Database.CanConnect();
                if (result)
                {
                    Console.WriteLine("Veritabanı bağlantısı başarılı.");
                }
                else
                {
                    Console.WriteLine("Veritabanı bağlantısı başarısız, ancak hata fırlatılmadı.");
                }
                return result;
            }
            catch (DbUpdateException sqlEx)
            {
                Console.WriteLine($"MySQL bağlantı hatası: {sqlEx.Message}");
                
                // Hata detayları
                if(sqlEx.InnerException != null)
                {
                    Console.WriteLine($"İç hata: {sqlEx.InnerException.Message}");
                }
                
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Veritabanı bağlantısı kontrol edilirken hata oluştu: {ex.Message}");
                return false;
            }
        }

        // MySQL bağlantısını bir kez daha deneme ve veritabanı oluşturma
        public bool TryCreateDatabase()
        {
            try
            {
                // Veritabanını oluştur
                _dbContext.Database.EnsureCreated();
                Console.WriteLine("Veritabanı başarıyla oluşturuldu.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Veritabanı oluşturulurken hata oluştu: {ex.Message}");
                return false;
            }
        }

        // Migrations uygula
        public async Task ApplyMigrationsAsync()
        {
            try
            {
                await _dbContext.Database.MigrateAsync();
                Console.WriteLine("Veritabanı migrasyonları başarıyla uygulandı.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Migrasyonlar uygulanırken hata oluştu: {ex.Message}");
                throw;
            }
        }
    }
} 