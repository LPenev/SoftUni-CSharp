USE Boardgames 
GO 

SELECT 
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	c.Email,
	MAX(b.Rating) AS Rating 
FROM CreatorsBoardgames AS cb
JOIN Creators AS c
ON cb.CreatorId=c.Id
JOIN Boardgames AS b
ON cb.BoardgameId=b.Id
WHERE Email NOT LIKE '%.net%'
GROUP BY CONCAT(c.FirstName, ' ', c.LastName), Email
ORDER BY CONCAT(c.FirstName, ' ', c.LastName)
