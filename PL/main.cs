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
            /* GuestRequest guestRequest1=new GuestRequest();
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
             bL.deleteGuestRequest(guestRequest4);
             /*foreach (GuestRequest item in bL.GetGuestRequests())
             {
                 Console.WriteLine(item.ToString());
             }*/
            // bL.deleteGuestRequest(guestRequest4);
            // bL.updateGuestRequest(guestRequest3, guestRequest2);
            /* foreach (GuestRequest item in bL.GetGuestRequests())
             {
                 Console.WriteLine(item.ToString());
             }
             guestRequest2= bL.GetGuestRequests()[0];
             guestRequest2.Adults = 9;
             bL.GetGuestRequests()[1].Adults = 9;
                 foreach (GuestRequest item in bL.GetGuestRequests())
             {
                 Console.WriteLine(item.ToString());
             }*/

            //--------------hosting unit---------------
            bool[,] Diary1 = new bool[12, 31];
            bool[,] Diary2 = new bool[12, 31];
            bool[,] Diary3 = new bool[12, 31];
            bool[,] Diary4 = new bool[12, 31];


            List<HostingUnit> hoster1 = new List<HostingUnit>();
            List<HostingUnit> hoster2= new List<HostingUnit>();




            Diary1[1, 2] =Diary1[1,3]= Diary1[1, 4]= Diary1[2, 3]= Diary1[2, 4]=Diary1[2,5]= true;
            Diary2[4, 2] = Diary2[4, 3] = Diary2[4, 4] = Diary2[5, 3] = Diary2[5, 4] = Diary2[5, 5] = true;
            Diary3[ 2,21] = Diary3[ 2,22] = Diary3[2,23] = Diary3[3,17] = Diary3[3,18] = Diary3[3,19] = true;
            Diary4[6,19] = Diary4[ 6,18] = Diary4[ 6,17] = Diary4[6,1] = Diary4[6,2] = Diary4[ 6,3] = true;


            HostingUnit hostingUnit = new HostingUnit();
            BankAccount bankAccount1 = new BankAccount();
            bankAccount1.BankNumber = 1213;
            bankAccount1.BankName = "Leumi Yeruham";
            bankAccount1.BranchNumber=1234;
            bankAccount1.BranchAddress="Segev 10 ";
            bankAccount1.BranchCity= "Ashdod";

            Host Host1 = new Host();
            Host1.HostKey = 12343;
            Host1.PrivateName = "Moshe";
            Host1.FamilyName = "Cohen";
            Host1.FhoneNumber = 0527618971;
            Host1.MailAddress = "MCohen@gmail.com";
            Host1.BankAccount = bankAccount1;
            Host1.CollectionClearance = true;
            Host1.hostingUnits = hoster1;

            hostingUnit.Owner = Host1;
            hostingUnit.HostingUnitName = "zimer1";
            hostingUnit.Diary = Diary1;
            hoster1.Add(hostingUnit);
            bL.addHostingUnit(hostingUnit);

            HostingUnit hostingUnit2 = new HostingUnit();
            hostingUnit.Owner = Host1;
            hostingUnit.HostingUnitName = "zimer2";
            hostingUnit.Diary = Diary2;
            hoster1.Add(hostingUnit2);
            bL.addHostingUnit(hostingUnit2);


            BankAccount bankAccount2 = new BankAccount();
            bankAccount1.BankNumber = 14673;
            bankAccount1.BankName = "Leumi Mercaz Shapira";
            bankAccount1.BranchNumber = 4378;
            bankAccount1.BranchAddress = "Hrimon5";
            bankAccount1.BranchCity = "Tel Aviv ";

            Host Host2 = new Host();
            Host1.HostKey = 9089;
            Host1.PrivateName = "Shimon";
            Host1.FamilyName = "Dadoun";
            Host1.FhoneNumber = 0527618868;
            Host1.MailAddress = "Sdadoun";
            Host1.BankAccount = bankAccount2;
            Host1.CollectionClearance = true;
            Host1.hostingUnits = hoster2;

            HostingUnit hostingUnit3 = new HostingUnit();
            hostingUnit3.Owner = Host2;
            hostingUnit3.HostingUnitName = "hotel1";
            hostingUnit3.Diary = Diary3;
            hoster2.Add(hostingUnit3);
            bL.addHostingUnit(hostingUnit3);

            HostingUnit hostingUnit4 = new HostingUnit();
            hostingUnit.Owner = Host2;
            hostingUnit.HostingUnitName = "hotel2";
            hostingUnit.Diary = Diary4;
            hoster2.Add(hostingUnit4);
            bL.addHostingUnit(hostingUnit4);








            Console.ReadKey();
        }
    }
}

