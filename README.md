# Restaurant Marketplace Management System

A desktop-based enterprise management application built with **C# Windows Forms** and **Microsoft SQL Server (MSSQL)** for the completion of **CSC2210: Object Oriented Programming 2** at **American International University-Bangladesh (AIUB)**.

---

## Academic Project Details
* **Course:** CSC2210 - Object Oriented Programming 2
* **Section:** R
* **Semester:** Summer 2025-2026
* **Project Domain:** Resurant Management

---

## Group Members & Contribution Breakdown

| Name | Student ID | Core Modules & Responsibilities | Contribution % |
| :--- | :--- | :--- | :--- |
| *Shefa Bintay Kashem* | 24-58681-2 | UI/UX Wireframing, Project Report Documentation, System Validation | 33.3% |
| *Dibosh Modak Shuvo* | 24-57868-2 | Employee Dashboard, Bonus Logic Integration, Unit Testing,schema diagram  | 33.3% |
| *Mashrafi Shahariar Smitoa* | 24-58452-2 | Database Architecture, ADO.NET DAL, Customer Catalog, Dynamic Filters & Cart Checkout Engine | 33.4% |

---

## Core System Architecture & Features

### 1. Role-Based Authentication & Portal Isolation
* **Owner Portal:** Food menu catalog management (CRUD), staff overview, and real-time inventory monitoring.
* **Employee Portal:** Profile overview, salary verification, and automatic qualification for experience-based bonuses.
* **Customer Portal:** Food catalog browsing, interactive cart, checkout engine, and invoice summaries.
* **Self-Registration:** New users can sign up on demand as Customers or Staff, with automatic database identity generation.

### 2. Food Catalog CRUD & Inventory Control
* Full Create, Read, Update, and Delete operations on menu items handled via parameterized ADO.NET queries.
* **Low-Stock Warning:** Interactive visual highlight (soft red alert) on items with <= 5 units remaining in stock.

### 3. Dynamic Search & Multi-Criteria Filtering
* **Live Search:** Real-time text search across food item titles.
* **Filter 1 (Category):** Fast Food, Italian, Beverage, and Main Course.
* **Filter 2 (Price Range):** Low (< 200 TK), Mid (200–500 TK), and High (> 500 TK).
* **Filter 3 (Stock Availability):** Toggle checkbox to filter out-of-stock items immediately.

### 4. Business Logic Automation
* **Customer Discount Rule:** A 10% instant discount is calculated automatically whenever a customer's gross order exceeds 1,500 TK.
* **Employee Bonus Rule:** Employees with more than 3 years of logged industry experience automatically receive a 1,000 TK bonus on their payroll slip.

### 5. ACID Transactional Order Checkout
* Atomic multi-table updates utilizing `SqlTransaction` across `[Order]`, `[Bill]`, and `[Food]` tables to ensure strict data consistency and immediate inventory deduction.

---

## Project Structure

```text
RestaurantManagementSystem/
│
├── README.md
├── RestaurantManagementSystem.slnx
│
└── RestaurantManagementSystem/
    ├── Program.cs
    ├── DataAccess/
    │   └── DbConnection.cs             # Centralized ADO.NET Connection & Query Helper
    ├── Views/
    │   ├── LoginForm.cs                # Multi-role secure login portal
    │   ├── RegisterForm.cs             # Self-service account creation
    │   ├── MainShellForm.cs            # Dynamic role-based navigation container
    │   ├── OwnerMenuControl.cs         # Food menu CRUD & low-stock monitor
    │   ├── OwnerEmployeesControl.cs    # Staff directory & payroll view
    │   ├── CustomerOrderControl.cs     # Search, 3 filters, cart & checkout engine
    │   └── EmployeeDashboardControl.cs # Staff compensation & bonus viewer
    └── database/
        └── schema.sql                  # Complete MSSQL table schema, constraints & seed data

