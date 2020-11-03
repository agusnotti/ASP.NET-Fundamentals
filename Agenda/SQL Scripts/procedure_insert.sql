--Procedimiento para crear un contacto

CREATE OR ALTER PROCEDURE Contacto_Insert
@name_lastname varchar(255),
@cuil varchar(255),
@genre varchar(255),
@country int,
@location varchar(255) = null,
@internal_contact bit = null,
@area int = null,
@active bit,
@adress varchar(255) = null,
@phone bigint = null,
@cell bigint = null,
@email varchar(255), 
@skype varchar(255) = null,
@organization varchar(255) = null,
@created_at datetime = null

AS
BEGIN
	INSERT INTO contact (name_lastname, cuil, genre, countryID, location, internal_contact, area, active, adress, phone, cell, email, skype, organization, created_at)
	Values(@name_lastname, @cuil, @genre,@country,@location,@internal_contact,@area,@active,@adress,@phone,@cell,@email,@skype, @organization, @created_at);
END




