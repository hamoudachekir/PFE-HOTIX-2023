CREATE PROCEDURE [dbo].[sp_user_insert]
	@roleId int,
	@firstName VARCHAR(100),
	@lastName VARCHAR(100),
	@login VARCHAR(100),
	@password VARCHAR(250),
	@email VARCHAR(100),
	@phone VARCHAR(30), 
	@birthDate DATE
AS
BEGIN

	INSERT INTO
		dbo.[app_user] (role_id, user_first_name, user_last_name, user_login, user_password,
					user_email, user_phone, user_is_active, user_birth_date, user_creation_date) 
	VALUES 
		(@roleId, @firstName, @lastName, @login, @password,
		 @email, @phone, 1, @birthDate, GETDATE())

END
