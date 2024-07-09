USE Geography
GO

-- 12. Highest Peaks in Bulgaria
-- Create a query that selects:
--	 CountryCode
--	 MountainRange
--	 PeakName
--	 Elevation
-- Filter all the peaks in Bulgaria, which have elevation over 2835. Return all the rows, sorted by elevation in descending order.

SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM MountainsCountries AS mc
JOIN Mountains AS m ON (m.Id = mc.MountainId)
JOIN Peaks AS p ON (p.MountainId = m.Id)
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC
