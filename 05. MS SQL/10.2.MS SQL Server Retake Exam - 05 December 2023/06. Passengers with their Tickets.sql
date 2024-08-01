SELECT 
    P.Name AS PassengerName,
    T.Price AS TicketPrice,
    T.DateOfDeparture,
    T.TrainId
FROM 
    Tickets T
JOIN 
    Passengers P ON T.PassengerId = P.Id
ORDER BY 
    T.Price DESC, 
    P.Name ASC;