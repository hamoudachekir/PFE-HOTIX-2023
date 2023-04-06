CREATE PROCEDURE [dbo].[sp_sub_fam_delete]
	@sfamId int
AS
BEGIN

	DELETE FROM
		dbo.[sub_family] 
	WHERE 
		fam_id = @sfamId

END
