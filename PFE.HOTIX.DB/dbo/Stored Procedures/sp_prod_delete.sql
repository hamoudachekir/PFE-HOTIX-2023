CREATE PROCEDURE [dbo].[sp_prod_delete]
	@prodId int
AS
BEGIN

	DELETE FROM
		dbo.[product] 
	WHERE 
		prod_id = @prodId

END
