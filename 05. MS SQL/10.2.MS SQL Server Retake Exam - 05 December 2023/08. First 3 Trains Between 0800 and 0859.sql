SELECT TOP(3) 
    t.Id AS TrainId,
    t.HourOfDeparture,
    ti.Price AS TicketPrice,
    dT.Name AS Destination
FROM Trains t
JOIN Tickets ti ON t.Id = ti.TrainId
JOIN Towns dT ON t.ArrivalTownId = dT.Id
WHERE t.HourOfDeparture LIKE '08:%'
AND ti.Price > 50.00
ORDER BY ti.Price ASC;