-- Select all hotels with "VIP Apartment" available
SELECT 
    H.Id, 
    H.Name
FROM 
    Hotels H
JOIN 
    HotelsRooms HR ON H.Id = HR.HotelId
JOIN 
    Rooms R ON HR.RoomId = R.Id
WHERE 
    R.Type = 'VIP Apartment'
GROUP BY 
    H.Id, H.Name
ORDER BY 
    (SELECT COUNT(*) FROM Bookings B WHERE B.HotelId = H.Id) DESC;
GO