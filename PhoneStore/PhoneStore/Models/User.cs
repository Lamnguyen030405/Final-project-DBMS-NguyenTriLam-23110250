using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Models/UserAccount.cs
namespace PhoneStoreManagement.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int? EmployeeId { get; set; }
        public string Status { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public string EmployeeName { get; set; }
        public string Position { get; set; }
        public List<string> Roles { get; set; }
    }
}