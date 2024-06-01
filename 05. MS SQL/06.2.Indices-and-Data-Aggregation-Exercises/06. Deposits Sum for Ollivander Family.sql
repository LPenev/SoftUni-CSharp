USE Gringotts
GO

-- 06. Deposits Sum for Ollivander Family
-- Select all deposit groups and their total deposit sums, but only for the wizards,
-- who have their magic wands crafted by the Ollivander family.

SELECT DepositGroup, SUM(DepositAmount)
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
