using BoardOperation.Commands.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkTest.Helper
{
    public static class SepidHelper
    {
        public static void OpenBox(string ip, int port, string pinNumber)
        {
            SepidBoardController sepidBoardController = new SepidBoardController();
            sepidBoardController.OpenBox(ip, port, pinNumber);
        }

        public static bool GetBoxState(string ip, int port, string pinNumber)
        {
            SepidBoardController sepidBoardController = new SepidBoardController();
            var result = sepidBoardController.GetBoxState(ip, port,Convert.ToInt32(pinNumber));
            return result;
        }
    }
}
