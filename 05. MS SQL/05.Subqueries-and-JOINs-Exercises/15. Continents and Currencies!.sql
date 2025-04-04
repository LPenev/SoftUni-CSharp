USE Geography
GO

-- 15. Continents and Currencies
--Create a query that selects:
--	ContinentCode
--	CurrencyCode
--	CurrencyUsage
--Find all continents and their most used currency. Filter any currency, which is used in only one country. Sort your results by ContinentCode.

SELECT 
	r.ContinentCode, 
	r.CurrencyCode, 
	r.CurrencyUsage
FROM 
(
	SELECT 
      c.ContinentCode,
	  c.CurrencyCode,
	  COUNT(c.CurrencyCode) AS CurrencyUsage,
	  DENSE_RANK() OVER
	  (
		PARTITION BY c.ContinentCode
		ORDER BY COUNT(c.CurrencyCode) DESC
	  ) AS CurrencyRank
	  FROM Countries AS c
	  GROUP BY c.ContinentCode,c.CurrencyCode
	  HAVING COUNT(c.CurrencyCode) > 1
) AS r
WHERE r.CurrencyRank = 1
ORDER BY r.ContinentCode