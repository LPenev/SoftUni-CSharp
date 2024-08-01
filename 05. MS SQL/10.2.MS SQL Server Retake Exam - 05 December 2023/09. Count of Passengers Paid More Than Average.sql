SELECT Tw.Name, COUNT(Ti.Id)
FROM Tickets AS Ti
JOIN Trains AS Tr ON Tr.Id = Ti.TrainId
JOIN Towns AS Tw ON Tw.Id = Tr.ArrivalTownId
WHERE Ti.Price > 76.99
GROUP BY Tw.Name
ORDER BY Tw.Name