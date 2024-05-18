USE SoftUni
GO
-- Create a SQL query that finds the first 10 projects which were started,
-- select all the information about them and order the result by starting date, then by name.
SELECT TOP(10) *
  FROM Projects
  ORDER BY StartDate, [Name]