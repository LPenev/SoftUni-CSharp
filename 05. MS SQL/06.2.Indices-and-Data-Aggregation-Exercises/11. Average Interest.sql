USE Gringotts
GO

-- 11. Average Interest
-- Mr. Bodrog is highly interested in profitability. He wants to know the average interest of all deposit groups,
-- split by whether the deposit has expired or not. But that's not all.
-- He wants you to select deposits with start date after 01/01/1985.
-- Order the data descending by Deposit Group and ascending by Expiration Flag.
-- The output should consist of the following columns:
-- -DepositGroup	
-- -IsDepositExpired
-- -AverageInterest

SELECT
      DepositGroup
	 ,IsDepositExpired
	 ,AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired



