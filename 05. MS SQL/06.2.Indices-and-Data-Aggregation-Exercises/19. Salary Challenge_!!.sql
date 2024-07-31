USE SoftUni
GO

-- 19. Salary Challenge_**
--Create a query that returns:
--	FirstName
--	LastName
--	DepartmentID
--Select all employees who have salary higher than the average salary of their respective departments. 
--Select only the first 10 rows. Order them by DepartmentID.

SELECT TOP 10
	e.FirstName,
	e.LastName,
	e.DepartmentID
FROM Employees AS e
JOIN
(
	SELECT
		e.DepartmentID,
		AVG(e.Salary) AS AverageSalary
	FROM Employees AS e
	GROUP BY e.DepartmentID
) AS AvgTable
ON e.DepartmentID = AvgTable.DepartmentID
WHERE e.Salary > AvgTable.AverageSalary