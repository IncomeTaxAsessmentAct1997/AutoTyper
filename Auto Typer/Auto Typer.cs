namespace Auto_Typer
{
    public partial class AutoTyper : Form
    {
        private readonly RectangleDrawer rectangleDrawer;
        private Button? clickedButton;
        private string originalButtonText = "Hotkey";

        public AutoTyper()
        {
            InitializeComponent();
            rectangleDrawer = new RectangleDrawer();
            MainText.Enter += new EventHandler(TextBox_Enter);
            MainText.Leave += new EventHandler(TextBox_Leave);
            MainText.KeyPress += new KeyPressEventHandler(Delay_KeyPress);
            this.Paint += new PaintEventHandler(this.AutoTyper_Paint);
        }
        private void AutoTyper_Paint(object? sender, PaintEventArgs e)
        {
            RectangleDrawer.DrawRectangles(e.Graphics);
            ControlPaint.DrawBorder(e.Graphics, MainText.Bounds, Color.Black, ButtonBorderStyle.Solid);
        }

        private void Hotkey_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Button btn)
            {
                clickedButton = btn;
                originalButtonText = btn.Text;
                btn.Text = "Press Any Key";
                btn.Focus();
                btn.KeyDown += new KeyEventHandler(Hotkey_KeyDown);
            }
        }

        private void Hotkey_KeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is Button btn)
            {
                btn.Text = $"{e.KeyCode}";
            }
        }

        private void TextBox_Enter(object? sender, EventArgs e)
        {
            if (sender is TextBox && clickedButton != null)
            {
                clickedButton.Text = originalButtonText;
            }
        }

        private void TextBox_Leave(object? sender, EventArgs e)
        {
            if (sender is TextBox && clickedButton != null)
            {
                clickedButton.Text = originalButtonText;
            }
        }

        private void Delay_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void DelayMax_TextChanged(object sender, EventArgs e)
        {

        }
    }
}