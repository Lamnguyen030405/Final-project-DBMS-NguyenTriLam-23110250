-- =====================================================
-- HỆ THỐNG PHÂN QUYỀN CHI TIẾT - CSDL phone_store_db_1
-- CỬA HÀNG ĐIỆN THOẠI - SQL SERVER
-- =====================================================

USE phone_store_db_1;
GO

-- =====================================================
-- 1. TẠO CÁC DATABASE ROLE
-- =====================================================

-- Tạo role cho Admin (toàn quyền)
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
-- 2. PHÂN QUYỀN CHO ADMIN ROLE (TOÀN QUYỀN)
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
GRANT EXECUTE ON GetRevenueReport TO db_admin;
GRANT EXECUTE ON LoginUser TO db_admin;
GRANT EXECUTE ON CheckUserRoles TO db_admin;


-- Admin có quyền truy cập tất cả views
GRANT SELECT ON v_AllActiveProducts TO db_admin;
GRANT SELECT ON v_ActiveEmployees TO db_admin;
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
-- 3. PHÂN QUYỀN CHO MANAGER ROLE
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
GRANT EXECUTE ON GetRevenueReport TO db_manager;
GRANT EXECUTE ON CheckUserRoles TO db_manager;
GRANT EXECUTE ON LoginUser TO db_manager;


-- Manager có quyền truy cập tất cả views
GRANT SELECT ON v_AllActiveProducts TO db_manager;
GRANT SELECT ON v_ActiveEmployees TO db_manager;
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
-- 4. PHÂN QUYỀN TINH GỌN CHO CASHIER (BÁN HÀNG)
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
GRANT EXECUTE ON CheckUserRoles TO db_cashier;
GRANT EXECUTE ON LoginUser TO db_cashier;

-- Cashier - Functions cần thiết
GRANT EXECUTE ON fn_GenerateOrderCode TO db_cashier;
GRANT EXECUTE ON fn_GenerateCustomerCode TO db_cashier;
GRANT SELECT ON fn_GetPaymentSummaryByOrderId TO db_cashier;

-- Cashier - Views cần thiết
GRANT SELECT ON v_AllActiveProducts TO db_cashier;
GRANT SELECT ON v_ActiveEmployees TO db_cashier;

-- =====================================================
-- 5. PHÂN QUYỀN TINH GỌN CHO SALESPERSON (BÁN HÀNG + BÁO CÁO CƠ BẢN)
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
GRANT SELECT ON daily_revenue_report TO db_salesperson;
GRANT SELECT ON top_selling_products TO db_salesperson;

-- =====================================================
-- 6. PHÂN QUYỀN CHO STAFF ROLE
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
GRANT EXECUTE ON CheckUserRoles TO db_staff;
GRANT EXECUTE ON LoginUser TO db_staff;

-- Staff có quyền truy cập view sản phẩm
GRANT SELECT ON v_AllActiveProducts TO db_staff;
GRANT SELECT ON v_ActiveEmployees TO db_salesperson;

-- =====================================================
-- 7. TẠO STORED PROCEDURE PHÂN QUYỀN TỰ ĐỘNG
-- =====================================================

CREATE PROCEDURE sp_AssignUserRole
    @user_id INT,
    @role_name NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @username NVARCHAR(50);
    DECLARE @database_role NVARCHAR(50);
    
    -- Lấy username
    SELECT @username = username FROM users WHERE user_id = @user_id;
    
    -- Xác định database role
    SET @database_role = CASE @role_name
        WHEN 'Admin' THEN 'db_admin'
        WHEN 'Manager' THEN 'db_manager'
        WHEN 'Cashier' THEN 'db_cashier'
        WHEN 'Salesperson' THEN 'db_salesperson'
        WHEN 'Staff' THEN 'db_staff'
        ELSE NULL
    END;
    
    IF @database_role IS NOT NULL AND @username IS NOT NULL
    BEGIN
        -- Tạo SQL động để thêm user vào role
        DECLARE @sql NVARCHAR(MAX);
        SET @sql = 'ALTER ROLE ' + @database_role + ' ADD MEMBER [' + @username + ']';
        EXEC sp_executesql @sql;
    END
END;
GO

-- =====================================================
-- 8. STORED PROCEDURE TẠO USER VÀ PHÂN QUYỀN
-- =====================================================

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

-- =====================================================
-- 9. STORED PROCEDURE XÓA USER VÀ QUYỀN
-- =====================================================

CREATE PROCEDURE sp_DropDatabaseUser
    @username NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        DECLARE @sql NVARCHAR(MAX);
        
        -- Xóa user khỏi database
        IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = @username)
        BEGIN
            SET @sql = 'DROP USER [' + @username + ']';
            EXEC sp_executesql @sql;
        END
        
        -- Xóa login
        IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = @username)
        BEGIN
            SET @sql = 'DROP LOGIN [' + @username + ']';
            EXEC sp_executesql @sql;
        END
        
        SELECT 1 as Result, 'User dropped successfully' as Message;
        
    END TRY
    BEGIN CATCH
        SELECT 0 as Result, ERROR_MESSAGE() as Message;
    END CATCH
END;
GO

-- =====================================================
-- 10. VIEW KIỂM TRA QUYỀN USER
-- =====================================================

CREATE VIEW v_UserPermissions AS
SELECT 
    p.state_desc as PermissionState,
    p.permission_name as Permission,
    s.name as PrincipalName,
    o.name as ObjectName,
    pr.principal_id as PrincipalID,
    pr.type_desc as PrincipalType
FROM sys.database_permissions p
    INNER JOIN sys.objects o ON p.major_id = o.object_id
    INNER JOIN sys.database_principals pr ON p.grantee_principal_id = pr.principal_id
    LEFT JOIN sys.schemas s ON o.schema_id = s.schema_id
WHERE pr.type IN ('S', 'U', 'G', 'R', 'A') -- SQL User, Windows User, Windows Group, Database Role, Application Role
GO

-- =====================================================
-- 11. STORED PROCEDURE KIỂM TRA QUYỀN CỦA USER
-- =====================================================

CREATE PROCEDURE sp_CheckUserPermissions
    @username NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT DISTINCT
        vp.Permission,
        vp.ObjectName,
        vp.PermissionState,
        vp.PrincipalType
    FROM v_UserPermissions vp
    WHERE vp.PrincipalName = @username
        OR vp.PrincipalName IN (
            SELECT r.name 
            FROM sys.database_role_members rm
            INNER JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id
            INNER JOIN sys.database_principals u ON rm.member_principal_id = u.principal_id
            WHERE u.name = @username
        )
    ORDER BY vp.ObjectName, vp.Permission;
END;
GO

-- =====================================================
-- 12. CẤP QUYỀN EXECUTE CHO STORED PROCEDURES MỚI
-- =====================================================

-- Admin có toàn quyền
GRANT EXECUTE ON sp_AssignUserRole TO db_admin;
GRANT EXECUTE ON sp_CreateDatabaseUser TO db_admin;
GRANT EXECUTE ON sp_DropDatabaseUser TO db_admin;
GRANT EXECUTE ON sp_CheckUserPermissions TO db_admin;
GRANT SELECT ON v_UserPermissions TO db_admin;

-- Manager chỉ có quyền kiểm tra permissions
GRANT EXECUTE ON sp_CheckUserPermissions TO db_manager;
GRANT SELECT ON v_UserPermissions TO db_manager;

-- =====================================================
-- 13. SCRIPT DEMO TẠO USER VÀ PHÂN QUYỀN
-- =====================================================

/*
-- Ví dụ tạo user cho từng role:

-- Tạo Admin user
EXEC sp_CreateDatabaseUser 'admin_user', 'Admin123!', 'Admin';

-- Tạo Manager user  
EXEC sp_CreateDatabaseUser 'manager_user', 'Manager123!', 'Manager';

-- Tạo Cashier user
EXEC sp_CreateDatabaseUser 'cashier_user', 'Cashier123!', 'Cashier';

-- Tạo Salesperson user
EXEC sp_CreateDatabaseUser 'sales_user', 'Sales123!', 'Salesperson';

-- Tạo Staff user
EXEC sp_CreateDatabaseUser 'staff_user', 'Staff123!', 'Staff';

-- Kiểm tra quyền của user
EXEC sp_CheckUserPermissions 'manager_user';
*/

-- =====================================================
-- 14. SCRIPT BACKUP PERMISSIONS
-- =====================================================

CREATE PROCEDURE sp_BackupPermissions
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        'GRANT ' + permission_name + ' ON ' + 
        OBJECT_SCHEMA_NAME(major_id) + '.' + OBJECT_NAME(major_id) + 
        ' TO [' + USER_NAME(grantee_principal_id) + ']' as GrantStatement
    FROM sys.database_permissions 
    WHERE major_id > 0
        AND grantee_principal_id > 4 -- Exclude system principals
        AND state = 'G' -- Only granted permissions
    ORDER BY OBJECT_NAME(major_id), USER_NAME(grantee_principal_id);
END;
GO

GRANT EXECUTE ON sp_BackupPermissions TO db_admin;

-- =====================================================
-- KẾT THÚC SCRIPT PHÂN QUYỀN
-- =====================================================

PRINT 'Hoàn thành việc thiết lập phân quyền cho hệ thống quản lý cửa hàng điện thoại!';
PRINT 'Các role đã được tạo:';
PRINT '- db_admin: Toàn quyền hệ thống';
PRINT '- db_manager: Quản lý cửa hàng và báo cáo';
PRINT '- db_cashier: Thu ngân và xử lý đơn hàng';
PRINT '- db_salesperson: Bán hàng và báo cáo cơ bản';
PRINT '- db_staff: Nhân viên cơ bản, chỉ đọc thông tin';

PRINT 'Sử dụng sp_CreateDatabaseUser để tạo user mới với quyền tương ứng.';
GO

-- Đổi hết thành mật khẩu mặc định
EXEC sp_CreateDatabaseUser 'user_EMP001', 'default123', 'Manager';
EXEC sp_CreateDatabaseUser 'user_EMP008', 'default123', 'Manager';

EXEC sp_CreateDatabaseUser 'user_EMP002', 'default123', 'Cashier';
EXEC sp_CreateDatabaseUser 'user_EMP004', 'default123', 'Cashier';
EXEC sp_CreateDatabaseUser 'user_EMP007', 'default123', 'Cashier';
EXEC sp_CreateDatabaseUser 'user_EMP010', 'default123', 'Cashier';

EXEC sp_CreateDatabaseUser 'user_EMP003', 'default123', 'Salesperson';
EXEC sp_CreateDatabaseUser 'user_EMP005', 'default123', 'Salesperson';
EXEC sp_CreateDatabaseUser 'user_EMP006', 'default123', 'Salesperson';
EXEC sp_CreateDatabaseUser 'user_EMP009', 'default123', 'Salesperson';

-- Xóa user và login cho từng người
EXEC sp_DropDatabaseUser 'user_EMP001';
EXEC sp_DropDatabaseUser 'user_EMP002';
EXEC sp_DropDatabaseUser 'user_EMP003';
EXEC sp_DropDatabaseUser 'user_EMP004';
EXEC sp_DropDatabaseUser 'user_EMP005';
EXEC sp_DropDatabaseUser 'user_EMP006';
EXEC sp_DropDatabaseUser 'user_EMP007';
EXEC sp_DropDatabaseUser 'user_EMP008';
EXEC sp_DropDatabaseUser 'user_EMP009';
EXEC sp_DropDatabaseUser 'user_EMP010';



-- Kiểm tra quyền của Manager
PRINT '========== QUYỀN CỦA MANAGER ==========';
EXEC sp_CheckUserPermissions 'user_EMP001';

-- Kiểm tra quyền của Cashier
PRINT '========== QUYỀN CỦA CASHIER ==========';
EXEC sp_CheckUserPermissions 'user_EMP002';

-- Kiểm tra quyền của Salesperson
PRINT '========== QUYỀN CỦA SALESPERSON ==========';
EXEC sp_CheckUserPermissions 'user_EMP003';

SELECT name, type_desc 
FROM sys.database_principals 
WHERE name = 'user_EMP001';
SELECT m.name AS MemberName, r.name AS RoleName
FROM sys.database_role_members rm
JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id
JOIN sys.database_principals m ON rm.member_principal_id = m.principal_id
WHERE m.name = 'user_EMP001';

-- Lấy user_id từ bảng users
SELECT user_id FROM users WHERE username = 'user_EMP001';
-- Giả sử kết quả là 12

-- Gán role tương ứng
EXEC sp_AssignUserRole @user_id = 12, @role_name = 'Manager';

SELECT name, type_desc
FROM sys.database_principals
WHERE name = 'user_EMP001';

SELECT class_desc, major_id, permission_name, state_desc, OBJECT_NAME(major_id) AS ObjectName, USER_NAME(grantee_principal_id) AS Grantee
FROM sys.database_permissions
WHERE USER_NAME(grantee_principal_id) = 'db_manager'
ORDER BY ObjectName;
SELECT 
    m.name AS MemberName, 
    r.name AS RoleName
FROM sys.database_role_members rm
JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id
JOIN sys.database_principals m ON rm.member_principal_id = m.principal_id
WHERE r.name = 'db_manager';

-- Dữ liệu từ role gán
SELECT 
    dp.permission_name,
    dp.state_desc,
    OBJECT_NAME(dp.major_id) AS ObjectName,
    r.name AS RoleName
FROM sys.database_permissions dp
JOIN sys.database_principals r ON dp.grantee_principal_id = r.principal_id
JOIN sys.database_role_members drm ON drm.role_principal_id = r.principal_id
JOIN sys.database_principals u ON drm.member_principal_id = u.principal_id
WHERE u.name = 'user_EMP003';
-- Cấp quyền EXECUTE cho tất cả các role cần dùng LoginUser

GRANT EXECUTE ON LoginUser TO db_admin;
GRANT EXECUTE ON LoginUser TO db_manager;
GRANT EXECUTE ON LoginUser TO db_cashier;
GRANT EXECUTE ON LoginUser TO db_salesperson;
GRANT EXECUTE ON LoginUser TO db_staff;
