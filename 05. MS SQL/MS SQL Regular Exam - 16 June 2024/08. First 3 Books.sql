SELECT TOP 3
    B.Title AS Title,
    B.YearPublished AS Year,
    G.Name AS Genre
FROM
    Books B
JOIN
    Genres G ON B.GenreId = G.Id
WHERE
    (B.YearPublished > 2000 AND B.Title LIKE '%a%')
    OR
    (B.YearPublished < 1950 AND G.Name LIKE '%Fantasy%')
ORDER BY
    B.Title ASC,
    B.YearPublished DESC;
GO