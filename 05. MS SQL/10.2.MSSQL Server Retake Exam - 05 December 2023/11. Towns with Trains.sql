CREATE FUNCTION udf_TownsWithTrains(@townName NVARCHAR(30))
RETURNS INT
AS
BEGIN
    DECLARE @trainCount INT;

    SELECT @trainCount = COUNT(DISTINCT Trains.Id)
    FROM Trains
    INNER JOIN Towns ON Trains.DepartureTownId = Towns.Id OR Trains.ArrivalTownId = Towns.Id
    WHERE Towns.[Name] = @townName;

    RETURN @trainCount;
END;