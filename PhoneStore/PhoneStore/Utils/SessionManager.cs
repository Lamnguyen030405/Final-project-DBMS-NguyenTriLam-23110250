using PhoneStoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Utils
{
    public static class SessionManager
    {
        private static User _currentUser;
        private static DateTime _loginTime;

        public static User CurrentUser
        {
            get { return _currentUser; }
            private set { _currentUser = value; }
        }

        public static bool IsLoggedIn => _currentUser != null;

        public static void SetCurrentUser(User user)
        {
            CurrentUser = user;
            _loginTime = DateTime.Now;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static bool HasRole(string roleName)
        {
            return CurrentUser?.Roles?.Contains(roleName) ?? false;
        }

        public static bool IsAdmin => HasRole("Admin");
        public static bool IsManager => HasRole("Manager") || IsAdmin;
        public static bool IsCashier => HasRole("Cashier") || IsManager;
        public static bool IsSalesperson => HasRole("Salesperson") || IsManager;

        public static string GetUserDisplayName()
        {
            return CurrentUser?.EmployeeName ?? CurrentUser?.Username ?? "Unknown";
        }
    }
}
