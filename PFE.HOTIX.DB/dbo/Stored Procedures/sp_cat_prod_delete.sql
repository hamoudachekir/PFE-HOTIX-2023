CREATE PROCEDURE [dbo].[sp_cat_prod_delete]
	@catId int
AS
BEGIN

	DELETE FROM
		dbo.[category] 
	WHERE 
		cat_id = @catId
END
