USE Gringotts
GO

-- 12. Rich Wizard, Poor Wizard_!
-- Mr. Bodrog definitely likes his werewolves more than you. This is your last chance to survive!
-- Give him some data to play his favorite game Rich Wizard, Poor Wizard. The rules are simple: 
-- You compare the deposits of every wizard with the wizard after him.
-- If a wizard is the last one in the database, simply ignore it.
-- In the end you have to sum the difference between the deposits.

SELECT
	SUM(w1.DepositAmount - w2.DepositAmount) AS SumDifference
FROM WizzardDeposits AS w1
LEFT JOIN WizzardDeposits AS w2
	ON w1.Id = w2.Id - 1



