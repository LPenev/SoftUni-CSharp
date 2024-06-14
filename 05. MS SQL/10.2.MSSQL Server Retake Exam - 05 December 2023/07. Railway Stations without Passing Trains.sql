SELECT t.[Name] AS Town,
	   rs.[Name] AS 'Railway Station'
FROM 
    RailwayStations rs
    LEFT JOIN TrainsRailwayStations trs ON rs.Id = trs.RailwayStationId
    INNER JOIN Towns t ON rs.TownId = t.Id
WHERE 
    trs.TrainId IS NULL
ORDER BY 
    t.[Name] ASC, rs.[Name] ASC;