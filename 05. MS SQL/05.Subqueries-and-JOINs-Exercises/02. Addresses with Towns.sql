USE SoftUni
GO

--2. Addresses with Towns
--Write a query that selects:
--	FirstName
--	LastName
--	Town
--	AddressText
--Sort them by FirstName in ascending order, then by LastName. Select the first 50 employees.

SELECT TOP(50) e.FirstName, e.LastName,t.[Name] ,a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON (a.AddressID = e.AddressID)
JOIN Towns AS t ON (t.TownID = a.TownID)
ORDER BY e.FirstName ASC, e.LastName