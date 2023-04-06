CREATE PROCEDURE [dbo].[sp_prod_insert]
	@sfamId int,
	@prodCode VARCHAR(100),
	@prodRef VARCHAR(100),
	@prodName VARCHAR(100),
	@prodesc VARCHAR(100),
	@prodImg VARCHAR(MAX),	
	@prodBarCode VARCHAR(100),
	@prodqtt int,
	@produnitprice decimal
AS
BEGIN

	INSERT INTO
		dbo.[product] (sfam_id, prod_code, prod_ref, prod_name, prod_desc, prod_image, prod_bar_code, prod_qtt, prod_unit_price) 
	VALUES 
		(@sfamId, @prodCode, @prodRef, @prodName, @prodesc, @prodImg, @prodBarCode, @prodqtt,  @produnitprice)

END
