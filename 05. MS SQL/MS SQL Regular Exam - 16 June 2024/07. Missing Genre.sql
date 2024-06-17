SELECT 
    l.Name AS LibraryName,
    c.Email
FROM Libraries l
JOIN Contacts c ON l.ContactId = c.Id
WHERE l.Id NOT IN (
    SELECT lb.LibraryId
    FROM LibrariesBooks lb
    JOIN Books b ON lb.BookId = b.Id
    WHERE b.GenreId = (SELECT Id FROM Genres WHERE Name = 'Mystery')
)
ORDER BY l.Name;