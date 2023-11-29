DROP DATABASE IF EXISTS TecTrek;
CREATE DATABASE TecTrek;
USE TecTrek;

-- DESCOMENTAR SI EL USUARIO NO HA SIDO CREADO --


/* CREATE USER
CREATE USER 'TrikiTrekatelas'@'localhost' IDENTIFIED BY 'AtentamenteElMencho!';
GRANT ALL PRIVILEGES ON *.* TO 'TrikiTrekatelas'@'localhost' WITH GRANT OPTION;
FLUSH PRIVILEGES;
*/


-- HACER EL DUMP ANTES DE CORRER ESTE SCRIPT 
-- 			vvvvvvvvvvvvvvv
--  >>>>>>>>mysqldump -u master -h localhost --port=3306 --protocol=TCP TecTrek -p > <Agrega/Tu/Path>/dbdump.sql <<<<<<<<<<
-- 			^^^^^^^^^^^^^^^
CREATE table Client(
	id_Client INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	username varchar(40) NOT NULL,
	first_name varchar(30) NOT NULL,
	last_name varchar(30) NOT NULL,
	birth_date date NOT NULL,
	user_password varchar(200) NOT NULL,
	email varchar(60) NOT NULL,
	sexo tinyint UNSIGNED NOT NULL,
	points bigint default 0,
    role varchar(60) 
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
	id_Client INT NOT NULL,
	log_in timestamp NOT NULL,
	log_out timestamp NOT NULL,
	points int NOT NULL,
	foreign key (id_Client) references Client(id_Client)
);


CREATE table address(
	id_address int NOT NULL auto_increment primary key,
	id_Client INT NOT NULL,
	state_name varchar(50) NOT NULL,
	city_name varchar(50) NOT NULL,
	foreign key (id_Client) references Client(id_Client)
);


CREATE table add_ons(
	id_add_on int NOT NULL auto_increment primary key,
	id_Client INT NOT NULL,
	coins bigint NOT NULL,
	extra_lives int NOT NULL,
	immunity int NOT NULL,
	current_skin int NOT NULL,
	foreign key (id_Client) references Client(id_Client)
);


CREATE table user_inventory(
	id_inventory int NOT NULL auto_increment primary key,
	id_Client INT NOT NULL,
	id_item int NOT NULL,
	quantity int,
	foreign key (id_Client) references Client(id_Client),
	foreign key (id_item) references items(id_item)
);


CREATE table transactions(
	id_transaction int NOT NULL auto_increment primary key,
	id_Client INT NOT NULL,
	id_item int NOT NULL,
	quantity int NOT NULL,
	payment_type bool NOT NULL,
	transaction_date timestamp NOT NULL,
	foreign key (id_Client) references Client(id_Client),
	foreign key (id_item) references items(id_item)
);

INSERT INTO items (id_item, item_name, item_virtual_price, item_real_price, description)
VALUES 
(1, 'Lootbox 1', 500, 100.00, 'Skins'),
(2, 'Lootbox 2', 1000, 200.00, 'Monedas y Boletos'),
(3, 'Lootbox 3', 1500, 300.00, 'Mas monedas'),
(4, 'Sorball 1', 2000, 50.00, 'Sorball mi Sueño'),
(5, 'Sorball 2', 2000, 50.00, 'Sorball Habitat'),
(6, 'Sorball 3', 2000, 50.00, 'Sorball Educativo'),
(7, 'Sorball 4', 2000, 50.00, 'Sorall Aventurat'),
(8, 'Discount 1', 0, 0, '0.1'),
(9, 'Discount 2', 0, 0, '0.15'),
(10,'Discount 3', 0, 0, '0.2'),
(11,'Discount 4', 0, 0, '0.25');


INSERT INTO `Client` VALUES (7,'Nataliaaa','Natalia','Salgado','2002-05-22','696969','natsg@gmail.com',1,500,'Cliente'),(8,'SylviaPoyito','Sylvia','Cortes','2000-07-07','070707','sylviac@hotmail.com',2,750,'Cliente'),(9,'Sebs','Sebastian','Rosas','2003-02-06','420420','sebs@gmail.com',0,501,'Cliente'),(10,'Yu','Yudith','Palacios','2003-08-07','50069','yuyu@hotmail.com',1,600,'Cliente'),(11,'Shaqx','Isaac','Enriquez','1999-01-20','123456','shax@hotmail.com',0,1530,'Cliente'),(12,'AOkay','Narharis','Narharinio','2001-01-01','nananabatman','aokei@gmail.com',0,90,'Cliente'),(13,'lucia123','Lucia','Perez','1970-01-01','123','lucia@gmail.com',1,NULL,'Cliente'),(14,'ximena123','Ximena','Garcia','1960-01-01','123','ximena@gmail.com',1,NULL,'Cliente'),(15,'jose123','Jose','Montero','1980-01-01','123','jose@gmail.com',0,NULL,'Cliente'),(16,'manuel123','Manuel','Gomez','1970-01-01','123','manuel@gmail.com',0,49998000,'Cliente'),(17,'Admin','Sebastian','Rosas','1980-01-01','123','L01234567@tec.mx',0,NULL,'Admin');


create view leaderboard as
select username, points from Client order by points desc;
