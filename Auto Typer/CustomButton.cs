using System;
using System.Windows.Forms;
using System.Drawing;

namespace Auto_Typer
{
    public class CustomButton : Button
    {
        public CustomButton()
        {
            SetStyle(ControlStyles.Selectable, false);
            this.FlatStyle = FlatStyle.Flat;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            using Pen borderPen = new(Color.Black, 2);
            pevent.Graphics.DrawRectangle(borderPen, 1, 1, this.Width - 2, this.Height - 2);
        }
        protected override bool ShowFocusCues => false;
    }
}
