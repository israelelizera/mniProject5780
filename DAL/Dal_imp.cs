using BE;
using DS;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class Dal_imp : IDAL
    {
        //GuestRequest
        public void addGuestRequest(GuestRequest guestRequest)
        {
            if (DS.DataSource.guestRequests != null)
            {
                var match = from guest in DS.DataSource.guestRequests
                            where guestRequest.GuestRequestKey == guest.GuestRequestKey
                            select guest;
                if (match.Count() > 0)
                    throw new dalExeptionIDalreadyExist();
                else
                    DataSource.guestRequests.Add(Cloning.Clon(guestRequest));
            }
            else
            {
                DataSource.guestRequests = new List<GuestRequest>();
                DataSource.guestRequests.Add(Cloning.Clon(guestRequest));
            }
        }
        public void updateGuestRequest(int guestRequestKey, StatusOrder guestRequestStatus)
        {
            var match = from guest in DS.DataSource.guestRequests
                        where guestRequestKey == guest.GuestRequestKey
                        select guest;
            if (match.Count() == 0)
                throw new dalExeptionItemDoesntExist();
            else if (match.Count() > 1)
                throw new dalExeptionMoreThanOneAnswer();
            match.ToList().RemoveAll(guest => guestRequestKey == guest.GuestRequestKey);
            match.ToList()[0].status = guestRequestStatus;
            GuestRequest matchGuest = new GuestRequest();
            matchGuest = match.ToList()[0];
            DataSource.guestRequests.RemoveAll(guest => guestRequestKey == guest.GuestRequestKey);
            DataSource.guestRequests.Add(matchGuest);
        }
        public void updateGuestRequest(GuestRequest guestRequestKey, GuestRequest guestRequestStatus)
        {
            updateGuestRequest(guestRequestKey.GuestRequestKey, guestRequestStatus.status);
        }

        public void deleteGuestRequest(int guestRequestKey)//if theres more than one matching its will remove all 
        {
            var match = from guest in DS.DataSource.guestRequests
                        where guestRequestKey == guest.GuestRequestKey
                        select guest;
            if (match.Count() == 0)
                throw new dalExeptionItemDoesntExist();
            DataSource.guestRequests.RemoveAll(guest => guestRequestKey == guest.GuestRequestKey);
        }
        public void deleteGuestRequest(GuestRequest guestRequestKey)
        {
            deleteGuestRequest(guestRequestKey.GuestRequestKey);
        }


        //HostingUnit
        public void addHostingUnit(HostingUnit hostingUnit)
        {
            if (DataSource.hostingUnits != null)
            {
                if (DataSource.hostingUnits.Exists(host => host.HostinUnitKey == hostingUnit.HostinUnitKey))
                    throw new dalExeptionIDalreadyExist();

                DataSource.hostingUnits.Add(Cloning.Clon(hostingUnit));
            }

            else
            {
                DataSource.hostingUnits = new List<HostingUnit>();
                DataSource.hostingUnits.Add(Cloning.Clon(hostingUnit));
            }
        }

        public void updateHostingUnit(int hostingUnitKey, bool[,] diary)
        {
            var match = from hostU in DS.DataSource.hostingUnits
                        where hostingUnitKey == hostU.HostinUnitKey
                        select hostU;
            if (match.Count() == 0)
                throw new dalExeptionItemDoesntExist();
            else if (match.Count() > 1)
                throw new dalExeptionMoreThanOneAnswer();
            match.ToList().RemoveAll(hostU => hostingUnitKey == hostU.HostinUnitKey);
            match.ToList()[0].Diary = diary;
            HostingUnit matchHosting = new HostingUnit();
            matchHosting = match.ToList()[0];
            DataSource.hostingUnits.RemoveAll(hostU => hostingUnitKey == hostU.HostinUnitKey);
            DataSource.hostingUnits.Add(matchHosting);
        }
        public void updateHostingUnit(HostingUnit hostingUnit, HostingUnit hostingUnitUpdate)
        {
            updateHostingUnit(hostingUnit.HostinUnitKey, hostingUnitUpdate.Diary);
        }

        public void deleteHostingUnit(HostingUnit hostingUnit)
        {
            var match = from hostU in DS.DataSource.hostingUnits
                        where hostingUnit.HostinUnitKey == hostU.HostinUnitKey
                        select hostU;
            if (match.Count() == 0)
                throw new dalExeptionItemDoesntExist();
            DataSource.guestRequests.RemoveAll(hostU => hostingUnit.HostinUnitKey == hostU.GuestRequestKey);
        }

        //Order
        public void addOrder(Order order)
        {
            if (DataSource.orders != null)
            {
                var match = from anOrder in DataSource.orders
                            let equal = anOrder.OrderKey == order.OrderKey
                            where equal
                            select anOrder;
                if (match.Count() > 0)
                    throw new dalExeptionIDalreadyExist();
                else
                {
                    DataSource.orders.Add(Cloning.Clon(order));
                }
            }
            else
            {
                DataSource.orders = new List<Order>();
                DataSource.orders.Add(Cloning.Clon(order));
            }
        }
        public void updateOrder(int orderKey, StatusOrder status)
        {

            var match = from anOrder in DataSource.orders
                        where orderKey == anOrder.HostingUnitKey
                        select anOrder;
            if (match.Count() == 0)
                throw new dalExeptionItemDoesntExist();
            else if (match.Count() > 1)
                throw new dalExeptionMoreThanOneAnswer();
            match.ToList().RemoveAll(anOrder => anOrder.OrderKey == orderKey);
            match.ToList()[0].status = status;
            Order matchOrder = new Order();
            matchOrder = match.ToList()[0];
            DataSource.orders.RemoveAll(anOrder => anOrder.OrderKey == orderKey);
            DataSource.orders.Add(matchOrder);
        }
        public void updateOrder(Order order, Order orderUpdate)
        {
            updateOrder(order.HostingUnitKey, orderUpdate.status);
        }
        public void updateOrder(Order order)
        {
            int index= DataSource.orders.FindIndex(HS => HS.OrderKey == order.OrderKey);

            if (index == -1)
                throw new dalExeptionItemDoesntExist();
            DataSource.orders[index] = order;
        }

        //get List
        public List<Order> GetOrders()
        {
            return DS.DataSource.orders;
        }
        public List<GuestRequest> GetGuestRequests()
        {
            return Cloning.Clon(DataSource.guestRequests);

        }
        public List<HostingUnit> getHostingUnits()
        {
            return DS.DataSource.hostingUnits;

        }

        public List<Host> GetHosts()
        {
            return DataSource.hosts;
        }

        public void updateHostingUnit(HostingUnit hostingUnit)
        {
            HostingUnit hosting = DataSource.hostingUnits.Find(HS => HS.HostinUnitKey == hostingUnit.HostinUnitKey);

            if (hosting == null)
                throw new dalExeptionItemDoesntExist();

            hosting = hostingUnit;
        }
    }
}
