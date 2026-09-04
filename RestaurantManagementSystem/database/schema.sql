-- 1. Owner Table
CREATE TABLE [Owner] (
    owner_id INT IDENTITY(1001, 1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    password VARCHAR(100) NOT NULL,
    login_status BIT DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE()
);

-- 2. Employee Table
CREATE TABLE [Employee] (
    employee_id INT IDENTITY(2001, 1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    experience INT NOT NULL,
    salary DECIMAL(10, 2) NOT NULL,
    bonus DECIMAL(10, 2) DEFAULT 0.00,
    password VARCHAR(100) NOT NULL
);

-- 3. Customer Table
CREATE TABLE [Customer] (
    customer_id INT IDENTITY(3001, 1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    password VARCHAR(100) NOT NULL,
    total_bill DECIMAL(10, 2) DEFAULT 0.00,
    login_status BIT DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE()
);

-- 4. Food Table (CRUD + Stock)
CREATE TABLE [Food] (
    food_id INT IDENTITY(1, 1) PRIMARY KEY,
    owner_id INT NOT NULL,
    food_name VARCHAR(100) NOT NULL,
    category VARCHAR(50) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    stock_quantity INT NOT NULL DEFAULT 50,
    CONSTRAINT FK_Food_Owner FOREIGN KEY (owner_id) 
        REFERENCES [Owner](owner_id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- 5. Order Table
CREATE TABLE [Order] (
    order_id INT IDENTITY(5001, 1) PRIMARY KEY,
    customer_id INT NOT NULL,
    food_id INT NOT NULL,
    quantity INT NOT NULL,
    unit_price DECIMAL(10, 2) NOT NULL,
    subtotal DECIMAL(10, 2) NOT NULL,
    order_date DATETIME DEFAULT GETDATE(),
    status VARCHAR(50) DEFAULT 'Completed',
    CONSTRAINT FK_Order_Customer FOREIGN KEY (customer_id) 
        REFERENCES [Customer](customer_id) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_Order_Food FOREIGN KEY (food_id) 
        REFERENCES [Food](food_id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- 6. Bill Table
CREATE TABLE [Bill] (
    bill_id INT IDENTITY(7001, 1) PRIMARY KEY,
    order_id INT UNIQUE NOT NULL,
    total_amount DECIMAL(10, 2) NOT NULL,
    discount_amount DECIMAL(10, 2) DEFAULT 0.00,
    net_amount DECIMAL(10, 2) NOT NULL,
    bill_date DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Bill_Order FOREIGN KEY (order_id) 
        REFERENCES [Order](order_id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Seed Baseline Records
INSERT INTO [Owner] (name, phone_number, password) VALUES ('Restaurant Owner', '01700000000', 'owner123');
INSERT INTO [Employee] (name, phone_number, experience, salary, bonus, password) VALUES 
('Rahim Ahmed', '01811111111', 4, 26000.00, 1000.00, 'emp123'),
('Tanvir Hossain', '01822222222', 2, 18000.00, 0.00, 'emp123');
INSERT INTO [Customer] (name, phone_number, password) VALUES ('Mashrafi Customer', '01933333333', 'cust123');

INSERT INTO [Food] (owner_id, food_name, category, price, stock_quantity) VALUES 
(1001, 'Beef Burger', 'Fast Food', 350.00, 25),
(1001, 'Cheese Pizza', 'Fast Food', 800.00, 15),
(1001, 'White Sauce Pasta', 'Italian', 400.00, 8),
(1001, 'Lemon Mint Drinks', 'Beverage', 70.00, 45),
(1001, 'Grilled Platter', 'Main Course', 650.00, 4);