using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//add reference
using System.Numerics;

//Generate a form and show an initial Hanoi situation.
//Also show the number of moves required for the solution.
//Allow the user to modify the number of pegs and discs.
//Provide start and stop buttons.
//When started the actual situation is reset and solved; an enumerator on the solution moves is generated.
//Also a timer is enabled; on each tick the next move of the soulution is drawn in the actual situation.
//When stopped or finished the timer is disabled.

namespace Hanoi
{
    public partial class HanoiForm : Form
    {
        //display properties
        private int width = 800;
        private int height = 400;
        private Pen pen;

        //show analyse information
        private AnalyseForm analyse;

        //model of actual situation
        private HanoiState hanoiState;

        //generated moves of solution
        private bool nextMovePresent;
        private BigInteger movesDone;
        private HanoiSolution solution;
        private IEnumerator<HanoiMove> solutionEnum;

        //process control
        private bool drawing;
        private bool running;
        private bool stopRunning;

        // DISPLAY: show actual situation

        private void DrawDiscs(Graphics g)
        {
            int pegs = hanoiState.pegs;
            int discs = hanoiState.discs;

            foreach (Peg peg in hanoiState.pegList)
            {
                int x = peg.id * (width / pegs) - width / (2 * pegs);
                int halfPegWidth = (width / pegs) * 4 / 10;

                int yBase = height * 14 / 15;
                int yBase1000 = 1000 * yBase;
                int discHeight1000 = 1000 * (2 * yBase - height) / (discs + 1);
                int discHeight = discHeight1000 / 1000;

                int minHalfDiscWidth = discHeight / 2;
                if (minHalfDiscWidth < 2) minHalfDiscWidth = 2;
                if (2 * minHalfDiscWidth > halfPegWidth) minHalfDiscWidth = halfPegWidth / 2;

                foreach (Disc disc in peg.discList)
                {
                    int halfDiscWidth = minHalfDiscWidth + (disc.id * (halfPegWidth - minHalfDiscWidth) / discs);

                    g.DrawEllipse(pen, x - halfDiscWidth, yBase - discHeight, 2 * halfDiscWidth, discHeight);

                    yBase1000 -= discHeight1000;
                    yBase = yBase1000 / 1000;
                }
            }
        }

        private void DrawPegs(Graphics g)
        {
            int pegs = hanoiState.pegs;

            foreach (Peg peg in hanoiState.pegList)
            {
                int x = peg.id * (width / pegs) - width / (2 * pegs);
                int halfPegWidth = (width / pegs) * 4 / 10;

                int yBase = height * 14 / 15;
                int yTop = height - yBase;

                g.DrawLine(pen, new Point(x - halfPegWidth, yBase), new Point(x + halfPegWidth, yBase));
                g.DrawLine(pen, new Point(x, yBase), new Point(x, yTop));
             }
        }

        private void Redraw()
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                DrawPegs(g);
                DrawDiscs(g);
                g.Flush();
            }
            pictureBox1.Image = bitmap;
            this.Controls.Add(pictureBox1);
        }

        // RESET: start new situation and generate solution

        private void Reset(int pegs, int discs)
        {
            timer1.Interval = 100;
            timer1.Enabled = false;

            hanoiState = new HanoiState(pegs, discs);
            solution = new HanoiSolution(pegs, discs);

            solutionEnum = solution.GetEnumerator();
            nextMovePresent = solutionEnum.MoveNext();

            movesDone = 0;
            drawing = false;
            running = false;
            stopRunning = true;

            countToolStripTextBox.Text = movesDone.ToString() + " / " + solution.GetMoves();
            pegsToolStripComboBox.Text = pegs.ToString();
            discsToolStripComboBox.Text = discs.ToString();
        }

        // HANDLE EVENTS: timer when running or start/stop button

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (running && !drawing)
            {
                if (stopRunning || !nextMovePresent)
                {
                    //stop running: stop showing all moves of the solution
                    timer1.Enabled = false;
                    pegsToolStripComboBox.Enabled = true;
                    discsToolStripComboBox.Enabled = true;
                    running = false;
                    stopRunning = true;
                }
                else
                {
                    drawing = true;

                    //get next move
                    HanoiMove move = solutionEnum.Current;
                    nextMovePresent = solutionEnum.MoveNext();

                    //update situation
                    hanoiState.Move(move.source, move.target);
                    movesDone++;
                    countToolStripTextBox.Text = movesDone.ToString() + " / " + solution.GetMoves();

                    //refresh
                    Redraw();

                    drawing = false;
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!running && !drawing)
            {
                //default 3 pegs, max 20
                int pegs = 3;
                if (!Int32.TryParse(pegsToolStripComboBox.Text, out pegs) || pegs < 3 || pegs > 20)
                {
                    pegs = (pegs < 3 ? 3 : pegs > 20 ? 20 : pegs);
                    pegsToolStripComboBox.Text = pegs.ToString();
                }

                //default 5 discs, min 1, max 1000
                int discs = 5;
                if (!Int32.TryParse(discsToolStripComboBox.Text, out discs) || discs < 1 || discs > 1000)
                {
                    discs = (discs < 1 ? 1 : discs > 1000 ? 1000 : discs);
                    pegsToolStripComboBox.Text = discs.ToString();
                }

                Reset(pegs, discs);

                //start running: show all moves of the solution
                running = true;
                stopRunning = false;
                pegsToolStripComboBox.Enabled = false;
                discsToolStripComboBox.Enabled = false;
                timer1.Enabled = true;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (running)
            {
                stopRunning = true;
            }
        }

        private void analyseButton_Click(object sender, EventArgs e)
        {
            analyse.Clear();

            FrameStewart fs = solution.GetFrameStewart();

            for (int peg = 3; peg <= hanoiState.pegs; peg++)
            {
                for (int disc = 1; disc <= hanoiState.discs; disc++)
                {
                    if (fs.GetMoves(peg, disc) > BigInteger.Zero)
                    {
                        string line = String.Format("Pegs {0}, Discs {1}, Moves {2}, K {3}",
                            peg, disc, fs.GetMoves(peg, disc), fs.GetK(peg, disc));
                        analyse.WriteLines(line + Environment.NewLine);
                    }
                }
            }
        }

        // STARTUP

        public HanoiForm()
        {
            InitializeComponent();
            analyse = new AnalyseForm();
            pen = new Pen(Color.Black, 1);

            //initial 3 pegs and 5 discs
            Reset(3, 5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Redraw();
            analyse.Show();
        }
    }
}
