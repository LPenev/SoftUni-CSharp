USE SoftUni
GO

-- 10. Employees Summary
--Create a query that selects:
--	EmployeeID
--	EmployeeName
--	ManagerName
--	DepartmentName
--Show the first 50 employees with their managers and the departments they are in (show the departments of the employees). Order them by EmployeeID.

SELECT TOP(50)
	e.EmployeeID,
	CONCAT_WS(' ', e.FirstName, e.LastName) AS 'EmployeeName',
	CONCAT_WS(' ', m.FirstName, m.LastName) AS 'ManagerName',
	d.[Name] AS 'DepartmentName'
FROM Employees AS e
JOIN Employees AS m ON (m.EmployeeID = e.ManagerID)
JOIN Departments AS d ON (d.DepartmentID = e.DepartmentID)
ORDER BY e.EmployeeID
