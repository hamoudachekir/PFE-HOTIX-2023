using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PFE.HOTIX.Entities
{
    public class Product
    {
        #region Constructors

        public Product()
        {
            subFamily = new SubFamily();
        }


        #endregion

        #region Properties

        public int prodId { get; set; }
        public string prodCode { get; set; }

        public string prodRef { get; set; }
        public string prodName { get; set; }
        public string prodesc { get; set; }
        public string prodImg { get; set; }
        public string prodBarCode { get; set; }
        public int prodqtt { get; set; }

        public decimal produnitprice { get; set; }

        public SubFamily subFamily { get; set; }

        #endregion

        #region Methods  

        public override string ToString()
        {
            try
            {
                return ((this.prodName != null) && (this.prodName.Trim() != string.Empty))
                       ? this.prodName
                       : this.prodCode;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        #endregion

    }
}
