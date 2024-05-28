USE SoftUni
GO

-- 07. Employees With Project
--Create a query that selects:
--	EmployeeID
--	FirstName
--	ProjectName
--Filter only employees with a project which has started after 13.08.2002 and it is still ongoing (no end date). Return the first 5 rows sorted by EmployeeID in ascending order.

SELECT TOP(5)
	e.EmployeeID,
	e.FirstName,
	p.[Name] AS 'ProjectName'
FROM Employees AS e
JOIN EmployeesProjects AS ep ON (ep.EmployeeID = e.EmployeeID)
JOIN Projects as p ON (p.ProjectID = ep.ProjectID)
WHERE p.StartDate > '2002.08.13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

