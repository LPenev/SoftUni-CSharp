-- Create a user-defined function to return the total number of tourists for a specific room type
CREATE FUNCTION dbo.udf_RoomsWithTourists (@name NVARCHAR(40))
RETURNS INT
AS
BEGIN
    DECLARE @TotalTourists INT;

    SELECT @TotalTourists = SUM(B.AdultsCount + B.ChildrenCount)
    FROM Bookings B
    JOIN Rooms R ON B.RoomId = R.Id
    WHERE R.Type = @name;

    RETURN @TotalTourists;
END;
GO

-- Query to get the total number of tourists for the 'Double Room' type
SELECT dbo.udf_RoomsWithTourists('Double Room') AS TotalTourists;

