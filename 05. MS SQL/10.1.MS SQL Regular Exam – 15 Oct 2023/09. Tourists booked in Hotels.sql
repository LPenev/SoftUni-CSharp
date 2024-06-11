-- Select tourists who do not have names ending in "EZ" and their booked hotel names and room prices
SELECT 
    H.Name AS HotelName, 
    R.Price AS RoomPrice
FROM 
    Bookings B
JOIN 
    Hotels H ON B.HotelId = H.Id
JOIN 
    Rooms R ON B.RoomId = R.Id
JOIN 
    Tourists T ON B.TouristId = T.Id
WHERE 
    T.Name NOT LIKE '%EZ'
ORDER BY 
    R.Price DESC;