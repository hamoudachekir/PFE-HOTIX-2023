﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PFE.HOTIX.Entities
{
    public class Category
    {
        #region Constructors

        public Category()
        { 

        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; } 

        #endregion

        #region Methods   

        public override string ToString()
        {
            try
            {
                return ((this.Name != null) && (this.Name.Trim() != string.Empty)) 
                       ? this.Name 
                       : this.Code;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        } 

        #endregion

    }
}
