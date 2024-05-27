USE SoftUni
GO
--1. Employee Address
--Create a query that selects:
--	EmployeeId
--	JobTitle
--	AddressId
--	AddressText
--Return the first 5 rows sorted by AddressId in ascending order.

SELECT TOP(5) e.EmployeeID, e.JobTitle,a.AddressID, a.AddressText 
FROM Employees AS e
JOIN Addresses AS a ON (a.AddressID = e.AddressID)
ORDER BY e.AddressID ASC