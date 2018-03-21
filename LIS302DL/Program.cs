using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace LIS302DL
{
    public class Program
    {
        public static void Main()
        {
            Debug.Print(Resources.GetString(Resources.StringResources.String1));
            // Connect PE3 (CS)
            // Connect PA5 (SCK)
            // Connect PA6 (MISO)
            // Connect PA7 (MOSI)

            LIS302DL Accelerometer =  new LIS302DL((Cpu.Pin)(16 * 4 + 3)); //PE3

            while (true)
            {
                Thread.Sleep(250);
                Debug.Print(Accelerometer.Xvalue.ToString() + "," + Accelerometer.Yvalue.ToString() + "," + Accelerometer.Zvalue.ToString());                
            }
        }
    }
}
