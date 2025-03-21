using System.Net.NetworkInformation;
using System.Security.AccessControl;

namespace Auto_Typer
{
    public partial class AutoTyper : Form
    {
        private readonly RectangleDrawer rectangleDrawer;
        public string? text;
        public string? max;
        public string? min;
        public string? lastkey1;
        public string? lastkey2;
        private Button? focusedButton;
        private Button? unfocusedButton;

        public AutoTyper()
        {
            InitializeComponent();
            rectangleDrawer = new RectangleDrawer();
            this.Paint += AutoTyper_Paint;
            this.KeyDown += GlobalKeyDown;
            this.KeyPreview = true;
            Hotkey1.Leave += Hotkey_LostFocus;
            Hotkey2.Leave += Hotkey_LostFocus;
            UpdateTextBoxLocation();
        }

        private void GlobalKeyDown(object? sender, KeyEventArgs e)
        {
            string globalKey = GetKeyName(e);
            if (globalKey == Hotkey1.Text)
            {
               Main.SetTextAndDelay(MainText.Text, DelayMin.Text, DelayMax.Text);
            }
        }

        private void UpdateTextBoxLocation()
        {
            MainTextBorder.MainTextHeight = MainText.Height;
            MainTextBorder.MainTextLength = MainText.Width;
            MainTextBorder.MainTextX = MainText.Location.X;
            MainTextBorder.MainTextY = MainText.Location.Y;

            DelayMaxBorder.DelayMaxHeight = DelayMaxPanel.Height;
            DelayMaxBorder.DelayMaxLength = DelayMaxPanel.Width;
            DelayMaxBorder.DelayMaxX = DelayMaxPanel.Location.X;
            DelayMaxBorder.DelayMaxY = DelayMaxPanel.Location.Y;

            DelayMinBorder.DelayMinHeight = DelayMinPanel.Height;
            DelayMinBorder.DelayMinLength = DelayMinPanel.Width;
            DelayMinBorder.DelayMinX = DelayMinPanel.Location.X;
            DelayMinBorder.DelayMinY = DelayMinPanel.Location.Y;
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

        public void Hotkey_GotFocus(object sender, MouseEventArgs e)
        {
            focusedButton = sender as Button;
            if (focusedButton.Text != "Press Any Key")
            {
                if (focusedButton.Name == "Hotkey1")
                {
                    lastkey1 = focusedButton.Text;
                }
                else
                {
                    lastkey2 = focusedButton.Text;
                }
                focusedButton.Text = "Press Any Key";
                focusedButton.Focus();
            }
        }

        public void Hotkey_LostFocus(object? sender, EventArgs e)
        {
            unfocusedButton = sender as Button;
            if (unfocusedButton.Name == "Hotkey1")
            {
                unfocusedButton.Text = lastkey1;
            }
            else
            {
                unfocusedButton.Text = lastkey2;
            }
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

        private new void TextChanged(object sender, EventArgs e)
        {
            text = MainText.Text;
            max = DelayMin.Text;
            min = DelayMin.Text;
        }
    }
}