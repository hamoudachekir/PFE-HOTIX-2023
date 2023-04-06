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
    public class FamilyDB : IFamily
    {

        #region Enums 

        private enum enumQryFamilyFields
        {
            fam_id = 0,
            cat_id,
            cat_code,
            cat_name,
            fam_code,
            fam_name
        }

        #endregion


        public IEnumerable<Family> GetAll()
        {
            Entities.Familys Ret = new Entities.Familys();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_fam_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.Family()
                            {
                                Id = Convert.ToInt32(DR[(int)enumQryFamilyFields.fam_id]),
                                famCode = (!DR.IsDBNull((int)enumQryFamilyFields.fam_code))
                                            ? DR[(int)enumQryFamilyFields.fam_code].ToString()
                                            : string.Empty,
                                famName = (!DR.IsDBNull((int)enumQryFamilyFields.fam_name))
                                           ? DR[(int)enumQryFamilyFields.fam_name].ToString()
                                           : string.Empty,  
                                category = new Category()
                                {
                                    Id = (!DR.IsDBNull((int)enumQryFamilyFields.cat_id))
                                         ? Convert.ToInt32(DR[(int)enumQryFamilyFields.cat_id])
                                         : 0,
                                    Code = (!DR.IsDBNull((int)enumQryFamilyFields.cat_code))
                                           ? DR[(int)enumQryFamilyFields.cat_code].ToString()
                                           : string.Empty,
                                    Name = (!DR.IsDBNull((int)enumQryFamilyFields.cat_name))
                                           ? DR[(int)enumQryFamilyFields.cat_name].ToString()
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
        public bool Add(Family family)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_fam_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@catId", SqlDbType.Int);
                        command.Parameters["@catId"].Value = family.category.Id;

                        command.Parameters.Add("@famCode", SqlDbType.VarChar);
                        command.Parameters["@famCode"].Value = family.famCode;

                        command.Parameters.Add("@famName", SqlDbType.VarChar);
                        command.Parameters["@famName"].Value = family.famName;

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

        public bool Update(Family family)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_fam_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@famId", SqlDbType.Int);
                        command.Parameters["@famId"].Value = family.Id;

                        command.Parameters.Add("@catId", SqlDbType.Int);
                        command.Parameters["@catId"].Value = family.category.Id;

                        command.Parameters.Add("@famCode", SqlDbType.VarChar);
                        command.Parameters["@famCode"].Value = family.famCode;

                        command.Parameters.Add("@famName", SqlDbType.VarChar);
                        command.Parameters["@famName"].Value = family.famName;


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

        public bool Remove(Family family)
        {
            int Ret = -1; 

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_prod_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@famId", SqlDbType.Int);
                        command.Parameters["@famId"].Value = family.Id;

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
