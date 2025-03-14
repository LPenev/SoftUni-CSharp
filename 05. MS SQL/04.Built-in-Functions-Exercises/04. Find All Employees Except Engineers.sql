USE SoftUni
GO

-- 04. Find All Employees Except Engineers
--
-- Create a SQL query that finds the first and last names of every employee, whose job title does not contain "engineer". 

SELECT FirstName, LastName
  FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%'