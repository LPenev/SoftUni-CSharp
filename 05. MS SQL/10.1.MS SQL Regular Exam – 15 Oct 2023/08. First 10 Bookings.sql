-- Select the first 10 bookings arriving before 2023-12-31 in hotels with odd-numbered IDs
SELECT TOP 10 
    H.Name AS HotelName, 
    D.Name AS DestinationName, 
    C.Name AS CountryName
FROM 
    Bookings B
JOIN 
    Hotels H ON B.HotelId = H.Id
JOIN 
    Destinations D ON H.DestinationId = D.Id
JOIN 
    Countries C ON D.CountryId = C.Id
WHERE 
    B.ArrivalDate < '2023-12-31' 
    AND H.Id % 2 = 1
ORDER BY 
    C.Name ASC,
    B.ArrivalDate ASC; 
GO