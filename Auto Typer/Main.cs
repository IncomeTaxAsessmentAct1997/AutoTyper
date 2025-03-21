using System;
using System.Threading;
using System.Windows.Forms;

namespace Auto_Typer
{
    class Main
    {
        private static string text = "";
        private static int currentChar = 0;
        private static int delayMin = 0;
        private static int delayMax = 0;
        private readonly Random random = new();

        public static void SetTextAndDelay(string inputText, string minDelay, string maxDelay)
        {
            text = inputText;
            delayMin = int.TryParse(minDelay, out int min) ? min : 0;
            delayMax = int.TryParse(maxDelay, out int max) ? max : 0;
            currentChar = 0;
        }

        public void TypeText()
        {
            if (currentChar < text.Length)
            {
                int delay = random.Next(delayMin, delayMax); 
                Thread.Sleep(delay); 
                SendKeys.SendWait(text[currentChar].ToString()); 
                currentChar++; 
                TypeText();  
            }
        }
    }
}
