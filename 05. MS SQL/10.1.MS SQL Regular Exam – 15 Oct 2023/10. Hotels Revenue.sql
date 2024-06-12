-- Calculate the total revenue for each hotel
SELECT 
    H.Name AS HotelName,
    SUM(R.Price * DATEDIFF(DAY, B.ArrivalDate, B.DepartureDate)) AS TotalRevenue
FROM 
    Bookings B
JOIN 
    Hotels H ON B.HotelId = H.Id
JOIN 
    Rooms R ON B.RoomId = R.Id
GROUP BY 
    H.Name
ORDER BY 
    TotalRevenue DESC;