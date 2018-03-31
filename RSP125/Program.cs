using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;
using RSP125.RSP_System;


namespace RSP125
{
    public class Program
    {
        private const Byte I2CAddressPinHigh = 0x69;
        private const Byte I2CAddressPinLow = 0x68;

        public static void Main()
        {
            Debug.Print(Resources.GetString(Resources.StringResources.String1));

            OutputPort ledGreen = new OutputPort((Cpu.Pin)60, false);
            OutputPort ledYellow = new OutputPort((Cpu.Pin)61, false);
            OutputPort ledRed = new OutputPort((Cpu.Pin)62, false);
            OutputPort ledBlue = new OutputPort((Cpu.Pin)63, false);
            
            RSP_System.RSP_System rsp = new RSP_System.RSP_System();

            rsp.SetDACScale(1);
            rsp.SetDACValue(0.8);

            if (rsp.CheckCarAccGyroSystem() == true)
            {
                rsp.InitCarAccGyro();
            }
            rsp.ShowCarAccGyroSystemReport();



            while (true)
            {
                Thread.Sleep(250);
                Debug.Print(rsp.RSP_Accelerometer.Xvalue.ToString() + "," + rsp.RSP_Accelerometer.Yvalue.ToString() + "," + rsp.RSP_Accelerometer.Zvalue.ToString());
                rsp.CAR_Accelerometer.getMotion();
                Debug.Print(rsp.CAR_Accelerometer.AX.ToString() + "," + rsp.CAR_Accelerometer.AY.ToString() + "," + rsp.CAR_Accelerometer.AZ.ToString());
                Debug.Print(rsp.CAR_Accelerometer.GX.ToString() + "," + rsp.CAR_Accelerometer.GY.ToString() + "," + rsp.CAR_Accelerometer.GZ.ToString());
                Debug.Print(rsp.CAR_Accelerometer.angleX.ToString() + "," + rsp.CAR_Accelerometer.angleY.ToString() + "," + rsp.CAR_Accelerometer.angleZ.ToString());
                ledGreen.Write(!ledGreen.Read());
                ledYellow.Write(!ledYellow.Read());
                ledRed.Write(!ledRed.Read());
                ledBlue.Write(!ledBlue.Read());
            }


        }
    }
}
