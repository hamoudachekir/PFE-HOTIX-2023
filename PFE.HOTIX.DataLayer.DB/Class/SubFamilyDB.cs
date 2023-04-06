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
    public class SubFamilyDB : ISubFamily
    {

        #region Enums 

        private enum enumQrySubFamilyFields
        {
            sfam_id = 0,
            fam_id,
            fam_code,
            fam_name,
            sfam_code,
            sfam_name
        }

        #endregion


        public IEnumerable<SubFamily> GetAll()
        {
            Entities.SubFamilys Ret = new Entities.SubFamilys();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_sub_fam_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.SubFamily()
                            {
                                Id = Convert.ToInt32(DR[(int)enumQrySubFamilyFields.sfam_id]),
                                sfamCode = (!DR.IsDBNull((int)enumQrySubFamilyFields.sfam_code))
                                            ? DR[(int)enumQrySubFamilyFields.sfam_code].ToString()
                                            : string.Empty,
                                sfamName = (!DR.IsDBNull((int)enumQrySubFamilyFields.sfam_name))
                                           ? DR[(int)enumQrySubFamilyFields.sfam_name].ToString()
                                           : string.Empty,

                                family = new Family()
                                {
                                    Id = (!DR.IsDBNull((int)enumQrySubFamilyFields.fam_id))
                                         ? Convert.ToInt32(DR[(int)enumQrySubFamilyFields.fam_id])
                                         : 0,
                                    famCode = (!DR.IsDBNull((int)enumQrySubFamilyFields.fam_code))
                                           ? DR[(int)enumQrySubFamilyFields.fam_code].ToString()
                                           : string.Empty,
                                    famName = (!DR.IsDBNull((int)enumQrySubFamilyFields.fam_name))
                                           ? DR[(int)enumQrySubFamilyFields.fam_name].ToString()
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

        public bool Add(SubFamily subFamily)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_sub_fam_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@famId", SqlDbType.Int);
                        command.Parameters["@famId"].Value = subFamily.family.Id;

                        command.Parameters.Add("@sfamCode", SqlDbType.VarChar);
                        command.Parameters["@sfamCode"].Value = subFamily.sfamCode;

                        command.Parameters.Add("@sfamName", SqlDbType.VarChar);
                        command.Parameters["@sfamName"].Value = subFamily.sfamName;

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

        public bool Update(SubFamily subFamily)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_prod_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@sfamId", SqlDbType.Int);
                        command.Parameters["@sfamId"].Value = subFamily.Id;

                        command.Parameters.Add("@scatId", SqlDbType.Int);
                        command.Parameters["@scatId"].Value = subFamily.family.Id;

                        command.Parameters.Add("@sfamCode", SqlDbType.VarChar);
                        command.Parameters["@sfamCode"].Value = subFamily.sfamCode;

                        command.Parameters.Add("@sfamName", SqlDbType.VarChar);
                        command.Parameters["@sfamName"].Value = subFamily.sfamName;

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

        public bool Remove(SubFamily subfamily)
        {
            int Ret = -1; 

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_sub_fam_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@sfamId", SqlDbType.Int);
                        command.Parameters["@sfamId"].Value = subfamily.Id;

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
