using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFE.HOTIX.DataLayer
{
    public interface IFamily
    {
        IEnumerable<Entities.Family> GetAll();

        bool Add(Entities.Family family);
        bool Update(Entities.Family family);
        bool Remove(Entities.Family family);
    }
}
