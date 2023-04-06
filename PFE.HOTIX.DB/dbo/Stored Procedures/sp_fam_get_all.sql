CREATE PROCEDURE [dbo].[sp_fam_get_all] 
AS
BEGIN

	SELECT 
		f.fam_id, 
		ISNULL(c.cat_id, '') AS cat_id,
		ISNULL(c.cat_code, '') AS cat_code,
		ISNULL(c.cat_name, '') AS cat_name,
		ISNULL(f.fam_code, '') AS fam_code,
		ISNULL(f.fam_name, '') AS fam_name
	FROM
		dbo.[family] f
		LEFT JOIN dbo.[category] c ON c.cat_id = f.cat_id
	ORDER BY
		f.fam_id ASC

END
