using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFE.HOTIX.Entities
{
    public class Products : List<Product>
    {
        public Products() : base() { }
        public Products(int capacity) : base(capacity) { }
        public Products(IEnumerable<Product> collection) : base(collection) { }
    }

}
