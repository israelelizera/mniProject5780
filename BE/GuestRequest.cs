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
        public int guestRequestkey = Configuration.getGuestRequestKeyTempPlusOne();
        public string PrivateName;
        public string FamilyName;
        public string MailAddress;

        public int Adults;//number of adults
        public int Children;//"      " children

        public StatusOrder status;//status bakasht iroah

        public DateTime RegistrationDate;//תאריך הרשמה למערכת
        public DateTime EntryDate;//
        public DateTime ReleaseDate;

        public Location location;
        public KindOfUnit Type;

        

        public Request Pool;
        public Request Jacuzzi;
        public Request Garden;
        public Request ChildrensAttractions;

        //constructor without initalize GRK(guestRequestKey)
        public GuestRequest(string privateName, string familyName, string mailAddress, int adults,//
            int children, StatusOrder status, DateTime registrationDate, DateTime entryDate,
            DateTime releaseDate, Location location, KindOfUnit type, Request pool, Request jacuzzi,
            Request garden, Request childrensAttractions)
        {
            PrivateName = privateName;
            FamilyName = familyName;
            MailAddress = mailAddress;
            Adults = adults;
            Children = children;
            this.status = status;
            RegistrationDate = registrationDate;
            EntryDate = entryDate;
            ReleaseDate = releaseDate;
            this.location = location;
            Type = type;
            Pool = pool;
            Jacuzzi = jacuzzi;
            Garden = garden;
            ChildrensAttractions = childrensAttractions;
        }

        public override string ToString() { return null; }

        public virtual bool Equals(GuestRequest guestRequest)
        {
            return
            (
                guestRequestkey == guestRequest.guestRequestkey &&
                PrivateName == guestRequest.PrivateName &&
                FamilyName == guestRequest.FamilyName &&
                MailAddress == guestRequest.MailAddress &&

                status == guestRequest.status &&
                RegistrationDate == guestRequest.RegistrationDate &&
                EntryDate == guestRequest.EntryDate &&
                ReleaseDate == guestRequest.ReleaseDate &&

                location == guestRequest.location &&                
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
