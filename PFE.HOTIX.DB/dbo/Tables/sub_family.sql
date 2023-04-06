CREATE TABLE [dbo].[sub_family]
(
	[sfam_id] INT NOT NULL PRIMARY KEY, 
    [fam_id] INT NOT NULL,
    [sfam_code] NCHAR(10) NULL, 
    [sfam_name] NCHAR(50) NULL, 
    CONSTRAINT [FK_Sub_Family_To_Family] FOREIGN KEY ([fam_id]) REFERENCES [family]([fam_id])
)
