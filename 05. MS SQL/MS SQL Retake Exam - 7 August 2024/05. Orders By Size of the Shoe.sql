USE ShoesApplicationDatabase;

SELECT s.Model, s.Price 
FROM Orders AS o
JOIN Shoes AS s ON (s.Id = o.ShoeId)
ORDER BY s.Price DESC, s.Model
