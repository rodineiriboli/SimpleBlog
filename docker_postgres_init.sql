drop table if exists Users;

BEGIN TRANSACTION;
CREATE TABLE users
(
	Id uuid NOT NULL,
	Name VARCHAR(100) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	Password VARCHAR(100) NOT NULL,
	SaltKey VARCHAR(100) NOT NULL,
	Active BOOLEAN NOT NULL,
	InclusionDate Date NOT NULL,
	PRIMARY KEY (Id)
);

	INSERT INTO Users
		(Id, Name, Email, Password, SaltKey, Active, InclusionDate)
	VALUES('70a5e624-381f-4cbc-9edc-b277a387f6ef',	'Diego', 'user1@example.com',	'bc6e60a158f637d2cf91380e30f40e515700ec956506e117afe8eef23d1ae77f',	'BeekARPD/MD2xp+pbxJ4ux8ILpPYm8xCppOTxdNP2Sc=',	true,	current_timestamp);


	CREATE TABLE posts
	(
		Id uuid NOT NULL,
		Title VARCHAR(50) NOT NULL,
		Message VARCHAR(300) NOT NULL,
		UserId uuid NOT NULL,
		Active BOOLEAN NOT NULL,
		InclusionDate Date NOT NULL,
		ChangeDate Date,
		PRIMARY KEY (Id),
		FOREIGN KEY (UserId) REFERENCES users (Id)
	);

	INSERT INTO Posts
	(Id, Title, Message, UserId, Active, InclusionDate, ChangeDate)
	VALUES('0a448cca-d1d9-4ba3-a1de-6e4eb233a97a',	'Teste ok2',	'Mensagem de esperança',	'70a5e624-381f-4cbc-9edc-b277a387f6ef',	true,	current_timestamp, current_timestamp);

	

COMMIT;