
CREATE TABLE user_agenda(
	userID int IDENTITY(1,1) NOT NULL,
    username varchar(255) NOT NULL,
    password varchar (255) NOT NULL,
    CONSTRAINT pk_usuario PRIMARY KEY(userID)
);

CREATE TABLE yes_no (
	ID bit NOT NULL,
    value bit NOT NULL,
    CONSTRAINT pk_yes_no PRIMARY KEY(ID)
);

CREATE TABLE country(
	countryID int IDENTITY(1,1) NOT NULL,
    name varchar(255) NOT NULL,
    CONSTRAINT pk_country PRIMARY KEY(countryID)
);

CREATE TABLE area (
	areaID int IDENTITY(1,1) NOT NULL,
	name varchar(255) NOT NULL,
    CONSTRAINT pk_area PRIMARY KEY(areaID)
);

CREATE TABLE contact (
	contactID int IDENTITY(1,1) NOT NULL,
	name_lastname varchar(255) NOT NULL,
	cuil VARCHAR(255),
	genre varchar(255) NOT NULL,
	countryID int NOT NULL,
	location varchar(255), 
	internal_contact bit,
	area int,
	active bit NOT NULL,
	adress varchar(255),
	phone bigint,
	cell bigint,
	email varchar(255) NOT NULL,
	skype varchar(255),
	organization varchar(255),
	created_at datetime

    CONSTRAINT pk_contact PRIMARY KEY(contactID),
	CONSTRAINT fk_countryID_contact FOREIGN KEY (countryID)
	REFERENCES country(countryID),
	CONSTRAINT fk_internal_contact_contact FOREIGN KEY (internal_contact)
	REFERENCES yes_no(ID),
	CONSTRAINT fk_active_contact FOREIGN KEY (active)
	REFERENCES yes_no(ID),
);