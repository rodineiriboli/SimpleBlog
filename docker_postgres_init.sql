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
	InclusionDate Date NOT NULL
);

	INSERT INTO Users
		(Id, Name, Email, Password, SaltKey, Active, InclusionDate)
	VALUES('2ae90450-9040-4f3d-900b-cd7565a1231c', 'Rodinei Riboli', 'rodineir@teste.com.br', '5ebbdf2a-5852-4eee-876b-f8df9708efbe', '234ceee3e5b9e2844af663547da0b4b3661c10306c8e291f68e9af2037469527', 
	TRUE, current_timestamp);

COMMIT;