CREATE PROCEDURE [dbo].[sp_cat_prod_update]
	@catId int,
	@catCode VARCHAR(10),
	@catName VARCHAR(50)
AS
BEGIN

	UPDATE
		dbo.[category] 
	SET 
		cat_code = @catCode,
		cat_name = @catName 
	WHERE
		cat_id = @catId

END
