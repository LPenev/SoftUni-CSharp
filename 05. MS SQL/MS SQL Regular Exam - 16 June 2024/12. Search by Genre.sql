CREATE PROCEDURE usp_SearchByGenre @genreName NVARCHAR(30)
AS
BEGIN
    SELECT 
        b.Title,
        b.YearPublished,
        b.ISBN,
        a.Name AS AuthorName,
        g.Name AS GenreName
    FROM Books b
    JOIN Authors a ON b.AuthorId = a.Id
    JOIN Genres g ON b.GenreId = g.Id
    WHERE g.Name = @genreName
    ORDER BY b.Title;
END;