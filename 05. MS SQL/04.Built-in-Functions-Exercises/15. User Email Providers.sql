Use Diablo
GO

-- 15. User Email Providers
--
-- Find all users with information about their email providers. Display the username and email provider. 
-- Sort the results by email provider alphabetically, then by username. 

SELECT Username, SUBSTRING(Email,CHARINDEX('@',Email) + 1, LEN(Email)) AS EmailProvider
FROM Users
ORDER BY EmailProvider, Username
