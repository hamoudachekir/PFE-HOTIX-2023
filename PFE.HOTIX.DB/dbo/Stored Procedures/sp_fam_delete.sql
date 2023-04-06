CREATE PROCEDURE [dbo].[sp_fam_delete]
	@famId int
AS
BEGIN

	DELETE FROM
		dbo.[family] 
	WHERE 
		fam_id = @famId

END
