USE ShoesApplicationDatabase;

SELECT s.Model, COUNT(ss.SizeId) AS CountOfSizes, b.Name AS BrandName
FROM Shoes AS s
JOIN ShoesSizes AS ss ON s.Id = ss.ShoeId
JOIN Brands AS b ON s.BrandId = b.Id
WHERE s.Model LIKE '%Run%' AND b.Name = 'Nike'
GROUP BY s.Model, b.Name
HAVING COUNT(ss.SizeId) > 5
ORDER BY s.Model DESC;
