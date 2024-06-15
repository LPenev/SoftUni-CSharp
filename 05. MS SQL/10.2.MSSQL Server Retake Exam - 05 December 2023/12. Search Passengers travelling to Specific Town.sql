CREATE PROCEDURE usp_SearchByTown(@townName NVARCHAR(30))
AS
BEGIN
    SELECT 
        Passengers.[Name],
        Tickets.DateOfDeparture,
        Trains.HourOfDeparture
    FROM 
        Tickets
    INNER JOIN 
        Trains ON Tickets.TrainId = Trains.Id
    INNER JOIN 
        Towns ON Trains.ArrivalTownId = Towns.Id
    INNER JOIN 
        Passengers ON Tickets.PassengerId = Passengers.Id
    WHERE 
        Towns.[Name] = @townName
    ORDER BY 
        Tickets.DateOfDeparture DESC,
        Passengers.[Name] ASC;
END;