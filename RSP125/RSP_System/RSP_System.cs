using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Collections;
using System.Threading;

namespace RSP125.RSP_System
{
    class RSP_System
    {
        private const Byte I2CAddressPinHigh = 0x69;
        private const Byte I2CAddressPinLow = 0x68;



        ArrayList Conditions = new ArrayList();

        // OutputPort testPort = new OutputPort((Cpu.Pin)24, false);  // 24 (PB8, SCL)
        // OutputPort testPort2 = new OutputPort((Cpu.Pin)25, false); // 25 (PB9, SDA)
        // Connect PE3 (CS) // Connect PA5 (SCK) // Connect PA6 (MISO) // Connect PA7 (MOSI) // PE3
        public LIS302DL RSP_Accelerometer = new LIS302DL((Cpu.Pin)(16 * 4 + 3));

        public MPU6000 CAR_Accelerometer = new MPU6000(I2CAddressPinLow, 400, 10, (Cpu.Pin)(16 * 4 + 2));  //PE2

        // ADC
        AnalogInput ADC0 = new AnalogInput(ADC.PA1);
        AnalogInput ADC1 = new AnalogInput(ADC.PA2);
        AnalogInput ADC2 = new AnalogInput(ADC.PA3);
        AnalogInput ADC3 = new AnalogInput(ADC.PB0); // PB0 = PA0 ???

        //DAC
        AnalogOutput DAC0 = new AnalogOutput(Cpu.AnalogOutputChannel.ANALOG_OUTPUT_0);
        // AnalogOutput DAC1 = new AnalogOutput(Cpu.AnalogOutputChannel.ANALOG_OUTPUT_1); // not working

        //DAC0.Scale = 1;
        //DAC0.Write(0.8);

        // DAC1.Scale = 1;    // not working
        // DAC1.Write(0.1);   // not working

        public bool CheckCarAccGyroSystem()
        {
            if (CAR_Accelerometer.getID() == 0x68)
            {
                Debug.Print(" MPU6000 is present");
                Conditions.Add("MPU6000 is present");
                return true;
            }
            else
            {
                Debug.Print(" MPU6000 is not connected");
                Conditions.Add("MPU6000 is not connected");
                return false;
            }
        }
        public void ShowCarAccGyroSystemReport ()
        {
            for (int i = 0; i < Conditions.Count; i++)
            {
                Debug.Print(Conditions[i].ToString());
            }
        }

        public void InitCarAccGyro ()
        {
            CAR_Accelerometer.Wake();

            CAR_Accelerometer.setFullScaleGyroRange(2);
            //or
            CAR_Accelerometer.setFullScaleGyroRange((byte)(MPU6000.Register.MPU6000_GYRO_FS_500));
            Debug.Print("FullScaleGyroRange =" + CAR_Accelerometer.getFullScaleGyroRange().ToString());

            CAR_Accelerometer.setFullScaleAccelRange(2);
            //or
            CAR_Accelerometer.setFullScaleAccelRange((byte)(MPU6000.Register.MPU6000_ACCEL_FS_2));
            Debug.Print("FullScaleAccelRange =" + CAR_Accelerometer.getFullScaleAccelRange().ToString());
            Debug.Print("getDLPFMode =" + CAR_Accelerometer.getDLPFMode().ToString());
            Thread.Sleep(100);
            CAR_Accelerometer.setDLPFMode((byte)(MPU6000.Register.MPU6000_DLPF_BW_5));
            Thread.Sleep(100);
            Debug.Print("getDLPFMode =" + CAR_Accelerometer.getDLPFMode().ToString());
            Debug.Print(" ");
        }

        

        public void SetDACScale (double value)
        {
            DAC0.Scale = value;
        }
        public void SetDACValue(double value)
        {
            DAC0.Write(value);
        }

        private void Up ()
        {

        }
        private void Down()
        {

        }
        private void Right_UP()
        {

        }
        private void Left_UP()
        {

        }
        private void Right_Down()
        {

        }
        private void Left_Down()
        {

        }
    }
}
