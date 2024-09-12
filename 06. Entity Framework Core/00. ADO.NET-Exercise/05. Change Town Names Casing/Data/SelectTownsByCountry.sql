SELECT UPPER(t.Name) 
FROM Countries AS c
JOIN Towns AS t ON t.CountryCode = c.Id
WHERE c.[Name] = @country