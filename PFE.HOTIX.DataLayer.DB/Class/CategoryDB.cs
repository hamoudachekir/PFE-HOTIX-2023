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
    public class CategoryDB : ICategory
    {

        #region Enums 

        private enum enumQryCategoryFields
        {
            cat_id = 0,
            cat_code,
            cat_name
        }

        #endregion


        public IEnumerable<Category> GetAll()
        {
            Entities.Categorys Ret = new Entities.Categorys();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_cat_prod_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.Category()
                            {
                                Id = Convert.ToInt32(DR[(int)enumQryCategoryFields.cat_id]),
                                Code = (!DR.IsDBNull((int)enumQryCategoryFields.cat_code))
                                       ? DR[(int)enumQryCategoryFields.cat_code].ToString()
                                       : string.Empty,
                                Name = (!DR.IsDBNull((int)enumQryCategoryFields.cat_name))
                                       ? DR[(int)enumQryCategoryFields.cat_name].ToString()
                                       : string.Empty,
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

        public bool Add(Category category)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_cat_prod_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@catId", SqlDbType.VarChar);
                        command.Parameters["@catId"].Value = category.Id;

                        command.Parameters.Add("@catCode", SqlDbType.VarChar);
                        command.Parameters["@catCode"].Value = category.Code;

                        command.Parameters.Add("@catName", SqlDbType.VarChar);
                        command.Parameters["@catName"].Value = category.Name;

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

        public bool Update(Category category)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_cat_prod_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@catId", SqlDbType.Int);
                        command.Parameters["@catId"].Value = category.Id;

                        command.Parameters.Add("@catCode", SqlDbType.VarChar);
                        command.Parameters["@catCode"].Value = category.Code;

                        command.Parameters.Add("@catName", SqlDbType.VarChar);
                        command.Parameters["@catName"].Value = category.Name;


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

        public bool Remove(Category category)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_cat_prod_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@catId", SqlDbType.Int);
                        command.Parameters["@catId"].Value = category.Id;

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
