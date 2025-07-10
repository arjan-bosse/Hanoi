using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    // Part of the actual sitation.
    // Each disc has an ID.

    class Disc
    {
        public int id { get; }

        public Disc(int id)
        {
            this.id = id;
        }
    }
}
