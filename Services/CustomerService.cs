using Microsoft.EntityFrameworkCore;
using ModernCRM.Data;
using ModernCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernCRM.Services
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _dbContext;
        
        public CustomerService()
        {
            _dbContext = new ApplicationDbContext();
        }
        
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }
        
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }
        
        public async Task<bool> AddCustomerAsync(Customer customer)
        {
            try
            {
                _dbContext.Customers.Add(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                _dbContext.Customers.Update(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            try
            {
                var customer = await _dbContext.Customers.FindAsync(id);
                if (customer == null)
                    return false;
                    
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public async Task<List<Customer>> SearchCustomersAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllCustomersAsync();
                
            return await _dbContext.Customers
                .Where(c => c.Name.Contains(searchTerm) || 
                       c.Email.Contains(searchTerm) || 
                       c.Company.Contains(searchTerm) ||
                       c.Phone.Contains(searchTerm))
                .ToListAsync();
        }
        
        // Günlük aramalar - burada customer araması kaydı tutmak için bir tablo olduğunu varsayıyorum,
        // eğer yoksa veya farklı bir tabloda tutuluyorsa bu metotları ona göre düzenlemek gerekir
        public async Task<int> GetTodaySearchCountAsync()
        {
            // Eğer gerçek bir arama kaydı tutuluyorsa, o tabloda sorgu yapılmalı
            // Şimdilik örnek olarak 15 rakamını döndürüyorum
            return 15; // Örnek değer
        }
        
        public async Task<List<Customer>> GetRecentSearchesAsync(int count = 5)
        {
            // Gerçek bir arama kaydı tutuluyorsa, son aramaları getirmeli
            // Şimdilik örnek olarak rasatgele 5 müşteriyi döndürüyorum
            return await _dbContext.Customers
                .OrderBy(c => Guid.NewGuid())
                .Take(count)
                .ToListAsync();
        }
    }
} 