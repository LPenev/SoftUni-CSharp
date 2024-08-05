USE Accounting
GO

-- 7. Clients without Products

SELECT
	c.Id,
	c.[Name],
	CONCAT(a.StreetName, ' ', a.StreetNumber, ', ', a.City, ', ', a.PostCode, ', ', co.[Name]) AS [Address]
FROM Clients AS c
LEFT JOIN ProductsClients AS pc ON c.Id = pc.ClientId
JOIN Addresses AS a ON c.AddressId = a.Id
JOIN Countries AS co ON a.CountryId = co.Id
WHERE pc.ProductId IS NULL
ORDER BY c.[Name]

