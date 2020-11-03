--procedimiento para modificar un contacto
CREATE OR ALTER PROCEDURE Contacto_update
@contactoID int,
@name_lastname Varchar(255),
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
	UPDATE contact 
		SET name_lastname = @name_lastname,
			genre = @genre,
			countryID = @country,
			location = @location,
			internal_contact = @internal_contact,
			area = @area,
			active = @active,
			adress = @adress,
			phone = @phone,
			cell = @cell,
			email = @email,
			skype = @skype,
			organization = @organization,
			created_at = @created_at

	WHERE @contactoID = contactID;
END