using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    // Model of actual shown Hanoi situation.
    // Contains a list of pegs, and per peg a list of discs.
    // Initial situation is all discs on the first peg.

    class HanoiState
    {
        public int pegs { get; }
        public int discs { get; }
        public List<Peg> pegList { get; }

        private Peg GetPeg(int id)
        {
            return pegList.Find(p => p.id == id);
        }

        public void Move(int source, int target)
        {
            Disc disc = GetPeg(source).Pop();
            GetPeg(target).Push(disc);
        }

        public HanoiState(int pegs, int discs)
        {
            this.pegs = pegs;
            this.discs = discs;

            pegList = new List<Peg>();

            for (int p = 1; p <= pegs; p++)
            {
                pegList.Add(new Peg(p));
            }

            for (int d = discs; d >= 1; d--)
            {
                pegList.First().Push(new Disc(d));
            }
        }
    }
}
