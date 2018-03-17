using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace STM32F4DISC_Test
{
    public class Program
    {
        public static void Main()
        {
            OutputPort ledGreen = new OutputPort((Cpu.Pin)60, false);
            OutputPort ledYellow = new OutputPort((Cpu.Pin)61, false);
            OutputPort ledRed = new OutputPort((Cpu.Pin)62, false);
            OutputPort ledBlue = new OutputPort((Cpu.Pin)63, false);

            while (true)
            {
                ledGreen.Write(true);
                ledYellow.Write(true);
                ledRed.Write(true);
                ledBlue.Write(true);
                Thread.Sleep(100);
                ledGreen.Write(false);
                ledYellow.Write(false);
                ledRed.Write(false);
                ledBlue.Write(false);
                Thread.Sleep(100);
            }
        }
    }
}