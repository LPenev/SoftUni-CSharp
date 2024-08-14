USE Boardgames
GO

CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @totalBoardgamesCreator INT = 
	(
		SELECT
			COUNT(cb.BoardgameId)
		FROM Creators AS c
		INNER JOIN CreatorsBoardgames as cb
		ON c.Id = cb.CreatorId
		WHERE c.FirstName = @name
	)
	RETURN @totalBoardgamesCreator
END
