USE ShoesApplicationDatabase;

SELECT u.FullName, u.PhoneNumber, s.Price AS OrderPrice, s.Id AS ShoeId, s.BrandId,
       CONCAT_WS('/',CONCAT(sz.EU,'EU'),CONCAT(sz.US,'US'),CONCAT(sz.UK,'UK')) AS ShoeSize
FROM Orders AS o
JOIN Users AS u ON O.UserId = u.Id
JOIN Shoes AS s ON O.ShoeId = s.Id
JOIN Sizes AS sz ON O.SizeId = sz.Id
WHERE u.PhoneNumber LIKE '%345%'
ORDER BY s.Model ASC;
