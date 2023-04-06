using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFE.HOTIX.DataLayer
{
    public interface ISubFamily
    {
        IEnumerable<Entities.SubFamily> GetAll();

        bool Add(Entities.SubFamily sfamily);
        bool Update(Entities.SubFamily sfamily);
        bool Remove(Entities.SubFamily sfamily);
    }
}
