USE SoftUni
GO

-- 08. Employee 24
--Create a query that selects:
--	EmployeeID
--	FirstName
--	ProjectName
--Filter all the projects of employee with Id 24. If the project has started during or after 2005 the returned value should be NULL.

SELECT 
	e.EmployeeID, 
	e.FirstName,
	CASE WHEN YEAR(p.StartDate) >= 2005
	THEN NULL
	ELSE p.[Name]
	END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON (ep.EmployeeID = e.EmployeeID)
JOIN Projects AS p ON (p.ProjectID = ep.ProjectID)
WHERE e.EmployeeID = 24