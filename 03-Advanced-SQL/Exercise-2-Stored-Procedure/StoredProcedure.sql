USE CognizantDB;
GO

CREATE PROCEDURE GetEmployeesByDepartment
    @Dept VARCHAR(50)
AS
BEGIN
    SELECT *
    FROM Employees
    WHERE Department = @Dept;
END;
GO

EXEC GetEmployeesByDepartment @Dept = 'IT';
