CREATE PROCEDURE [dbo].[sp_prod_get_all] 
AS
BEGIN

	SELECT 
		p.prod_id,
		p.sfam_id,
		ISNULL(sf.sfam_code, '') AS sfam_code,
		ISNULL(sf.sfam_name, '') AS sfam_name,
		ISNULL(p.prod_ref, '') AS prod_ref,
		ISNULL(p.prod_code, '') AS prod_code,
		ISNULL(p.prod_name, '') AS prod_name,
		ISNULL(p.prod_desc, '') AS prod_desc,
		ISNULL(p.prod_image, '') AS prod_image,
		ISNULL(p.prod_bar_code, '') AS prod_bar_code,
		ISNULL(p.prod_qtt, 0) AS prod_qtt,
		ISNULL(p.prod_unit_price, 0) AS prod_unit_price
	FROM
		dbo.[product] p
		
		LEFT JOIN sub_family sf ON sf.sfam_id =  p.sfam_id
	ORDER BY
		p.prod_id ASC

END
