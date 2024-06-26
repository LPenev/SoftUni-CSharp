USE Geography
GO
-- 24. Find all the countries with information about their currency.
-- Display the "CountryName", "CountryCode", and information about its "Currency": either "Euro" or "Not Euro".
-- Sort the results by country name alphabetically.

SELECT CountryName, CountryCode,
  CASE
		WHEN CurrencyCode = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
   END AS Currency
  FROM Countries
 WHERE CurrencyCode != ''
 ORDER BY CountryName
