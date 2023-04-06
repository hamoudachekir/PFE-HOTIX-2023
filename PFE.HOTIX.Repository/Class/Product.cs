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
    public static class Product
    {
        private static IProduct Product_DL;

        static Product()
        {
            Product_DL = new ProductDB();
        }

        public static Entities.Products GetAll()
        {
            return (Product_DL != null)
                   ? new Entities.Products(Product_DL.GetAll())
                   : null;
        }
     

        public static bool Add(Entities.Product product)
        {
            return (Product_DL != null)
                   ? Product_DL.Add(product)
                   : false;
        }

        public static bool Update(Entities.Product product)
        {
            return (Product_DL != null)
                   ? Product_DL.Update(product)
                   : false;
        }

        public static bool Remove(Entities.Product product)
        {
            return (Product_DL != null)
                   ? Product_DL.Remove(product)
                   : false;
        }

    }
}
