CREATE PROCEDURE [dbo].[sp_sub_fam_get_all] 
AS
BEGIN

	SELECT 
		s.sfam_id,
		f.fam_id,
		ISNULL(f.fam_code, '') AS fam_code,
		ISNULL(f.fam_name, '') AS fam_name,
		ISNULL(s.sfam_code, '') AS sfam_code,
		ISNULL(s.sfam_name, '') AS sfam_name
	FROM
		dbo.[sub_family] s
		LEFT JOIN family f ON f.fam_id = s.fam_id
	ORDER BY
		s.sfam_id ASC

END
