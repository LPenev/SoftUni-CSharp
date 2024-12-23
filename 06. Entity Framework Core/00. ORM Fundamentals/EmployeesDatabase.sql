CREATE Database Projects;
GO
USE Projects;
GO
CREATE TABLE Departments (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50));
GO
CREATE TABLE Employees 
	(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30),
	MiddleName VARCHAR(30),
	LastName VARCHAR(30),
	IsEmpolyed BIT,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
	);

CREATE TABLE Projects 
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30)
);
GO

CREATE TABLE EmployeesProjects
(
	ProjectId INT FOREIGN KEY REFERENCES Projects(Id),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
);


GO
INSERT INTO Departments (Name)
VALUES ('IT');
INSERT INTO Departments (Name)
VALUES ('Finance');
INSERT INTO Departments (Name)
VALUES ('Logistic');
INSERT INTO Departments (Name)
VALUES ('Security');
INSERT INTO Departments (Name)
VALUES ('Productions');
GO
INSERT INTO Projects (Name)
VALUES ('Bildung Prog'),
		('Turbo Charger'),
		('Chalga Killer');

INSERT INTO Employees (FirstName, MiddleName, LastName, IsEmpolyed, DepartmentId)
VALUES  ('Ivo','M','Stanovski',0,1),
		('Milen','V','Tonev',1,4),
		('Stanislav','A','Tahow',1,3),
		('Ginio','M','Ilienski',1,2),
		('Toshko','E','Kostov',1,2),
		('Kiril','D','Dumbev',1,3);

INSERT INTO EmployeesProjects
VALUES	(1,1),
		(2,2),
		(3,3),
		(1,6),
		(2,5);