USE Demo
GO

-- Create one table and use appropriate data types.
-- Insert the data from the example above and add primary keys and foreign keys.
-- The foreign key should be between ManagerId and TeacherId.

CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY,
	[Name] VARCHAR(32) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)
GO

INSERT INTO Teachers 
VALUES	(101, 'John', NULL),
		(106, 'Greta', 101),
		(105, 'Mark', 101),
		(104, 'Ted', 105),
		(102, 'Maya', 106),
		(103, 'Silvia', 106)


