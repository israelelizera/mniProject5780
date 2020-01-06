using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL.Exeptions;
using DS;

namespace DAL
{
    public class Dal_imp : IDAL
    {
        //GuestRequest
        public void addGuestRequest(GuestRequest guestRequest)
        {
            var match = from guest in DS.DataSource.guestRequests
                        where guestRequest.GuestRequestKey == guest.GuestRequestKey
                        select guest;
            if (match.Count() > 0)
                throw new dalExeptionIdAlreadyexist();
            else
                DataSource.guestRequests.Add(Cloning.Clon( guestRequest));
        }
        public void updateGuestRequest(int guestRequestKey, StatusOrder guestRequestStatus)
        {
            var match = from guest in DS.DataSource.guestRequests
                        where guestRequestKey == guest.GuestRequestKey
                        select guest;
            if (match.Count() == 0)
                throw new dalExeptionItemDoesntexist();
            else if (match.Count() > 1)
                throw new dalExeptionMoreThanOneAnswer();
            match.ToList().RemoveAll(guest => guestRequestKey == guest.GuestRequestKey);
            match.ToList()[0].status = guestRequestStatus;
            DataSource.guestRequests.Add(Cloning.Clon(match.ToList()[0]));

        }
        public void deleteGuestRequest(int guestRequestKey)//if theres more than one matching its will remove all 
        {
            var match = from guest in DS.DataSource.guestRequests
                        where guestRequestKey == guest.GuestRequestKey
                        select guest;
            if (match.Count() == 0)
                throw new dalExeptionItemDoesntexist();
            DataSource.guestRequests.RemoveAll(guest => guestRequestKey == guest.GuestRequestKey);
        }

        //HostingUnit
        public void addHostingUnit(HostingUnit hostingUnit)
        {
            var match = from hostU in DS.DataSource.hostingUnits
                        let equal = hostU.HostingUnitKey== hostingUnit.HostingUnitKey
                        where equal
                        select hostU;
            if (match.Count() > 0)
                throw new dalExeptionIdAlreadyexist();
            else
            {
                DS.DataSource.hostingUnits.Add(Cloning.Clon(hostingUnit));
            }

        }
        public void updateHostingUnit(int hostingUnitKey, bool [,] diary)
        {
            var match = from hostU in DS.DataSource.hostingUnits
                        where hostingUnitKey == hostU.HostingUnitKey
                        select hostU;
            if (match.Count() == 0)
                throw new dalExeptionItemDoesntexist();
            else if (match.Count() > 1)
                throw new dalExeptionMoreThanOneAnswer();
            match.ToList().RemoveAll(hostU  => hostingUnitKey == hostU.HostingUnitKey);
            match.ToList()[0].Diary = diary;
            DataSource.hostingUnits.Add(Cloning.Clon(match.ToList()[0]));

        }
        public void deleteHostingUnit(HostingUnit hostingUnit)
        {
            var match = from hostU in DS.DataSource.hostingUnits
                        where hostingUnit.HostingUnitKey == hostU.HostingUnitKey
                        select hostU;
            if (match.Count() == 0)
                throw new dalExeptionItemDoesntexist();
            DataSource.guestRequests.RemoveAll(hostU => hostingUnit.HostingUnitKey == hostU.GuestRequestKey);
        }

        //Order
        public void addOrder(Order order)
        {
            var match = from anOrder in DataSource.orders
                        let equal = anOrder.OrderKey == order.OrderKey
                        where equal
                        select anOrder;
            if (match.Count() > 0)
                throw new dalExeptionIdAlreadyexist();
            else
            {
                DataSource.orders.Add(Cloning.Clon(order));
            }
        }
        public void updateOrder(int orderKey, StatusOrder status )
        {

            var match = from anOrder in DataSource.orders
                        where orderKey == anOrder.HostingUnitKey
                        select anOrder;
            if (match.Count() == 0)
                throw new dalExeptionItemDoesntexist();
            else if (match.Count() > 1)
                throw new dalExeptionMoreThanOneAnswer();
            match.ToList().RemoveAll(anOrder => anOrder.OrderKey  == orderKey);
            match.ToList()[0].status = status;
            DataSource.orders.Add(match.ToList()[0]);
        }

        //get List
        public List<Order> GetOrders()
        {
            return DS.DataSource.orders;
        }
        public List<GuestRequest> GetGuestRequests()
        {
            return DS.DataSource.guestRequests;

        }
        public List<HostingUnit> getHostingUnits()
        {
            return DS.DataSource.hostingUnits;

        }

        public List<Host> GetHosts()
        {
            return ((List<Host>)(Cloning.Clon(DataSource.hosts)));
        }


    }
}
