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
                key = guestRequest.key,
                PrivateName = guestRequest.PrivateName,
                FamilyName = guestRequest.FamilyName,
                MailAddress = guestRequest.MailAddress,

                status = guestRequest.status,
                RegistrationDate = guestRequest.RegistrationDate,
                EntryDate = guestRequest.EntryDate,
                ReleaseDate = guestRequest.ReleaseDate,

                location = guestRequest.location,
                SubLocation = guestRequest.SubLocation,
                Type = guestRequest.Type,

                Adults = guestRequest.Adults,
                Children = guestRequest.Children,

                Pool = guestRequest.Pool,
                Jacuzzi = guestRequest.Jacuzzi,
                Garden = guestRequest.Garden,
                ChildrensAttractions = guestRequest.ChildrensAttractions
            };
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
        public static HostingUnit Clon(this HostingUnit hostingUnit)
        {
            return new HostingUnit()
            {
                key = hostingUnit.key,
                Owner = hostingUnit.Owner,
                HostingUnitName = hostingUnit.HostingUnitName,
                Diary = hostingUnit.Diary
            };
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
    }
}
