USE SoftUni
GO

-- 11.	Find All Employees with Rank 2
--
-- Upgrade the query from the previous problem, so that it finds only the employees with a Rank 2.
-- Order the result by Salary (descending).

WITH CTE_RankedEmployees AS
(
	SELECT EmployeeID, FirstName, LastName, Salary,
		   DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID ) AS [Rank] 
	  FROM Employees
	 WHERE Salary BETWEEN 10000 AND 50000
 )

 SELECT *
   FROM CTE_RankedEmployees
  WHERE [Rank] = 2
  ORDER BY Salary DESC

-- Nested query
SELECT * FROM
(
	SELECT EmployeeID, FirstName, LastName, Salary,
		   DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID ) AS [Rank] 
	  FROM Employees
	 WHERE Salary BETWEEN 10000 AND 50000
 ) AS Result
WHERE [Rank] = 2
ORDER BY Salary DESC