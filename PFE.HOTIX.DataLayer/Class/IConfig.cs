using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFE.HOTIX.DataLayer
{
    public interface IConfig
    {
        IEnumerable<Entities.UserRole> GetAll();
    }
}
