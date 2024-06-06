USE SoftUni
GO
-- Create a SQL query that finds the last 7 hired employees, select their first, last name and hire date.
-- Order the result by hire date descending.
SELECT TOP(7) FirstName, LastName, HireDate 
  FROM Employees
 ORDER BY HireDate DESC 
