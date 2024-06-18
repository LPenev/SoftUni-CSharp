CREATE FUNCTION udf_AuthorsWithBooks (@name NVARCHAR(100))
RETURNS INT
AS
BEGIN
    DECLARE @totalBooks INT;

    SELECT @totalBooks = COUNT(*)
    FROM Books b
    JOIN Authors a ON b.AuthorId = a.Id
    JOIN LibrariesBooks lb ON b.Id = lb.BookId
    WHERE a.Name = @name;

    RETURN @totalBooks;
END;