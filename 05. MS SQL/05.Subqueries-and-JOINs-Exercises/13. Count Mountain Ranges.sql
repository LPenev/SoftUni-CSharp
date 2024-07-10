USE Geography
GO

-- 13. Count Mountain Ranges
--Create a query that selects:
--	CountryCode
--	MountainRanges
--Filter the count of the mountain ranges in the United States, Russia and Bulgaria.

SELECT	mc.CountryCode,
		COUNT(m.MountainRange) AS 'MountainRanges' 
FROM MountainsCountries AS mc
JOIN Mountains AS m ON (m.Id = mc.MountainId)
WHERE mc.CountryCode IN ('US','RU','BG')
GROUP BY mc.CountryCode
ORDER BY mc.CountryCode

-- Version 2
SELECT CountryCode, Count(MountainId)
FROM MountainsCountries
WHERE CountryCode IN ('US','RU','BG')
GROUP BY CountryCode
ORDER BY CountryCode