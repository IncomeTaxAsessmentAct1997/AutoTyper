namespace Auto_Typer
{
    internal class RectangleDrawer
    {
        public static void DrawRectangles(Graphics graphics)
        {
            using Pen blackPen = new(Color.Black, 2);
            using SolidBrush whiteBrush = new(Color.White);

            Rectangle rect1 = new(196, 145, 510, 183);
            graphics.DrawRectangle(blackPen, rect1);

            Rectangle rect2 = new(196, 29, 149, 35);
            graphics.DrawRectangle(blackPen, rect2);

            Rectangle rect3 = new(196, 77, 149, 35);
            graphics.DrawRectangle(blackPen, rect3);

            Rectangle rect4 = new(196, 358, 149, 38);
            graphics.FillRectangle(whiteBrush, rect4);
            graphics.DrawRectangle(blackPen, rect4);

            Rectangle rect5 = new(394, 358, 149, 38);
            graphics.FillRectangle(whiteBrush, rect5);
            graphics.DrawRectangle(blackPen, rect5);
        }
    }
}