USE CognizantDB;
GO

CREATE PROCEDURE GetEmployeeCountByDepartment
    @Dept VARCHAR(50),
    @EmpCount INT OUTPUT
AS
BEGIN
    SELECT @EmpCount = COUNT(*)
    FROM Employees
    WHERE Department = @Dept;
END;
GO

DECLARE @Count INT;

EXEC GetEmployeeCountByDepartment
    @Dept = 'IT',
    @EmpCount = @Count OUTPUT;

SELECT @Count AS EmployeeCount;
