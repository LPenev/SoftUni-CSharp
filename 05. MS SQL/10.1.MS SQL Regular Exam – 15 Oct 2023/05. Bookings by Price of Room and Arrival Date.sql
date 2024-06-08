-- Select all bookings ordered by room price (descending) and arrival date (ascending)
SELECT 
    CONVERT(VARCHAR(10), B.ArrivalDate, 120) AS ArrivalDate, 
    B.AdultsCount, 
    B.ChildrenCount
FROM 
    Bookings B
JOIN 
    Rooms R ON B.RoomId = R.Id
ORDER BY 
    R.Price DESC, 
    B.ArrivalDate ASC;
GO