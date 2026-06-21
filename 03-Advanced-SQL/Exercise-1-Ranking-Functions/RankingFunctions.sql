CREATE DATABASE CognizantDB;
GO

USE CognizantDB;
GO
CREATE TABLE Employees
(
    EmployeeID INT PRIMARY KEY,
    EmployeeName VARCHAR(50),
    Department VARCHAR(50),
    Salary INT
);
INSERT INTO Employees VALUES
(101, 'Deepika', 'IT', 60000),
(102, 'Rahul', 'IT', 75000),
(103, 'Anjali', 'HR', 50000),
(104, 'Kiran', 'HR', 55000),
(105, 'Suresh', 'Sales', 70000),
(106, 'Priya', 'Sales', 65000);
SELECT
    EmployeeName,
    Department,
    Salary,
    ROW_NUMBER() OVER (ORDER BY Salary DESC) AS Row_Num
FROM Employees;

SELECT
    EmployeeName,
    Department,
    Salary,
    RANK() OVER (ORDER BY Salary DESC) AS Rank_Num
FROM Employees;


SELECT
    EmployeeName,
    Department,
    Salary,
    DENSE_RANK() OVER (ORDER BY Salary DESC) AS Dense_Rank
FROM Employees;

