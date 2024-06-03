USE Gringotts
GO

-- 09. Age Groups
--Write down a query that creates 7 different groups based on their age.
--Age groups should be as follows:
--	[0-10]
--	[11-20]
--	[21-30]
--	[31-40]
--	[41-50]
--	[51-60]
--	[61+]
--The query should return
--	Age groups
--	Count of wizards in it

SELECT AgeGroup, COUNT(AgeGroup) AS WizardCount
FROM (
	SELECT
		CASE
			WHEN AGE <= 10 THEN '[1-10]'
			WHEN AGE <= 20 THEN '[11-20]'
			WHEN AGE <= 30 THEN '[21-30]'
			WHEN AGE <= 40 THEN '[31-40]'
			WHEN AGE <= 50 THEN '[41-50]'
			WHEN AGE <= 60 THEN '[51-60]'
			ELSE '[61+]'
			END AS AgeGroup
			FROM WizzardDeposits
) AS a
GROUP BY AgeGroup
