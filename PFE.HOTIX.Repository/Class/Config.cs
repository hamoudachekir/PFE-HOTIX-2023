using PFE.HOTIX.DataLayer;
using PFE.HOTIX.DataLayer.DB;
using PFE.HOTIX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFE.HOTIX.Repository
{
    public static class Config
    {
        private static IConfig Config_DL;

        static Config()
        {
            Config_DL = new ConfigDB();
        }

        public static Entities.UserRoles GetAll()
        {
            return (Config_DL != null)
                   ? new Entities.UserRoles(Config_DL.GetAll())
                   : null;
        }

    }
}
