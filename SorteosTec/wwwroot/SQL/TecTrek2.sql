DROP DATABASE IF EXISTS TecTrek;
CREATE DATABASE TecTrek;
USE TecTrek;

CREATE USER 'TrikiTrekatelas'@'localhost' IDENTIFIED BY 'AtentamenteElMencho!';
GRANT ALL PRIVILEGES ON *.* TO 'TrikiTrekatelas'@'localhost' WITH GRANT OPTION;
FLUSH PRIVILEGES;

-- HACER EL DUMP ANTES DE CORRER ESTE SCRIPT 
-- 			vvvvvvvvvvvvvvv
--  >>>>>>>>mysqldump -u master -h localhost --port=3306 --protocol=TCP TecTrek -p > <Agrega/Tu/Path>/dbdump.sql <<<<<<<<<<
-- 			^^^^^^^^^^^^^^^
CREATE table client(
	id_client INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	username varchar(40) NOT NULL,
	first_name varchar(30) NOT NULL,
	last_name varchar(30) NOT NULL,
	birth_date date NOT NULL,
	user_password varchar(200) NOT NULL,
	email varchar(60) NOT NULL,
	sexo tinyint UNSIGNED NOT NULL,
	points bigint NOT NULL default 0,
    admin bool default false
);

CREATE table items(
	id_item int NOT NULL auto_increment primary key,
	item_name varchar(50) NOT NULL,
	item_virtual_price int NOT NULL,
	item_real_price float NOT NULL,
	description varchar(250)
);


CREATE table log_user(
	id_log int NOT NULL auto_increment primary key,
	id_client INT NOT NULL,
	log_in timestamp NOT NULL,
	log_out timestamp NOT NULL,
	points int NOT NULL,
	foreign key (id_client) references client(id_client)
);


CREATE table address(
	id_address int NOT NULL auto_increment primary key,
	id_client INT NOT NULL,
	state_name varchar(50) NOT NULL,
	city_name varchar(50) NOT NULL,
	foreign key (id_client) references client(id_client)
);


CREATE table add_ons(
	id_add_on int NOT NULL auto_increment primary key,
	id_client INT NOT NULL,
	coins bigint NOT NULL,
	extra_lives int NOT NULL,
	immunity int NOT NULL,
	current_skin int NOT NULL,
	foreign key (id_client) references client(id_client)
);


CREATE table user_inventory(
	id_inventory int NOT NULL auto_increment primary key,
	id_client INT NOT NULL,
	id_item int NOT NULL,
	quantity int,
	foreign key (id_client) references client(id_client),
	foreign key (id_item) references items(id_item)
);


CREATE table transactions(
	id_transaction int NOT NULL auto_increment primary key,
	id_client INT NOT NULL,
	id_item int NOT NULL,
	quantity int NOT NULL,
	payment_type bool NOT NULL,
	transaction_date timestamp NOT NULL,
	foreign key (id_client) references client(id_client),
	foreign key (id_item) references items(id_item)
);

INSERT INTO items (id_item, item_name, item_virtual_price, item_real_price, description)
VALUES (1, 'Lootbox 1', 500, 100.00, 'Skins');

INSERT INTO items (id_item, item_name, item_virtual_price, item_real_price, description)
VALUES (2, 'Lootbox 2', 1000, 200.00, 'Monedas y Boletos');

INSERT INTO items (id_item, item_name, item_virtual_price, item_real_price, description)
VALUES (3, 'Lootbox 3', 1500, 300.00, 'Mas monedas');

INSERT INTO items (id_item, item_name, item_virtual_price, item_real_price, description)
VALUES (4, 'Sorball 1', 2000, 50.00, 'Sorball mi Sueño');

INSERT INTO items (id_item, item_name, item_virtual_price, item_real_price, description)
VALUES (5, 'Sorball 2', 2000, 50.00, 'Sorball Habitat');

INSERT INTO items (id_item, item_name, item_virtual_price, item_real_price, description)
VALUES (6, 'Sorball 3', 2000, 50.00, 'Sorball Educativo');

INSERT INTO items (id_item, item_name, item_virtual_price, item_real_price, description)
VALUES (7, 'Sorball 4', 2000, 50.00, 'Sorall Aventurat');
