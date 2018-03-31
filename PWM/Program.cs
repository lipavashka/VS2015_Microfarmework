//using System;
//using Microsoft.SPOT;
//using Microsoft.SPOT.Hardware;
//using System.Threading;
////using STM32F4_Discovery.Netmf.Hardware;

using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace PWM_Test
{
    public class Program
    {
        static UInt32 Frequency = 25000;
        // static PWM MyFader = new PWM(Cpu.PWMChannel.PWM_0, 10000, 0.1, false);
        //static PWM PWM0 = new PWM(PWM_Channels.PWM0_PA8, Frequency, 0.25, false);
        static PWM LED_PWM_1111;
        public static void Main()
        {
            Debug.Print(Resources.GetString(Resources.StringResources.String1));
            
            // PWM MyServo;

            try
            {
                //MyServo = new PWM(Cpu.PWMChannel.PWM_3, 2175, 175,  PWM.ScaleFactor.Microseconds, false);
                LED_PWM_1111 = new PWM(Cpu.PWMChannel.PWM_15, 1000, 0.10, false);
            }
            catch
            {
                Debug.Print("PWM Error");
            }

            PWM MyServo = new PWM(Cpu.PWMChannel.PWM_14, 2175, 175, PWM.ScaleFactor.Microseconds, false);
            //OutputPort LED1 = new OutputPort((Cpu.Pin)60, false);
            //OutputPort LED2 = new OutputPort((Cpu.Pin)61, false);
            //OutputPort LED3 = new OutputPort((Cpu.Pin)62, false);
            //OutputPort LED4 = new OutputPort((Cpu.Pin)63, false);

            // PWM PWM_Led = new PWM(Cpu.PWMChannel.PWM_0, 10000, 0.10, false);

            // Lots of PWMs on processor, use a cast to access an extra PWM
            // PWM LED = new PWM((Cpu.PWMChannel)9, 10000, 0.10, false);

            while (true)
            {
                //LED1.Write(!LED1.Read());
                //LED2.Write(!LED2.Read());
                //LED3.Write(!LED3.Read());
                //LED4.Write(!LED4.Read());
                Thread.Sleep(250);                
            }
        }
    }
}
