USE SoftUni
GO

-- 05. Employees Without Projects
--Create a query that selects:
--	EmployeeID
--	FirstName
--Filter only employees without a project. Return the first 3 rows, sorted by EmployeeID in ascending order.

SELECT TOP(3)
	e.EmployeeID,
	e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON (e.EmployeeID = ep.EmployeeID)
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID
