DROP DATABASE IF EXISTS TecTrek;
create database TecTrek;

use TecTrek;
create table client(
	id_user int auto_increment not null, 
	primary key (id_user),
	name varchar(32),
	last_name varchar(32),
	gender varchar(32),
	email varchar(32),
	username varchar(50),
	pw varchar(40)
);
/*
create table transactions(
	id_transaction int auto_increment not null,
	primary key (id_transaction),
	id_user int not null,
	foreign key id_user references client (id_user),
	description varchar(100),
	amount decimal(10,2),
	transaction_date timestamp,
);*/
CREATE TABLE transactions (
    id_transaction INT AUTO_INCREMENT NOT NULL,
    id_user INT NOT NULL,
    description VARCHAR(100),
    amount DECIMAL(10,2),
    transaction_date TIMESTAMP,
    PRIMARY KEY (id_transaction),
    FOREIGN KEY (id_user) REFERENCES client(id_user)
);

CREATE TABLE client_transactions (
    id_client_transactions INT AUTO_INCREMENT NOT NULL,
    id_transaction INT NOT NULL,
    id_user INT,
    PRIMARY KEY (id_client_transactions),
    FOREIGN KEY (id_transaction) REFERENCES transactions (id_transaction),
    FOREIGN KEY (id_user) REFERENCES client (id_user)
);

create table player_sessions(
	id_player_sessions int auto_increment not null,
	id_user int not null,
	score int,
	start_time timestamp,
	end_time timestamp,
	primary key (id_player_sessions),
	foreign key (id_user) references client (id_user)
);

create table items(
	id_item int auto_increment not null,
	name varchar(50),
	description varchar(100),
	parameters varchar(200),
	primary key (id_item)
);

create table items_player(
	id_items_player int auto_increment not null,
	id_user int,
	id_item int,
	primary key (id_items_player),
	foreign key (id_user) references client (id_user),
	foreign key (id_item) references items (id_item)
);

create table player_registry(
	id_player_registry int auto_increment not null, 
	id_user int,
	log_in timestamp,
	log_out timestamp,
	id_session int not null,
	id_items_player int not null,
	primary key (id_player_registry),
	foreign key (id_user) references client (id_user),
	foreign key (id_items_player) references items_player (id_items_player)	
);





-- Alter the stored procedure
CREATE PROCEDURE Register_Player(
    IN in_name VARCHAR(32),
    IN in_last_name VARCHAR(32),
    IN in_gender VARCHAR(32), -- Corrected the data type definition
    IN in_email VARCHAR(32),
    IN in_username VARCHAR(50),
    IN in_pw VARCHAR(40)
)
BEGIN
    DECLARE foundClients INT;
    
    -- Check if the username or email is already registered
    SELECT COUNT(*) INTO foundClients FROM client WHERE username = in_username OR email = in_email;
    
    IF foundClients > 0 THEN
        -- User already registered
        SELECT "User already registered" AS message;
    ELSE
        -- Insert the new user into the client table
        INSERT INTO client (name, last_name, gender, email, username, pw)
        VALUES (in_name, in_last_name, in_gender, in_email, in_username, in_pw);
        
        -- User created successfully
        SELECT "User created successfully" AS message;
    END IF;
END;


call Register_Player("xd","xd","xd","xd","xd","xd");

SELECT * FROM client c ;
delete from client;







-- DB 2  --

-- *********************************************** --
use TecTrek;

create table client(
	username varchar(40) not null primary key,
	first_name varchar(30) not null,
	last_name varchar(30) not null,
	birth_date date not null,
	user_password varchar(200) not null,
	email varchar(60) not null,
	sexo tinyint unsigned not null
);


create table items(
	id_item int not null auto_increment primary key,
	item_name varchar(50) not null,
	item_virtual_price int not null,
	item_real_price float not null,
	description varchar(250)
);


create table log_user(
	id_log int not null auto_increment primary key,
	id_client varchar(40) not null,
	log_in timestamp not null,
	log_out timestamp not null,
	points int not null,
	foreign key (id_client) references client(username)
);


create table address(
	id_address int not null auto_increment primary key,
	id_client varchar(40) not null,
	state_name varchar(50) not null,
	city_name varchar(50) not null,
	foreign key (id_client) references client(username)
);


create table add_ons(
	id_add_on int not null auto_increment primary key,
	id_client varchar(40) not null,
	coins bigint not null,
	extra_lives int not null,
	immunity int not null,
	current_skin int not null,
	foreign key (id_client) references client(username)
);


create table user_inventory(
	id_inventory int not null auto_increment primary key,
	id_client varchar(40) not null,
	id_item int not null,
	quantity int,
	foreign key (id_client) references client(username),
	foreign key (id_item) references items(id_item)
);


create table transactions(
	id_transaction int not null auto_increment primary key,
	id_client varchar(40) not null,
	id_item int not null,
	quantity int not null,
	payment_type bool not null,
	transaction_date timestamp not null,
	foreign key (id_client) references client(username),
	foreign key (id_item) references items(id_item)
)