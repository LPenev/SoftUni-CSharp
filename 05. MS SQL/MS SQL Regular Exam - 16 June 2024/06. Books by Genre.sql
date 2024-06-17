SELECT 
    b.Id,
    b.Title AS [Book Title],
    b.ISBN,
    g.Name AS Genre
FROM Books b
JOIN Genres g ON b.GenreId = g.Id
WHERE g.Name IN ('Biography', 'Historical Fiction')
ORDER BY g.Name, b.Title;