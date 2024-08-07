USE ShoesApplicationDatabase;

SELECT b.[Name] AS BrandName, s.Model AS ShoesCount 
FROM Shoes AS s
JOIN Brands AS b ON (b.Id = s.BrandId)
ORDER BY b.[Name],s.Model
