CREATE PROCEDURE Contacto_Delete
@contactID int

AS
BEGIN
	DELETE FROM contact where contactID = @contactID;
END