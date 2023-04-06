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
    public static class SubFamily
    {
        private static ISubFamily SubFamily_DL;

        static SubFamily()
        {
            SubFamily_DL = new SubFamilyDB();
        }

        public static Entities.SubFamilys GetAll()
        {
            return (SubFamily_DL != null)
                   ? new Entities.SubFamilys(SubFamily_DL.GetAll())
                   : null;
        }
        public static bool Add(Entities.SubFamily subfamily)
        {
            return (SubFamily_DL != null)
                   ? SubFamily_DL.Add(subfamily)
                   : false;
        }

        public static bool Update(Entities.SubFamily subfamily)
        {
            return (SubFamily_DL != null)
                   ? SubFamily_DL.Update(subfamily)
                   : false;
        }

        public static bool Remove(Entities.SubFamily subfamily)
        {
            return (SubFamily_DL != null)
                   ? SubFamily_DL.Remove(subfamily)
                   : false;
        }

    }
}
