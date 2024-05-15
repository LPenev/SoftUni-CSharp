CREATE DATABASE HOTEL
GO
USE HOTEL
GO
CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(60) NOT NULL,
	LastName VARCHAR(60) NOT NULL,
	Title VARCHAR(30),
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers 
(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(60) NOT NULL,
	LastName VARCHAR(60) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	EmergencyName VARCHAR(60),
	EmergencyNumber VARCHAR(20),
	Notes VARCHAR(MAX)
)

CREATE TABLE RoomStatus 
(
	RoomStatus VARCHAR(30) PRIMARY KEY NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(30) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

CREATE TABLE BedTypes
(
	BedType VARCHAR(30) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

GO
CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(30) FOREIGN KEY REFERENCES [RoomTypes](RoomType) NOT NULL,
	BedType VARCHAR(30) FOREIGN KEY REFERENCES [BedTypes](BedType) NOT NULL,
	Rate DECIMAL(10, 2) NOT NULL,
	RoomStatus VARCHAR(30) FOREIGN KEY REFERENCES [RoomStatus](RoomStatus),
	Notes VARCHAR(MAX)
)

CREATE TABLE Payments 
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays TINYINT NOT NULL,
	CHECK(DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied) = TotalDays),
	AmountCharged DECIMAL(8,2),
	TaxRate DECIMAL(8,2),
	TaxAmount DECIMAL(8,2),
	CHECK(TaxAmount = TotalDays * TaxRate),
	PaymentTotal DECIMAL(8,2),
	Notes VARCHAR(MAX)
)

CREATE TABLE Occupancies 
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
	RateApplied DECIMAL(8,2) NOT NULL,
	PhoneCharge DECIMAL(6,2) NOT NULL,
	Notes VARCHAR(MAX)
)

GO

INSERT INTO Employees (FirstName, LastName) 
	VALUES  ('Employer 1','LastName 1'),
			('Employer 2','LastName 2'),
			('Employer 3','LastName 3')

INSERT INTO Customers (FirstName, LastName, PhoneNumber)
	VALUES  ('Customer 1','LastName 1','0886222'),
			('Customer 2','LastName 2','0886552323'),
			('Customer 3','LastName 3','088753434')

INSERT INTO RoomStatus (RoomStatus)
	VALUES  ('Free'),
			('In use'),
			('Reserved')

INSERT INTO RoomTypes (RoomType)
	VALUES  ('Single'),
			('Double'),
			('Apartment')

INSERT INTO BedTypes (BedType)
	VALUES  ('Single'),
			('Double'),
			('King size')
GO
INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus)
	VALUES  (111, 'Single', 'Single',120.00, 'Free'),
			(222, 'Double', 'Single',160.00, 'Free'),
			(333, 'Apartment', 'Single',290.00, 'Free')

GO
INSERT INTO Payments(EmployeeId,PaymentDate,AccountNumber,FirstDateOccupied,LastDateOccupied,TotalDays,AmountCharged,TaxRate,TaxAmount,PaymentTotal)
	VALUES  (1,'10-05-2024',1,'10-05-2024','10-10-2024',5,120,120,600,600),
		    (3,'10-11-2024',1,'12-15-2024','12-25-2024',10,120,120,1200,1200),
			(2,'12-23-2024',1,'12-23-2024','12-24-2024',1,120,120,120,120);
GO
INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
	VALUES  (1,'01-10-2024', 1, 111,120,0),
			(1,'02-10-2024', 2, 111,160,0),
			(1,'03-10-2024', 3, 111,290,0)
