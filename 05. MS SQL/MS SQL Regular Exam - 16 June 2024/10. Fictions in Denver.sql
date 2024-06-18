SELECT a.[Name] AS 'Author', b.Title, l.[Name] AS 'Library', c.PostAddress AS 'Library Address'
FROM Books b
JOIN Authors a ON b.AuthorId = a.Id
JOIN LibrariesBooks lb ON b.Id = lb.BookId
JOIN Libraries l ON lb.LibraryId = l.Id
JOIN Contacts c ON l.ContactId = c.Id
WHERE b.GenreId = (SELECT Id FROM Genres WHERE [Name] = 'Fiction')
AND c.PostAddress LIKE '%Denver%'
GROUP BY a.[Name], b.Title, l.[Name], c.PostAddress
ORDER BY b.Title;