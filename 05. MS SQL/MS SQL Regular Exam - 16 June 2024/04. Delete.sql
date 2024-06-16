DECLARE @AuthorId INT;
SET @AuthorId = (SELECT Id FROM Authors WHERE Name = 'Alex Michaelides');

DELETE lb
FROM LibrariesBooks lb
INNER JOIN Books b ON lb.BookId = b.Id
WHERE b.AuthorId = @AuthorId;

DELETE FROM Books
WHERE AuthorId = @AuthorId;

DELETE FROM Authors
WHERE Id = @AuthorId;