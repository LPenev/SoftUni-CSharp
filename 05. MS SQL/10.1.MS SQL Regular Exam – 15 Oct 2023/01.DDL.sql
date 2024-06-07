CREATE DATABASE TouristAgency;
GO

USE TouristAgency;
GO

-- Create the Countries table
CREATE TABLE Countries (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL
);
GO

-- Create the Destinations table
CREATE TABLE Destinations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    CountryId INT NOT NULL,
    FOREIGN KEY (CountryId) REFERENCES Countries(Id)
);
GO

-- Create the Rooms table
CREATE TABLE Rooms (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Type NVARCHAR(40) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    BedCount INT NOT NULL CHECK (BedCount > 0 AND BedCount <= 10)
);
GO

-- Create the Hotels table
CREATE TABLE Hotels (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    DestinationId INT NOT NULL,
    FOREIGN KEY (DestinationId) REFERENCES Destinations(Id)
);
GO

-- Create the Tourists table
CREATE TABLE Tourists (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(80) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    Email NVARCHAR(80) NULL,
    CountryId INT NOT NULL,
    FOREIGN KEY (CountryId) REFERENCES Countries(Id)
);
GO

-- Create the Bookings table
CREATE TABLE Bookings (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ArrivalDate DATETIME2 NOT NULL,
    DepartureDate DATETIME2 NOT NULL,
    AdultsCount INT NOT NULL CHECK (AdultsCount >= 1 AND AdultsCount <= 10),
    ChildrenCount INT NOT NULL CHECK (ChildrenCount >= 0 AND ChildrenCount <= 9),
    TouristId INT NOT NULL,
    HotelId INT NOT NULL,
    RoomId INT NOT NULL,
    FOREIGN KEY (TouristId) REFERENCES Tourists(Id),
    FOREIGN KEY (HotelId) REFERENCES Hotels(Id),
    FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
);
GO

-- Create the HotelsRooms table
CREATE TABLE HotelsRooms (
    HotelId INT NOT NULL,
    RoomId INT NOT NULL,
    PRIMARY KEY (HotelId, RoomId),
    FOREIGN KEY (HotelId) REFERENCES Hotels(Id),
    FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
);
GO