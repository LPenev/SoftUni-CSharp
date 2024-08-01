SELECT 
    Trains.Id AS TrainId,
    Towns.[Name] AS DepartureTown,
    MaintenanceRecords.Details AS Details
FROM 
    Trains
INNER JOIN 
    MaintenanceRecords ON Trains.Id = MaintenanceRecords.TrainId
INNER JOIN 
    Towns ON Trains.DepartureTownId = Towns.Id
WHERE 
    MaintenanceRecords.Details LIKE '%inspection%'
ORDER BY 
    Trains.Id