using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    /// <summary>
    /// this class represent a Hosting unit (of the host man)
    /// </summary>
    public class HostingUnit
    {
        public Host Owner;
        public string HostingUnitName;
        public bool[,] Diary = new bool[12, 31];
        public int hostinUnitkey = Configuration.getHostingUnitKeyTempPlusOne();
        public Location location;
        public KindOfUnit Type;
        public int capacity;
        public bool Pool;
        public bool Jacuzzi;
        public bool Garden;
        public bool ChildrensAttractions;
        public override string ToString() 
        { return ("Owner: " + Owner.PrivateName + " " + Owner.FamilyName + "\n" + 
                "HostingUnitName: " + HostingUnitName + "\n" + "Diary (Busy dates):\n"+printDateTime(printDiary()) + "hostinUnitkey: " + hostinUnitkey +"\n"+
                "location: " + location + "\n") ; }
        private List< DateTime> printDiary()
        {
            List<DateTime> retVal=new List<DateTime>();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; ++j)
                    if (Diary[i, j])
                        retVal.Add(new DateTime(DateTime.Now.Year, i+1, j+1));
            }
            return retVal;
        }
        private String printDateTime(List<DateTime> dateTimes)
        {
            string retVal="";
            foreach (var item in dateTimes)
            {
                retVal+= (string)(item.ToString())+" \n";
            }
            return retVal;
        }
        /// <summary>
        /// The function receives date and days of vacation, and returns if the unit is available.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public bool AvailableOnDate(DateTime dateTime, int days)
        {
            int startIndexInDiary = dateTime.Day+ (dateTime.Month) * 31;
            int endIndexInDiary = startIndexInDiary + days;

            for (int i = startIndexInDiary; i < endIndexInDiary; i++)
                if (Diary[i / 12, i % 31]) return false;
            return true;
        }
        public bool AvailableOnDate(GuestRequest guestRequest)
        {
            DateTime EntryDate = guestRequest.EntryDate;
            int days = (guestRequest.ReleaseDate - EntryDate).Days;

            int startIndexInDiary = EntryDate.Day - 1 + (EntryDate.Month - 1) * 31;
            int endIndexInDiary = startIndexInDiary + days;

            for (int i = startIndexInDiary; i < endIndexInDiary; i++)
                if (Diary[i / 12, i % 31]) return false;
            return true;
        }
        public virtual bool Equals(HostingUnit hostingUnit)
        {
            return (hostinUnitkey == hostingUnit.hostinUnitkey &&
             Owner == hostingUnit.Owner &&
             HostingUnitName == hostingUnit.HostingUnitName &&
             Diary == hostingUnit.Diary);
        }
    }
}
