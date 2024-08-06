USE Accounting
GO

-- 9. Clients with VAT

SELECT c.[Name], MAX(p.Price) AS Price ,c.NumberVAT
FROM Clients AS C
JOIN ProductsClients AS pc ON (pc.ClientId = c.Id)
JOIN Products AS p ON (p.Id = pc.ProductId)
WHERE c.[Name] NOT LIKE '%KG'
GROUP BY c.[Name],c.NumberVAT
ORDER BY Price DESC
