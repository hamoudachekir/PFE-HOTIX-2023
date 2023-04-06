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
    public static class Category
    {
        private static ICategory Category_DL;

        static Category()
        {
            Category_DL = new CategoryDB();
        }

        public static Entities.Categorys GetAll()
        {
            return (Category_DL != null)
                   ? new Entities.Categorys(Category_DL.GetAll())
                   : null;
        }
        public static bool Add(Entities.Category category)
        {
            return (Category_DL != null)
                   ? Category_DL.Add(category)
                   : false;
        }

        public static bool Update(Entities.Category category)
        {
            return (Category_DL != null)
                   ? Category_DL.Update(category)
                   : false;
        }

        public static bool Remove(Entities.Category category)
        {
            return (Category_DL != null)
                   ? Category_DL.Remove(category)
                   : false;
        }

    }
}
