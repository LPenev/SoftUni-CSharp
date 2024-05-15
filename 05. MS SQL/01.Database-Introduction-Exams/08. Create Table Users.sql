CREATE TABLE [Users] 
	(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture BINARY(900),
	LastLoginTime DATETIME2,
	IsDeleted BIT
	)

	INSERT INTO [Users] (Username, [Password], IsDeleted)
	VALUES 
	( 'Ivan','1234','0'),
	( 'Toga','KrivaDora2','0'),
	( 'Moya','Dora22','0'),
	( 'Yamaha','ChiChi','1'),
	( 'BMW','AaaBbb','1')