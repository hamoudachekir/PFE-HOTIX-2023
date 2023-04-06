using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using PFE.HOTIX.Entities;

namespace PFE.HOTIX.DataLayer.DB
{
    public class ProductDB : IProduct
    {

        #region Enums 

        private enum enumQryProductFields
        {
            prod_id = 0,
            sfam_id,
            sfam_code,
            sfam_name,
            prod_ref,
            prod_code,
            prod_name,
            prod_desc,
            prod_image,
            prod_bar_code,
            prod_qtt,
            prod_unit_price
        }

        #endregion


        public IEnumerable<Product> GetAll()
        {
            Entities.Products Ret = new Entities.Products();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_prod_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.Product()
                            {
                                prodId = Convert.ToInt32(DR[(int)enumQryProductFields.prod_id]),

                                prodCode = (!DR.IsDBNull((int)enumQryProductFields.prod_code))
                                            ? DR[(int)enumQryProductFields.prod_code].ToString()
                                            : string.Empty,
                                prodRef = (!DR.IsDBNull((int)enumQryProductFields.prod_ref))
                                           ? DR[(int)enumQryProductFields.prod_ref].ToString()
                                           : string.Empty,
                                prodName = (!DR.IsDBNull((int)enumQryProductFields.prod_name))
                                           ? DR[(int)enumQryProductFields.prod_name].ToString()
                                           : string.Empty,
                                prodesc = (!DR.IsDBNull((int)enumQryProductFields.prod_desc))
                                           ? DR[(int)enumQryProductFields.prod_desc].ToString()
                                           : string.Empty,
                                prodImg = (!DR.IsDBNull((int)enumQryProductFields.prod_image))
                                           ? DR[(int)enumQryProductFields.prod_image].ToString()
                                           : string.Empty,
                                prodBarCode = (!DR.IsDBNull((int)enumQryProductFields.prod_bar_code))
                                              ? DR[(int)enumQryProductFields.prod_bar_code].ToString()
                                              : string.Empty,

                                prodqtt = (!DR.IsDBNull((int)enumQryProductFields.prod_qtt))
                                           ? Convert.ToInt32(DR[(int)enumQryProductFields.prod_qtt])
                                           : 0,

                                produnitprice = (!DR.IsDBNull((int)enumQryProductFields.prod_unit_price))
                                           ? Convert.ToDecimal(DR[(int)enumQryProductFields.prod_unit_price])
                                           : 0,

                                subFamily = new SubFamily()
                                {
                                    Id = (!DR.IsDBNull((int)enumQryProductFields.sfam_id))
                                         ? Convert.ToInt32(DR[(int)enumQryProductFields.sfam_id])
                                         : 0,
                                    sfamCode = (!DR.IsDBNull((int)enumQryProductFields.sfam_code))
                                           ? DR[(int)enumQryProductFields.sfam_code].ToString()
                                           : string.Empty,
                                    sfamName = (!DR.IsDBNull((int)enumQryProductFields.sfam_name))
                                           ? DR[(int)enumQryProductFields.sfam_name].ToString()
                                           : string.Empty,
                                    
                                    
                                    
                                },
                            });
                        }
                    }
                }

                return Ret;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
            finally
            {
                if (DR != null)
                {
                    DR.Close();
                    DR = null;
                }
            }
        }

        public bool Add(Product product)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_prod_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@sfamId", SqlDbType.Int);
                        command.Parameters["@sfamId"].Value = product.subFamily.Id;

                        command.Parameters.Add("@prodCode", SqlDbType.VarChar);
                        command.Parameters["@prodCode"].Value = product.prodCode;

                        command.Parameters.Add("@prodRef", SqlDbType.VarChar);
                        command.Parameters["@prodRef"].Value = product.prodRef;

                        command.Parameters.Add("@prodName", SqlDbType.VarChar);
                        command.Parameters["@prodName"].Value = product.prodName;

                        command.Parameters.Add("@prodesc", SqlDbType.VarChar);
                        command.Parameters["@prodesc"].Value = product.prodesc;

                        command.Parameters.Add("@prodImg", SqlDbType.VarChar);
                        command.Parameters["@prodImg"].Value = product.prodImg;

                        command.Parameters.Add("@prodBarCode", SqlDbType.VarChar);
                        command.Parameters["@prodBarCode"].Value = product.prodBarCode;

                        command.Parameters.Add("@prodqtt", SqlDbType.Int);
                        command.Parameters["@prodqtt"].Value = product.prodqtt;

                        command.Parameters.Add("@produnitprice", SqlDbType.Int);
                        command.Parameters["@produnitprice"].Value = product.produnitprice;

                        conn.Open();
                        Ret = command.ExecuteNonQuery();
                    }
                }

                return Ret > -1;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
        }

        public bool Update(Product product)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_prod_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@prodId", SqlDbType.Int);
                        command.Parameters["@prodId"].Value = product.prodId;

                        command.Parameters.Add("@sfam_Id", SqlDbType.Int);
                        command.Parameters["@sfam_Id"].Value = product.subFamily.Id;

                        command.Parameters.Add("@prodCode", SqlDbType.VarChar);
                        command.Parameters["@prodCode"].Value = product.prodCode;

                        command.Parameters.Add("@prodRef", SqlDbType.VarChar);
                        command.Parameters["@prodRef"].Value = product.prodRef;

                        command.Parameters.Add("@prodName", SqlDbType.VarChar);
                        command.Parameters["@prodName"].Value = product.prodName;

                        command.Parameters.Add("@prodesc", SqlDbType.VarChar);
                        command.Parameters["@prodesc"].Value = product.prodesc;

                        command.Parameters.Add("@prodImg", SqlDbType.VarChar);
                        command.Parameters["@prodImg"].Value = product.prodImg;

                        command.Parameters.Add("@prodBarCode", SqlDbType.VarChar);
                        command.Parameters["@prodBarCode"].Value = product.prodBarCode;

                        command.Parameters.Add("@prodqtt", SqlDbType.Int);
                        command.Parameters["@prodqtt"].Value = product.prodqtt;

                        command.Parameters.Add("@produnitprice", SqlDbType.Int);
                        command.Parameters["@produnitprice"].Value = product.produnitprice;

                        conn.Open();
                        Ret = command.ExecuteNonQuery();
                    }
                }

                return Ret > -1;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
        }

        public bool Remove(Product product)
        {
            int Ret = -1; 

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_prod_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@prodId", SqlDbType.Int);
                        command.Parameters["@prodId"].Value = product.prodId;

                        conn.Open();
                        Ret = command.ExecuteNonQuery(); 
                    }
                }

                return Ret > -1;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
        }

    }
}
