using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;
using Windows.Devices.Gpio; //<------https://docs.microsoft.com/en-us/uwp/api/windows.devices.gpio

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace HelloBlinky
{
    public sealed class StartupTask : IBackgroundTask
    {
        private const int LED_PIN = 12;
        private GpioPin pin;
        private GpioPinValue pinValue;
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            InitGPIO();
            if (pin != null)
            {
                if (pinValue == GpioPinValue.High)
                {
                    pinValue = GpioPinValue.Low;
                    pin.Write(pinValue);
                }
                else
                {
                    pinValue = GpioPinValue.High;
                    pin.Write(pinValue);
                }
            }
        }
        public void InitGPIO()
        {
            var gpio = GpioController.GetDefault();

            if (gpio != null) //Tehát van GPIO vezérlő az eszközön
            {
                pin = gpio.OpenPin(LED_PIN);
                pinValue = GpioPinValue.High;
                pin.Write(pinValue);
                pin.SetDriveMode(GpioPinDriveMode.Output);
            }

        }
    }
}
