USE ShoesApplicationDatabase;

CREATE PROCEDURE usp_SearchByShoeSize @shoeSize DECIMAL(5,2)
AS
BEGIN
    SELECT s.Model AS ModelName, u.FullName AS UserFullName,
           CASE 
               WHEN s.Price < 100 THEN 'Low'
               WHEN s.Price BETWEEN 100 AND 200 THEN 'Medium'
               ELSE 'High'
           END AS PriceLevel,
           b.Name AS BrandName, sz.EU AS SizeEU
    FROM Orders AS o
    JOIN Shoes AS s ON O.ShoeId = s.Id
    JOIN Users AS u ON O.UserId = u.Id
    JOIN Brands AS b ON S.BrandId = b.Id
    JOIN Sizes AS sz ON O.SizeId = sz.Id
    WHERE sz.EU = @shoeSize
    ORDER BY b.Name, u.FullName
END

EXEC usp_SearchByShoeSize 40.00
