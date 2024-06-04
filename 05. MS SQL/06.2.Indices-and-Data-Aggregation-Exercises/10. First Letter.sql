USE Gringotts
GO

-- 10. First Letter
-- Create a query that returns all the unique wizard first letters of their first names
-- only if they have deposit of type Troll Chest. Order them alphabetically. Use GROUP BY for uniqueness.

SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits 
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter
