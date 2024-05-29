USE SoftUni
GO

-- 11. Min Average Salary
-- Create a query that returns the value of the lowest average salary of all departments.
-- Example
-- MinAverageSalary
-- 10866.6666

SELECT TOP(1) 
	AVG(Salary) AS MinAverageSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY MinAverageSalary
