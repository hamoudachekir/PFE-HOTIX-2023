using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFE.HOTIX.Entities
{
    public class Categorys : List<Category>
    {
        public Categorys() : base() { }
        public Categorys(int capacity) : base(capacity) { }
        public Categorys(IEnumerable<Category> collection) : base(collection) { }
    }

}
