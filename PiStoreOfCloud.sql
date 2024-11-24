CREATE DATABASE PiStoreOfCloud;
USE PiStoreOfCloud;

CREATE TABLE [User] (
    ID INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,  
    Role NVARCHAR(20) CHECK (Role IN ('Admin', 'Employee', 'Client')),
    EmployeeID NVARCHAR(10) NULL,  -- Lk Employee 
    ClientID NVARCHAR(10) NULL     -- Lk Client 
);

SELECT * FROM Client 
WHERE 1=1 
AND Name LIKE N'%Trần Mỹ Vân%'

CREATE TABLE Employee (
    ID NVARCHAR(10) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    Phone NVARCHAR(15),
    Address NVARCHAR(255),
    Salary DECIMAL(18, 2),
    HireDate DATE
);

CREATE TABLE Client (
    ID NVARCHAR(10) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    Phone NVARCHAR(15),
    Address NVARCHAR(255)
);

-- Bảng Product
CREATE TABLE Product (
    ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(18, 2),
    Quantity INT
);

-- Bảng Order
CREATE TABLE [Order] (
    ID INT PRIMARY KEY IDENTITY,
    ClientID NVARCHAR(10),
    EmployeeID NVARCHAR(10),
    OrderDate DATE,
    TotalPrice DECIMAL(18, 2)
);

-- Bảng OrderItem
CREATE TABLE OrderItem (
    ID INT PRIMARY KEY IDENTITY,
    OrderID INT,
    ProductID INT,
    Quantity INT
);

-- Bảng Bill
CREATE TABLE Bill (
    ID INT PRIMARY KEY IDENTITY,
    OrderID INT,
    ClientID NVARCHAR(10),
    EmployeeID NVARCHAR(10),
    BillDate DATE,
    TotalPrice DECIMAL(18, 2)
);

SELECT c.ID, c.Name, b.ID, b.TotalPrice as TotalSpent
FROM Client c
INNER JOIN Bill b ON c.ID = b.ClientID

INSERT INTO Employee (ID, Name, Email, Phone, Address, Salary, HireDate)
VALUES 
    ('e0010', 'Nguyễn Văn Linh', 'a.nguyen@pistore.com', '0145856789', '123 Đường Bà Chiểu, Hà Nội', 10000000, '2023-01-1'),
    ('e0002', 'Tran Thi B', 'b.tran@pistore.com', '0987654321', '456 Street B, Ho Chi Minh City', 12000000, '2023-02-20'),
    ('e0003', 'Le Van C', 'c.le@pistore.com', '0912345678', '789 Street C, Da Nang', 11000000, '2023-03-10'),
    ('e0004', 'Nguyen Van X', 'x.nguyen@pistore.com', '0123456700', '100 Street X, Hanoi', 13000000, '2023-04-05'),
    ('e0005', 'Le Thi Y', 'y.le@company.net', '0987600000', '200 Street Y, Ho Chi Minh City', 14000000, '2023-05-10'),
    ('e0006', 'Tran Van Z', 'z.tran@outlook.com', '0912300001', '300 Street Z, Da Nang', 12500000, '2023-06-20');

-- Insert dữ liệu vào bảng Client với ID dạng c000 + số thứ tự
INSERT INTO Client (ID, Name, Email, Phone, Address)
VALUES 
    ('c0001', 'Pham Thi D', 'd.pham@gmail.com', '0934567890', '321 Street D, Can Tho'),
    ('c0002', 'Vo Van E', 'e.vo@gmail.com', '0976543210', '654 Street E, Nha Trang'),
    ('c0003', 'Nguyen Thi F', 'f.nguyen@gmail.com', '0901234567', '987 Street F, Hue'),
    ('c0004', 'Bui Thi K', 'k.bui@company.com', '0934000002', '400 Street K, Hue'),
    ('c0005', 'Pham Van M', 'm.pham@yahoo.com', '0976500003', '500 Street M, Nha Trang'),
    ('c0006', 'Do Thi N', 'n.do@business.org', '0901200004', '600 Street N, Can Tho');

-- Insert dữ liệu vào bảng Product
INSERT INTO Product (Name, Description, Price, Quantity)
VALUES 
    ('Basic Pi Kit', 'Includes essential tools and materials for beginners', 5000, 100),
    ('Advanced Pi Kit', 'Enhanced kit with additional features', 15000, 50),
    ('Professional Pi Kit', 'Comprehensive set for professional use', 30000, 30),
    ('Pi Ultra', 'Advanced model with high performance', 45000, 20),
    ('Master Pi Kit', 'Complete set with all available accessories', 80000, 10);

-- Insert dữ liệu vào bảng Order
INSERT INTO [Order] (ClientID, EmployeeID, OrderDate, TotalPrice)
VALUES 
    ('c0001', 'e0001', '2023-07-01', 25000),  -- (2 x 5000 + 1 x 15000)
    ('c0002', 'e0002', '2023-07-15', 15000),  -- (1 x 15000)
    ('c0003', 'e0003', '2023-08-05', 45000),  -- (1 x 30000 + 3 x 5000)
    ('c0004', 'e0004', '2023-08-20', 55000),  -- (1 x 45000 + 2 x 5000)
    ('c0005', 'e0005', '2023-09-02', 110000), -- (1 x 80000 + 1 x 30000)
    ('c0006', 'e0006', '2023-09-18', 50000),  -- (1 x 5000 + 3 x 15000)
    ('c0001', 'e0003', '2023-10-01', 105000), -- (2 x 30000 + 1 x 45000)
    ('c0004', 'e0002', '2023-10-15', 75000);  -- (2 x 15000 + 1 x 45000)

-- Insert dữ liệu vào bảng OrderItem
INSERT INTO OrderItem (OrderID, ProductID, Quantity)
VALUES 
    (1, 1, 2),  -- Basic Pi Kit x2
    (1, 2, 1),  -- Advanced Pi Kit x1
    (2, 2, 1),  -- Advanced Pi Kit x1
    (3, 3, 1),  -- Professional Pi Kit x1
    (3, 1, 3),  -- Basic Pi Kit x3
    (4, 4, 1),  -- Pi Ultra x1
    (4, 1, 2),  -- Basic Pi Kit x2
    (5, 5, 1),  -- Master Pi Kit x1
    (5, 3, 1),  -- Professional Pi Kit x1
    (6, 1, 1),  -- Basic Pi Kit x1
    (6, 2, 3),  -- Advanced Pi Kit x3
    (7, 3, 2),  -- Professional Pi Kit x2
    (7, 4, 1),  -- Pi Ultra x1
    (8, 2, 2),  -- Advanced Pi Kit x2
    (8, 4, 1);  -- Pi Ultra x1

-- Insert dữ liệu vào bảng Bill
INSERT INTO Bill (OrderID, ClientID, EmployeeID, BillDate, TotalPrice)
VALUES 
    (1, 'c0001', 'e0001', '2023-07-01', 25000),
    (2, 'c0002', 'e0002', '2023-07-15', 15000),
    (3, 'c0003', 'e0003', '2023-08-05', 45000),
    (4, 'c0004', 'e0004', '2023-08-20', 55000),
    (5, 'c0005', 'e0005', '2023-09-02', 110000),
    (6, 'c0006', 'e0006', '2023-09-18', 50000),
    (7, 'c0001', 'e0003', '2023-10-01', 105000),
    (8, 'c0004', 'e0002', '2023-10-15', 75000);

-- Insert dữ liệu vào bảng User
INSERT INTO [User] (Username, Password, Role, EmployeeID, ClientID)
VALUES 
    ('admin', 'ad123', 'Admin', 'e0000', NULL),  -- Tài khoản Admin không liên kết với Employee hay Client
    ('employee1', 'emp1', 'Employee', 'e0001', NULL),  -- Employee 1 liên kết với Employee
    ('employee2', 'emp2', 'Employee', 'e0002', NULL),  -- Employee 2 liên kết với Employee
    ('employee3', 'emp3', 'Employee', 'e0003', NULL),  -- Employee 3 liên kết với Employee
    ('employee4', 'emp4', 'Employee', 'e0004', NULL),  -- Employee 4 liên kết với Employee
    ('employee5', 'emp5', 'Employee', 'e0005', NULL),  -- Employee 5 liên kết với Employee
    ('employee6', 'emp6', 'Employee', 'e0006', NULL),  -- Employee 6 liên kết với Employee
    ('client1', 'cli1', 'Client', NULL, 'c0001'),  -- Client 1 liên kết với Client
    ('client2', 'cli2', 'Client', NULL, 'c0002'),  -- Client 2 liên kết với Client
    ('client3', 'cli3', 'Client', NULL, 'c0003'),  -- Client 3 liên kết với Client
    ('client4', 'cli4', 'Client', NULL, 'c0004'),  -- Client 4 liên kết với Client
    ('client5', 'cli5', 'Client', NULL, 'c0005'),  -- Client 5 liên kết với Client
    ('client6', 'cli6', 'Client', NULL, 'c0006');  -- Client 6 liên kết với Client


SELECT p.Name AS ProductName, p.Price AS ProductPrice,oi.Quantity, (oi.Quantity * p.Price) AS TotalPrice
FROM OrderItem oi
JOIN Product p ON oi.ProductID = p.ID
WHERE oi.OrderID = 7