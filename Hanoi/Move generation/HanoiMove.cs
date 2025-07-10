using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    struct HanoiMove
    {
        public int pegs { get; }
        public int discs { get; }
        public int source { get; }
        public int target { get; }

        public HanoiMove(int pegs, int discs, int source, int target)
        {
            this.pegs = pegs;
            this.discs = discs;
            this.source = source;
            this.target = target;
        }
    }
}
