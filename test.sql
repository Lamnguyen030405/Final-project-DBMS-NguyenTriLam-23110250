
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
-- 2. BẢNG QUẢN LÝ KHUYẾN MÃI
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
-- 3. BẢNG QUẢN LÝ BÁN HÀNG
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
-- 4. TẠO CÁC INDEX ĐỂ TỐI ƯU HIỆU SUẤT
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
-- 5. TẠO CÁC TRIGGER TỰ ĐỘNG
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

-- Procedure tạo user và phân quyền
CREATE PROCEDURE sp_CreateDatabaseUser
    @username NVARCHAR(50),
    @password NVARCHAR(256),
    @role_name NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        -- Tạo login
        DECLARE @sql NVARCHAR(MAX);
        SET @sql = 'CREATE LOGIN [' + @username + '] WITH PASSWORD = ''' + @password + '''';
        EXEC sp_executesql @sql;
        
        -- Tạo user trong database
        SET @sql = 'CREATE USER [' + @username + '] FOR LOGIN [' + @username + ']';
        EXEC sp_executesql @sql;
        
        -- Phân quyền role
        DECLARE @database_role NVARCHAR(50);
        SET @database_role = CASE @role_name
            WHEN 'Admin' THEN 'db_admin'
            WHEN 'Manager' THEN 'db_manager'
            WHEN 'Cashier' THEN 'db_cashier'
            WHEN 'Salesperson' THEN 'db_salesperson'
            WHEN 'Staff' THEN 'db_staff'
            ELSE NULL
        END;
        
        IF @database_role IS NOT NULL
        BEGIN
            SET @sql = 'ALTER ROLE ' + @database_role + ' ADD MEMBER [' + @username + ']';
            EXEC sp_executesql @sql;
        END
        
        SELECT 1 as Result, 'User created and permissions assigned successfully' as Message;
        
    END TRY
    BEGIN CATCH
        SELECT 0 as Result, ERROR_MESSAGE() as Message;
    END CATCH
END;
GO

-- Trigger tự động tạo tài khoản người dùng khi thêm nhân viên
CREATE TRIGGER tr_employees_insert
ON employees
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT OFF; -- Cho phép xử lý lỗi tốt hơn

    DECLARE @employee_id INT, @employee_code NVARCHAR(20), @username NVARCHAR(50);
    DECLARE @default_password NVARCHAR(50) = 'default123';
    DECLARE @position NVARCHAR(50);
    DECLARE @role_name NVARCHAR(50);

    DECLARE employee_cursor CURSOR FOR
    SELECT employee_id, employee_code, position FROM inserted;

    OPEN employee_cursor;
    FETCH NEXT FROM employee_cursor INTO @employee_id, @employee_code, @position;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        BEGIN TRY
            -- Tạo username từ employee_code
            SET @username = 'user_' + @employee_code;

            -- Xác định role name từ position
            SET @role_name = CASE
                WHEN @position = N'Admin' THEN 'Admin'
                WHEN @position = N'Quản lý' THEN 'Manager'
                WHEN @position = N'Thu ngân' THEN 'Cashier'
                WHEN @position = N'Bán hàng' THEN 'Salesperson'
                ELSE 'Staff'
            END;

            -- Thêm vào bảng users (dùng mật khẩu đã hash để lưu riêng cho ứng dụng)
            INSERT INTO users (username, password_hash, employee_id, status)
            VALUES (
                @username,
                dbo.HashPassword(@default_password),
                @employee_id,
                'active'
            );

            -- Gán vai trò (ghi vào bảng user_roles)
            DECLARE @role_id INT;
            SELECT @role_id = role_id FROM roles WHERE role_name = @role_name;

            IF @role_id IS NOT NULL
            BEGIN
                INSERT INTO user_roles (user_id, role_id)
                SELECT user_id, @role_id FROM users WHERE employee_id = @employee_id;
            END

            -- Gọi stored procedure để tạo SQL login/user (với xử lý lỗi)
            BEGIN TRY
                EXEC sp_CreateDatabaseUser 
                    @username = @username, 
                    @password = @default_password, 
                    @role_name = @role_name;
            END TRY
            BEGIN CATCH
                -- Nếu tạo database user thất bại, chỉ log lỗi nhưng không làm fail toàn bộ transaction
                PRINT 'Warning: Failed to create database user for ' + @username + ': ' + ERROR_MESSAGE();
            END CATCH

        END TRY
        BEGIN CATCH
            -- Nếu có lỗi nghiêm trọng, log và tiếp tục với employee tiếp theo
            PRINT 'Error processing employee ' + @employee_code + ': ' + ERROR_MESSAGE();
        END CATCH

        FETCH NEXT FROM employee_cursor INTO @employee_id, @employee_code, @position;
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
GO

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
-- 6. TẠO CÁC VIEW HỖ TRỢ BÁO CÁO
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

-- View báo cáo sản phẩm có sẵn
CREATE VIEW v_AllActiveProducts
AS
SELECT 
    p.*, 
    c.category_name, 
    b.brand_name, 
    COALESCE(i.quantity_on_hand, 0) AS quantity_on_hand
FROM products p
LEFT JOIN categories c ON p.category_id = c.category_id
LEFT JOIN brands b ON p.brand_id = b.brand_id
LEFT JOIN inventory i ON p.product_id = i.product_id
WHERE p.status = 'active';
GO

-- View báo cáo nhân viên hoạt động
CREATE VIEW v_ActiveEmployees
AS
SELECT 
    employee_id, 
    employee_code, 
    full_name, 
    position, 
    status
FROM employees
WHERE status = 'active';	
GO

-- View báo cáo khuyến mãi còn hoạt động
CREATE VIEW v_ActivePromotions
AS
SELECT *
FROM promotions
WHERE 
    status = 'active'
    AND CAST(GETDATE() AS DATE) BETWEEN start_date AND end_date
    AND (usage_limit IS NULL OR used_count < usage_limit);
GO

-- =====================================================
-- 7. TẠO FUNCTION HỖ TRỢ
-- =====================================================

-- Function tạo order code tự động
CREATE FUNCTION fn_GenerateOrderCode()
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @prefix NVARCHAR(20) = 'ORD' + FORMAT(GETDATE(), 'yyyyMMdd');

    DECLARE @nextNumber INT = (
        SELECT COALESCE(MAX(CAST(RIGHT(order_code, 4) AS INT)), 0) + 1
        FROM orders
        WHERE order_code LIKE @prefix + '%'
    );

    DECLARE @code NVARCHAR(50) = @prefix + RIGHT('0000' + CAST(@nextNumber AS NVARCHAR(4)), 4);

    RETURN @code;
END
GO
-- Function tạo customer code tự động
CREATE FUNCTION fn_GenerateCustomerCode()
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @prefix NVARCHAR(20) = 'CUS' + FORMAT(GETDATE(), 'yyyyMMdd');

    DECLARE @nextNumber INT = (
        SELECT COALESCE(MAX(CAST(RIGHT(customer_code, 4) AS INT)), 0) + 1
        FROM customers
        WHERE customer_code LIKE @prefix + '%'
    );

    RETURN @prefix + RIGHT('0000' + CAST(@nextNumber AS NVARCHAR(4)), 4);
END
GO

-- Function lấy thông tin thanh toán theo order id
CREATE FUNCTION fn_GetPaymentSummaryByOrderId (@orderId INT)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        o.order_id,
        o.order_code,
        o.total_amount AS total_order_amount,
        COALESCE(SUM(p.amount), 0) AS total_paid_amount,
        (o.total_amount - COALESCE(SUM(p.amount), 0)) AS remaining_amount,
        o.payment_status,
        COUNT(p.payment_id) AS payment_count,
        MAX(p.payment_date) AS last_payment_date
    FROM orders o
    LEFT JOIN payments p ON o.order_id = p.order_id AND p.status = 'successful'
    WHERE o.order_id = @orderId
    GROUP BY o.order_id, o.order_code, o.total_amount, o.payment_status
);
GO
-- Function lấy tất cả các order trong khoảng thời gian đã cho
CREATE FUNCTION fn_GetAllOrders
(
    @fromDate DATE = NULL,
    @toDate DATE = NULL
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        o.*, 
        c.full_name AS customer_name, 
        e.full_name AS employee_name,
        COUNT(od.detail_id) AS total_items
    FROM orders o
    LEFT JOIN customers c ON o.customer_id = c.customer_id
    LEFT JOIN employees e ON o.employee_id = e.employee_id
    LEFT JOIN order_details od ON o.order_id = od.order_id
    WHERE 
        (@fromDate IS NULL OR CAST(o.order_date AS DATE) >= @fromDate)
        AND (@toDate IS NULL OR CAST(o.order_date AS DATE) <= @toDate)
    GROUP BY 
        o.order_id, o.order_code, o.customer_id, o.employee_id, 
        o.order_date, o.subtotal, o.discount_amount, o.tax_amount,
        o.total_amount, o.promotion_id, o.payment_method, o.payment_status,
        o.order_status, o.notes, o.created_at, o.updated_at,
        c.full_name, e.full_name
);
GO
-- Function lấy báo cáo bán doanh thu theo ngày trong khoảng thời gian đã cho
CREATE FUNCTION fn_GetDailySalesReport
(
    @fromDate DATE,
    @toDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        CAST(order_date AS DATE) AS report_date,
        COUNT(*) AS total_orders,
        SUM(total_amount) AS total_revenue,
        AVG(total_amount) AS avg_order_value
    FROM orders 
    WHERE order_status = 'completed'
      AND CAST(order_date AS DATE) BETWEEN @fromDate AND @toDate
    GROUP BY CAST(order_date AS DATE)
);
GO

-- =====================================================
-- 8. TẠO STORED PROCEDURES HỖ TRỢ
-- =====================================================

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

-- Procedure lấy dashboard
CREATE PROCEDURE sp_GetDashboardStats
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @today DATE = CAST(GETDATE() AS DATE);
    DECLARE @month_start DATE = DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1);

    SELECT 
        -- Today's stats
        COALESCE(SUM(CASE WHEN CAST(o.order_date AS DATE) = @today AND o.order_status = 'completed' THEN o.total_amount END), 0) AS today_revenue,
        COALESCE(COUNT(CASE WHEN CAST(o.order_date AS DATE) = @today AND o.order_status = 'completed' THEN 1 END), 0) AS today_orders,

        -- Month stats
        COALESCE(SUM(CASE WHEN CAST(o.order_date AS DATE) >= @month_start AND o.order_status = 'completed' THEN o.total_amount END), 0) AS month_revenue,
        COALESCE(COUNT(CASE WHEN CAST(o.order_date AS DATE) >= @month_start AND o.order_status = 'completed' THEN 1 END), 0) AS month_orders,

        -- Other stats
        COALESCE(AVG(CASE WHEN o.order_status = 'completed' THEN o.total_amount END), 0) AS avg_order_value,
        (SELECT COUNT(*) FROM customers) AS total_customers,
        (SELECT COUNT(*) FROM inventory i WHERE i.quantity_on_hand <= i.min_stock_level) AS low_stock_products
    FROM orders o;
END;
GO

-- Procedure lấy số lượng sản phẩm tồn kho
CREATE PROCEDURE sp_GetProductStock
    @productId INT
AS
BEGIN
    SELECT COALESCE(quantity_on_hand, 0)
    FROM inventory
    WHERE product_id = @productId;
END
GO

-- Procedure lấy sản phẩm theo id
CREATE PROCEDURE sp_GetProductById
    @productId INT
AS
BEGIN
    SELECT 
        p.*, 
        c.category_name, 
        b.brand_name, 
        COALESCE(i.quantity_on_hand, 0) AS quantity_on_hand
    FROM products p
    LEFT JOIN categories c ON p.category_id = c.category_id
    LEFT JOIN brands b ON p.brand_id = b.brand_id
    LEFT JOIN inventory i ON p.product_id = i.product_id
    WHERE p.product_id = @productId;
END
GO

-- Procedure lấy khách hàng theo số điện thoại
CREATE PROCEDURE sp_GetCustomerByPhone
    @phone NVARCHAR(20)
AS
BEGIN
    SELECT c.*, 
           COUNT(o.order_id) AS total_orders,
           COALESCE(MAX(o.order_date), c.created_at) AS last_order_date
    FROM customers c
    LEFT JOIN orders o 
        ON c.customer_id = o.customer_id 
       AND o.order_status = 'completed'
    WHERE c.phone = @phone
    GROUP BY 
        c.customer_id, c.customer_code, c.full_name, c.phone, c.email, 
        c.address, c.date_of_birth, c.gender, c.customer_type, 
        c.total_spent, c.created_at, c.updated_at
END
GO

-- Procedure thêm order
CREATE PROCEDURE sp_InsertOrder
    @order_code NVARCHAR(50),
    @customer_id INT = NULL,
    @employee_id INT = NULL,
    @order_date DATETIME,
    @subtotal DECIMAL(18,2),
    @discount_amount DECIMAL(18,2),
    @tax_amount DECIMAL(18,2),
    @total_amount DECIMAL(18,2),
    @promotion_id INT = NULL,
    @payment_method NVARCHAR(50),
    @payment_status NVARCHAR(50),
    @order_status NVARCHAR(50),
    @notes NVARCHAR(MAX),
    @order_id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO orders (
            order_code, customer_id, employee_id, order_date, 
            subtotal, discount_amount, tax_amount, total_amount,
            promotion_id, payment_method, payment_status, order_status, notes
        )
        VALUES (
            @order_code, @customer_id, @employee_id, @order_date,
            @subtotal, @discount_amount, @tax_amount, @total_amount,
            @promotion_id, @payment_method, @payment_status, @order_status, @notes
        );

        SET @order_id = SCOPE_IDENTITY();

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END
GO

-- Procedure thêm chi tiết order
CREATE PROCEDURE sp_InsertOrderDetail
    @order_id INT,
    @product_id INT,
    @quantity INT,
    @unit_price DECIMAL(18,2),
    @discount_per_item DECIMAL(18,2),
    @total_price DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO order_details (
            order_id, product_id, quantity, unit_price, discount_per_item, total_price
        )
        VALUES (
            @order_id, @product_id, @quantity, @unit_price, @discount_per_item, @total_price
        );

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END
GO

-- Procedure thêm thanh toán
CREATE PROCEDURE sp_InsertPayment
    @order_id INT,
    @payment_date DATETIME,
    @payment_method NVARCHAR(50),
    @amount DECIMAL(18,2),
    @reference_number NVARCHAR(100),
    @status NVARCHAR(50),
    @notes NVARCHAR(MAX),
    @payment_id INT OUTPUT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO payments (
            order_id, payment_date, payment_method, amount,
            reference_number, status, notes
        )
        VALUES (
            @order_id, @payment_date, @payment_method, @amount,
            @reference_number, @status, @notes
        );

        SET @payment_id = SCOPE_IDENTITY();

        -- Cập nhật trạng thái thanh toán của đơn hàng
        DECLARE @total_paid DECIMAL(18,2) = (
            SELECT SUM(amount)
            FROM payments
            WHERE order_id = @order_id AND status = 'successful'
        );

        DECLARE @order_total DECIMAL(18,2) = (
            SELECT total_amount FROM orders WHERE order_id = @order_id
        );

        UPDATE orders
        SET payment_status = 
            CASE 
                WHEN @total_paid >= @order_total THEN 'paid'
                WHEN @total_paid > 0 THEN 'partial'
                ELSE 'unpaid'
            END
        WHERE order_id = @order_id;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END
GO

-- Procedure lấy order bằng order id
CREATE PROCEDURE sp_GetOrderById
    @orderId INT
AS
BEGIN
    SELECT 
        o.*, 
        c.full_name AS customer_name, 
        e.full_name AS employee_name
    FROM orders o
    LEFT JOIN customers c ON o.customer_id = c.customer_id
    LEFT JOIN employees e ON o.employee_id = e.employee_id
    WHERE o.order_id = @orderId;
END
GO

-- Procedure lấy chi tiết order bằng order id
CREATE PROCEDURE sp_GetOrderDetails
    @orderId INT
AS
BEGIN
    SELECT 
        od.*, 
        p.product_name, 
        p.product_code
    FROM order_details od
    INNER JOIN products p ON od.product_id = p.product_id
    WHERE od.order_id = @orderId
    ORDER BY od.detail_id;
END
GO
-- Procedure thêm khách hàng
CREATE PROCEDURE sp_InsertCustomer
    @customer_code NVARCHAR(50),
    @full_name NVARCHAR(100),
    @phone NVARCHAR(20),
    @email NVARCHAR(100),
    @address NVARCHAR(255),
    @date_of_birth DATE = NULL,
    @gender NVARCHAR(10),
    @customer_type NVARCHAR(50)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO customers (
            customer_code, full_name, phone, email, address,
            date_of_birth, gender, customer_type
        )
        VALUES (
            @customer_code, @full_name, @phone, @email, @address,
            @date_of_birth, @gender, @customer_type
        );

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END
GO

-- Procedure cập nhật trạng thái order
CREATE PROCEDURE sp_UpdateOrderStatus
    @orderId INT,
    @newStatus NVARCHAR(50)
AS
BEGIN
    UPDATE orders
    SET order_status = @newStatus
    WHERE order_id = @orderId;
END
GO

-- Procedure cập nhật trạng thái thanh toán
CREATE PROCEDURE sp_UpdatePaymentStatus
    @orderId INT,
    @newStatus NVARCHAR(50)
AS
BEGIN
    UPDATE orders
    SET payment_status = @newStatus
    WHERE order_id = @orderId;
END
GO

-- Procedure lấy danh sách sản phẩm bán chạy
CREATE PROCEDURE sp_GetTopSellingProducts
    @fromDate DATE,
    @toDate DATE,
    @topCount INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP (@topCount)
        p.product_id,
        p.product_name,
        b.brand_name,
        SUM(od.quantity) AS quantity_sold,
        SUM(od.total_price) AS total_revenue,
        AVG(od.unit_price) AS avg_price,
        COUNT(DISTINCT od.order_id) AS total_orders
    FROM products p
    INNER JOIN order_details od ON p.product_id = od.product_id
    INNER JOIN orders o ON od.order_id = o.order_id
    LEFT JOIN brands b ON p.brand_id = b.brand_id
    WHERE o.order_status = 'completed'
      AND CAST(o.order_date AS DATE) BETWEEN @fromDate AND @toDate
    GROUP BY p.product_id, p.product_name, b.brand_name
    ORDER BY quantity_sold DESC;
END
GO

-- Procedure lấy danh sách năng suất của nhân viên
CREATE PROCEDURE sp_GetEmployeePerformanceReport
    @fromDate DATE,
    @toDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        e.employee_id,
        e.full_name,
        e.position,
        COUNT(o.order_id) AS total_orders,
        COALESCE(SUM(o.total_amount), 0) AS total_sales,
        COALESCE(AVG(o.total_amount), 0) AS avg_order_value,
        COALESCE(MAX(o.order_date), e.created_at) AS last_sale_date
    FROM employees e
    LEFT JOIN orders o ON e.employee_id = o.employee_id 
        AND o.order_status = 'completed'
        AND CAST(o.order_date AS DATE) BETWEEN @fromDate AND @toDate
    WHERE e.status = 'active'
    GROUP BY e.employee_id, e.full_name, e.position, e.created_at
    ORDER BY total_sales DESC;
END
GO

-- Procedure lấy khuyến mãi bằng mã khuyến mãi
CREATE PROCEDURE sp_GetPromotionByCode
    @code NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM promotions
    WHERE promotion_code = @code
      AND status = 'active'
      AND CAST(GETDATE() AS DATE) BETWEEN start_date AND end_date
      AND (usage_limit IS NULL OR used_count < usage_limit);
END
GO

-- Procedure thêm khuyến mãi
CREATE PROCEDURE sp_InsertPromotion
    @code NVARCHAR(50),
    @name NVARCHAR(100),
    @description NVARCHAR(MAX),
    @discountType NVARCHAR(20),
    @discountValue DECIMAL(18, 2),
    @startDate DATE,
    @endDate DATE,
    @minOrderAmount DECIMAL(18, 2),
    @maxDiscountAmount DECIMAL(18, 2),
    @usageLimit INT = NULL,
    @status NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO promotions (
            promotion_code, promotion_name, description, discount_type,
            discount_value, start_date, end_date, min_order_amount,
            max_discount_amount, usage_limit, status
        )
        VALUES (
            @code, @name, @description, @discountType, @discountValue,
            @startDate, @endDate, @minOrderAmount, @maxDiscountAmount, @usageLimit, @status
        );

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        DECLARE @err NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50001, @err, 1;
    END CATCH
END
GO

-- Procedure lấy tất cả các khuyến mãi
CREATE PROCEDURE sp_GetAllPromotions
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM promotions
    ORDER BY created_at DESC;
END
GO

-- Procedure cập nhật trạng thái khuyến mãi
CREATE PROCEDURE sp_UpdatePromotionStatus
    @promotionId INT,
    @status NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE promotions 
    SET status = @status,
        updated_at = GETDATE()
    WHERE promotion_id = @promotionId;
END
GO

-- Procedure xóa khuyến mãi
CREATE PROCEDURE sp_DeletePromotion
    @promotionId INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM promotions
        WHERE promotion_id = @promotionId;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW; -- ném lỗi rõ ràng lên ứng dụng
    END CATCH
END
GO

-- Procedure cập nhật khuyến mãi
CREATE PROCEDURE sp_UpdatePromotion
    @promotionId INT,
    @name NVARCHAR(100),
    @description NVARCHAR(MAX),
    @discountType NVARCHAR(20),
    @discountValue DECIMAL(18, 2),
    @startDate DATE,
    @endDate DATE,
    @minOrderAmount DECIMAL(18, 2),
    @maxDiscountAmount DECIMAL(18, 2),
    @usageLimit INT = NULL,
    @status NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE promotions 
    SET promotion_name = @name,
        description = @description,
        discount_type = @discountType,
        discount_value = @discountValue,
        start_date = @startDate,
        end_date = @endDate,
        min_order_amount = @minOrderAmount,
        max_discount_amount = @maxDiscountAmount,
        usage_limit = @usageLimit,
        status = @status,
        updated_at = GETDATE()
    WHERE promotion_id = @promotionId;
END
GO

-- Tạo role cho admin (admin cửa hàng)
CREATE ROLE db_admin;
GO

-- Tạo role cho Manager (quản lý cửa hàng)
CREATE ROLE db_manager;
GO

-- Tạo role cho Cashier (thu ngân)
CREATE ROLE db_cashier;
GO

-- Tạo role cho Salesperson (nhân viên bán hàng)
CREATE ROLE db_salesperson;
GO

-- Tạo role cho Staff (nhân viên cơ bản)
CREATE ROLE db_staff;
GO

-- =====================================================
-- 10. PHÂN QUYỀN CHO ADMIN ROLE (TOÀN QUYỀN)
-- =====================================================

-- Admin có toàn quyền trên tất cả tables
GRANT SELECT, INSERT, UPDATE, DELETE ON employees TO db_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON roles TO db_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON users TO db_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON user_roles TO db_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON customers TO db_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON suppliers TO db_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON categories TO db_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON brands TO db_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON products TO db_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON inventory TO db_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON promotions TO db_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON orders TO db_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON order_details TO db_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON payments TO db_admin;

-- Admin có quyền thực thi tất cả stored procedures
GRANT EXECUTE ON sp_GetDashboardStats TO db_admin;
GRANT EXECUTE ON sp_GetCustomerByPhone TO db_admin;
GRANT EXECUTE ON sp_GetProductStock TO db_admin;
GRANT EXECUTE ON sp_GetProductById TO db_admin;
GRANT EXECUTE ON sp_InsertOrder TO db_admin;
GRANT EXECUTE ON sp_InsertOrderDetail TO db_admin;
GRANT EXECUTE ON sp_GetOrderById TO db_admin;
GRANT EXECUTE ON sp_GetOrderDetails TO db_admin;
GRANT EXECUTE ON sp_InsertPayment TO db_admin;
GRANT EXECUTE ON sp_InsertCustomer TO db_admin;
GRANT EXECUTE ON sp_UpdateOrderStatus TO db_admin;
GRANT EXECUTE ON sp_UpdatePaymentStatus TO db_admin;
GRANT EXECUTE ON sp_GetTopSellingProducts TO db_admin;
GRANT EXECUTE ON sp_GetEmployeePerformanceReport TO db_admin;
GRANT EXECUTE ON sp_GetPromotionByCode TO db_admin;
GRANT EXECUTE ON sp_InsertPromotion TO db_admin;
GRANT EXECUTE ON sp_GetAllPromotions TO db_admin;
GRANT EXECUTE ON sp_UpdatePromotionStatus TO db_admin;
GRANT EXECUTE ON sp_DeletePromotion TO db_admin;
GRANT EXECUTE ON sp_UpdatePromotion TO db_admin;
GRANT EXECUTE ON GetRevenueReport TO db_admin;
GRANT EXECUTE ON LoginUser TO db_admin;
GRANT EXECUTE ON CheckUserRoles TO db_admin;


-- Admin có quyền truy cập tất cả views
GRANT SELECT ON v_AllActiveProducts TO db_admin;
GRANT SELECT ON v_ActiveEmployees TO db_admin;
GRANT SELECT ON v_ActivePromotions TO db_admin;
GRANT SELECT ON daily_revenue_report TO db_admin;
GRANT SELECT ON top_selling_products TO db_admin;
GRANT SELECT ON employee_performance TO db_admin;
GRANT SELECT ON profit_report TO db_admin;

-- Admin có quyền truy cập functions
GRANT EXECUTE ON fn_GenerateOrderCode TO db_admin;
GRANT EXECUTE ON fn_GenerateCustomerCode TO db_admin;
GRANT SELECT ON fn_GetPaymentSummaryByOrderId TO db_admin;
GRANT SELECT ON fn_GetAllOrders TO db_admin;
GRANT SELECT ON fn_GetDailySalesReport TO db_admin;

-- =====================================================
-- 11. PHÂN QUYỀN CHO MANAGER ROLE
-- =====================================================

-- Manager có quyền đọc hầu hết các bảng
GRANT SELECT ON employees TO db_manager;
GRANT SELECT ON customers TO db_manager;
GRANT SELECT ON suppliers TO db_manager;
GRANT SELECT ON categories TO db_manager;
GRANT SELECT ON brands TO db_manager;
GRANT SELECT ON products TO db_manager;
GRANT SELECT ON inventory TO db_manager;
GRANT SELECT ON promotions TO db_manager;
GRANT SELECT ON orders TO db_manager;
GRANT SELECT ON order_details TO db_manager;
GRANT SELECT ON payments TO db_manager;
GRANT SELECT ON roles TO db_manager;
GRANT SELECT ON users TO db_manager;
GRANT SELECT ON user_roles TO db_manager;

-- Manager có quyền quản lý khách hàng và đơn hàng
GRANT INSERT, UPDATE ON customers TO db_manager;
GRANT INSERT, UPDATE ON orders TO db_manager;
GRANT INSERT, UPDATE ON order_details TO db_manager;
GRANT INSERT, UPDATE ON payments TO db_manager;

-- Manager có quyền quản lý khuyến mãi và kho
GRANT INSERT, UPDATE ON promotions TO db_manager;
GRANT UPDATE ON inventory TO db_manager;

-- Manager có quyền thực thi stored procedures cần thiết
GRANT EXECUTE ON sp_GetDashboardStats TO db_manager;
GRANT EXECUTE ON sp_GetCustomerByPhone TO db_manager;
GRANT EXECUTE ON sp_GetProductStock TO db_manager;
GRANT EXECUTE ON sp_GetProductById TO db_manager;
GRANT EXECUTE ON sp_InsertOrder TO db_manager;
GRANT EXECUTE ON sp_InsertOrderDetail TO db_manager;
GRANT EXECUTE ON sp_GetOrderById TO db_manager;
GRANT EXECUTE ON sp_GetOrderDetails TO db_manager;
GRANT EXECUTE ON sp_InsertPayment TO db_manager;
GRANT EXECUTE ON sp_InsertCustomer TO db_manager;
GRANT EXECUTE ON sp_UpdateOrderStatus TO db_manager;
GRANT EXECUTE ON sp_UpdatePaymentStatus TO db_manager;
GRANT EXECUTE ON sp_GetTopSellingProducts TO db_manager;
GRANT EXECUTE ON sp_GetEmployeePerformanceReport TO db_manager;
GRANT EXECUTE ON sp_GetPromotionByCode TO db_manager;
GRANT EXECUTE ON sp_GetAllPromotions TO db_manager;
GRANT EXECUTE ON sp_InsertPromotion TO db_manager;
GRANT EXECUTE ON sp_UpdatePromotionStatus TO db_manager;
GRANT EXECUTE ON sp_DeletePromotion TO db_manager;
GRANT EXECUTE ON sp_UpdatePromotion TO db_manager;
GRANT EXECUTE ON GetRevenueReport TO db_manager;
GRANT EXECUTE ON CheckUserRoles TO db_manager;
GRANT EXECUTE ON LoginUser TO db_manager;


-- Manager có quyền truy cập tất cả views
GRANT SELECT ON v_AllActiveProducts TO db_manager;
GRANT SELECT ON v_ActiveEmployees TO db_manager;
GRANT SELECT ON v_ActivePromotions TO db_manager;
GRANT SELECT ON daily_revenue_report TO db_manager;
GRANT SELECT ON top_selling_products TO db_manager;
GRANT SELECT ON employee_performance TO db_manager;
GRANT SELECT ON profit_report TO db_manager;

-- Manager có quyền truy cập functions
GRANT EXECUTE ON fn_GenerateOrderCode TO db_manager;
GRANT EXECUTE ON fn_GenerateCustomerCode TO db_manager;
GRANT SELECT ON fn_GetPaymentSummaryByOrderId TO db_manager;
GRANT SELECT ON fn_GetAllOrders TO db_manager;
GRANT SELECT ON fn_GetDailySalesReport TO db_manager;

-- =====================================================
-- 12. PHÂN QUYỀN TINH GỌN CHO CASHIER (THU NGÂN)
-- =====================================================

-- Cashier - Quyền SELECT cơ bản cho bán hàng
GRANT SELECT ON employees TO db_cashier;
GRANT SELECT ON customers TO db_cashier;
GRANT SELECT ON suppliers TO db_cashier;
GRANT SELECT ON categories TO db_cashier;
GRANT SELECT ON brands TO db_cashier;
GRANT SELECT ON products TO db_cashier;
GRANT SELECT ON inventory TO db_cashier;
GRANT SELECT ON promotions TO db_cashier;
GRANT SELECT ON orders TO db_cashier;
GRANT SELECT ON order_details TO db_cashier;
GRANT SELECT ON payments TO db_cashier;
GRANT SELECT ON roles TO db_cashier;
GRANT SELECT ON users TO db_cashier;
GRANT SELECT ON user_roles TO db_cashier;

-- Cashier - Quyền INSERT/UPDATE cho bán hàng
GRANT INSERT ON customers TO db_cashier;
GRANT INSERT, UPDATE ON orders TO db_cashier;
GRANT INSERT ON order_details TO db_cashier;
GRANT INSERT ON payments TO db_cashier;

-- Cashier - Stored procedures cần thiết cho bán hàng
GRANT EXECUTE ON sp_GetCustomerByPhone TO db_cashier;
GRANT EXECUTE ON sp_GetProductById TO db_cashier;
GRANT EXECUTE ON sp_GetProductStock TO db_cashier;
GRANT EXECUTE ON sp_InsertCustomer TO db_cashier;
GRANT EXECUTE ON sp_InsertOrder TO db_cashier;
GRANT EXECUTE ON sp_InsertOrderDetail TO db_cashier;
GRANT EXECUTE ON sp_InsertPayment TO db_cashier;
GRANT EXECUTE ON sp_GetOrderById TO db_cashier;
GRANT EXECUTE ON sp_GetOrderDetails TO db_cashier;
GRANT EXECUTE ON sp_InsertPayment TO db_cashier;
GRANT EXECUTE ON sp_InsertCustomer TO db_cashier;
GRANT EXECUTE ON sp_UpdateOrderStatus TO db_cashier;
GRANT EXECUTE ON sp_UpdatePaymentStatus TO db_cashier;
GRANT EXECUTE ON sp_GetPromotionByCode TO db_cashier;
GRANT EXECUTE ON sp_GetAllPromotions TO db_cashier;
GRANT EXECUTE ON CheckUserRoles TO db_cashier;
GRANT EXECUTE ON LoginUser TO db_cashier;

-- Cashier - Functions cần thiết
GRANT EXECUTE ON fn_GenerateOrderCode TO db_cashier;
GRANT EXECUTE ON fn_GenerateCustomerCode TO db_cashier;
GRANT SELECT ON fn_GetPaymentSummaryByOrderId TO db_cashier;
GRANT SELECT ON fn_GetAllOrders TO db_cashier;

-- Cashier - Views cần thiết
GRANT SELECT ON v_AllActiveProducts TO db_cashier;
GRANT SELECT ON v_ActiveEmployees TO db_cashier;
GRANT SELECT ON v_ActivePromotions TO db_cashier;

-- =====================================================
-- 13. PHÂN QUYỀN TINH GỌN CHO SALESPERSON (BÁN HÀNG + BÁO CÁO CƠ BẢN)
-- =====================================================

-- Salesperson - Kế thừa tất cả quyền của Cashier
GRANT SELECT ON employees TO db_salesperson;
GRANT SELECT ON customers TO db_salesperson;
GRANT SELECT ON suppliers TO db_salesperson;
GRANT SELECT ON categories TO db_salesperson;
GRANT SELECT ON brands TO db_salesperson;
GRANT SELECT ON products TO db_salesperson;
GRANT SELECT ON inventory TO db_salesperson;
GRANT SELECT ON promotions TO db_salesperson;
GRANT SELECT ON orders TO db_salesperson;
GRANT SELECT ON order_details TO db_salesperson;
GRANT SELECT ON payments TO db_salesperson;
GRANT SELECT ON roles TO db_salesperson;
GRANT SELECT ON users TO db_salesperson;
GRANT SELECT ON user_roles TO db_salesperson;


GRANT INSERT ON customers TO db_salesperson;
GRANT INSERT, UPDATE ON orders TO db_salesperson;
GRANT INSERT ON order_details TO db_salesperson;
GRANT INSERT ON payments TO db_salesperson;

-- Salesperson - Stored procedures bán hàng
GRANT EXECUTE ON sp_GetCustomerByPhone TO db_salesperson;
GRANT EXECUTE ON sp_GetProductById TO db_salesperson;
GRANT EXECUTE ON sp_GetProductStock TO db_salesperson;
GRANT EXECUTE ON sp_InsertCustomer TO db_salesperson;
GRANT EXECUTE ON sp_InsertOrder TO db_salesperson;
GRANT EXECUTE ON sp_InsertOrderDetail TO db_salesperson;
GRANT EXECUTE ON sp_InsertPayment TO db_salesperson;
GRANT EXECUTE ON sp_GetOrderById TO db_salesperson;
GRANT EXECUTE ON sp_GetOrderDetails TO db_salesperson;
GRANT EXECUTE ON sp_InsertPayment TO db_salesperson;
GRANT EXECUTE ON sp_InsertCustomer TO db_salesperson;
GRANT EXECUTE ON sp_UpdateOrderStatus TO db_salesperson;
GRANT EXECUTE ON sp_UpdatePaymentStatus TO db_salesperson;
GRANT EXECUTE ON sp_GetPromotionByCode TO db_salesperson;
GRANT EXECUTE ON sp_GetAllPromotions TO db_salesperson;
GRANT EXECUTE ON CheckUserRoles TO db_salesperson;
GRANT EXECUTE ON LoginUser TO db_salesperson;


-- Salesperson - Stored procedures báo cáo doanh thu
GRANT EXECUTE ON sp_GetDashboardStats TO db_salesperson;
GRANT EXECUTE ON sp_GetTopSellingProducts TO db_salesperson;

-- Salesperson - Functions
GRANT EXECUTE ON fn_GenerateOrderCode TO db_salesperson;
GRANT EXECUTE ON fn_GenerateCustomerCode TO db_salesperson;
GRANT SELECT ON fn_GetPaymentSummaryByOrderId TO db_salesperson;
GRANT SELECT ON fn_GetDailySalesReport TO db_salesperson;
GRANT SELECT ON fn_GetAllOrders TO db_salesperson;

-- Salesperson - Views cần thiết
GRANT SELECT ON v_AllActiveProducts TO db_salesperson;
GRANT SELECT ON v_ActiveEmployees TO db_salesperson;
GRANT SELECT ON v_ActivePromotions TO db_salesperson;
GRANT SELECT ON daily_revenue_report TO db_salesperson;
GRANT SELECT ON top_selling_products TO db_salesperson;

-- =====================================================
-- 14. PHÂN QUYỀN CHO STAFF ROLE
-- =====================================================

-- Staff chỉ có quyền đọc thông tin cơ bản
GRANT SELECT ON employees TO db_staff;
GRANT SELECT ON customers TO db_staff;
GRANT SELECT ON suppliers TO db_staff;
GRANT SELECT ON categories TO db_staff;
GRANT SELECT ON brands TO db_staff;
GRANT SELECT ON products TO db_staff;
GRANT SELECT ON inventory TO db_staff;
GRANT SELECT ON promotions TO db_staff;
GRANT SELECT ON orders TO db_staff;
GRANT SELECT ON order_details TO db_staff;
GRANT SELECT ON payments TO db_staff;
GRANT SELECT ON roles TO db_staff;
GRANT SELECT ON users TO db_staff;
GRANT SELECT ON user_roles TO db_staff;

-- Staff có quyền thực thi một số stored procedures cơ bản
GRANT EXECUTE ON sp_GetCustomerByPhone TO db_staff;
GRANT EXECUTE ON sp_GetProductStock TO db_staff;
GRANT EXECUTE ON sp_GetProductById TO db_staff;
GRANT EXECUTE ON sp_GetOrderById TO db_staff;
GRANT EXECUTE ON sp_GetOrderDetails TO db_staff;
GRANT EXECUTE ON sp_GetPromotionByCode TO db_staff;
GRANT EXECUTE ON CheckUserRoles TO db_staff;
GRANT EXECUTE ON LoginUser TO db_staff;

-- Staff có quyền truy cập view sản phẩm
GRANT SELECT ON v_AllActiveProducts TO db_staff;
GRANT SELECT ON v_ActiveEmployees TO db_staff;
GRANT SELECT ON v_ActivePromotions TO db_staff;

-- =====================================================
-- 15. THÊM DỮ LIỆU MẪU
-- =====================================================

-- Thêm dữ liệu mẫu cho roles
INSERT INTO roles (role_name, description) VALUES
('Admin', N'Quản trị viên hệ thống, có toàn quyền'),
('Manager', N'Quản lý cửa hàng, quản lý nhân viên và đơn hàng'),
('Cashier', N'Thu ngân, xử lý thanh toán'),
('Salesperson', N'Nhân viên bán hàng, tạo đơn hàng'),
('Staff', N'Nhân viên cơ bản, hỗ trợ các công việc khác');
GO

-- Thêm dữ liệu mẫu cho categories
INSERT INTO categories (category_name, description) VALUES
(N'Điện thoại', N'Điện thoại thông minh các loại'),
(N'Phụ kiện', N'Phụ kiện điện thoại'),
(N'Tablet', N'Máy tính bảng'),
(N'Đồng hồ thông minh', N'Smart watch các loại');
GO

-- Thêm dữ liệu mẫu cho brands
INSERT INTO brands (brand_name, country_origin, description) VALUES
('Apple', 'USA', N'Thương hiệu công nghệ hàng đầu'),
('Samsung', 'South Korea', N'Tập đoàn công nghệ Hàn Quốc'),
('Xiaomi', 'China', N'Thương hiệu công nghệ Trung Quốc'),
('OPPO', 'China', N'Thương hiệu điện thoại'),
('Vivo', 'China', N'Thương hiệu điện thoại');
GO

-- Thêm dữ liệu mẫu cho suppliers
INSERT INTO suppliers (supplier_code, company_name, contact_person, phone, email, address) VALUES
('SUP001', N'Công ty TNHH Phân phối A', N'Nguyễn Văn A', '0901234567', 'contact@supplier-a.com', N'123 Đường ABC, Quận 1, TP.HCM'),
('SUP002', N'Công ty Cổ phần Thương mại B', N'Trần Thị B', '0902345678', 'info@supplier-b.com', N'456 Đường DEF, Quận 3, TP.HCM');
GO

-- Thêm dữ liệu mẫu cho employees (tự động tạo users và user_roles qua trigger)
INSERT INTO employees (employee_code, full_name, phone, email, position, hire_date, salary) VALUES
('EMP001', N'Nguyễn Văn Nam', '0911111111', 'nam@phonestore.com', N'Quản lý', '2023-01-01', 15000000),
('EMP002', N'Trần Thị Lan', '0922222222', 'lan@phonestore.com', N'Thu ngân', '2023-02-01', 8000000),
('EMP003', N'Lê Văn Hùng', '0933333333', 'hung@phonestore.com', N'Bán hàng', '2023-03-01', 10000000),
('EMP004', N'Nguyễn Trí Lâm', '0772944071', 'nguyentrilam0304@gmail.com', N'Admin', '2023-03-01', 100000000);
GO

-- Thêm dữ liệu mẫu cho customers
INSERT INTO customers (customer_code, full_name, phone, email, address, customer_type) VALUES
('CUS001', N'Phạm Văn Khách', '0944444444', 'khach@email.com', N'789 Đường GHI, Quận 5, TP.HCM', 'regular'),
('CUS002', N'Hoàng Thị Mai', '0955555555', 'mai@email.com', N'321 Đường JKL, Quận 7, TP.HCM', 'vip');
GO

-- Thêm dữ liệu mẫu cho products
INSERT INTO products (
    product_code, 
    product_name, 
    category_id, 
    brand_id, 
    supplier_id, 
    description, 
    specifications, 
    cost_price, 
    selling_price, 
    warranty_period, 
    image_url, 
    status
) VALUES
('PROD001', 'iPhone 14 Pro Max', 1, 1, 1, 
    'Điện thoại thông minh cao cấp từ Apple', 
    '{"RAM": "6GB", "Storage": "256GB", "Screen": "6.7 inch", "Camera": "48MP"}', 
    25000000.00, 29990000.00, 12, 
    'https://example.com/images/iphone14promax.jpg', 'active'),
('PROD002', 'Samsung Galaxy S23 Ultra', 1, 2, 1, 
    'Điện thoại flagship từ Samsung', 
    '{"RAM": "8GB", "Storage": "512GB", "Screen": "6.8 inch", "Camera": "200MP"}', 
    22000000.00, 26990000.00, 12, 
    'https://example.com/images/galaxys23ultra.jpg', 'active'),
('PROD003', 'Xiaomi 13 Pro', 1, 3, 2, 
    'Điện thoại cao cấp từ Xiaomi', 
    '{"RAM": "12GB", "Storage": "256GB", "Screen": "6.73 inch", "Camera": "50MP"}', 
    15000000.00, 18990000.00, 12, 
    'https://example.com/images/xiaomi13pro.jpg', 'active'),
('PROD004', 'AirPods Pro 2', 2, 1, 1, 
    'Tai nghe không dây cao cấp từ Apple', 
    '{"Type": "In-ear", "Battery": "6 hours", "ANC": "Yes"}', 
    5000000.00, 6990000.00, 6, 
    'https://example.com/images/airpodspro2.jpg', 'active'),
('PROD005', 'Samsung Galaxy Tab S8', 3, 2, 1, 
    'Máy tính bảng hiệu năng cao', 
    '{"RAM": "8GB", "Storage": "128GB", "Screen": "11 inch"}', 
    14000000.00, 17990000.00, 12, 
    'https://example.com/images/galaxytabs8.jpg', 'active'),
('PROD006', 'Apple Watch Series 8', 4, 1, 1, 
    'Đồng hồ thông minh cao cấp', 
    '{"Screen": "1.9 inch", "Battery": "18 hours", "Features": "ECG, SpO2"}', 
    9000000.00, 11990000.00, 12, 
    'https://example.com/images/applewatch8.jpg', 'active'),
('PROD007', 'OPPO Reno8', 1, 4, 2, 
    'Điện thoại tầm trung từ OPPO', 
    '{"RAM": "8GB", "Storage": "128GB", "Screen": "6.4 inch", "Camera": "64MP"}', 
    8000000.00, 9990000.00, 12, 
    'https://example.com/images/opporeno8.jpg', 'active'),
('PROD008', 'Vivo Y76', 1, 5, 2, 
    'Điện thoại giá rẻ từ Vivo', 
    '{"RAM": "6GB", "Storage": "128GB", "Screen": "6.58 inch", "Camera": "50MP"}', 
    5000000.00, 6990000.00, 12, 
    'https://example.com/images/vivoy76.jpg', 'active');
GO

INSERT INTO inventory (product_id, quantity_on_hand, quantity_reserved, min_stock_level, max_stock_level)
VALUES
(1, 50, 5, 10, 100), -- iPhone 14 Pro Max
(2, 40, 3, 15, 80),  -- Samsung Galaxy S23 Ultra
(3, 60, 10, 20, 120), -- Xiaomi 13 Pro
(4, 100, 20, 30, 200), -- AirPods Pro 2
(5, 30, 5, 10, 50),  -- Samsung Galaxy Tab S8
(6, 25, 2, 5, 40),   -- Apple Watch Series 8
(7, 70, 15, 20, 150), -- OPPO Reno8
(8, 80, 10, 25, 160); -- Vivo Y76
GO

-- =====================================================
-- KẾT THÚC SCRIPT TẠO CƠ SỞ DỮ LIỆU
-- =====================================================

-- Hiển thị danh sách các bảng đã tạo
SELECT name AS TableName FROM sys.tables;
GO