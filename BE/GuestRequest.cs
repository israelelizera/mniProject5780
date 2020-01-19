using System;
using System.Collections.Generic;
using System.Text;
using BE;

namespace BE
{
    /// <summary>
    /// this class represent request of guest for vacation
    /// </summary>
    public class GuestRequest
    {
        public int GuestRequestKey = Configuration.getGuestRequestKeyTempPlusOne();

        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string MailAddress { get; set; }
        public StatusOrder status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Location location { get; set; }
        public Location SubLocation { get; set; }
        public KindOfUnit Type { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public Request Pool { get; set; }
        public Request Jacuzzi { get; set; }
        public Request Garden { get; set; }
        public Request ChildrensAttractions { get; set; }

        public override string ToString()
        {
            return ("GuestRequestKey: " + GuestRequestKey + "\n" + "PrivateName :" + PrivateName + "\n"
                + "FamilyName: " + FamilyName + "\n" + "MailAddress: " + MailAddress + "\n" + "status: " + status
                + "\n" + "RegistrationDate: " + RegistrationDate + "\n" + "EntryDate: " + EntryDate + "\n" + "ReleaseDate :"
                + ReleaseDate + "\n" + "location: " + location + "\n" + "SubLocation: " + SubLocation + "\n" + "Type: " + Type + "\n"
                + "Adults :" + Adults + "\n" + "Children: " + Children + "\n" + "Pool: " + Pool + "\n" + "Jacuzzi: " + Jacuzzi + "\n"
                + "Garden: " + Garden + "\n" + "ChildrensAttractions :" + ChildrensAttractions + "\n");
        }


    }
}
