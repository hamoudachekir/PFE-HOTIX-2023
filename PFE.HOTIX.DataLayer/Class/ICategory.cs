using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFE.HOTIX.DataLayer
{
    public interface ICategory
    {
        IEnumerable<Entities.Category> GetAll();

        bool Add(Entities.Category category);
        bool Update(Entities.Category category);
        bool Remove(Entities.Category category);
    }
}
