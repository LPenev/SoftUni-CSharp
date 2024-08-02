USE Accounting
GO

-- 4. DELETE
DECLARE @clientId INT =
(
	SELECT Id FROM Clients
	WHERE NumberVAT LIKE 'IT%'
)

DELETE FROM ProductsClients
WHERE ClientId = @clientId

DELETE FROM Invoices
WHERE ClientId = @clientId

DELETE FROM Clients
WHERE Id = @clientId

