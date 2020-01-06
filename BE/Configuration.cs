using System;
using System.Collections.Generic;
using System.Text;
using BE;
namespace BE
{
    public class Configuration
    {
        public static int GuestRequestKeyTemp = 10000000;
        static int HostingUnitKeyTemp = 10000000;
        static double Commission = 0.5;
        static int DaysToEnd;

        internal static int getGuestRequestKeyTemp() { return GuestRequestKeyTemp; }
        internal static int getGuestRequestKeyTempPlusOne() { ++GuestRequestKeyTemp; return GuestRequestKeyTemp; }
        internal static int getHostingUnitKeyTemp() { return HostingUnitKeyTemp; }
        internal static int getHostingUnitKeyTempPlusOne() { ++HostingUnitKeyTemp; return HostingUnitKeyTemp; }
    }
}
