USE Boardgames 
GO 

SELECT TOP(5)
	c.[Name],
	Rating,
	cat.[Name] AS CategoryName
FROM Boardgames AS c
LEFT JOIN Categories AS cat
ON c.CategoryId = cat.Id
LEFT JOIN PlayersRanges as r
ON c.PlayersRangeId = r.Id
WHERE Rating > 7
AND (c.[Name] LIKE '%a%'
OR Rating > 7.50)
AND PlayersMin >= 2
AND PlayersMax <= 5
ORDER BY [Name], CategoryName DESC