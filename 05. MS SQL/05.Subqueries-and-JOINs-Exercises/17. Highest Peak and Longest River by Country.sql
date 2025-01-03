USE Geography
GO

-- 17. Highest Peak and Longest River by Country
-- For each country, find the elevation of the highest peak and the length of the longest river,
-- sorted by the highest peak elevation (from highest to lowest),
-- then by the longest river length (from longest to smallest),
-- then by country name (alphabetically).
-- Display NULL when no data is available in some of the columns. Limit only the first 5 rows.

SELECT TOP(5) 
      c.CountryName
     ,CASE WHEN p.Elevation = NULL
	  THEN NULL
	  ELSE MAX(p.Elevation)
	  END AS HighestPeakElevation

	  ,CASE WHEN r.[Length] = NULL
	  THEN NULL
	  ELSE MAX(r.[Length])
	  END AS LongestRiverLength
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Peaks AS p ON mc.MountainId = p.MountainId
JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName