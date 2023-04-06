using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PFE.HOTIX.Entities
{
    public class SubFamily
    {
        #region Constructors

        public SubFamily()
        {
            family = new Family();
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string sfamCode { get; set; }
        public string sfamName { get; set; }

        public Family family { get; set; }

        #endregion

        #region Methods  

        public override string ToString()
        {
            try
            {
                return ((this.sfamName != null) && (this.sfamName.Trim() != string.Empty))
                       ? this.sfamName
                       : this.sfamCode;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        #endregion

    }
}
