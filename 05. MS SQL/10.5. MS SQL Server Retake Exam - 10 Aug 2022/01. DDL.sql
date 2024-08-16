USE NationalTouristSitesOgBulgaria
GO

CREATE TABLE Categories(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Locations(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
Municipality VARCHAR(50),
Province VARCHAR(50)
)

CREATE TABLE Sites(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(100) NOT NULL,
LocationId INT NOT NULL FOREIGN KEY REFERENCES Locations(Id), 
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
Establishment VARCHAR(15)
)

CREATE TABLE Tourists(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
Age INT NOT NULL 
	CHECK(Age >= 0 AND Age <= 120),
PhoneNumber VARCHAR(20) NOT NULL,
Nationality VARCHAR(30) NOT NULL,
Reward VARCHAR(20)
)

CREATE TABLE SitesTourists(
TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id),
SiteId INT NOT NULL FOREIGN KEY REFERENCES Sites(Id),
PRIMARY KEY (TouristId, SiteId)
)

CREATE TABLE BonusPrizes(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes(
TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id),
BonusPrizeId INT NOT NULL FOREIGN KEY REFERENCES BonusPrizes(Id),
PRIMARY KEY (TouristId, BonusPrizeId)
)
