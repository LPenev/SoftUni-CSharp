CREATE DATABASE Demo
GO
USE Demo
GO
-- Create two tables and use appropriate data types.
-- Insert the data from the example above. 
-- Alter the Persons table and make PersonID a primary key.
-- Create a foreign key between Persons and Passports by using the PassportID column.

CREATE TABLE [Passports]
(
	[PassportID]  INT PRIMARY KEY IDENTITY(101,1),
	[PassportNumber] VARCHAR(8) UNIQUE NOT NULL
)

CREATE TABLE [Persons]
(
	[PersonID] INT PRIMARY KEY IDENTITY,
	[FistName] VARCHAR(60) NOT NULL,
	[Salary] DECIMAL(8,2) NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE NOT NULL
)
GO
INSERT INTO [Passports] (PassportNumber)
VALUES  ('N34FG21B'),
		('K65LO4R7'),
		('ZE657QP2')
GO
INSERT INTO [Persons] (FistName,Salary,PassportID)
VALUES ('Roberto',43300.00,102),
       ('Tom',56100,103),
	   ('Yana',60200,101)
