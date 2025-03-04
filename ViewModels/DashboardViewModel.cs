using ModernCRM.Models;
using ModernCRM.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModernCRM.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private readonly CustomerService _customerService;
        private readonly TransactionService _transactionService;
        
        private int _totalCustomers;
        private decimal _totalIncome;
        private decimal _totalExpense;
        private decimal _balance;
        private ObservableCollection<Transaction> _recentTransactions;
        private ObservableCollection<Customer> _topCustomers;
        
        public int TotalCustomers
        {
            get => _totalCustomers;
            set => SetProperty(ref _totalCustomers, value);
        }
        
        public decimal TotalIncome
        {
            get => _totalIncome;
            set => SetProperty(ref _totalIncome, value);
        }
        
        public decimal TotalExpense
        {
            get => _totalExpense;
            set => SetProperty(ref _totalExpense, value);
        }
        
        public decimal Balance
        {
            get => _balance;
            set => SetProperty(ref _balance, value);
        }
        
        public ObservableCollection<Transaction> RecentTransactions
        {
            get => _recentTransactions;
            set => SetProperty(ref _recentTransactions, value);
        }
        
        public ObservableCollection<Customer> TopCustomers
        {
            get => _topCustomers;
            set => SetProperty(ref _topCustomers, value);
        }
        
        public DashboardViewModel()
        {
            _customerService = new CustomerService();
            _transactionService = new TransactionService();
            
            RecentTransactions = new ObservableCollection<Transaction>();
            TopCustomers = new ObservableCollection<Customer>();
            
            LoadDataAsync();
        }
        
        private async Task LoadDataAsync()
        {
            await LoadCustomersAsync();
            await LoadFinancialsAsync();
            await LoadRecentTransactionsAsync();
        }
        
        private async Task LoadCustomersAsync()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            TotalCustomers = customers.Count;
            
            TopCustomers.Clear();
            
            // Basit bir implementasyon, gerçekte daha karmaşık bir sıralama kullanılabilir
            foreach (var customer in customers.Take(5))
            {
                TopCustomers.Add(customer);
            }
        }
        
        private async Task LoadFinancialsAsync()
        {
            TotalIncome = await _transactionService.GetTotalIncomeAsync();
            TotalExpense = await _transactionService.GetTotalExpenseAsync();
            Balance = await _transactionService.GetBalanceAsync();
        }
        
        private async Task LoadRecentTransactionsAsync()
        {
            var transactions = await _transactionService.GetAllTransactionsAsync();
            
            RecentTransactions.Clear();
            
            // Son 10 işlemi al
            foreach (var transaction in transactions.OrderByDescending(t => t.Date).Take(10))
            {
                RecentTransactions.Add(transaction);
            }
        }
    }
} 