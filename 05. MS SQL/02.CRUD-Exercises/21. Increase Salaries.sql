USE SoftUni
GO
-- Create a SQL query that increases salaries by 12% for all employees that work in one of the following departments
-- Engineering, Tool Design, Marketing or Information Services.
-- As a result, select and display only the "Salaries" column from the Employees table.
-- After this, you should restore the database to the original data.

BEGIN TRANSACTION
GO
UPDATE Employees 
   SET Salary = Salary * 1.12
 WHERE DepartmentID = 1 OR DepartmentID = 2 OR DepartmentID = 4 OR DepartmentID = 11
 GO
SELECT Salary 
  FROM Employees
 WHERE DepartmentID = '1' OR DepartmentID = '2' OR DepartmentID = '4' OR DepartmentID = '11'
GO
ROLLBACK TRANSACTION
