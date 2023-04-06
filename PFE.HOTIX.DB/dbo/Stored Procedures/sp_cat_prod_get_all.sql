CREATE PROCEDURE [dbo].[sp_cat_prod_get_all] 
AS
BEGIN

	SELECT 
		c.cat_id,
		ISNULL(c.cat_code, '') AS cat_code,
		ISNULL(c.cat_name, '') AS cat_name
	FROM
		dbo.[category] c
	ORDER BY
		c.cat_id ASC

END
