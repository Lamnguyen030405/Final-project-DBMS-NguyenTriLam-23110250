using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Models/Customer.cs
namespace PhoneStoreManagement.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string CustomerType { get; set; }
        public decimal TotalSpent { get; set; }
        public DateTime CreatedAt { get; internal set; }
    }
}
