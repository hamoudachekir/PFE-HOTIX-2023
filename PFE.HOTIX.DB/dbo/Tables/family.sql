CREATE TABLE [dbo].[family]
(
	[fam_id] INT NOT NULL PRIMARY KEY, 
    [cat_id] INT NOT NULL, 
    [fam_code] NVARCHAR(10) NOT NULL,  
    [fam_name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Family_To_Category] FOREIGN KEY (cat_id) REFERENCES [category](cat_id) 
 
)
