USE Gringotts
GO
-- 05. Deposits Sum
-- Select all deposit groups and their total deposit sums.

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup