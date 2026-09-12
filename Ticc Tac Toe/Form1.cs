using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Ticc_Tac_Toe
{
    public partial class Form1 : Form
    {
        private const string PLAYER = "X";
        private const string CPU = "O";

        private Button[] buttons;

        private int[][] winningCombinations = new int[][]
        {
            new int[] { 1, 2, 3 }, // Row 1
            new int[] { 4, 5, 6 }, // Row 2
            new int[] { 7, 8, 9 }, // Row 3

            new int[] { 1, 4, 7 }, // Column 1
            new int[] { 2, 5, 8 }, // Column 2
            new int[] { 3, 6, 9 }, // Column 3

            new int[] { 1, 5, 9 }, // Diagonal 1
            new int[] { 3, 5, 7 }  // Diagonal 2
        };

        public Form1()
        {
            InitializeComponent();

            buttons = new[]
            {
                button1, button2, button3,
                button4, button5, button6,
                button7, button8, button9
            };

            foreach (var btn in buttons)
                btn.Click += PlayerMove;

            ClearGame();
        }

        private void PlayerMove(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                Hit(btn, PLAYER);
            }
        }

        private void Hit(Button btn, string val)
        {
            btn.Text = val;
            btn.Enabled = false;
            btn.Update();

            if (!CheckWinner() && val == PLAYER)
            {
                Thread.Sleep(500);
                Prio1();
            }

            if (val == CPU)
            {
                CheckWinner();
            }
        }

        private void Prio1()
        {
            // HORIZONTAL
            if (button1.Text == CPU && button2.Text == CPU && button3.Text == "")
                Hit(button3, CPU);
            else if (button1.Text == CPU && button2.Text == "" && button3.Text == CPU)
                Hit(button2, CPU);
            else if (button1.Text == "" && button2.Text == CPU && button3.Text == CPU)
                Hit(button1, CPU);

            else if (button4.Text == CPU && button5.Text == CPU && button6.Text == "")
                Hit(button6, CPU);
            else if (button4.Text == CPU && button5.Text == "" && button6.Text == CPU)
                Hit(button5, CPU);
            else if (button4.Text == "" && button5.Text == CPU && button6.Text == CPU)
                Hit(button4, CPU);

            else if (button7.Text == CPU && button8.Text == CPU && button9.Text == "")
                Hit(button9, CPU);
            else if (button7.Text == CPU && button8.Text == "" && button9.Text == CPU)
                Hit(button8, CPU);
            else if (button7.Text == "" && button8.Text == CPU && button9.Text == CPU)
                Hit(button7, CPU);

            // VERTICAL
            else if (button1.Text == CPU && button4.Text == CPU && button7.Text == "")
                Hit(button7, CPU);
            else if (button1.Text == CPU && button4.Text == "" && button7.Text == CPU)
                Hit(button4, CPU);
            else if (button1.Text == "" && button4.Text == CPU && button7.Text == CPU)
                Hit(button1, CPU);

            else if (button2.Text == CPU && button5.Text == CPU && button8.Text == "")
                Hit(button8, CPU);
            else if (button2.Text == CPU && button5.Text == "" && button8.Text == CPU)
                Hit(button5, CPU);
            else if (button2.Text == "" && button5.Text == CPU && button8.Text == CPU)
                Hit(button2, CPU);

            else if (button3.Text == CPU && button6.Text == CPU && button9.Text == "")
                Hit(button9, CPU);
            else if (button3.Text == CPU && button6.Text == "" && button9.Text == CPU)
                Hit(button6, CPU);
            else if (button3.Text == "" && button6.Text == CPU && button9.Text == CPU)
                Hit(button3, CPU);

            // DIAGONAL
            else if (button1.Text == CPU && button5.Text == CPU && button9.Text == "")
                Hit(button9, CPU);
            else if (button1.Text == CPU && button5.Text == "" && button9.Text == CPU)
                Hit(button5, CPU);
            else if (button1.Text == "" && button5.Text == CPU && button9.Text == CPU)
                Hit(button1, CPU);

            else if (button3.Text == CPU && button5.Text == CPU && button7.Text == "")
                Hit(button7, CPU);
            else if (button3.Text == CPU && button5.Text == "" && button7.Text == CPU)
                Hit(button5, CPU);
            else if (button3.Text == "" && button5.Text == CPU && button7.Text == CPU)
                Hit(button3, CPU);

            else
                Prio2();
        }

        private void Prio2()
        {
            // HORIZONTAL
            if (button1.Text == PLAYER && button2.Text == PLAYER && button3.Text == "")
                Hit(button3, CPU);
            else if (button1.Text == PLAYER && button2.Text == "" && button3.Text == PLAYER)
                Hit(button2, CPU);
            else if (button1.Text == "" && button2.Text == PLAYER && button3.Text == PLAYER)
                Hit(button1, CPU);

            else if (button4.Text == PLAYER && button5.Text == PLAYER && button6.Text == "")
                Hit(button6, CPU);
            else if (button4.Text == PLAYER && button5.Text == "" && button6.Text == PLAYER)
                Hit(button5, CPU);
            else if (button4.Text == "" && button5.Text == PLAYER && button6.Text == PLAYER)
                Hit(button4, CPU);

            else if (button7.Text == PLAYER && button8.Text == PLAYER && button9.Text == "")
                Hit(button9, CPU);
            else if (button7.Text == PLAYER && button8.Text == "" && button9.Text == PLAYER)
                Hit(button8, CPU);
            else if (button7.Text == "" && button8.Text == PLAYER && button9.Text == PLAYER)
                Hit(button7, CPU);

            // VERTICAL
            else if (button1.Text == PLAYER && button4.Text == PLAYER && button7.Text == "")
                Hit(button7, CPU);
            else if (button1.Text == PLAYER && button4.Text == "" && button7.Text == PLAYER)
                Hit(button4, CPU);
            else if (button1.Text == "" && button4.Text == PLAYER && button7.Text == PLAYER)
                Hit(button1, CPU);

            else if (button2.Text == PLAYER && button5.Text == PLAYER && button8.Text == "")
                Hit(button8, CPU);
            else if (button2.Text == PLAYER && button5.Text == "" && button8.Text == PLAYER)
                Hit(button5, CPU);
            else if (button2.Text == "" && button5.Text == PLAYER && button8.Text == PLAYER)
                Hit(button2, CPU);

            else if (button3.Text == PLAYER && button6.Text == PLAYER && button9.Text == "")
                Hit(button9, CPU);
            else if (button3.Text == PLAYER && button6.Text == "" && button9.Text == PLAYER)
                Hit(button6, CPU);
            else if (button3.Text == "" && button6.Text == PLAYER && button9.Text == PLAYER)
                Hit(button3, CPU);

            // DIAGONAL
            else if (button1.Text == PLAYER && button5.Text == PLAYER && button9.Text == "")
                Hit(button9, CPU);
            else if (button1.Text == PLAYER && button5.Text == "" && button9.Text == PLAYER)
                Hit(button5, CPU);
            else if (button1.Text == "" && button5.Text == PLAYER && button9.Text == PLAYER)
                Hit(button1, CPU);

            else if (button3.Text == PLAYER && button5.Text == PLAYER && button7.Text == "")
                Hit(button7, CPU);
            else if (button3.Text == PLAYER && button5.Text == "" && button7.Text == PLAYER)
                Hit(button5, CPU);
            else if (button3.Text == "" && button5.Text == PLAYER && button7.Text == PLAYER)
                Hit(button3, CPU);

            else
                Prio3();
        }

        private void Prio3()
        {
            var vacantBtn = buttons.Where(btn => btn.Text == "").ToList();

            if (vacantBtn.Any())
            {
                var random = new Random();
                var btn = vacantBtn[random.Next(vacantBtn.Count)];
                Hit(btn, CPU);
            }
        }

        private bool CheckWinner()
        {
            return false;
        }

        private void ClearGame()
        {
            foreach (var button in buttons)
            {
                button.Text = "";
                button.Enabled = true;
            }
        }
    }
}