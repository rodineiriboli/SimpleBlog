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
	VALUES('2ae90450-9040-4f3d-900b-cd7565a1231c', 'Rodinei Riboli', 'rodineir@teste.com.br', '5ebbdf2a-5852-4eee-876b-f8df9708efbe', '234ceee3e5b9e2844af663547da0b4b3661c10306c8e291f68e9af2037469527', 
	TRUE, current_timestamp);


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
	VALUES('2ae90450-9040-4f3d-900b-cd7565a1231a', 'Title teste mensagem', 'Esta é uma mensagem de teste populada inicialmente na base...', '2ae90450-9040-4f3d-900b-cd7565a1231c', TRUE, current_timestamp, NULL);

COMMIT;