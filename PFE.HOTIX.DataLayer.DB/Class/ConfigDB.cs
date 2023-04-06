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
    public class ConfigDB : IConfig
    {

        #region Enums 

        private enum enumQryUserFields
        { 
            role_id = 0,
            role_code,
            role_name
        }

        #endregion
         
        public IEnumerable<UserRole> GetAll()
        {
            Entities.UserRoles Ret = new Entities.UserRoles();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_role_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.UserRole()
                            { 
                                    Id = (!DR.IsDBNull((int)enumQryUserFields.role_id))
                                         ? Convert.ToInt32(DR[(int)enumQryUserFields.role_id])
                                         : 0,
                                    Code = (!DR.IsDBNull((int)enumQryUserFields.role_code))
                                           ? DR[(int)enumQryUserFields.role_code].ToString()
                                           : string.Empty,
                                    Name = (!DR.IsDBNull((int)enumQryUserFields.role_name))
                                           ? DR[(int)enumQryUserFields.role_name].ToString()
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

    }
}
