using Auto_Typer;
using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace Auto_Typer
{
    public partial class AutoTyper : Form
    {
        private RectangleDrawer rectangleDrawer;
        private GlobalHotkey? ghk;

        public string? text;
        public string? max;
        public string? min;
        public string? lastkey1;
        public string? lastkey2;
        private Button? focusedButton;
        private Button? unfocusedButton;
        private bool keychange;

        public AutoTyper()
        {
            InitializeComponent();
            rectangleDrawer = new RectangleDrawer();
            this.KeyPreview = true;
            UpdateTextBoxLocation();
            ghk = new GlobalHotkey(Keys.F2, this);
            ghk.Register();
        }


        private void PreventFocusShift(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        // Put global commands here
        private static void HandleHotkey()
        {
            MessageBox.Show("Global Hotkey F2 Pressed!", "Hotkey Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GlobalKeyDown(object? sender, KeyEventArgs e)
        {
            if ((unfocusedButton == null || unfocusedButton.Text != GetKeyName(e)) && Hotkey1.Text == GetKeyName(e) && !this.ContainsFocus)
            {
                MessageBox.Show("Program Started");
                MainText.BackColor = Color.White;
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

        private void AutoTyper_Paint(object? sender, PaintEventArgs e)
        {
            RectangleDrawer.DrawRectangles(e.Graphics);
            ControlPaint.DrawBorder(e.Graphics, MainText.Bounds, Color.Black, ButtonBorderStyle.Solid);
        }

        public void Hotkey_GotFocus(object? sender, MouseEventArgs e)
        {

            focusedButton = sender as Button;
            if (focusedButton.Text != "Press Any Key")
            {
                if (focusedButton.Name == "Hotkey1")
                {
                    lastkey1 = focusedButton.Text;
                    unfocusedButton = Hotkey2;
                }
                else
                {
                    lastkey2 = focusedButton.Text;
                    unfocusedButton = Hotkey1;
                }
                focusedButton.Text = "Press Any Key";
                focusedButton.Focus();
                keychange = false;
            }
        }

        public void SetHotkey(object? sender, KeyEventArgs e)
        {
            if (unfocusedButton.Text != GetKeyName(e) || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.Menu)
            {
                focusedButton.Text = GetKeyName(e);
                keychange = true;
            }
            else
            {
                MessageBox.Show("Both functions can't have the same hotkey", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Hotkey_KeyUp(object sender, KeyEventArgs e)
        {
            if (focusedButton.Text == unfocusedButton.Text)
            {
                focusedButton.Text = "Press Any Key";
                MessageBox.Show("Both functions can't have the same hotkey", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Hotkey_LostFocus(object? sender, EventArgs e)
        {

            if (keychange == false)
            {
                if (unfocusedButton.Name == "Hotkey1")
                {
                    unfocusedButton.Text = lastkey1;
                }
                else
                {
                    unfocusedButton.Text = lastkey2;
                }
            }
            if (focusedButton.Text == unfocusedButton.Text)
            {
                focusedButton.Text = "Press Any Key";
                MessageBox.Show("Both functions can't have the same hotkey" + keychange, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                focusedButton.Focus();
                keychange = false;
            }
        }

        private static string GetKeyName(KeyEventArgs e)
        {
            string keyName = e.KeyCode switch
            {
                Keys.Oem3 => "`",
                Keys.Oemcomma => ",",
                Keys.OemPeriod => ".",
                Keys.OemPipe => "\\",
                Keys.OemMinus => "-",
                Keys.Oemplus => "=",
                Keys.Oem2 => "/",
                Keys.Oem4 => "[",
                Keys.Oem6 => "]",
                Keys.Oem7 => "'",
                Keys.OemSemicolon => ";",
                Keys.Next => "PageDn",
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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private new void TextChanged(object sender, EventArgs e)
        {
            text = MainText.Text;
            max = DelayMin.Text;
            min = DelayMin.Text;
        }

        // Handles the global hotkey
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            ghk?.Unregister();
            base.OnFormClosing(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                HandleHotkey();
            }
            base.WndProc(ref m);
        }

        public static class Constants
        {
            public const int WM_HOTKEY_MSG_ID = 0x0312;
        }
    }
}
