USE Geography
GO
-- 09
-- Display all peaks for "Rila" mountain. Include:
--	- MountainRange
--	- PeakName
--	- Elevation
-- Peaks should be sorted by elevation descending.

SELECT MountainRange, PeakName, Elevation FROM Peaks
JOIN Mountains ON Peaks.MountainId = Mountains.Id
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC

