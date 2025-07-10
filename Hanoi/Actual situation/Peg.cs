using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    // Part of the actual sitation.
    // Each peg has an ID, and contains a list of discs.

    class Peg
    {
        public int id { get; }
        public List<Disc> discList { get; }

        public Disc Peek()
        {
            if (discList.Count == 0) return null;

            Disc disc = discList.ElementAt(discList.Count - 1);
            return disc;
        }

        public Disc Pop()
        {
            if (discList.Count == 0) return null;

            Disc disc = discList.ElementAt(discList.Count - 1);
            discList.RemoveAt(discList.Count - 1);
            return disc;
        }

        public void Push(Disc disc)
        {
            discList.Add(disc);
        }

        public Peg(int id)
        {
            this.id = id;
            discList = new List<Disc>();
        }
    }
}
