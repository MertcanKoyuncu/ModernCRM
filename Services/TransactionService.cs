using Microsoft.EntityFrameworkCore;
using ModernCRM.Data;
using ModernCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernCRM.Services
{
    public class TransactionService
    {
        private readonly ApplicationDbContext _dbContext;
        
        public TransactionService()
        {
            _dbContext = new ApplicationDbContext();
        }
        
        public async Task<List<Transaction>> GetAllTransactionsAsync()
        {
            return await _dbContext.Transactions
                .Include(t => t.Customer)
                .ToListAsync();
        }
        
        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            return await _dbContext.Transactions
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
        
        public async Task<List<Transaction>> GetTransactionsByCustomerIdAsync(int customerId)
        {
            return await _dbContext.Transactions
                .Where(t => t.CustomerId == customerId)
                .Include(t => t.Customer)
                .ToListAsync();
        }
        
        public async Task<bool> AddTransactionAsync(Transaction transaction)
        {
            try
            {
                _dbContext.Transactions.Add(transaction);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public async Task<bool> UpdateTransactionAsync(Transaction transaction)
        {
            try
            {
                _dbContext.Transactions.Update(transaction);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public async Task<bool> DeleteTransactionAsync(int id)
        {
            try
            {
                var transaction = await _dbContext.Transactions.FindAsync(id);
                if (transaction == null)
                    return false;
                    
                _dbContext.Transactions.Remove(transaction);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public async Task<decimal> GetTotalIncomeAsync()
        {
            return await _dbContext.Transactions
                .Where(t => t.Type == TransactionType.Income)
                .SumAsync(t => t.Amount);
        }
        
        public async Task<decimal> GetTotalExpenseAsync()
        {
            return await _dbContext.Transactions
                .Where(t => t.Type == TransactionType.Expense)
                .SumAsync(t => t.Amount);
        }
        
        public async Task<decimal> GetBalanceAsync()
        {
            var income = await GetTotalIncomeAsync();
            var expense = await GetTotalExpenseAsync();
            return income - expense;
        }
        
        public async Task<List<Transaction>> GetTransactionsForTodayAsync()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            
            return await _dbContext.Transactions
                .Include(t => t.Customer)
                .Where(t => t.Date >= today && t.Date < tomorrow)
                .ToListAsync();
        }
        
        public async Task<int> GetTodayTransactionsCountAsync()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            
            return await _dbContext.Transactions
                .CountAsync(t => t.Date >= today && t.Date < tomorrow);
        }
        
        public async Task<decimal> GetTodayIncomeAsync()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            
            return await _dbContext.Transactions
                .Where(t => t.Date >= today && t.Date < tomorrow && t.Type == TransactionType.Income)
                .SumAsync(t => t.Amount);
        }
    }
} 