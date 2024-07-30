USE SoftUni
GO

-- 18. 3rd Highest Salary*
-- Find the third highest salary in each department if there is such. 

SELECT
 	DepartmentID,
	MAX(Salary) AS ThirdHighestSalary
FROM
(
	SELECT 
		DepartmentID,
		Salary,
		DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
	FROM [Employees]
) AS t
WHERE [Rank] = 3
GROUP BY DepartmentID