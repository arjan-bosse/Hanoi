using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    class PegPool
    {
        private bool[] available;

        public void Lock(int peg)
        {
            available[peg] = false;
        }

        public void Unlock(int peg)
        {
            available[peg] = true;
        }

        public int GetFreePeg(int source, int target)
        {
            for (int p = 1; p < available.Length; p++)
            {
                if (p != source && p != target && available[p])
                {
                    return p;
                }
            }

            return 0;
        }

        public PegPool(int pegs)
        {
            available = new bool[pegs + 1];

            for (int p = 1; p <= pegs; p++)
            {
                available[p] = true;
            }
        }
    }
}
