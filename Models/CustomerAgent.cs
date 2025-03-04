using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernCRM.Models
{
    public class CustomerAgent
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        
        public int AgentId { get; set; }
        
        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }
        
        [ForeignKey("AgentId")]
        public virtual Agent? Agent { get; set; }
        
        public DateTime AssignedDate { get; set; } = DateTime.Now;
        
        public bool IsActive { get; set; } = true;
        
        [MaxLength(500)]
        public string? Notes { get; set; }
        
        // Çağrı durumu
        public CallStatus Status { get; set; } = CallStatus.NotCalled;
        
        // Son çağrı tarihi
        public DateTime? LastCallDate { get; set; }
        
        public CustomerAgent()
        {
        }
    }
    
    public enum CallStatus
    {
        NotCalled,
        Called,
        Busy,
        NoAnswer,
        WrongNumber,
        Callback,
        Completed,
        Rejected
    }
} 