using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;
using STM32F429I_Discovery.Netmf.Hardware;

namespace ADC_Test
{
    public class Program
    {
        public static void Main()
        {
            // var op = new OutputPort(Stm32F4Discovery.FreePins.PA15, false);


            Debug.Print(Resources.GetString(Resources.StringResources.String1));


            ///* Initialize ADC channel 0 (PA6) */
            AnalogInput ADC0 = new AnalogInput(ADC.Channel0_PA6);

            /* Initialize ADC channel 1 (PA7) */
            AnalogInput ADC1 = new AnalogInput(ADC.Channel1_PA7);

            /* Initialize ADC channel 2 (PC1) */
            AnalogInput ADC2 = new AnalogInput(ADC.Channel2_PC1);

            /* Initialize ADC channel 3 (PC3) */
            AnalogInput ADC3 = new AnalogInput(ADC.Channel3_PC3);


            // AnalogOutput DAC0 = new AnalogOutput(Cpu.AnalogOutputChannel.ANALOG_OUTPUT_0);
            //AnalogOutput DAC1 = new AnalogOutput(Cpu.AnalogOutputChannel.ANALOG_OUTPUT_1);
            //AnalogOutput DAC2 = new AnalogOutput(Cpu.AnalogOutputChannel.ANALOG_OUTPUT_2);

            /* Initialize LEDs */
            LED.LEDInit();
            LED.GreenLedToggle();
            while (true)
            {
                /* Display the ADC converted value */
                Debug.Print("Channel0 (pin " + ADC0.Pin + ") = " + (ADC0.Read() * 3.3).ToString("f2") + "V");
                Debug.Print("Channel1 (pin " + ADC1.Pin + ") = " + (ADC1.Read() * 3.3).ToString("f2") + "V");
                Debug.Print("Channel2 (pin " + ADC2.Pin + ") = " + (ADC2.Read() * 3.3).ToString("f2") + "V");
                Debug.Print("Channel3 (pin " + ADC3.Pin + ") = " + (ADC3.Read() * 3.3).ToString("f2") + "V");
                Debug.Print("\r\n--------------------------------\r\n");

                /* Wait for 1s */
                Thread.Sleep(1000);

                /* Toggle Green LED */
                LED.GreenLedToggle();
                LED.RedLedToggle();
            }
        }
    }
}
