CREATE PROCEDURE [dbo].[sp_sub_fam_update]
	@sfamId int,
	@famId int,
	@sfamCode VARCHAR(10),
	@sfamName VARCHAR(50)
AS
BEGIN

	UPDATE
		dbo.[sub_family] 
	SET
		fam_id = @sfamId,
		sfam_code = @sfamCode,
		sfam_name = @sfamName 
	WHERE
		sfam_id = @sfamId

END
