USE Diablo
GO

-- 17. Show All Games with Duration and Part of the Day

-- Find all games with part of the day and duration. Sort them by game name alphabetically,
-- then by duration (alphabetically, not by the timespan) and part of the day (all ascending).
-- Part of the Day should be Morning (time is >= 0 and < 12), Afternoon (time is >= 12 and < 18),
-- Evening (time is >= 18 and < 24). Duration should be Extra Short (smaller or equal to 3),
-- Short (between 4 and 6 including), Long (greater than 6) and Extra Long (without duration).

SELECT [Name], [Part of the Day] = 
	CASE
		WHEN DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	END,
		[Duration] =
	CASE
		WHEN [Duration] <= 3 THEN 'Extra Short'
		WHEN [Duration] <= 6 THEN 'Short'
		WHEN [Duration] > 6 THEN 'Long'
		ELSE 'Extra Long'
	END
FROM Games
ORDER BY [Name], [Duration], [Part of the Day]
