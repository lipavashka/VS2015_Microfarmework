using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;

namespace MPU6050_Test
{
    public class Program
    {
        private const Byte I2CAddressPinHigh = 0x69;
        private const Byte I2CAddressPinLow = 0x68;

        public static void Main()
        {
            Debug.Print(Resources.GetString(Resources.StringResources.String1));

            MPU6000 MyMPU6000 = new MPU6000(I2CAddressPinLow, 400, 10, (Cpu.Pin)(16 * 4 + 2));  //PE2

            if (MyMPU6000.getID() == 0x68)
            {
                Debug.Print(" ******************");
                Debug.Print(" MPU6000 is present");
                Debug.Print(" ******************");
            }

            MyMPU6000.Wake();

            MyMPU6000.setFullScaleGyroRange(2);
            //or
            MyMPU6000.setFullScaleGyroRange((byte)(MPU6000.Register.MPU6000_GYRO_FS_500));
            Debug.Print("FullScaleGyroRange =" + MyMPU6000.getFullScaleGyroRange().ToString());

            MyMPU6000.setFullScaleAccelRange(2);
            //or
            MyMPU6000.setFullScaleAccelRange((byte)(MPU6000.Register.MPU6000_ACCEL_FS_2));
            Debug.Print("FullScaleAccelRange =" + MyMPU6000.getFullScaleAccelRange().ToString());
            Debug.Print(" ");



            while (true)
            {


                //Access the data registers in a single read using getMotion6 
                MyMPU6000.getMotion6();
                Debug.Print("                                      X                    Y                  Z ".ToString());
                Debug.Print("getMotion6 Accelerometer values = " + MyMPU6000.ax.ToString() + "         " + MyMPU6000.ay.ToString() + "         " + MyMPU6000.az.ToString());
                Debug.Print("getMotion6 Gyro values =         " + MyMPU6000.gx.ToString() + "   " + MyMPU6000.gy.ToString() + "   " + MyMPU6000.gz.ToString());


                //Read the data registers individually
                Debug.Print("Read gyro values individually");
                Debug.Print(" Xgyro: " + MyMPU6000.readGyroX().ToString());
                Debug.Print(" Ygyro: " + MyMPU6000.readGyroY().ToString());
                Debug.Print(" Zgyro: " + MyMPU6000.readGyroZ().ToString());
                Debug.Print(" ");
                Debug.Print(" Temperature: " + MyMPU6000.readTemp().ToString() + " celsius");
                Debug.Print("*******************************************".ToString());

                Thread.Sleep(500);
            }
        }
    }
}
