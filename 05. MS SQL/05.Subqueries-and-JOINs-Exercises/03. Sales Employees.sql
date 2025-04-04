USE SoftUni
GO

-- 03. Sales Employees
--Create a query that selects:
--	EmployeeID
--	FirstName
--	LastName
--	DepartmentName
--Sort them by EmployeeID in ascending order. Select only employees from the "Sales" department.

SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS 'DepartmentName'
FROM Employees AS e
JOIN Departments AS d ON (d.DepartmentID = e.DepartmentID)
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID ASC