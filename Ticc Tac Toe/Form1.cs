namespace Ticc_Tac_Toe
{
    public partial class Form1 : Form
    {
        private Button[] buttons;

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

        private void PlayerMove(object sender, EventArgs e)
        {
            Button btn = (sender as Button);

            if (btn is Button)
            {
                btn.Text = "X";
                btn.Enabled = false;
            }
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