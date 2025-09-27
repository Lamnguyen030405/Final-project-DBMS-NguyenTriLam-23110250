
-- =====================================================
-- SCRIPT TẠO CƠ SỞ DỮ LIỆU HOÀN CHỈNH
-- HỆ THỐNG QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI (SQL SERVER)
-- =====================================================

-- Tạo cơ sở dữ liệu
IF DB_ID('phone_store_db') IS NOT NULL
    DROP DATABASE phone_store_db;
GO
CREATE DATABASE phone_store_db;
GO
USE phone_store_db;
GO

-- =====================================================
-- 1. TẠO CÁC BẢNG CƠ BẢN
-- =====================================================

-- Bảng Nhân viên (tạo trước vì được tham chiếu bởi users)
CREATE TABLE employees (
    employee_id INT IDENTITY(1,1) PRIMARY KEY,
    employee_code NVARCHAR(20) UNIQUE NOT NULL,
    full_name NVARCHAR(100) NOT NULL,
    phone NVARCHAR(15),
    email NVARCHAR(100),
    address NVARCHAR(MAX),
    position NVARCHAR(50), -- Quản lý, Thu ngân, Bán hàng
    hire_date DATE,
    salary DECIMAL(15,2),
    status NVARCHAR(10) DEFAULT 'active' CHECK (status IN ('active', 'inactive')),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Vai trò (Roles)
CREATE TABLE roles (
    role_id INT IDENTITY(1,1) PRIMARY KEY,
    role_name NVARCHAR(50) NOT NULL UNIQUE, -- Admin, Manager, Cashier, Salesperson
    description NVARCHAR(MAX),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Người dùng (Users)
CREATE TABLE users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) UNIQUE NOT NULL,
    password_hash NVARCHAR(256) NOT NULL, -- Lưu mật khẩu đã băm (SHA-256)
    employee_id INT, -- Liên kết với nhân viên
    status NVARCHAR(10) DEFAULT 'active' CHECK (status IN ('active', 'inactive')),
    last_login DATETIME,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_users_employees FOREIGN KEY (employee_id) REFERENCES employees(employee_id)
);
GO

-- Bảng Phân quyền (User_Roles)
CREATE TABLE user_roles (
    user_id INT,
    role_id INT,
    assigned_at DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (user_id, role_id),
    CONSTRAINT FK_user_roles_users FOREIGN KEY (user_id) REFERENCES users(user_id),
    CONSTRAINT FK_user_roles_roles FOREIGN KEY (role_id) REFERENCES roles(role_id)
);
GO

-- Bảng Khách hàng
CREATE TABLE customers (
    customer_id INT IDENTITY(1,1) PRIMARY KEY,
    customer_code NVARCHAR(20) UNIQUE NOT NULL,
    full_name NVARCHAR(100) NOT NULL,
    phone NVARCHAR(15) UNIQUE,
    email NVARCHAR(100),
    address NVARCHAR(MAX),
    date_of_birth DATE,
    gender NVARCHAR(10) CHECK (gender IN ('male', 'female', 'other')),
    customer_type NVARCHAR(10) DEFAULT 'regular' CHECK (customer_type IN ('regular', 'vip')),
    total_spent DECIMAL(15,2) DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Nhà cung cấp
CREATE TABLE suppliers (
    supplier_id INT IDENTITY(1,1) PRIMARY KEY,
    supplier_code NVARCHAR(20) UNIQUE NOT NULL,
    company_name NVARCHAR(200) NOT NULL,
    contact_person NVARCHAR(100),
    phone NVARCHAR(15),
    email NVARCHAR(100),
    address NVARCHAR(MAX),
    tax_code NVARCHAR(20),
    status NVARCHAR(10) DEFAULT 'active' CHECK (status IN ('active', 'inactive')),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Danh mục sản phẩm
CREATE TABLE categories (
    category_id INT IDENTITY(1,1) PRIMARY KEY,
    category_name NVARCHAR(100) NOT NULL,
    description NVARCHAR(MAX),
    status NVARCHAR(10) DEFAULT 'active' CHECK (status IN ('active', 'inactive')),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Thương hiệu
CREATE TABLE brands (
    brand_id INT IDENTITY(1,1) PRIMARY KEY,
    brand_name NVARCHAR(100) NOT NULL,
    country_origin NVARCHAR(50),
    description NVARCHAR(MAX),
    logo_url NVARCHAR(500),
    status NVARCHAR(10) DEFAULT 'active' CHECK (status IN ('active', 'inactive')),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Sản phẩm
CREATE TABLE products (
    product_id INT IDENTITY(1,1) PRIMARY KEY,
    product_code NVARCHAR(50) UNIQUE NOT NULL,
    product_name NVARCHAR(200) NOT NULL,
    category_id INT,
    brand_id INT,
    supplier_id INT,
    description NVARCHAR(MAX),
    specifications NVARCHAR(MAX), -- Lưu JSON dưới dạng chuỗi
    cost_price DECIMAL(15,2), -- Giá vốn
    selling_price DECIMAL(15,2), -- Giá bán
    warranty_period INT, -- Thời gian bảo hành (tháng)
    image_url NVARCHAR(500),
    status NVARCHAR(15) DEFAULT 'active' CHECK (status IN ('active', 'inactive', 'discontinued')),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_products_categories FOREIGN KEY (category_id) REFERENCES categories(category_id),
    CONSTRAINT FK_products_brands FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    CONSTRAINT FK_products_suppliers FOREIGN KEY (supplier_id) REFERENCES suppliers(supplier_id)
);
GO

-- Bảng Tồn kho
CREATE TABLE inventory (
    inventory_id INT IDENTITY(1,1) PRIMARY KEY,
    product_id INT,
    quantity_on_hand INT DEFAULT 0, -- Số lượng tồn kho
    quantity_reserved INT DEFAULT 0, -- Số lượng đã đặt hàng
    min_stock_level INT DEFAULT 0, -- Mức tồn kho tối thiểu
    max_stock_level INT DEFAULT 0, -- Mức tồn kho tối đa
    last_updated DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_inventory_products FOREIGN KEY (product_id) REFERENCES products(product_id),
    CONSTRAINT unique_product_inventory UNIQUE (product_id)
);
GO

-- =====================================================
-- 2. BẢNG QUẢN LÝ NHẬP HÀNG
-- =====================================================

-- Bảng Đơn nhập hàng
CREATE TABLE purchase_orders (
    purchase_order_id INT IDENTITY(1,1) PRIMARY KEY,
    order_code NVARCHAR(20) UNIQUE NOT NULL,
    supplier_id INT,
    employee_id INT, -- Nhân viên tạo đơn
    order_date DATE,
    expected_delivery_date DATE,
    actual_delivery_date DATE,
    total_amount DECIMAL(15,2),
    status NVARCHAR(20) DEFAULT 'pending' CHECK (status IN ('pending', 'confirmed', 'delivered', 'cancelled')),
    notes NVARCHAR(MAX),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_purchase_orders_suppliers FOREIGN KEY (supplier_id) REFERENCES suppliers(supplier_id),
    CONSTRAINT FK_purchase_orders_employees FOREIGN KEY (employee_id) REFERENCES employees(employee_id)
);
GO

-- Bảng Chi tiết đơn nhập hàng
CREATE TABLE purchase_order_details (
    detail_id INT IDENTITY(1,1) PRIMARY KEY,
    purchase_order_id INT,
    product_id INT,
    quantity INT NOT NULL,
    unit_cost DECIMAL(15,2),
    total_cost DECIMAL(15,2),
    received_quantity INT DEFAULT 0,
    CONSTRAINT FK_purchase_order_details_purchase_orders FOREIGN KEY (purchase_order_id) REFERENCES purchase_orders(purchase_order_id),
    CONSTRAINT FK_purchase_order_details_products FOREIGN KEY (product_id) REFERENCES products(product_id)
);
GO

-- =====================================================
-- 3. BẢNG QUẢN LÝ KHUYẾN MÃI
-- =====================================================

-- Bảng Khuyến mãi
CREATE TABLE promotions (
    promotion_id INT IDENTITY(1,1) PRIMARY KEY,
    promotion_code NVARCHAR(20) UNIQUE NOT NULL,
    promotion_name NVARCHAR(200) NOT NULL,
    description NVARCHAR(MAX),
    discount_type NVARCHAR(20) CHECK (discount_type IN ('percentage', 'fixed_amount')),
    discount_value DECIMAL(15,2),
    start_date DATE,
    end_date DATE,
    min_order_amount DECIMAL(15,2),
    max_discount_amount DECIMAL(15,2),
    usage_limit INT, -- Số lần sử dụng tối đa
    used_count INT DEFAULT 0, -- Số lần đã sử dụng
    status NVARCHAR(10) DEFAULT 'active' CHECK (status IN ('active', 'inactive', 'expired')),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- =====================================================
-- 4. BẢNG QUẢN LÝ BÁN HÀNG
-- =====================================================

-- Bảng Đơn hàng
CREATE TABLE orders (
    order_id INT IDENTITY(1,1) PRIMARY KEY,
    order_code NVARCHAR(20) UNIQUE NOT NULL,
    customer_id INT,
    employee_id INT, -- Nhân viên bán hàng
    order_date DATETIME,
    subtotal DECIMAL(15,2), -- Tổng tiền trước chiết khấu
    discount_amount DECIMAL(15,2) DEFAULT 0, -- Số tiền giảm giá
    tax_amount DECIMAL(15,2) DEFAULT 0, -- Thuế VAT
    total_amount DECIMAL(15,2), -- Tổng tiền cuối cùng
    promotion_id INT NULL, -- Khuyến mãi áp dụng
    payment_method NVARCHAR(20) CHECK (payment_method IN ('cash', 'card', 'transfer', 'installment')),
    payment_status NVARCHAR(20) DEFAULT 'pending' CHECK (payment_status IN ('pending', 'paid', 'partial', 'refunded')),
    order_status NVARCHAR(20) DEFAULT 'processing' CHECK (order_status IN ('processing', 'completed', 'cancelled', 'returned')),
    notes NVARCHAR(MAX),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_orders_customers FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    CONSTRAINT FK_orders_employees FOREIGN KEY (employee_id) REFERENCES employees(employee_id),
    CONSTRAINT FK_orders_promotions FOREIGN KEY (promotion_id) REFERENCES promotions(promotion_id)
);
GO

-- Bảng Chi tiết đơn hàng
CREATE TABLE order_details (
    detail_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT NOT NULL,
    unit_price DECIMAL(15,2), -- Giá bán tại thời điểm đó
    discount_per_item DECIMAL(15,2) DEFAULT 0,
    total_price DECIMAL(15,2),
    warranty_start_date DATE,
    warranty_end_date DATE,
    CONSTRAINT FK_order_details_orders FOREIGN KEY (order_id) REFERENCES orders(order_id),
    CONSTRAINT FK_order_details_products FOREIGN KEY (product_id) REFERENCES products(product_id)
);
GO

-- Bảng Thanh toán
CREATE TABLE payments (
    payment_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT,
    payment_date DATETIME,
    payment_method NVARCHAR(20) CHECK (payment_method IN ('cash', 'card', 'transfer', 'installment')),
    amount DECIMAL(15,2),
    reference_number NVARCHAR(100), -- Số tham chiếu giao dịch
    status NVARCHAR(10) DEFAULT 'successful' CHECK (status IN ('successful', 'failed', 'pending')),
    notes NVARCHAR(MAX),
    created_at DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_payments_orders FOREIGN KEY (order_id) REFERENCES orders(order_id)
);
GO

-- =====================================================
-- 5. BẢNG QUẢN LÝ TRẢ HÀNG
-- =====================================================

-- Bảng Trả hàng
CREATE TABLE returns (
    return_id INT IDENTITY(1,1) PRIMARY KEY,
    return_code NVARCHAR(20) UNIQUE NOT NULL,
    order_id INT,
    customer_id INT,
    employee_id INT, -- Nhân viên xử lý
    return_date DATE,
    reason NVARCHAR(MAX),
    return_type NVARCHAR(20) CHECK (return_type IN ('defective', 'wrong_item', 'customer_request')),
    total_refund_amount DECIMAL(15,2),
    status NVARCHAR(20) DEFAULT 'pending' CHECK (status IN ('pending', 'approved', 'rejected', 'completed')),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_returns_orders FOREIGN KEY (order_id) REFERENCES orders(order_id),
    CONSTRAINT FK_returns_customers FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    CONSTRAINT FK_returns_employees FOREIGN KEY (employee_id) REFERENCES employees(employee_id)
);
GO

-- Bảng Chi tiết trả hàng
CREATE TABLE return_details (
    detail_id INT IDENTITY(1,1) PRIMARY KEY,
    return_id INT,
    product_id INT,
    quantity INT,
    reason NVARCHAR(MAX),
    condition_note NVARCHAR(MAX), -- Tình trạng sản phẩm
    refund_amount DECIMAL(15,2),
    CONSTRAINT FK_return_details_returns FOREIGN KEY (return_id) REFERENCES returns(return_id),
    CONSTRAINT FK_return_details_products FOREIGN KEY (product_id) REFERENCES products(product_id)
);
GO

-- =====================================================
-- 6. TẠO CÁC INDEX ĐỂ TỐI ƯU HIỆU SUẤT
-- =====================================================

CREATE INDEX idx_products_name ON products(product_name);
CREATE INDEX idx_products_code ON products(product_code);
CREATE INDEX idx_customers_phone ON customers(phone);
CREATE INDEX idx_orders_date ON orders(order_date);
CREATE INDEX idx_orders_customer ON orders(customer_id);
CREATE INDEX idx_orders_employee ON orders(employee_id);
CREATE INDEX idx_inventory_product ON inventory(product_id);
CREATE INDEX idx_orders_date_status ON orders(order_date, order_status);
CREATE INDEX idx_payments_date ON payments(payment_date);
CREATE INDEX idx_order_details_product ON order_details(product_id);
CREATE INDEX idx_users_username ON users(username);
GO

-- =====================================================
-- 7. TẠO CÁC TRIGGER TỰ ĐỘNG
-- =====================================================

CREATE FUNCTION dbo.HashPassword (@password NVARCHAR(256))
RETURNS NVARCHAR(64)
AS
BEGIN
    DECLARE @hash NVARCHAR(64);

    -- Always cast to VARCHAR to avoid NVARCHAR vs VARCHAR mismatches
    SET @hash = CONVERT(NVARCHAR(64), HASHBYTES('SHA2_256', CAST(@password AS VARCHAR(256))), 2);

    RETURN @hash;
END;
GO

-- Trigger cập nhật thời gian updated_at cho roles
CREATE TRIGGER tr_roles_update
ON roles
AFTER UPDATE
AS
BEGIN
    UPDATE roles
    SET updated_at = GETDATE()
    FROM inserted
    WHERE roles.role_id = inserted.role_id;
END;
GO

-- Trigger cập nhật thời gian updated_at cho users
CREATE TRIGGER tr_users_update
ON users
AFTER UPDATE
AS
BEGIN
    UPDATE users
    SET updated_at = GETDATE()
    FROM inserted
    WHERE users.user_id = inserted.user_id;
END;
GO

-- Trigger tự động tạo tài khoản người dùng khi thêm nhân viên
CREATE TRIGGER tr_employees_insert
ON employees
AFTER INSERT
AS
BEGIN
    DECLARE @employee_id INT, @employee_code NVARCHAR(20), @username NVARCHAR(50), @default_password NVARCHAR(256);
    SET @default_password = dbo.HashPassword('default123'); -- Mật khẩu mặc định: default123

    DECLARE employee_cursor CURSOR FOR
    SELECT employee_id, employee_code FROM inserted;

    OPEN employee_cursor;
    FETCH NEXT FROM employee_cursor INTO @employee_id, @employee_code;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Tạo username từ employee_code
        SET @username = 'user_' + @employee_code;

        -- Thêm vào bảng users
        INSERT INTO users (username, password_hash, employee_id, status)
        VALUES (@username, @default_password, @employee_id, 'active');

        -- Gán vai trò mặc định dựa trên position
        DECLARE @role_id INT;
        SELECT @role_id = role_id FROM roles 
        WHERE role_name = CASE 
            WHEN (SELECT position FROM employees WHERE employee_id = @employee_id) = 'Quản lý' THEN 'Manager'
            WHEN (SELECT position FROM employees WHERE employee_id = @employee_id) = 'Thu ngân' THEN 'Cashier'
            WHEN (SELECT position FROM employees WHERE employee_id = @employee_id) = 'Bán hàng' THEN 'Salesperson'
            ELSE 'Staff'
        END;

        IF @role_id IS NOT NULL
        BEGIN
            INSERT INTO user_roles (user_id, role_id)
            SELECT user_id, @role_id FROM users WHERE employee_id = @employee_id;
        END

        FETCH NEXT FROM employee_cursor INTO @employee_id, @employee_code;
    END;

    CLOSE employee_cursor;
    DEALLOCATE employee_cursor;
END;
GO

-- Trigger cập nhật thời gian updated_at
CREATE TRIGGER tr_employees_update
ON employees
AFTER UPDATE
AS
BEGIN
    UPDATE employees
    SET updated_at = GETDATE()
    FROM inserted
    WHERE employees.employee_id = inserted.employee_id;
END;
GO

CREATE TRIGGER tr_customers_update
ON customers
AFTER UPDATE
AS
BEGIN
    UPDATE customers
    SET updated_at = GETDATE()
    FROM inserted
    WHERE customers.customer_id = inserted.customer_id;
END;
GO

CREATE TRIGGER tr_suppliers_update
ON suppliers
AFTER UPDATE
AS
BEGIN
    UPDATE suppliers
    SET updated_at = GETDATE()
    FROM inserted
    WHERE suppliers.supplier_id = inserted.supplier_id;
END;
GO

CREATE TRIGGER tr_categories_update
ON categories
AFTER UPDATE
AS
BEGIN
    UPDATE categories
    SET updated_at = GETDATE()
    FROM inserted
    WHERE categories.category_id = inserted.category_id;
END;
GO

CREATE TRIGGER tr_brands_update
ON brands
AFTER UPDATE
AS
BEGIN
    UPDATE brands
    SET updated_at = GETDATE()
    FROM inserted
    WHERE brands.brand_id = inserted.brand_id;
END;
GO

CREATE TRIGGER tr_products_update
ON products
AFTER UPDATE
AS
BEGIN
    UPDATE products
    SET updated_at = GETDATE()
    FROM inserted
    WHERE products.product_id = inserted.product_id;
END;
GO

CREATE TRIGGER tr_inventory_update
ON inventory
AFTER UPDATE
AS
BEGIN
    UPDATE inventory
    SET last_updated = GETDATE()
    FROM inserted
    WHERE inventory.inventory_id = inserted.inventory_id;
END;
GO

CREATE TRIGGER tr_purchase_orders_update
ON purchase_orders
AFTER UPDATE
AS
BEGIN
    UPDATE purchase_orders
    SET updated_at = GETDATE()
    FROM inserted
    WHERE purchase_orders.purchase_order_id = inserted.purchase_order_id;
END;
GO

CREATE TRIGGER tr_promotions_update
ON promotions
AFTER UPDATE
AS
BEGIN
    UPDATE promotions
    SET updated_at = GETDATE()
    FROM inserted
    WHERE promotions.promotion_id = inserted.promotion_id;
END;
GO

CREATE TRIGGER tr_orders_update
ON orders
AFTER UPDATE
AS
BEGIN
    UPDATE orders
    SET updated_at = GETDATE()
    FROM inserted
    WHERE orders.order_id = inserted.order_id;
END;
GO

CREATE TRIGGER tr_returns_update
ON returns
AFTER UPDATE
AS
BEGIN
    UPDATE returns
    SET updated_at = GETDATE()
    FROM inserted
    WHERE returns.return_id = inserted.return_id;
END;
GO

-- Trigger cập nhật tồn kho khi có đơn hàng
CREATE TRIGGER update_inventory_after_order
ON order_details
AFTER INSERT
AS
BEGIN
    UPDATE i
    SET i.quantity_on_hand = i.quantity_on_hand - inserted.quantity,
        i.last_updated = GETDATE()
    FROM inventory i
    INNER JOIN inserted ON i.product_id = inserted.product_id;
END;
GO

-- Trigger hoàn trả tồn kho khi hủy đơn hàng
CREATE TRIGGER restore_inventory_on_cancel
ON orders
AFTER UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted WHERE order_status = 'cancelled')
    AND EXISTS (SELECT * FROM deleted WHERE order_status != 'cancelled')
    BEGIN
        UPDATE i
        SET i.quantity_on_hand = i.quantity_on_hand + od.quantity,
            i.last_updated = GETDATE()
        FROM inventory i
        INNER JOIN order_details od ON i.product_id = od.product_id
        INNER JOIN inserted ON od.order_id = inserted.order_id
        WHERE inserted.order_status = 'cancelled';
    END;
END;
GO

-- Trigger cập nhật tổng chi tiêu khách hàng
CREATE TRIGGER update_customer_total_spent
ON orders
AFTER UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted WHERE order_status = 'completed')
    AND EXISTS (SELECT * FROM deleted WHERE order_status != 'completed')
    BEGIN
        UPDATE c
        SET c.total_spent = c.total_spent + inserted.total_amount
        FROM customers c
        INNER JOIN inserted ON c.customer_id = inserted.customer_id;
    END;
    IF EXISTS (SELECT * FROM inserted WHERE order_status = 'cancelled')
    AND EXISTS (SELECT * FROM deleted WHERE order_status = 'completed')
    BEGIN
        UPDATE c
        SET c.total_spent = c.total_spent - deleted.total_amount
        FROM customers c
        INNER JOIN deleted ON c.customer_id = deleted.customer_id;
    END;
END;
GO

-- Trigger cập nhật loại khách hàng
CREATE TRIGGER update_customer_type_auto
ON customers
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(total_spent)
    BEGIN
        UPDATE c
        SET c.customer_type = 'vip'
        FROM customers c
        INNER JOIN inserted i ON c.customer_id = i.customer_id
        WHERE 
            ISNULL(i.customer_type, '') = 'regular'
            AND ISNULL(i.total_spent, 0) >= 50000000;
    END
END;

-- Trigger cập nhật số lần sử dụng khuyến mãi
CREATE TRIGGER update_promotion_usage
ON orders
AFTER INSERT
AS
BEGIN
    UPDATE p
    SET p.used_count = p.used_count + 1
    FROM promotions p
    INNER JOIN inserted ON p.promotion_id = inserted.promotion_id
    WHERE inserted.promotion_id IS NOT NULL;
END;
GO

-- Trigger tính tổng tiền chi tiết đơn hàng
CREATE TRIGGER calculate_order_detail_total
ON order_details
AFTER INSERT
AS
BEGIN
    UPDATE od
    SET od.total_price = inserted.quantity * inserted.unit_price - inserted.discount_per_item
    FROM order_details od
    INNER JOIN inserted ON od.detail_id = inserted.detail_id;
END;
GO

-- Trigger cập nhật ngày bảo hành
CREATE TRIGGER set_warranty_dates
ON order_details
AFTER INSERT
AS
BEGIN
    UPDATE od
    SET od.warranty_start_date = CAST(GETDATE() AS DATE),
        od.warranty_end_date = DATEADD(MONTH, p.warranty_period, CAST(GETDATE() AS DATE))
    FROM order_details od
    INNER JOIN inserted ON od.detail_id = inserted.detail_id
    INNER JOIN products p ON inserted.product_id = p.product_id;
END;
GO

-- =====================================================
-- 8. TẠO CÁC VIEW HỖ TRỢ BÁO CÁO
-- =====================================================

-- View báo cáo doanh thu theo ngày
CREATE VIEW daily_revenue_report AS
SELECT TOP 100 PERCENT
    CAST(order_date AS DATE) AS report_date,
    COUNT(*) AS total_orders,
    SUM(total_amount) AS total_revenue,
    AVG(total_amount) AS avg_order_value,
    SUM(CASE WHEN payment_status = 'paid' THEN total_amount ELSE 0 END) AS paid_revenue
FROM orders 
WHERE order_status IN ('completed', 'processing')
GROUP BY CAST(order_date AS DATE)
ORDER BY report_date DESC;
GO

-- View top sản phẩm bán chạy
CREATE VIEW top_selling_products AS
SELECT TOP 100 PERCENT
    p.product_id,
    p.product_name,
    p.product_code,
    b.brand_name,
    c.category_name,
    SUM(od.quantity) AS total_sold,
    SUM(od.total_price) AS total_revenue,
    COUNT(DISTINCT od.order_id) AS total_orders,
    AVG(od.unit_price) AS avg_selling_price
FROM products p
INNER JOIN order_details od ON p.product_id = od.product_id
INNER JOIN orders o ON od.order_id = o.order_id
LEFT JOIN brands b ON p.brand_id = b.brand_id
LEFT JOIN categories c ON p.category_id = c.category_id
WHERE o.order_status = 'completed'
GROUP BY p.product_id, p.product_name, p.product_code, b.brand_name, c.category_name
ORDER BY total_sold DESC;
GO

-- View khách hàng VIP
CREATE VIEW vip_customers AS
SELECT TOP 100 PERCENT
    c.customer_id,
    c.customer_code,
    c.full_name,
    c.phone,
    c.email,
    c.customer_type,
    c.total_spent,
    COUNT(o.order_id) AS total_orders,
    AVG(o.total_amount) AS avg_order_value,
    MAX(o.order_date) AS last_order_date,
    DATEDIFF(DAY, MAX(o.order_date), GETDATE()) AS days_since_last_order
FROM customers c
LEFT JOIN orders o ON c.customer_id = o.customer_id AND o.order_status = 'completed'
WHERE c.customer_type = 'vip' OR c.total_spent > 10000000
GROUP BY c.customer_id, c.customer_code, c.full_name, c.phone, c.email, c.customer_type, c.total_spent
ORDER BY c.total_spent DESC;
GO

-- View tồn kho cảnh báo
CREATE VIEW low_stock_alert AS
SELECT TOP 100 PERCENT
    p.product_id,
    p.product_name,
    p.product_code,
    b.brand_name,
    c.category_name,
    i.quantity_on_hand,
    i.quantity_reserved,
    i.min_stock_level,
    i.max_stock_level,
    (i.min_stock_level - i.quantity_on_hand) AS shortage,
    p.selling_price,
    s.company_name AS supplier_name,
    s.phone AS supplier_phone
FROM products p
INNER JOIN inventory i ON p.product_id = i.product_id
LEFT JOIN brands b ON p.brand_id = b.brand_id
LEFT JOIN categories c ON p.category_id = c.category_id
LEFT JOIN suppliers s ON p.supplier_id = s.supplier_id
WHERE i.quantity_on_hand <= i.min_stock_level
AND p.status = 'active'
ORDER BY (i.min_stock_level - i.quantity_on_hand) DESC;
GO

-- View báo cáo hiệu suất nhân viên
CREATE VIEW employee_performance AS
SELECT TOP 100 PERCENT
    e.employee_id,
    e.employee_code,
    e.full_name,
    e.position,
    COUNT(o.order_id) AS total_orders,
    SUM(o.total_amount) AS total_sales,
    AVG(o.total_amount) AS avg_order_value,
    MAX(o.order_date) AS last_sale_date,
    FORMAT(MIN(o.order_date), 'yyyy-MM') AS first_sale_month
FROM employees e
LEFT JOIN orders o ON e.employee_id = o.employee_id AND o.order_status = 'completed'
WHERE e.status = 'active'
GROUP BY e.employee_id, e.employee_code, e.full_name, e.position
ORDER BY total_sales DESC;
GO

-- View báo cáo lợi nhuận
CREATE VIEW profit_report AS
SELECT TOP 100 PERCENT
    p.product_id,
    p.product_name,
    p.cost_price,
    p.selling_price,
    (p.selling_price - p.cost_price) AS unit_profit,
    ((p.selling_price - p.cost_price) / NULLIF(p.cost_price, 0) * 100) AS profit_margin_percent,
    COALESCE(SUM(od.quantity), 0) AS total_sold,
    COALESCE(SUM(od.quantity * p.cost_price), 0) AS total_cost,
    COALESCE(SUM(od.total_price), 0) AS total_revenue,
    COALESCE(SUM(od.total_price) - SUM(od.quantity * p.cost_price), 0) AS total_profit
FROM products p
LEFT JOIN order_details od ON p.product_id = od.product_id
LEFT JOIN orders o ON od.order_id = o.order_id AND o.order_status = 'completed'
WHERE p.status = 'active'
GROUP BY p.product_id, p.product_name, p.cost_price, p.selling_price
ORDER BY total_profit DESC;
GO

-- =====================================================
-- 9. THÊM DỮ LIỆU MẪU
-- =====================================================

-- Thêm dữ liệu mẫu cho roles
INSERT INTO roles (role_name, description) VALUES
('Admin', 'Quản trị viên hệ thống, có toàn quyền'),
('Manager', 'Quản lý cửa hàng, quản lý nhân viên và đơn hàng'),
('Cashier', 'Thu ngân, xử lý thanh toán'),
('Salesperson', 'Nhân viên bán hàng, tạo đơn hàng'),
('Staff', 'Nhân viên cơ bản, hỗ trợ các công việc khác');
GO

-- Thêm dữ liệu mẫu cho categories
INSERT INTO categories (category_name, description) VALUES
('Điện thoại', 'Điện thoại thông minh các loại'),
('Phụ kiện', 'Phụ kiện điện thoại'),
('Tablet', 'Máy tính bảng'),
('Đồng hồ thông minh', 'Smart watch các loại');
GO

-- Thêm dữ liệu mẫu cho brands
INSERT INTO brands (brand_name, country_origin, description) VALUES
('Apple', 'USA', 'Thương hiệu công nghệ hàng đầu'),
('Samsung', 'South Korea', 'Tập đoàn công nghệ Hàn Quốc'),
('Xiaomi', 'China', 'Thương hiệu công nghệ Trung Quốc'),
('OPPO', 'China', 'Thương hiệu điện thoại'),
('Vivo', 'China', 'Thương hiệu điện thoại');
GO

-- Thêm dữ liệu mẫu cho suppliers
INSERT INTO suppliers (supplier_code, company_name, contact_person, phone, email, address) VALUES
('SUP001', 'Công ty TNHH Phân phối A', 'Nguyễn Văn A', '0901234567', 'contact@supplier-a.com', '123 Đường ABC, Quận 1, TP.HCM'),
('SUP002', 'Công ty Cổ phần Thương mại B', 'Trần Thị B', '0902345678', 'info@supplier-b.com', '456 Đường DEF, Quận 3, TP.HCM');
GO

-- Thêm dữ liệu mẫu cho employees (tự động tạo users và user_roles qua trigger)
INSERT INTO employees (employee_code, full_name, phone, email, position, hire_date, salary) VALUES
('EMP001', 'Nguyễn Văn Nam', '0911111111', 'nam@phonestore.com', 'Quản lý', '2023-01-01', 15000000),
('EMP002', 'Trần Thị Lan', '0922222222', 'lan@phonestore.com', 'Thu ngân', '2023-02-01', 8000000),
('EMP003', 'Lê Văn Hùng', '0933333333', 'hung@phonestore.com', 'Bán hàng', '2023-03-01', 10000000);
GO

-- Thêm dữ liệu mẫu cho customers
INSERT INTO customers (customer_code, full_name, phone, email, address, customer_type) VALUES
('CUS001', 'Phạm Văn Khách', '0944444444', 'khach@email.com', '789 Đường GHI, Quận 5, TP.HCM', 'regular'),
('CUS002', 'Hoàng Thị Mai', '0955555555', 'mai@email.com', '321 Đường JKL, Quận 7, TP.HCM', 'vip');
GO

-- =====================================================
-- 10. TẠO STORED PROCEDURES HỖ TRỢ
-- =====================================================

-- Procedure tạo mã tự động
CREATE PROCEDURE GenerateOrderCode
    @order_code NVARCHAR(20) OUTPUT
AS
BEGIN
    DECLARE @next_id INT;
    SELECT @next_id = COALESCE(MAX(order_id), 0) + 1 FROM orders;
    SET @order_code = 'ORD' + FORMAT(GETDATE(), 'yyyyMMdd') + RIGHT('0000' + CAST(@next_id AS NVARCHAR(4)), 4);
END;
GO

-- Procedure báo cáo doanh thu theo khoảng thời gian
CREATE PROCEDURE GetRevenueReport
    @start_date DATE,
    @end_date DATE
AS
BEGIN
    SELECT 
        CAST(o.order_date AS DATE) AS report_date,
        COUNT(*) AS total_orders,
        SUM(o.total_amount) AS total_revenue,
        SUM(CASE WHEN o.payment_status = 'paid' THEN o.total_amount ELSE 0 END) AS paid_revenue,
        AVG(o.total_amount) AS avg_order_value
    FROM orders o
    WHERE CAST(o.order_date AS DATE) BETWEEN @start_date AND @end_date
    AND o.order_status IN ('completed', 'processing')
    GROUP BY CAST(o.order_date AS DATE)
    ORDER BY report_date;
END;
GO

-- Procedure cập nhật loại khách hàng dựa trên tổng chi tiêu
CREATE PROCEDURE UpdateCustomerTypes
AS
BEGIN
    UPDATE customers 
    SET customer_type = 'vip' 
    WHERE total_spent >= 50000000 AND customer_type = 'regular';
END;
GO

-- Procedure đăng ký người dùng
CREATE PROCEDURE RegisterUser
    @username NVARCHAR(50),
    @password NVARCHAR(256),
    @employee_id INT,
    @role_name NVARCHAR(50),
    @result INT OUTPUT -- 1: Thành công, 0: Thất bại
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        -- Kiểm tra username đã tồn tại
        IF EXISTS (SELECT 1 FROM users WHERE username = @username)
        BEGIN
            SET @result = 0;
            RETURN;
        END

        -- Kiểm tra employee_id hợp lệ
        IF NOT EXISTS (SELECT 1 FROM employees WHERE employee_id = @employee_id)
        BEGIN
            SET @result = 0;
            RETURN;
        END

        -- Băm mật khẩu
        DECLARE @password_hash NVARCHAR(64) = dbo.HashPassword(@password);

        -- Thêm người dùng
        INSERT INTO users (username, password_hash, employee_id, status)
        VALUES (@username, @password_hash, @employee_id, 'active');

        -- Gán vai trò
        DECLARE @user_id INT = SCOPE_IDENTITY();
        DECLARE @role_id INT;
        SELECT @role_id = role_id FROM roles WHERE role_name = @role_name;

        IF @role_id IS NOT NULL
        BEGIN
            INSERT INTO user_roles (user_id, role_id)
            VALUES (@user_id, @role_id);
        END

        SET @result = 1;
    END TRY
    BEGIN CATCH
        SET @result = 0;
    END CATCH
END;
GO

-- Procedure đăng nhập
CREATE PROCEDURE LoginUser
    @username NVARCHAR(50),
    @password NVARCHAR(256),
    @result INT OUTPUT, -- 1: Đăng nhập thành công, 0: Thất bại
    @user_id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @password_hash NVARCHAR(64) = dbo.HashPassword (@password);

    SELECT @user_id = user_id
    FROM users
    WHERE username = @username 
    AND password_hash = @password_hash
    AND status = 'active';

    IF @user_id IS NOT NULL
    BEGIN
        -- Cập nhật thời gian đăng nhập cuối
        UPDATE users
        SET last_login = GETDATE()
        WHERE user_id = @user_id;
        SET @result = 1;
    END
    ELSE
    BEGIN
        SET @result = 0;
    END
END;
GO

-- Procedure kiểm tra vai trò của người dùng
CREATE PROCEDURE CheckUserRoles
    @user_id INT
AS
BEGIN
    SELECT r.role_name, r.description
    FROM user_roles ur
    INNER JOIN roles r ON ur.role_id = r.role_id
    WHERE ur.user_id = @user_id;
END;
GO

-- =====================================================
-- KẾT THÚC SCRIPT TẠO CƠ SỞ DỮ LIỆU
-- =====================================================

-- Hiển thị danh sách các bảng đã tạo
SELECT name AS TableName FROM sys.tables;
GO