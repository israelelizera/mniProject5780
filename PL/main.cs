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
            GuestRequest guestRequest =
                new GuestRequest("Yehuda", "Ohayon", "Oha123@gmail.com", 2, 0, StatusOrder.SentEmail, new DateTime(2020, 1, 7), new DateTime(2020, 1, 14), 
                new DateTime(2020, 1, 17), Location.Jerusalem, KindOfUnit.HotelRoom, Request.possible, Request.necessary,
                Request.notInterested, Request.notInterested);
            BankAccount bankAccount = new BankAccount();
            Host owner = new Host(10000,"Israel","Elizera",0522960171,"elizera654@gmail.com",);
            HostingUnit hostingUnit =
                new HostingUnit();

        }
    }
}

