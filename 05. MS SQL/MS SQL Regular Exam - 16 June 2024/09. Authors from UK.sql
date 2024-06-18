SELECT 
    a.Name AS AuthorName,
    c.Email,
    c.PostAddress
FROM Authors a
JOIN Contacts c ON a.ContactId = c.Id
WHERE c.PostAddress LIKE '%UK%'
ORDER BY a.Name;