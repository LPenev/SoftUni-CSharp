USE Geography
GO

-- 13. Mix of Peak and River Names
--
-- Combine all peak names with all river names,
-- so that the last letter of each peak name is the same as the first letter of its corresponding river name.
-- Display the peak names, river names and the obtained mix (mix should be in lowercase). Sort the results by the obtained mix.

SELECT PeakName, RiverName, 
	LOWER(CONCAT(LEFT(PeakName,LEN(PeakName)-1),RiverName)) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix



