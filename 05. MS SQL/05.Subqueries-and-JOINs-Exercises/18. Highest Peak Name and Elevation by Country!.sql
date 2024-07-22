USE Geography
GO

-- 18. Highest Peak Name and Elevation by Country
-- For each country, find the name and elevation of the highest peak, along with its mountain.
-- When no peaks are available in some countries, display elevation 0,
-- "(no highest peak)" as peak name and "(no mountain)" as a mountain name.
-- When multiple peaks in some countries have the same elevation, display all of them.
-- Sort the results by country name alphabetically, then by highest peak name alphabetically. Limit only the first 5 rows.

SELECT TOP(5)
	[Country],
	CASE
		WHEN PeakName IS NULL THEN '(no highest peak)'
		ELSE PeakName
	    END AS [Highest Peak Name],
	CASE
		WHEN Elevation IS NULL THEN 0
		ELSE Elevation
	    END AS [Highest Peak Elevation],
	CASE
		WHEN MountainRange IS NULL THEN '(no mountain)'
		ELSE MountainRange
	    END AS [Mountain]

FROM
(
	SELECT 
		c.CountryName AS Country,
		m.MountainRange,
		p.PeakName,
		p.Elevation,
		DENSE_RANK() OVER
		(
			PARTITION BY c.CountryName
			ORDER BY p.Elevation DESC
		) AS PeakRank
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains AS m
		ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p
		ON p.MountainId = m.Id
) AS PeakRankingTable
WHERE PeakRank = 1
ORDER BY Country, [Highest Peak Name] 


WITH PeaksRankedByElevation AS 
(
	SELECT
		c.CountryName,
		p.PeakName,
		p.Elevation,
		m.MountainRange,
		DENSE_RANK() OVER
			(PARTITION BY c.CountryName ORDER BY Elevation DESC) AS PeakRank
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId
)

SELECT TOP(5)
	CountryName AS Country,
	ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name],
	ISNULL(Elevation, 0) AS [Highest Peak Elevation],
	ISNULL(MountainRange, '(no mountain)') AS Mountain
FROM PeaksRankedByElevation
WHERE PeakRank = 1
ORDER BY 
	CountryName, [Highest Peak Name]