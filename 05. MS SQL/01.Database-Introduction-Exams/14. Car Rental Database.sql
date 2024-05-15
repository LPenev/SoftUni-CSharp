CREATE DATABASE [CarRental]
GO
USE [CarRental]
GO
CREATE TABLE [Categories]
	(
	Id INT PRIMARY KEY,
	CategoryName VARCHAR(60) NOT NULL,
	DailyRate INT,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate INT
	)

CREATE TABLE [Cars]
(
	Id INT PRIMARY KEY,
	PlateNumber VARCHAR(10) UNIQUE NOT NULL,
	Manufacturer VARCHAR(60) NOT NULL,
	Model VARCHAR(60) NOT NULL,
	CarYear DATE NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition VARCHAR(100),
	Available BIT
)

CREATE TABLE [Employees] 
(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(60) NOT NULL,
	LastName VARCHAR(60) NOT NULL,
	Title VARCHAR(60),
	Notes VARCHAR(200)
)

CREATE TABLE [Customers]
(
	Id INT PRIMARY KEY,
	DriverLicenceNumber VARCHAR(20) NOT NULL,
	FullName VARCHAR(60) NOT NULL,
	Address VARCHAR(60) NOT NULL,
	City VARCHAR(60) NOT NULL,
	ZIPCode TINYINT,
	Notes VARCHAR(200)
)

GO
CREATE TABLE [RentalOrders]
(
	Id INT PRIMARY KEY,
	EmployeeId INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES [Customers](Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES [Cars](Id) NOT NULL,
	TankLevel TINYINT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	CHECK(KilometrageEnd - KilometrageStart = TotalKilometrage),
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays TINYINT NOT NULL,
	CHECK(DATEDIFF(DAY, StartDate, EndDate) = TotalDays),
	RateApplied INT,
	TaxRate INT,
	OrderStatus TINYINT,
	Notes VARCHAR(200)
)

INSERT INTO Categories(Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
	( 1, 'First Category', 10, 50, 200, 50),
	( 2, 'Second Category', 20, 90, 330, 100),
	( 3, 'Third Category', 30, 130, 2700, 155)

GO
INSERT INTO Cars(Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Available)
VALUES
	( 1, 'CA1727BB', 'BMW', '750', '2018', 3, 4, 1),
	( 2, 'CA2553BB', 'BMW', 'M7', '2024', 3, 4, 1),
	( 3, 'CA4323AB', 'BMW', '530', '2012', 1, 2, 1)

INSERT INTO Employees( Id, FirstName, LastName, Title)
VALUES
	( 1, 'First', 'One', 'Mechanic'),
	( 2, 'Second', 'Two', 'Team Leader'),
	( 3, 'Third', 'Three', 'Boss')

INSERT INTO Customers( Id, DriverLicenceNumber, FullName, Address, City)
VALUES
	( 1, '111', 'First Name', 'Ulica 1','Town 1'),
	( 2, '222', 'Second Name', 'Ulica 2','Town 2'),
	( 3, '333', 'Third Name', 'Ulica 3','Town 3')

GO
INSERT INTO RentalOrders ( Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart,
KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays)
VALUES
	( 1, 3, 3, 3, 11, 100, 110, 10, '01-01-2020', '01-02-2020', 1),
	( 2, 1, 1, 1, 22, 200, 220, 20, '01-01-2021', '01-03-2021', 2),
	( 3, 2, 2, 2, 33, 300, 330, 30, '01-01-2022', '01-04-2022', 3)
