USE ShoesApplicationDatabase;

SELECT u.Username, u.Email, CAST(ROUND(AVG(s.Price), 2) AS DECIMAL(10,2)) AS AvgPrice
FROM Orders AS o
JOIN Users u ON o.UserId = u.Id
JOIN Shoes s ON o.ShoeId = s.Id
GROUP BY u.Username, u.Email
HAVING COUNT(o.Id) > 2
ORDER BY AvgPrice DESC
