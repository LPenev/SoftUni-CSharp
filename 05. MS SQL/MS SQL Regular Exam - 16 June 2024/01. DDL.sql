CREATE DATABASE LibraryDb;
GO

-- Use the newly created database
USE LibraryDb;
GO
-- Create the Genres table
CREATE TABLE Genres (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(30) NOT NULL
);
GO
-- Create the Contacts table
CREATE TABLE Contacts (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(100) NULL,
    PhoneNumber NVARCHAR(20) NULL,
    PostAddress NVARCHAR(200) NULL,
    Website NVARCHAR(50) NULL
);
GO
-- Create the Authors table
CREATE TABLE Authors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    ContactId INT NOT NULL FOREIGN KEY REFERENCES Contacts(Id)
);
GO
-- Create the Books table
CREATE TABLE Books (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    YearPublished INT NOT NULL,
    ISBN NVARCHAR(13) UNIQUE NOT NULL,
    AuthorId INT NOT NULL,
    GenreId INT NOT NULL,
    FOREIGN KEY (AuthorId) REFERENCES Authors(Id),
    FOREIGN KEY (GenreId) REFERENCES Genres(Id)
);
GO
-- Create the Libraries table
CREATE TABLE Libraries (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    ContactId INT NOT NULL FOREIGN KEY REFERENCES Contacts(Id)
);
GO

-- Create the LibrariesBooks table (many-to-many relationship between Libraries and Books)
CREATE TABLE LibrariesBooks (
    LibraryId INT NOT NULL,
    BookId INT NOT NULL,
    PRIMARY KEY (LibraryId, BookId),
    FOREIGN KEY (LibraryId) REFERENCES Libraries(Id),
    FOREIGN KEY (BookId) REFERENCES Books(Id)
);