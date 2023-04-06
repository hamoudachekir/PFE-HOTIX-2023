CREATE TABLE [dbo].[product]
(
	[prod_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [sfam_id] INT NOT NULL,
    [prod_ref] VARCHAR(10) NULL,
    [prod_code] VARCHAR(10) NULL, 
    [prod_name] VARCHAR(50) NULL, 
    [prod_desc] VARCHAR(250) NULL,
    [prod_image] VARCHAR(MAX) NULL,
    [prod_bar_code] VARCHAR(100) NULL, 
    [prod_qtt] INT NULL, 
    [prod_unit_price] DECIMAL(18, 3) NULL, 
    CONSTRAINT [FK_Product_To_Sub_family] FOREIGN KEY ([sfam_id]) REFERENCES [sub_family]([sfam_id])
)
