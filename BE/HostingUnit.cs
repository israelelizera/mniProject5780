﻿using System;
using System.Collections.Generic;

namespace BE
{
    /// <summary>
    /// this class represent a Hosting unit (of the host man)
    /// </summary>
    public class HostingUnit
    {
        public string HostingUnitName { get; set; }
        public bool[,] Diary = new bool[12, 31];
        public int HostinUnitKey = Configuration.getHostingUnitKeyTempPlusOne();
        public Location Location { get; set; }
        public KindOfUnit Type { get; set; }
        public int Capacity { get; set; }
        public bool Pool { get; set; }
        public bool Jacuzzi { get; set; }
        public bool Garden { get; set; }
        public bool ChildrensAttractions { get; set; }

        public override string ToString()
        {
            return ("HostingUnitName: " + HostingUnitName + "\n" + "Diary (Busy dates):\n" + printDateTime(printDiary()) + "hostinUnitkey: " + HostinUnitKey + "\n" +
                  "location: " + Location + "\n");
        }
        private List<DateTime> printDiary()
        {
            List<DateTime> retVal = new List<DateTime>();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; ++j)
                    if (Diary[i, j])
                        retVal.Add(new DateTime(DateTime.Now.Year, i + 1, j + 1));
            }
            return retVal;
        }
        private String printDateTime(List<DateTime> dateTimes)
        {
            string retVal = "";
            foreach (var item in dateTimes)
            {
                retVal += (string)(item.ToString()) + " \n";
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
            int startIndexInDiary = dateTime.Day + (dateTime.Month) * 31;
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
            return (HostinUnitKey == hostingUnit.HostinUnitKey &&
             HostingUnitName == hostingUnit.HostingUnitName &&
             Diary == hostingUnit.Diary);
        }
    }
}
