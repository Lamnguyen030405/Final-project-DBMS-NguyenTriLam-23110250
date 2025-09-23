using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Utils
{
    public static class AppConstants
    {
        // Order Status
        public const string ORDER_STATUS_PROCESSING = "processing";
        public const string ORDER_STATUS_COMPLETED = "completed";
        public const string ORDER_STATUS_CANCELLED = "cancelled";
        public const string ORDER_STATUS_RETURNED = "returned";

        // Payment Status
        public const string PAYMENT_STATUS_PENDING = "pending";
        public const string PAYMENT_STATUS_PAID = "paid";
        public const string PAYMENT_STATUS_PARTIAL = "partial";
        public const string PAYMENT_STATUS_REFUNDED = "refunded";

        // Payment Methods
        public const string PAYMENT_METHOD_CASH = "cash";
        public const string PAYMENT_METHOD_CARD = "card";
        public const string PAYMENT_METHOD_TRANSFER = "transfer";
        public const string PAYMENT_METHOD_INSTALLMENT = "installment";

        // User Roles
        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_MANAGER = "Manager";
        public const string ROLE_CASHIER = "Cashier";
        public const string ROLE_SALESPERSON = "Salesperson";
        public const string ROLE_STAFF = "Staff";

        // Customer Types
        public const string CUSTOMER_TYPE_REGULAR = "regular";
        public const string CUSTOMER_TYPE_VIP = "vip";

        // Product Status
        public const string PRODUCT_STATUS_ACTIVE = "active";
        public const string PRODUCT_STATUS_INACTIVE = "inactive";
        public const string PRODUCT_STATUS_DISCONTINUED = "discontinued";

        // General Status
        public const string STATUS_ACTIVE = "active";
        public const string STATUS_INACTIVE = "inactive";

        // Discount Types
        public const string DISCOUNT_TYPE_PERCENTAGE = "percentage";
        public const string DISCOUNT_TYPE_FIXED_AMOUNT = "fixed_amount";

        // Default Values
        public const int DEFAULT_PAGE_SIZE = 50;
        public const int MAX_SEARCH_RESULTS = 1000;
        public const decimal DEFAULT_TAX_RATE = 0.1m; // 10% VAT

        // VIP Customer Threshold
        public const decimal VIP_CUSTOMER_THRESHOLD = 10000000m; // 10 million VND

        // File Paths
        public const string PRODUCT_IMAGES_FOLDER = "ProductImages";
        public const string REPORTS_FOLDER = "Reports";
        public const string BACKUP_FOLDER = "Backups";

        // Date Formats
        public const string DATE_FORMAT = "dd/MM/yyyy";
        public const string DATETIME_FORMAT = "dd/MM/yyyy HH:mm:ss";
        public const string TIME_FORMAT = "HH:mm";

        // Currency Format
        public const string CURRENCY_FORMAT = "N0";
        public const string CURRENCY_SYMBOL = "đ";

        // Company Information
        public const string COMPANY_NAME = "Cửa hàng điện thoại ABC";
        public const string COMPANY_ADDRESS = "123 Đường ABC, Quận 1, TP.HCM";
        public const string COMPANY_PHONE = "028-1234-5678";
        public const string COMPANY_EMAIL = "info@phonestore.com";
    }
}
