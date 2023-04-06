CREATE PROCEDURE [dbo].[sp_prod_update]
	@prodId int,
	@sfam_Id int,
	@prodRef VARCHAR(10) NULL,
	@prodCode VARCHAR(10) NULL,
	@prodName VARCHAR(50) NULL,
	@prodesc VARCHAR(250) NULL,
	@prodImg VARCHAR(MAX) NULL,
	@prodBarCode VARCHAR(100),
	@prodqtt int,
	@produnitprice DECIMAL
AS
BEGIN

	UPDATE
		dbo.[product] 
	SET
		sfam_id = @sfam_Id,
		prod_ref = @prodRef,
		prod_code = @prodCode,
		prod_name = @prodName,
		prod_desc = @prodesc,
		prod_image = @prodImg,
		prod_bar_code = @prodBarCode,
		prod_qtt = @prodqtt,
		prod_unit_price = @produnitprice
	WHERE
		prod_id = @prodId

END
