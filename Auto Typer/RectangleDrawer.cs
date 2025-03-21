namespace Auto_Typer
{
    internal class RectangleDrawer
    {
        public static void DrawRectangles(Graphics graphics)
        {
            int x1 = MainTextBorder.MainTextX - 1;
            int y1 = MainTextBorder.MainTextY - 1;
            int width1 = MainTextBorder.MainTextLength + 2;
            int height1 = MainTextBorder.MainTextHeight + 2;

            int x2 = DelayMinBorder.DelayMinX - 1;
            int y2 = DelayMinBorder.DelayMinY - 6;
            int width2 = DelayMinBorder.DelayMinLength + 7;
            int height2 = DelayMinBorder.DelayMinHeight + 7;

            int x3 = DelayMaxBorder.DelayMaxX - 1;
            int y3 = DelayMaxBorder.DelayMaxY - 6;
            int width3 = DelayMaxBorder.DelayMaxLength + 7;
            int height3 = DelayMaxBorder.DelayMaxHeight + 7;

            using Pen blackPen = new(Color.Black, 2);
            using SolidBrush whiteBrush = new(Color.White);

            Rectangle rect1 = new(x1, y1, width1, height1);
            graphics.DrawRectangle(blackPen, rect1);

            Rectangle rect2 = new(x2, y2, width2, height2);
            graphics.FillRectangle(whiteBrush, rect2);
            graphics.DrawRectangle(blackPen, rect2);

            Rectangle rect3 = new(x3, y3, width3, height3);
            graphics.FillRectangle(whiteBrush, rect3);
            graphics.DrawRectangle(blackPen, rect3);
        }
    }
}