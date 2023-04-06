using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFE.HOTIX.Entities
{
    public class Familys : List<Family>
    {
        public Familys() : base() { }
        public Familys(int capacity) : base(capacity) { }
        public Familys(IEnumerable<Family> collection) : base(collection) { }
    }

}
