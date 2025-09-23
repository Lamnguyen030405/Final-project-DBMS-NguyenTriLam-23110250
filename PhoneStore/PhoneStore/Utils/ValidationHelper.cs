    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneStore.Utils
{
    public static class ValidationHelper
    {
        public static bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Vietnamese phone number pattern
            return Regex.IsMatch(phone.Trim(), @"^(\+84|0)[3|5|7|8|9][0-9]{8}$");
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return Regex.IsMatch(email.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        public static bool IsValidPrice(decimal? price)
        {
            return price.HasValue && price.Value > 0;
        }

        public static bool IsValidQuantity(int quantity)
        {
            return quantity > 0;
        }

        public static bool IsValidDateRange(DateTime fromDate, DateTime toDate)
        {
            return fromDate <= toDate;
        }

        public static string FormatCurrency(decimal amount)
        {
            return amount.ToString("N0") + "đ";
        }

        public static string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy HH:mm");
        }

        public static string FormatDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        public static string TruncateString(string input, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "";

            return input.Length <= maxLength ? input : input.Substring(0, maxLength - 3) + "...";
        }
    }
}
