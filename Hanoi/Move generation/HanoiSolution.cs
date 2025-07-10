using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//add reference
using System.Numerics;

namespace Hanoi
{
    class HanoiSolution : IEnumerable<HanoiMove>
    {
        private int pegs;
        private int discs;
        private FrameStewart frameStewart;
        private PegPool pegPool;
        private Stack<HanoiMove> stack;

        public IEnumerator<HanoiMove> GetEnumerator()
        {
            stack = new Stack<HanoiMove>();
            HanoiMove move = new HanoiMove(pegs, discs, 1, pegs);
            stack.Push(move);

            while (stack.Count > 0)
            {
                move = stack.Pop();

                if (move.discs == 0)
                {
                    if (move.source > 0) pegPool.Lock(move.source);
                    if (move.target > 0) pegPool.Unlock(move.target);
                }
                else if (move.discs == 1)
                {
                    yield return move;
                }
                else // move.discs > 1
                {
                    int k = frameStewart.GetK(move.pegs, move.discs);
                    int freePeg = pegPool.GetFreePeg(move.source, move.target);

                    HanoiMove move1 = new HanoiMove(move.pegs, k, move.source, freePeg);
                    HanoiMove lockPeg = new HanoiMove(0, 0, freePeg, 0);
                    HanoiMove move2 = new HanoiMove(move.pegs - 1, move.discs - k, move.source, move.target);
                    HanoiMove unlockPeg = new HanoiMove(0, 0, 0, freePeg);
                    HanoiMove move3 = new HanoiMove(move.pegs, k, freePeg, move.target);

                    stack.Push(move3);
                    stack.Push(unlockPeg);
                    stack.Push(move2);
                    stack.Push(lockPeg);
                    stack.Push(move1);
                }
            }
        }

        private IEnumerator GetEnumeratorNongeneric() { return this.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumeratorNongeneric(); }

        public BigInteger GetMoves()
        {
            return frameStewart.GetMoves(pegs, discs);
        }

        public FrameStewart GetFrameStewart()
        {
            return frameStewart;
        }

        public HanoiSolution(int pegs, int discs)
        {
            this.pegs = pegs;
            this.discs = discs;

            frameStewart = new FrameStewart(pegs, discs);
            pegPool = new PegPool(pegs);
        }
    }
}
