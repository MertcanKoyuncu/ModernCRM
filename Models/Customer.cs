using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModernCRM.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(100)]
        public string? Company { get; set; }
        
        [MaxLength(15)]
        public string? Phone { get; set; }
        
        [MaxLength(100)]
        public string? Email { get; set; }
        
        [MaxLength(200)]
        public string? Address { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime? LastContactDate { get; set; }
        
        [MaxLength(500)]
        public string? Notes { get; set; }
        
        // İlişkiler
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        
        // Müşteriye atanmış temsilciler
        public virtual ICollection<CustomerAgent> CustomerAgents { get; set; } = new List<CustomerAgent>();
        
        public Customer()
        {
            Name = string.Empty;
        }
    }
} 