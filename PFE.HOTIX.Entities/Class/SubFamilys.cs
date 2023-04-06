using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFE.HOTIX.Entities
{
    public class SubFamilys : List<SubFamily>
    {
        public SubFamilys() : base() { }
        public SubFamilys(int capacity) : base(capacity) { }
        public SubFamilys(IEnumerable<SubFamily> collection) : base(collection) { }
    }

}
