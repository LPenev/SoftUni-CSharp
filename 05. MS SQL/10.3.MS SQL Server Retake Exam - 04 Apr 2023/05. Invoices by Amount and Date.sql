USE Accounting
GO

-- 5. Invoices by Amount and Date

SELECT Number, Currency
FROM Invoices
ORDER BY Amount DESC, DueDate ASC

