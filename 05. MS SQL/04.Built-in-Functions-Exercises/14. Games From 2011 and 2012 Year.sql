USE Diablo
GO

-- 14. Games from 2011 and 2012 Year
--
-- Find and display the top 50 games which start date is from 2011 and 2012 year.
-- Order them by start date, then by name of the game.
-- The start date should be in the following format: "yyyy-MM-dd". 

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM [Games]
WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]