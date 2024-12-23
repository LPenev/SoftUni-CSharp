Use Diablo
GO

-- 16. Get Users with IP Address Like Pattern
--
-- Find all users with their IP addresses, sorted by username alphabetically.
-- Display only the rows which IP address matches the pattern: "***.1^.^.***". 
-- Legend: 
-- * - one symbol
-- ^ - one or more symbols

SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

