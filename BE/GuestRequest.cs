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

        public StatusOrder status; /*NotAddressed,SentEmail,ClosedForCustomerUnresponsiveness,ClosedForCustomerResponse*/

        public DateTime RegistrationDate;
        public DateTime EntryDate;
        public DateTime ReleaseDate;

        public Location location;/*All, North, South, Center, Jerusalem*/
        public Location SubLocation;
        public KindOfUnit Type;/* GuesRoom, Apartment, HotelRoom, Tent*/

        public int Adults { get; set; }
        public int Children { get; set; }

        public Request Pool;/*All,North,South,Center,Jerusalem*/
        public Request Jacuzzi;
        public Request Garden;
        public Request ChildrensAttractions;
        public override string ToString()
        {
            return("G");
        }

        public virtual bool Equals(GuestRequest guestRequest)
        {
            return
            (
                GuestRequestKey == guestRequest.GuestRequestKey &&
                PrivateName == guestRequest.PrivateName &&
                FamilyName == guestRequest.FamilyName &&
                MailAddress == guestRequest.MailAddress &&

                status == guestRequest.status &&
                RegistrationDate == guestRequest.RegistrationDate &&
                EntryDate == guestRequest.EntryDate &&
                ReleaseDate == guestRequest.ReleaseDate &&

                location == guestRequest.location &&
                SubLocation == guestRequest.SubLocation &&
                Type == guestRequest.Type &&

                Adults == guestRequest.Adults &&
                Children == guestRequest.Children &&

                Pool == guestRequest.Pool &&
                Jacuzzi == guestRequest.Jacuzzi &&
                Garden == guestRequest.Garden &&
                ChildrensAttractions == guestRequest.ChildrensAttractions
            );
        }


    }
}
