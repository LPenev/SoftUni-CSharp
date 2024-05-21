USE Demo
GO
-- Create three tables and use appropriate data types.
-- Insert the data from the example above and add primary keys and foreign keys.
-- Keep in mind that the table "StudentsExams" should have a composite primary key.

CREATE TABLE [Students] 
(
	[StudentID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(60) NOT NULL
)

CREATE TABLE [Exams]
(
	[ExamID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(60) NOT NULL
)
GO

CREATE TABLE [StudentsExams]
(
	[StudentID] INT FOREIGN KEY REFERENCES [Students](StudentId) NOT NULL,
	[ExamID] INT FOREIGN KEY REFERENCES [Exams](ExamID) NOT NULL,
	CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO [Students] ([Name])
VALUES  ('Mila'),
		('Toni'),
		('Ron')

INSERT INTO [Exams] ([Name])
VALUES  ('SpringMVC'),
		('Neo4j'),
		('Oracle 11g')

GO
INSERT INTO [StudentsExams]
VALUES  (1,101),
		(1,102),
		(2,101),
		(3,103),
		(2,102),
		(2,103)

SELECT * FROM Students
SELECT * FROM StudentsExams
SELECT * FROM Exams
