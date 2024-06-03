USE Gringotts
GO

-- 08. Deposit Charge
--Create a query that selects:
--	Deposit group 
--	Magic wand creator
--	Minimum deposit charge for each group 
--Select the data in ascending order by MagicWandCreator and DepositGroup.

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge)
FROM WizzardDeposits AS MinDepositCharge
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup
