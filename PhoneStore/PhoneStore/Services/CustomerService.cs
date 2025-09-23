using PhoneStore.Dao;
using PhoneStore.Utils;
using PhoneStoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneStore.Services
{
    public class CustomerService
    {
        private CustomerDao customerDao;

        public CustomerService()
        {
            customerDao = new CustomerDao();
        }

        public ServiceResult<List<Customer>> GetAllCustomers()
        {
            try
            {
                var customers = customerDao.GetAllCustomers();
                return ServiceResult<List<Customer>>.Success(customers);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Customer>>.Error($"Lỗi lấy danh sách khách hàng: {ex.Message}");
            }
        }

        public ServiceResult<List<Customer>> SearchCustomers(string keyword)
        {
            try
            {
                var customers = customerDao.SearchCustomers(keyword);
                return ServiceResult<List<Customer>>.Success(customers);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Customer>>.Error($"Lỗi tìm kiếm khách hàng: {ex.Message}");
            }
        }

        public ServiceResult<Customer> GetCustomerByPhone(string phone)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(phone))
                {
                    return ServiceResult<Customer>.Error("Số điện thoại không được để trống.");
                }

                var customer = customerDao.GetCustomerByPhone(phone.Trim());
                return ServiceResult<Customer>.Success(customer);
            }
            catch (Exception ex)
            {
                return ServiceResult<Customer>.Error($"Lỗi tìm kiếm khách hàng: {ex.Message}");
            }
        }

        public ServiceResult<bool> AddCustomer(Customer customer)
        {
            try
            {
                // Validation
                var validationResult = ValidateCustomer(customer);
                if (!validationResult.IsSuccess)
                {
                    return ServiceResult<bool>.Error(validationResult.Message);
                }

                // Check if phone exists
                if (!string.IsNullOrWhiteSpace(customer.Phone))
                {
                    var existingCustomer = customerDao.GetCustomerByPhone(customer.Phone);
                    if (existingCustomer != null)
                    {
                        return ServiceResult<bool>.Error("Số điện thoại này đã được sử dụng bởi khách hàng khác.");
                    }
                }

                var result = customerDao.InsertCustomer(customer);

                if (result)
                {
                    return ServiceResult<bool>.Success(true, "Thêm khách hàng thành công!");
                }
                else
                {
                    return ServiceResult<bool>.Error("Không thể thêm khách hàng. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Error($"Lỗi thêm khách hàng: {ex.Message}");
            }
        }

        public ServiceResult<List<Customer>> GetVIPCustomers()
        {
            try
            {
                var customers = customerDao.GetVIPCustomers();
                return ServiceResult<List<Customer>>.Success(customers);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Customer>>.Error($"Lỗi lấy danh sách khách hàng VIP: {ex.Message}");
            }
        }

        private ServiceResult<bool> ValidateCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FullName))
            {
                return ServiceResult<bool>.Error("Họ tên không được để trống.");
            }

            if (customer.FullName.Length < 2)
            {
                return ServiceResult<bool>.Error("Họ tên phải có ít nhất 2 ký tự.");
            }

            if (!string.IsNullOrWhiteSpace(customer.Phone))
            {
                if (!IsValidPhoneNumber(customer.Phone))
                {
                    return ServiceResult<bool>.Error("Số điện thoại không hợp lệ.");
                }
            }

            if (!string.IsNullOrWhiteSpace(customer.Email))
            {
                if (!IsValidEmail(customer.Email))
                {
                    return ServiceResult<bool>.Error("Email không hợp lệ.");
                }
            }

            if (customer.DateOfBirth.HasValue && customer.DateOfBirth.Value > DateTime.Now.AddYears(-5))
            {
                return ServiceResult<bool>.Error("Ngày sinh không hợp lệ.");
            }

            return ServiceResult<bool>.Success(true);
        }

        private bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^(\+84|0)[3|5|7|8|9][0-9]{8}$");
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
    }
}
