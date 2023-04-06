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
    public static class Family
    {
        private static IFamily Family_DL;

        static Family()
        {
            Family_DL = new FamilyDB();
        }

        public static Entities.Familys GetAll()
        {
            return (Family_DL != null)
                   ? new Entities.Familys(Family_DL.GetAll())
                   : null;
        }
        public static bool Add(Entities.Family family)
        {
            return (Family_DL != null)
                   ? Family_DL.Add(family)
                   : false;
        }

        public static bool Update(Entities.Family family)
        {
            return (Family_DL != null)
                   ? Family_DL.Update(family)
                   : false;
        }

        public static bool Remove(Entities.Family family)
        {
            return (Family_DL != null)
                   ? Family_DL.Remove(family)
                   : false;
        }

    }
}
