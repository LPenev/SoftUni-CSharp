USE SoftUni
GO

-- 09. Length of Last Name
--
-- Create a SQL query that finds all employees, whose last name is exactly 5 characters long.

SELECT FirstName, LastName
  FROM Employees
 WHERE LEN(LastName) = 5 