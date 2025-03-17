namespace Auto_Typer
{
    public partial class AutoTyper : Form
    {
        private readonly RectangleDrawer rectangleDrawer;
        private Button? clickedButton;
        private string originalButtonText = "Hotkey";
        private bool isHotkeyMouseDown = false;

        public AutoTyper()
        {
            InitializeComponent();
            rectangleDrawer = new RectangleDrawer();
            this.Paint += AutoTyper_Paint;
        }

        private void Form_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                e.IsInputKey = true;
        }

        private void AutoTyper_Paint(object? sender, PaintEventArgs e)
        {
            RectangleDrawer.DrawRectangles(e.Graphics);
            ControlPaint.DrawBorder(e.Graphics, MainText.Bounds, Color.Black, ButtonBorderStyle.Solid);
        }

        private void Hotkey_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is not Button btn)
                return;

            if (clickedButton != btn)
            {
                ResetPreviousButton();
                SetupButtonForHotkeyInput(btn);
            }
        }

        private void ResetPreviousButton()
        {
            if (clickedButton != null)
            {
                clickedButton.Text = originalButtonText;
                clickedButton.KeyDown -= Hotkey_KeyDown;
                clickedButton.LostFocus -= Hotkey_LostFocus;
            }
        }

        private void SetupButtonForHotkeyInput(Button btn)
        {
            clickedButton = btn;
            originalButtonText = btn.Text;
            btn.Text = "Press Any Key";
            btn.Focus();
            btn.KeyDown += Hotkey_KeyDown;
            btn.LostFocus += Hotkey_LostFocus;
        }

        private void Hotkey_KeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is not Button btn || clickedButton == null)
                return;

            string keyPressed = GetKeyName(e);
            Console.WriteLine($"Button clicked: {clickedButton?.Name}, Key pressed: {keyPressed}");

            if (HasDuplicateHotkey(keyPressed))
            {
                MessageBox.Show("Can't have the same key for both Start/Pause, and Stop", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetButton(btn);
            }
            else
            {
                btn.Text = keyPressed;
                isHotkeyMouseDown = true;
                btn.KeyDown -= Hotkey_KeyDown;
                btn.LostFocus -= Hotkey_LostFocus;
                clickedButton = null;
            }
        }

        private bool HasDuplicateHotkey(string keyPressed)
        {
            return (clickedButton == Hotkey1 && keyPressed == Hotkey2.Text) ||
                   (clickedButton == Hotkey2 && keyPressed == Hotkey1.Text);
        }

        private void ResetButton(Button btn)
        {
            btn.Text = originalButtonText;
            isHotkeyMouseDown = false;
        }

        private static string GetKeyName(KeyEventArgs e)
        {
            string keyName = e.KeyCode switch
            {
                Keys.D1 => "1",
                Keys.D2 => "2",
                Keys.D3 => "3",
                Keys.D4 => "4",
                Keys.D5 => "5",
                Keys.D6 => "6",
                Keys.D7 => "7",
                Keys.D8 => "8",
                Keys.D9 => "9",
                Keys.D0 => "0",
                Keys.LWin => "Left Windows",
                Keys.RWin => "Right Windows",
                Keys.ControlKey => "Control",
                Keys.LControlKey => "Left Control",
                Keys.RControlKey => "Right Control",
                Keys.Menu => "Alt",
                Keys.LMenu => "Left Alt",
                Keys.RMenu => "Right Alt",
                Keys.ShiftKey => "Shift",
                Keys.CapsLock => "Caps Lock",
                _ => e.KeyCode.ToString()
            };

            if (e.Shift && e.KeyCode != Keys.ShiftKey)
                keyName = "Shift+" + keyName;

            if (e.Alt && e.KeyCode != Keys.Menu)
                keyName = "Alt+" + keyName;

            if (e.Control && e.KeyCode != Keys.ControlKey)
                keyName = "Control+" + keyName;

            return keyName;
        }

        private void Hotkey_LostFocus(object? sender, EventArgs e)
        {
            if (sender is not Button btn)
                return;

            if (!isHotkeyMouseDown)
                btn.Text = originalButtonText;

            btn.KeyDown -= Hotkey_KeyDown;
            btn.LostFocus -= Hotkey_LostFocus;

            if (clickedButton != null && sender == clickedButton)
            {
                clickedButton.Text = originalButtonText;
                clickedButton = null;
                isHotkeyMouseDown = false;
            }
        }

        private void Delay_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) ||
                e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void AutoTyper_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
                e.Handled = true;
        }
    }
}