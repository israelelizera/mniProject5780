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

        public string PrivateName;
        public string FamilyName;
        public string MailAddress;
        public StatusOrder status;
        public DateTime RegistrationDate;
        public DateTime EntryDate;
        public DateTime ReleaseDate;
        public Location location;
        public Location SubLocation;
        public KindOfUnit Type;
        public int Adults { get; set; }
        public int Children { get; set; }
        public Request Pool;
        public Request Jacuzzi;
        public Request Garden;
        public Request ChildrensAttractions;

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
