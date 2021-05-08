using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.Entity
{
    class CBBItem
    {
        public int? Value { get; set; }
        public String Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
