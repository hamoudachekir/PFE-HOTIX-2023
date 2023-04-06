using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PFE.HOTIX.Entities
{
    public class Family
    {
        #region Constructors

        public Family()
        {
            category = new Category();
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string famCode { get; set; }
        public string famName { get; set; }

        public Category category { get; set; }

        #endregion

        #region Methods   

        public override string ToString()
        {
            try
            {
                return ((this.famName != null) && (this.famName.Trim() != string.Empty)) 
                       ? this.famName 
                       : this.famCode;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        } 

        #endregion

    }
}
