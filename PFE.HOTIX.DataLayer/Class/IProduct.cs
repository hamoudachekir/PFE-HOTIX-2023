using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFE.HOTIX.DataLayer
{
    public interface IProduct
    {
        IEnumerable<Entities.Product> GetAll();

        bool Add(Entities.Product product);
        bool Update(Entities.Product product);
        bool Remove(Entities.Product product);
    }
}
