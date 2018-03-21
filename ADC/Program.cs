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
            int DacValue1 = 10;
            int DacValue2 = 10;

            Debug.Print(Resources.GetString(Resources.StringResources.String1));

            // ADC
            AnalogInput ADC0 = new AnalogInput(ADC.PA1);
            AnalogInput ADC1 = new AnalogInput(ADC.PA2);
            AnalogInput ADC2 = new AnalogInput(ADC.PA3);
            AnalogInput ADC3 = new AnalogInput(ADC.PB0); // PB0 = PA0 ???

            //DAC
            AnalogOutput DAC0 = new AnalogOutput(Cpu.AnalogOutputChannel.ANALOG_OUTPUT_0);
            AnalogOutput DAC1 = new AnalogOutput(Cpu.AnalogOutputChannel.ANALOG_OUTPUT_1);

            DAC0.Scale = 1;
            DAC0.Write(0.8); 

            DAC1.Scale = 1;
            DAC1.Write(0.1); 

            /* Initialize LEDs */
            LED.LEDInit();
            LED.GreenLedToggle();
            while (true)
            {
                /* Display the ADC converted value */
                //int AdcValue = (ADC0.ReadRaw() * 1);
                //string str = AdcValue.ToString();
                Debug.Print("ADC0 (pin " + ADC0.Pin + ") = " + (ADC0.ReadRaw()));
                Debug.Print("ADC1 (pin " + ADC1.Pin + ") = " + (ADC1.ReadRaw()));
                Debug.Print("ADC2 (pin " + ADC2.Pin + ") = " + (ADC2.ReadRaw()));
                Debug.Print("ADC3 (pin " + ADC3.Pin + ") = " + (ADC3.ReadRaw()));

                Debug.Print("\r\n--------------------------------\r\n");

                /* Wait for 1s */
                Thread.Sleep(250);

                /* Toggle Green LED */
                LED.GreenLedToggle();
                LED.RedLedToggle();

                DacValue1 += 100;
                if (DacValue1 > 4000)
                {
                    DacValue1 = 0;
                }
                DAC0.WriteRaw(DacValue1);

                DacValue2 += 100;
                if (DacValue2 > 4000)
                {
                    DacValue2 = 0;
                }
                DAC1.WriteRaw(DacValue2);

            }
        }
    }
}
