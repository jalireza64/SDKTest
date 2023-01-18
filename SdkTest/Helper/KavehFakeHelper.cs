using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glassess.IO.Drivers.ControllersDriver;
using MainController;

namespace SdkTest.Helper
{
    public static class KavehFakeHelper
    {
        public static void openBox(string comPort,int routerAddress,int endUserAddress,int relayNumber,int timeOn)
        {
            var boardCommunication = new BoardCommunication(comPort, 19200, false);
            boardCommunication.OpenPort();
            ErrorType errorType = ErrorType.RouterTimeOut;
            boardCommunication.OpenRelay(routerAddress, endUserAddress, relayNumber, timeOn, ref errorType);
            if (errorType != ErrorType.Successfull)
            {
                boardCommunication.OpenRelay(routerAddress, endUserAddress, relayNumber, timeOn, ref errorType);
                if (errorType != ErrorType.Successfull)
                {
                    boardCommunication.OpenRelay(routerAddress, endUserAddress, relayNumber, timeOn, ref errorType);
                    if (errorType != ErrorType.Successfull)
                    {
                        boardCommunication.OpenRelay(routerAddress, endUserAddress, relayNumber, timeOn, ref errorType);
                        if (errorType != ErrorType.Successfull && errorType != ErrorType.MainControllerTimeOut)
                        {
                            string res = errorType.ToString();
                            throw new Exception("صندوق باید به صورت مکانیکی باز شود" +"=============>"+ res);
                        }
                    }
                }
            }
        }
    }
}
