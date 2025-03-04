using Microsoft.EntityFrameworkCore;
using ModernCRM.Data;
using ModernCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernCRM.Services
{
    public class AgentService
    {
        private readonly ApplicationDbContext _dbContext;
        
        public AgentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// Tüm agent'ları getirir
        /// </summary>
        public async Task<List<Agent>> GetAllAgentsAsync()
        {
            try
            {
                return await _dbContext.Agents
                    .OrderBy(a => a.Name)
                    .ToListAsync();
            }
            catch (Exception)
            {
                return new List<Agent>();
            }
        }
        
        /// <summary>
        /// ID'ye göre agent getirir
        /// </summary>
        public async Task<Agent> GetAgentByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Agents
                    .FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Yeni agent ekler
        /// </summary>
        public async Task<bool> AddAgentAsync(Agent agent)
        {
            try
            {
                if (agent == null)
                    return false;

                // Agent'ı ekle
                _dbContext.Agents.Add(agent);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        /// <summary>
        /// Agent bilgilerini günceller
        /// </summary>
        public async Task<bool> UpdateAgentAsync(Agent agent)
        {
            try
            {
                if (agent == null || agent.Id <= 0)
                    return false;

                // Agent'ı güncelle
                _dbContext.Agents.Update(agent);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        /// <summary>
        /// Agent siler
        /// </summary>
        public async Task<bool> DeleteAgentAsync(int id)
        {
            try
            {
                var agent = await _dbContext.Agents.FindAsync(id);
                if (agent == null)
                    return false;
                
                // Agent'ı pasif hale getir (tamamen silme)
                agent.IsActive = false;
                
                // İlişkili CustomerAgent kayıtlarını da pasif yap
                var customerAgents = await _dbContext.CustomerAgents
                    .Where(ca => ca.AgentId == id && ca.IsActive)
                    .ToListAsync();
                
                foreach (var ca in customerAgents)
                {
                    ca.IsActive = false;
                }
                
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        /// <summary>
        /// Agent'ın atandığı müşterileri getirir
        /// </summary>
        public async Task<List<Customer>> GetAgentCustomersAsync(int agentId)
        {
            try
            {
                return await _dbContext.CustomerAgents
                    .Where(ca => ca.AgentId == agentId && ca.IsActive)
                    .Include(ca => ca.Customer)
                    .Select(ca => ca.Customer)
                    .ToListAsync();
            }
            catch (Exception)
            {
                return new List<Customer>();
            }
        }
        
        /// <summary>
        /// Agent'ın çağrı durumlarını özet olarak getirir
        /// </summary>
        public async Task<Dictionary<CallStatus, int>> GetAgentCallStatusSummaryAsync(int agentId)
        {
            try
            {
                // Tüm olası durumlar için dictionary başlat
                var summary = Enum.GetValues(typeof(CallStatus))
                    .Cast<CallStatus>()
                    .ToDictionary(status => status, status => 0);

                // Agentın aktif müşterilerini getir
                var customerAgents = await _dbContext.CustomerAgents
                    .Where(ca => ca.AgentId == agentId && ca.IsActive)
                    .ToListAsync();

                // Her durum için sayı
                foreach (var ca in customerAgents)
                {
                    summary[ca.Status]++;
                }

                return summary;
            }
            catch (Exception)
            {
                return new Dictionary<CallStatus, int>();
            }
        }
        
        /// <summary>
        /// Belirli bir agent'a müşteri atar
        /// </summary>
        public async Task<bool> AssignCustomerToAgentAsync(int customerId, int agentId)
        {
            try
            {
                // Müşteri ve agentın varlığını kontrol et
                var customer = await _dbContext.Customers.FindAsync(customerId);
                var agent = await _dbContext.Agents.FindAsync(agentId);

                if (customer == null || agent == null)
                    return false;

                // Bu müşterinin daha önce bu agenta atanıp atanmadığını kontrol et
                var existingAssignment = await _dbContext.CustomerAgents
                    .FirstOrDefaultAsync(ca => ca.CustomerId == customerId && ca.AgentId == agentId);

                if (existingAssignment != null)
                {
                    // Varsa aktif yap
                    if (!existingAssignment.IsActive)
                    {
                        existingAssignment.IsActive = true;
                        existingAssignment.AssignedDate = DateTime.Now;
                        existingAssignment.Status = CallStatus.NotCalled;
                    }
                }
                else
                {
                    // Yoksa yeni bir atama oluştur
                    var customerAgent = new CustomerAgent
                    {
                        CustomerId = customerId,
                        AgentId = agentId,
                        AssignedDate = DateTime.Now,
                        IsActive = true,
                        Status = CallStatus.NotCalled
                    };

                    _dbContext.CustomerAgents.Add(customerAgent);
                }

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        /// <summary>
        /// Çağrı durumunu günceller
        /// </summary>
        public async Task<bool> UpdateCallStatusAsync(int customerAgentId, CallStatus status, string notes = null)
        {
            try
            {
                var customerAgent = await _dbContext.CustomerAgents.FindAsync(customerAgentId);
                if (customerAgent == null)
                    return false;
                
                customerAgent.Status = status;
                customerAgent.LastCallDate = DateTime.Now;
                
                if (!string.IsNullOrWhiteSpace(notes))
                {
                    customerAgent.Notes = notes;
                }
                
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
} 