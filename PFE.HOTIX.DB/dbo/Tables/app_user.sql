CREATE TABLE [dbo].[app_user]
(
	[user_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [role_id] INT NOT NULL, 
    [user_first_name] VARCHAR(100) NOT NULL, 
    [user_last_name] VARCHAR(100) NULL, 
    [user_login] VARCHAR(100) NOT NULL, 
    [user_password] VARCHAR(250) NOT NULL, 
    [user_email] VARCHAR(100) NULL, 
    [user_phone] VARCHAR(30) NULL, 
    [user_is_active] BIT NULL, 
    [user_birth_date] DATETIME NULL, 
    [user_creation_date] DATETIME NOT NULL, 
    CONSTRAINT [FK_AppUser_To_DefUserRole] FOREIGN KEY ([role_id]) REFERENCES [def_user_role]([role_id]) 
)
