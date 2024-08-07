USE ShoesApplicationDatabase;

UPDATE Shoes SET Shoes.Price = s.Price * 1.15
FROM Shoes AS s
JOIN Brands as b ON (b.Id = s.BrandId)
WHERE b.[Name] = 'Nike'