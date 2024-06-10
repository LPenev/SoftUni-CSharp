-- Select all tourists who haven't booked a hotel yet
SELECT 
    T.Id, 
    T.Name, 
    T.PhoneNumber
FROM 
    Tourists T
LEFT JOIN 
    Bookings B ON T.Id = B.TouristId
WHERE 
    B.Id IS NULL
ORDER BY 
    T.Name ASC;
GO