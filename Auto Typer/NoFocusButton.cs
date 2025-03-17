using System;
using System.Windows.Forms;
using System.Drawing;

namespace Auto_Typer
{
    public class NoFocusButton : Button
    {
        public NoFocusButton()
        {
            SetStyle(ControlStyles.Selectable, false);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
        }

        // Override the focus handling
        protected override bool ShowFocusCues => false;
    }
}