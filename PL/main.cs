using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;



namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            BL_imp bL = new BL_imp();
            GuestRequest guestRequest1=new GuestRequest();
            guestRequest1.PrivateName = "Yehuda";
            guestRequest1.FamilyName = "Ohayon";
            guestRequest1.MailAddress = "Oha123@gmail.com";
            guestRequest1.Adults = 2;
            guestRequest1.Children = 0;
            guestRequest1.status = StatusOrder.SentEmail;
            guestRequest1.RegistrationDate= new DateTime(2020, 1, 7);
            guestRequest1.EntryDate = new DateTime(2020, 1, 14);
            guestRequest1.ReleaseDate = new DateTime(2020, 1, 17);
            guestRequest1.location = Location.Jerusalem;
            guestRequest1.Type = KindOfUnit.HotelRoom;
            guestRequest1.Pool = Request.possible;
            guestRequest1.Jacuzzi = Request.necessary;
            guestRequest1.Garden = Request.notInterested;
            guestRequest1.ChildrensAttractions = Request.notInterested;
            bL.addGuestRequest(guestRequest1);



            GuestRequest guestRequest2 = new GuestRequest();
            guestRequest2.PrivateName = "Israel";
            guestRequest2.FamilyName = "Eizera";
            guestRequest2.MailAddress = "elizera654@gmail.com";
            guestRequest2.Adults = 4;
            guestRequest2.Children = 1;
            guestRequest2.status = StatusOrder.ClosedForCustomerResponse;
            guestRequest2.RegistrationDate = new DateTime(2020, 1, 17);
            guestRequest2.EntryDate = new DateTime(2020, 1, 20);
            guestRequest2.ReleaseDate = new DateTime(2020, 1, 25);
            guestRequest2.location = Location.Center;
            guestRequest2.Type = KindOfUnit.Apartment;
            guestRequest2.Pool = Request.possible;
            guestRequest2.Jacuzzi = Request.necessary;
            guestRequest2.Garden = Request.notInterested;
            guestRequest2.ChildrensAttractions = Request.notInterested;
            bL.addGuestRequest(guestRequest2);



            GuestRequest guestRequest3 = new GuestRequest();
            guestRequest3.PrivateName = "Ilay";
            guestRequest3.FamilyName = "levi";
            guestRequest3.MailAddress = "ilay@gmail.com";
            guestRequest3.Adults = 3;
            guestRequest3.Children = 2;
            guestRequest3.status = StatusOrder.NotAddressed;
            guestRequest3.RegistrationDate = new DateTime(2020, 2, 7);
            guestRequest3.EntryDate = new DateTime(2020, 2, 14);
            guestRequest3.ReleaseDate = new DateTime(2020, 2, 17);
            guestRequest3.location = Location.North;
            guestRequest3.Type = KindOfUnit.Tent;
            guestRequest3.Pool = Request.notInterested;
            guestRequest3.Jacuzzi = Request.notInterested;
            guestRequest3.Garden = Request.notInterested;
            guestRequest3.ChildrensAttractions = Request.notInterested;
            bL.addGuestRequest(guestRequest3);



            GuestRequest guestRequest4 = new GuestRequest();
            guestRequest4.PrivateName = "Netanel";
            guestRequest4.FamilyName = "Booskila";
            guestRequest4.MailAddress = "habbabBoski@gmail.com";
            guestRequest4.Adults = 4;
            guestRequest4.Children = 2;
            guestRequest4.status = StatusOrder.ClosedForCustomerResponse;
            guestRequest4.RegistrationDate = new DateTime(2020, 3, 7);
            guestRequest4.EntryDate = new DateTime(2020, 3, 14);
            guestRequest4.ReleaseDate = new DateTime(2020, 3, 17);
            guestRequest4.location = Location.South;
            guestRequest4.Type = KindOfUnit.HotelRoom;
            guestRequest4.Pool = Request.necessary;
            guestRequest4.Jacuzzi = Request.necessary;
            guestRequest4.Garden = Request.necessary;
            guestRequest4.ChildrensAttractions = Request.necessary;
            bL.addGuestRequest(guestRequest4);

            foreach(GuestRequest item in bL.GetGuestRequests())
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}

