USE Gringotts
GO

-- 07. Deposits Filter
-- Select all deposit groups and their total deposit sums, but only for the wizards,
-- who have their magic wands crafted by the Ollivander family. Filter total deposit amounts lower than 150000.
-- Order by total deposit amount in descending order.

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC