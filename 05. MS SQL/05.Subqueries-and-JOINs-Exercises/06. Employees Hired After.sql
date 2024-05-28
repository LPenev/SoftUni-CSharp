USE SoftUni
GO

-- 06. Employees Hired After
--Create a query that selects:
--	FirstName
--	LastName
--	HireDate
--	DeptName
--Filter only employees hired after 1.1.1999 and are from either "Sales" or "Finance" department. Sort them by HireDate (ascending).

SELECT e.FirstName, e.LastName, e. HireDate, d.[Name] AS 'DeptName'
FROM Employees AS e
JOIN Departments AS d ON (d.DepartmentID = e.DepartmentID)
WHERE e.DepartmentID = 3 OR e.DepartmentID = 10 AND HireDate > '1999.1.1'
ORDER BY HireDate