USE [db_agenda]
GO
/****** Object:  StoredProcedure [dbo].[Contactos_GetByFilter]    Script Date: 1/11/2020 20:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER   PROCEDURE [dbo].[Contactos_GetByFilter]
	
	@name_lastname VARCHAR(200) = NULL,
	@country int = NULL,
	@location VARCHAR(200) = NULL,
	@date_from datetime = NULL,
	@date_to datetime = NULL,
	@internal_contact bit = NULL,
	@organization varchar(200) = NULL,
	@area int = NULL,
	@active bit = NULL,

	--PAGINADO CON ORDENAMIENTO--
    @PageSize int = null,
    @PageIndex int = null, 
    @SortBy varchar(max) = null,
    @Order int = null
    --PAGINADO CON ORDENAMIENTO--
AS
BEGIN

	--PAGINADO CON ORDENAMIENTO--
    IF @PageIndex > 0
    BEGIN
        set @PageIndex = @PageIndex -1
    END
    --PAGINADO CON ORDENAMIENTO--
	
	SELECT  contact.contactId, contact.name_lastname, contact.cuil, contact.genre, country.countryID as countryID, country.name as country_name, contact.location, 
	ic.ID as internal_contactID, ic.value as internal_contact_value ,contact.area as areaID, ac.ID as activeID, ac.value as active_value, 
	contact.adress, contact.phone, contact.cell, contact.email, contact.skype, contact.organization, contact.created_at

	--PAGINADO CON ORDENAMIENTO--
        ,COUNT(*) OVER() total_records
    --PAGINADO CON ORDENAMIENTO--

	FROM [dbo].[contact] 
	INNER JOIN country on contact.countryID = country.countryID
	INNER JOIN yes_no as ic on contact.internal_contact = ic.ID
	INNER JOIN yes_no as ac on contact.active = ac.ID
	
	WHERE 
		(@name_lastname IS NULL OR contact.name_lastname LIKE '%' + @name_lastname + '%') AND
		(@country IS NULL OR country.countryID = @country) AND
		(@location IS NULL OR contact.location LIKE '%' + @location + '%') AND
		(@internal_contact IS NULL OR ic.ID = @internal_contact) AND
		(@organization IS NULL OR contact.organization LIKE '%' + @organization + '%') AND
		(@area IS NULL OR contact.area = @area) AND
		(@active IS NULL OR ac.ID = @active) AND
		(@date_from IS NULL OR contact.created_at > @date_from) AND
		(@date_to IS NULL OR contact.created_at < @date_to)

				
	ORDER BY name_lastname asc
        --POR CADA CAMPO DE LA GRILLA QUE PERMITE ORDERNAR SE LE AGREGA 2 LINEAS PARA EL ORDEN
        	-- case when @order > 0 and @SortBy = 'name_lastname' then name_lastname end desc,
        	-- case when @order < 0 and @SortBy = 'name_lastname' then name_lastname end asc,

        -- Y POR ULTIMO EL ORDENAMIENTO POR DEFAULT
        -- case when @order is null then  contactID else null end

        OFFSET 
            case 
                when @PageIndex is not null and @PageSize is not null then            --APLICO PAGINADO
                    (@PageIndex * @PageSize) 
            else
                0                                        --NO APLICO EL PAGINADO
            end 
        rows 
        fetch next 
            case
                when @PageIndex is not null and @PageSize is not null then
                    @PageSize                                --APLICO PAGINADO
                else
                	case 
                		when (select count(*) from [contact]) > 0 then 
                    		(select count(*) from [contact])    --ESTE SELECT TIENE QUE SER DE LA TABLA PRINCIPAL DE DONDE SALEN LOS DATOS --NO APLICO PAGINADO
                    	else
                    		1
                    end 
            end
        rows only
END
