USE SoftUni
GO

-- 07. Find Towns Not Starting With
--
-- Create a SQL query that finds all towns, which do not start with 'R', 'B' or 'D'.
-- Order the result alphabetically by name. 

SELECT TownID, [Name]
  FROM Towns
 WHERE [Name] NOT LIKE '[RBD]%'
  ORDER BY [Name]

-- Var 2
  SELECT TownID, [Name]
  FROM Towns
 WHERE [Name] LIKE '[^RBD]%'
  ORDER BY [Name]