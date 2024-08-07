USE ShoesApplicationDatabase;

CREATE FUNCTION udf_OrdersByEmail (@Email NVARCHAR(100))
RETURNS INT
AS
BEGIN
    DECLARE @OrderCount INT;
    SELECT @OrderCount = COUNT(*)
    FROM Orders AS o
    JOIN Users u ON o.UserId = u.Id
    WHERE u.Email = @Email
    RETURN @OrderCount
END

SELECT dbo.udf_OrdersByEmail('sstewart@example.com')

