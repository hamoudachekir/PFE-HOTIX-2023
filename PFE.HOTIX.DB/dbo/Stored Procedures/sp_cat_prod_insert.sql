CREATE PROCEDURE [dbo].[sp_cat_prod_insert]
	@catId int,
	@catCode VARCHAR(10),
	@catName VARCHAR(50)
AS
BEGIN

	INSERT INTO
		dbo.[category] (cat_id, cat_code, cat_name) 
	VALUES 
		(@catId, @catCode, @catName)

END
