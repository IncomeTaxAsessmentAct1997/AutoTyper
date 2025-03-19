using System;
using System.Threading;
using System.Windows.Forms;

namespace Auto_Typer
{
    class Main
    {
        readonly bool isWriting = false;
        readonly string text = $"";
        int currentChar = 0;
        readonly int currentMin = 0;
        readonly int currentMax = 0;
        readonly Random random = new();

        public void TypeText()
        {
            int delay = random.Next(currentMin, currentMax);
            Thread.Sleep(delay);
            if (currentChar < text.Length)
            {
                SendKeys.SendWait(text[currentChar].ToString());
                currentChar++;
                TypeText();
            }
        }
    }
}