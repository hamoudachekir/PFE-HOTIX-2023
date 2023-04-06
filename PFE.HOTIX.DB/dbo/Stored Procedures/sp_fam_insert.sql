CREATE PROCEDURE [dbo].[sp_fam_insert]
	@catId int,
	@famCode VARCHAR(10),
	@famName VARCHAR(50)
AS
BEGIN

	INSERT INTO
		dbo.[family] (fam_id, cat_id, fam_code, fam_name) 
	VALUES 
		((SELECT ISNULL(MAX(fam_id), 0) FROM family ) + 1, @catId, @famCode, @famName)

END
