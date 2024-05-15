CREATE TABLE [People] 
(
	ID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(2048),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(3,2),
	[Gender] CHAR(1) NOT NULL,
		CHECK(Gender in('m','f')),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)


INSERT INTO [People] ([Name], [Gender], [Birthdate]) 
	VALUES 
		('Ivan','m','1988-05-12'),
		('Kamelia','f','1979-08-30'),
		('Rosen','m','1973-07-31'),
		('Ivelin','m','1964-03-23'),
		('Rosana','f','1987-09-20')

