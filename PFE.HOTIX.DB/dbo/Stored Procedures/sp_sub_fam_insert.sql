CREATE PROCEDURE [dbo].[sp_sub_fam_insert]
	@famId int,
	@sfamCode VARCHAR(10),
	@sfamName VARCHAR(50)
AS
BEGIN

	INSERT INTO
		dbo.[sub_family] (sfam_id, fam_id, sfam_code, sfam_name) 
	VALUES 
		((SELECT ISNULL(MAX(sfam_id), 0) FROM sub_family ) + 1, @famId, @sfamCode, @sfamName)

END
