UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
WHERE ArrivalDate BETWEEN '2023-12-01' AND '2023-12-31';
GO

UPDATE Tourists
SET Email = NULL
WHERE Name LIKE '%MA%';
GO