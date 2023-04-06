CREATE PROCEDURE [dbo].[sp_fam_update]
	@famId int,
	@catId int,
	@famCode VARCHAR(10),
	@famName VARCHAR(50)
AS
BEGIN

	UPDATE
		dbo.[family] 
	SET
		fam_id = @famId,
		fam_code = @famCode,
		fam_name = @famName 
	WHERE
		fam_id = @famId

END
