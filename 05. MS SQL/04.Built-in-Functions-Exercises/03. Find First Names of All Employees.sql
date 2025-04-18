USE SoftUni
GO

-- 03. Find First Names of All Employees
--
-- Create a SQL query that finds the first names of all employees whose department ID is 3 or 10,
-- and the hire year is between 1995 and 2005 inclusive.

SELECT FirstName
  FROM Employees
 WHERE DepartmentID = 3 OR DepartmentID = 10 
		AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005
