using System;
using System.Collections.Generic;
using System.Text;
using BE;

namespace DAL
{
    public static class Cloning
    {
        public static GuestRequest Clon(this GuestRequest guestRequest)
        {
            return new GuestRequest()
            {
                GuestRequestKey = guestRequest.GuestRequestKey,
                PrivateName = guestRequest.PrivateName,
                FamilyName = guestRequest.FamilyName,
                MailAddress = guestRequest.MailAddress,

                status = guestRequest.status,
                RegistrationDate = guestRequest.RegistrationDate,
                EntryDate = guestRequest.EntryDate,
                ReleaseDate = guestRequest.ReleaseDate,

                location = guestRequest.location,
                Type = guestRequest.Type,

                Adults = guestRequest.Adults,
                Children = guestRequest.Children,

                Pool = guestRequest.Pool,
                Jacuzzi = guestRequest.Jacuzzi,
                Garden = guestRequest.Garden,
                ChildrensAttractions = guestRequest.ChildrensAttractions
            };
        }
        public static List<GuestRequest> Clon(this List<GuestRequest> guestRequest)
        {
            int counter = 0;
            List<GuestRequest> retVal = new List<GuestRequest>();
            foreach (var item in guestRequest)
            {
                retVal.Add(Cloning.Clon(guestRequest[counter]));
                ++counter;
            }

            return retVal;
        }
        public static Host Clon(this Host host)
        {
            return new Host()
            {
                HostKey = host.HostKey,
                PrivateName = host.PrivateName,
                FamilyName = host.FamilyName,
                FhoneNumber = host.FhoneNumber,
                MailAddress = host.MailAddress,
                BankAccount = host.BankAccount,
                CollectionClearance = host.CollectionClearance,
                hostingUnits = new List<HostingUnit>(host.hostingUnits)
            };
        }
        public static List<Host> Clon(this List<Host> hosts)
        {
            int counter = 0;
            List<Host> retVal = new List<Host>();
            foreach (var item in hosts)
            {
                retVal.Add(Cloning.Clon(hosts[counter]));
                ++counter;
            }

            return retVal;
        }

        public static HostingUnit Clon(this HostingUnit hostingUnit)
        {
            return new HostingUnit()
            {
                hostinUnitKey = hostingUnit.hostinUnitKey,              
                HostingUnitName = hostingUnit.HostingUnitName,
                Diary = hostingUnit.Diary,
                Location = hostingUnit.Location,
                capacity = hostingUnit.capacity,
                Pool = hostingUnit.Pool,
                Jacuzzi = hostingUnit.Jacuzzi,
                Garden = hostingUnit.Garden,
                ChildrensAttractions = hostingUnit.ChildrensAttractions
            };
        }
        public static List<HostingUnit> Clon(this List<HostingUnit> hostingUnit)
        {
            int counter = 0;
            List<HostingUnit> retVal = new List<HostingUnit>();
            foreach (var item in hostingUnit)
            {
                retVal.Add(Cloning.Clon(hostingUnit[counter]));
                ++counter;
            }

            return retVal;
        }

        public static Order Clon(this Order order)
        {
            return new Order()
            {
                HostingUnitKey = order.HostingUnitKey,
                GuestRequestKey = order.GuestRequestKey,
                OrderKey = order.OrderKey,
                status = order.status,
                CreateDate = order.CreateDate,
                OrderDate = order.OrderDate
            };
        }
        public static List<Order> Clon(this List<Order> orders)
        {
            int counter = 0;
            List<Order> retVal = new List<Order>();
            foreach (var item in orders)
            {
                retVal.Add(Cloning.Clon(orders[counter]));
                ++counter;
            }

            return retVal;
        }
    }
}
