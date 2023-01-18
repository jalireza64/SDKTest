using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainController;

namespace SdkTest.Helper
{
    public static class KavehHelper
    {
        public static void openBox(string comPort,int routerAddress,int endUserAddress,int relayNumber,int timeOn)
        {
            Controller controller = new Controller();
            controller.ComPort = comPort;
            controller.Open();
            if (controller.IsOpen)
            {
                controller.SendCommand(routerAddress: routerAddress, endUserAddress: endUserAddress, openLock: true, relayNumber: relayNumber, timeOn: timeOn);
            }
        }

        public static void closeBox(string comPort, int routerAddress, int endUserAddress, int relayNumber)
        {
            Controller controller = new Controller();
            controller.ComPort = comPort;
            controller.Open();
            if (controller.IsOpen)
            {
                controller.SendCommand(routerAddress: routerAddress, endUserAddress: endUserAddress, resetOne: true,relayNumber: relayNumber);
            }
        }
    }
}
