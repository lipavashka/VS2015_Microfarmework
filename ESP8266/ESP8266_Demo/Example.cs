using System;
using System.Threading;
using IngenuityMicro.Hardware.Neon;
using IngenuityMicro.Hardware.Oxygen;
using IngenuityMicro.Net;
using IngenuityMicro.Net.Azure.MobileService;
using Microsoft.SPOT;

namespace AzureInsertTest
{
    public class Program
    {
        private const string SSID = "XXX";
        private const string PASSWD = "XXX";
        private static readonly Uri azureMobileAppUri = new Uri("http://myservice.azure-mobile.net/");
        private const string AzureAppKey = "XXX";

        public static void Main()
        {
            var wifi = new NeonWifiDevice();

            wifi.Connect(SSID, PASSWD);

            var sntp = new SntpClient(wifi, "time1.google.com");
            sntp.SetTime();

            MobileServiceClient msc = new MobileServiceClient(wifi, azureMobileAppUri, null, AzureAppKey);
            IMobileServiceTable tab = msc.GetTable("environment_measures");

            // Test a dummy insert for now
            MeasurementRow row = new MeasurementRow();
            string result = tab.Insert(row);
            Debug.Print(DateTime.Now.ToString("T") + " " + result);

            bool state = true;
            int iCounter = 0;
            while (true)
            {
                Hardware.UserLed.Write(state);
                state = !state;
                if (++iCounter == 10)
                {
                    Debug.Print("Current UTC time : " + DateTime.UtcNow);
                    iCounter = 0;
                }
                Thread.Sleep(500);
            }
        }
    }
}