using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFE.HOTIX.Entities
{
    public static class Enumeration
    {
        public enum Langue
        {
            AR = 1,
            FR,
            EN
        }

        public enum UserRole
        {
            ADMIN = 1,
            VEND,
            USER
        }
    }
}
