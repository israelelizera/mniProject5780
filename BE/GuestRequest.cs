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
        public int key = Configuration.getGuestRequestKeyTempPlusOne();
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

        public int Adults;
        public int Children;

        public Request Pool;
        public Request Jacuzzi;
        public Request Garden;
        public Request ChildrensAttractions;

        public override string ToString() { return null; }

        public virtual bool Equals(GuestRequest guestRequest)
        {
            return
            (
                key == guestRequest.key &&
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
