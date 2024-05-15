CREATE DATABASE [Movies]
GO
USE [Movies]
GO
CREATE TABLE [Directors] 
	(
	Id INT PRIMARY KEY,
	DirectorName VARCHAR(60) NOT NULL,
	Notes VARCHAR(120)
	)

CREATE TABLE [Genres]
	(
	Id INT PRIMARY KEY,
	GenreName VARCHAR(60) NOT NULL,
	Notes VARCHAR(120)
	)

CREATE TABLE [Categories]
	(
	Id INT PRIMARY KEY,
	CategoryName VARCHAR(60) NOT NULL,
	Notes VARCHAR(120)
	)
GO
CREATE TABLE [Movies]
(
	Id INT PRIMARY KEY,
	Title VARCHAR(60),
	DirectorId INT FOREIGN KEY REFERENCES [Directors](Id),
	CopyrightYear INT,
	Length float,
	GenreId INT FOREIGN KEY REFERENCES [Genres](Id),
	CategoryId INT FOREIGN KEY REFERENCES [Categories](Id),
	Rating INT,
	Notes VARCHAR(200)
)

GO
INSERT INTO Directors (Id,DirectorName)
VALUES
	(1,'Director One'),
	(2,'Director Two'),
	(3,'Director Three'),
	(4,'Director Four'),
	(5,'Director Five')

INSERT INTO Genres (Id, GenreName)
VALUES
	(1,'Genre One'),
	(2,'Genre Two'),
	(3,'Genre Three'),
	(4,'Genre Four'),
	(5,'Genre Five')

INSERT INTO Categories(Id, CategoryName)
VALUES
	(1,'Category One'),
	(2,'Category Two'),
	(3,'Category Three'),
	(4,'Category Four'),
	(5,'Category Five')

GO
INSERT INTO Movies(Id,Title,DirectorId,GenreId,CategoryId)
VALUES
	(1, 'Movie One', 1, 1, 1),
	(2, 'Movie Two', 2, 2, 2),
	(3, 'Movie Three', 3, 3, 3),
	(4, 'Movie Four', 4, 4, 4),
	(5, 'Movie Five', 5, 5, 5)

