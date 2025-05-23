USE Gringotts
GO

-- 04. Smallest Deposit Group Per Magic Wand Size
-- Select the two deposit groups with the lowest average wand size.

SELECT TOP(2)
	DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)