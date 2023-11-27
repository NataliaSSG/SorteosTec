DROP DATABASE IF EXISTS TecTrek;
CREATE DATABASE TecTrek;
USE TecTrek;

CREATE table client(
	id_client INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	username varchar(40) NOT NULL,
	first_name varchar(30) NOT NULL,
	last_name varchar(30) NOT NULL,
	birth_date date NOT NULL,
	user_password varchar(200) NOT NULL,
	email varchar(60) NOT NULL,
	sexo tinyint UNSIGNED NOT NULL,
	points bigint NOT NULL,
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

