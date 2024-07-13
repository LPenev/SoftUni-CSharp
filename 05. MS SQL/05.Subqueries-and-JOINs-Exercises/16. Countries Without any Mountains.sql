USE Geography
GO

-- 16. Countries Without any Mountains
-- Create a query that returns the count of all countries, which don’t have a mountain.

SELECT COUNT(*) FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.CountryCode IS NULL
