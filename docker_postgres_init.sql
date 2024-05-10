drop table if exists motorcycle;

CREATE TABLE motorcycle
(
	id uuid NOT NULL,
	model VARCHAR NOT NULL,
	year INT4,
	licensePlate VARCHAR(10),
	registrationUserId uuid NOT NULL
);

	INSERT INTO motorcycle
		(id, model, year, licensePlate, registrationUserId)
	VALUES('2ae90450-9040-4f3d-900b-cd7565a1231c', 'CG 150cc_TESTE_01', 2015, 'MXH-5555', '5ebbdf2a-5852-4eee-876b-f8df9708efbe');

	INSERT INTO motorcycle
		(id, model, year, licensePlate, registrationUserId)
	VALUES('d7a5777c-565c-4ae2-a7ae-7e29ca507bcd', 'CG 150cc_TESTE_02', 2015, 'MHB-3216', '60db4445-324c-4d30-b819-93baa0a54616');

	INSERT INTO motorcycle
		(id, model, year, licensePlate, registrationUserId)
	VALUES('abba8826-e56d-46d0-80d7-9775d3f32035', 'CG 150cc_TESTE_03', 2015, 'ABH-6498', 'fa1ef0e6-fc13-4823-ac52-ddd14220d53f');

COMMIT;

