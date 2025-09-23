using PhoneStore.Dao;
using PhoneStoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Services
{
    public class AuthenticationService
    {
        private UserDao userDao;

        public AuthenticationService()
        {
            userDao = new UserDao();
        }

        public LoginResult Login(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "Vui lòng nhập tên đăng nhập."
                    };
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "Vui lòng nhập mật khẩu."
                    };
                }

                var user = userDao.LoginUser(username, password);

                if (user == null)
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "Tên đăng nhập hoặc mật khẩu không đúng."
                    };
                }

                if (user.Status != "active")
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "Tài khoản đã bị vô hiệu hóa."
                    };
                }

                return new LoginResult
                {
                    Success = true,
                    Message = "Đăng nhập thành công!",
                    User = user
                };
            }
            catch (Exception ex)
            {
                return new LoginResult
                {
                    Success = false,
                    Message = $"Lỗi hệ thống: {ex.Message}"
                };
            }
        }

        public bool ChangePassword(int userId, string newPassword)
        {
            return userDao.ChangePassword(userId, newPassword);
        }
    }

    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
    }
}
