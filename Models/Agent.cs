using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModernCRM.Models
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(15)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(100)]
        public string? Department { get; set; }

        [MaxLength(100)]
        public string? Position { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime HireDate { get; set; } = DateTime.Now;

        [MaxLength(500)]
        public string? Notes { get; set; }

        // Agent'a atanmış müşteriler
        public virtual ICollection<CustomerAgent> CustomerAgents { get; set; } = new List<CustomerAgent>();
        
        public Agent()
        {
            Name = string.Empty;
        }
    }
} 