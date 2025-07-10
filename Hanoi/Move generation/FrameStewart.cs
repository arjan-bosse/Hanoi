using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//add reference
using System.Numerics;

namespace Hanoi
{
    class FrameStewart
    {
        private BigInteger[,] moves;
        private int[,] klist;

        private BigInteger Calc(int pegs, int discs)
        {
            if (moves[pegs, discs] == BigInteger.Zero)
            {
                if (discs == 1)
                {
                    moves[pegs, discs] = BigInteger.One;
                    klist[pegs, discs] = 0;
                }
                else // discs > 1
                {
                    if (pegs == 3)
                    {
                        int k = discs - 1;
                        BigInteger m = Calc(pegs, k) + BigInteger.One + Calc(pegs, k);

                        moves[pegs, discs] = m;
                        klist[pegs, discs] = k;
                    }
                    else // pegs > 3
                    {
                        int foundK = 0;
                        BigInteger minMoves = BigInteger.MinusOne;

                        for (int k = discs - 1; k >= 1; k--)
                        {
                            BigInteger m = Calc(pegs, k) + Calc(pegs - 1, discs - k) + Calc(pegs, k);

                            if (minMoves == BigInteger.MinusOne || m < minMoves)
                            {
                                minMoves = m;
                                foundK = k;
                            }
                            else if (m > minMoves)
                            {
                                break;
                            }
                        }

                        moves[pegs, discs] = minMoves;
                        klist[pegs, discs] = foundK;
                    }
                }
            }

            return moves[pegs, discs];
        }

        public int GetK(int pegs, int discs)
        {
            return klist[pegs, discs];
        }

        public BigInteger GetMoves(int pegs, int discs)
        {
            return moves[pegs, discs];
        }

        public FrameStewart(int pegs, int discs)
        {
            moves = new BigInteger[pegs + 1, discs + 1];
            klist = new int[pegs + 1, discs + 1];

            Calc(pegs, discs);
        }
    }
}
