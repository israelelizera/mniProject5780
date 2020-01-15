using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DAL;

namespace BL
{
   public class BL_imp : IBL
    {
        IDAL dal = FactoryDal.getDal();

        //------------------------GuestRequest------------------------------
        public void addGuestRequest(GuestRequest guestRequest)
        {
            //Logical Enforcement
            if (guestRequest.ReleaseDate <= guestRequest.EntryDate || guestRequest.ReleaseDate < DateTime.Now)
                throw new BLexception.InvalidDatesException();

            if (guestRequest.PrivateName == "" || guestRequest.PrivateName == null)
                throw new BLexception.InvalidPrivateNameException();

            if (guestRequest.FamilyName == "" || guestRequest.FamilyName == null)
                throw new BLexception.InvalidFamilyNameException();

            if (guestRequest.MailAddress == "" || guestRequest.MailAddress == null || !BLexception.IsValidEmail(guestRequest.MailAddress))
                throw new BLexception.InvalidMailAddressEception();

            if (guestRequest.Adults < 0 || guestRequest.Children < 0 || guestRequest.Adults + guestRequest.Children == 0)
                throw new BLexception.InvalidNumberVacationersException();

            try
            {
                dal.addGuestRequest(guestRequest);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void updateGuestRequest(GuestRequest guestRequest, GuestRequest guestRequestUpdate)
        {
            //Logical Enforcement
            if (guestRequest.ReleaseDate <= guestRequest.EntryDate || guestRequest.ReleaseDate < DateTime.Now)
                throw new BLexception.InvalidDatesException();

            if (guestRequest.PrivateName == "" || guestRequest.PrivateName == null)
                throw new BLexception.InvalidPrivateNameException();

            if (guestRequest.FamilyName == "" || guestRequest.FamilyName == null)
                throw new BLexception.InvalidFamilyNameException();

            if (guestRequest.MailAddress == "" || guestRequest.MailAddress == null || !BLexception.IsValidEmail(guestRequest.MailAddress))
                throw new BLexception.InvalidMailAddressEception();

            if (guestRequest.Adults < 0 || guestRequest.Children < 0 || guestRequest.Adults + guestRequest.Children == 0)
                throw new BLexception.InvalidNumberVacationersException();

            try
            {
                dal.updateGuestRequest(guestRequest, guestRequest);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void deleteGuestRequest(GuestRequest guestRequest)
        {
            try
            {
                dal.deleteGuestRequest(guestRequest);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //-----------------------HostingUnit--------------------------------
        public void addHostingUnit(HostingUnit hostingUnit)
        {
            //Logical Enforcement
            if (hostingUnit.HostingUnitName == "" || hostingUnit.HostingUnitName == null)
                throw new BLexception.InvalidHostingUnitNameException();

            if (hostingUnit.Diary == null)
                throw new BLexception.DiaryIsNullException();

            try
            {
                dal.addHostingUnit(hostingUnit);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void updateHostingUnit(HostingUnit hostingUnit, HostingUnit hostingUnitUpdate)
        {
            //Logical Enforcement
            if (hostingUnit.HostingUnitName == "" || hostingUnit.HostingUnitName == null)
                throw new BLexception.InvalidHostingUnitNameException();

            if (hostingUnit.Diary == null)
                throw new BLexception.DiaryIsNullException();

            try
            {
                dal.updateHostingUnit(hostingUnit, hostingUnitUpdate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void deleteHostingUnit(HostingUnit hostingUnit)
        {
            //Checks if there is an open invitation for this hosting unit
            var hostingUnitOreder = from order in GetOrders()
                                    where (order.HostingUnitKey == hostingUnit.hostinUnitkey) &&
                                            (order.status == StatusOrder.NotAddressed || order.status == StatusOrder.SentEmail)
                                    select order;

            if (hostingUnitOreder != null)
                throw new BLexception.OpenOrderException();

            try
            {
                dal.deleteHostingUnit(hostingUnit);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //-----------------------Order--------------------------------
        public void addOrder(Order order)
        {
            //Checks if the hosting unit is available on the requested date
            HostingUnit hostingUnit = GetHostingUnitByKey(order.HostingUnitKey);
            GuestRequest guestRequest = GetGuestRequestByKey(order.GuestRequestKey);

            if (!hostingUnit.AvailableOnDate(guestRequest))
                throw new BLexception.UnvailableHostingUnitException();

            try
            {
                dal.addOrder(order);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void updateOrder(Order order, Order orderUpdate)
        {
            //can't change a closed order status
            if (order.status != orderUpdate.status && order.status == StatusOrder.ClosedForCustomerResponse)
                throw new BLexception.CloseOrderException();

            //Checks if the hosting unit is available on the requested date
            HostingUnit hostingUnit = GetHostingUnitByKey(order.HostingUnitKey);
            GuestRequest guestRequest = GetGuestRequestByKey(order.GuestRequestKey);

            if (!hostingUnit.AvailableOnDate(guestRequest))
                throw new BLexception.UnvailableHostingUnitException();

            try
            {
                dal.updateOrder(order, orderUpdate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //-----------------------gets--------------------------------
        public List<HostingUnit> getHostingUnits()
        {
            return dal.getHostingUnits();
        }
        public List<GuestRequest> GetGuestRequests()
        {
            return dal.GetGuestRequests();
        }
        public List<Order> GetOrders()
        {
            return dal.GetOrders();
        }
        public List<Host> GetHosts()
        {
            return dal.GetHosts();
        }

        /*-------------------------------------------------*/
        public List<HostingUnit> freeHostingUnits(DateTime dateTime, int day)
        {
            if (day < 0)
                throw new BLexception.DayCantBeUnderZeroException();

            var list = from unit in getHostingUnits()
                       where unit.AvailableOnDate(dateTime, day)
                       select unit;

               return list.ToList();
        }

        public int daysBetween(DateTime date1, DateTime date2)
        {
            if (date1 > date2)
                return (date1 - date2).Days;
            return (date2 - date1).Days;

        }

        public int daysBetween(DateTime date)
        {
            if (DateTime.Now > date)
                return (DateTime.Now - date).Days;
            return (date - DateTime.Now).Days;
        }

        public List<Order> timePast(int day)
        {
            var list = from order in GetOrders()
                       where (DateTime.Now - order.OrderDate).Days > day
                       select order;

            return list.ToList();
        }

        public List<GuestRequest> GetGuestRequestByFunc(Func<GuestRequest, bool> func)
        {
            var list = from guestRequest in GetGuestRequests()
                       where func(guestRequest)
                       select guestRequest;

            return list.ToList();
        }

        public int numOfOrders(GuestRequest guestRequest)
        {
            var list = from order in GetOrders()
                       where order.GuestRequestKey == guestRequest.GuestRequestKey
                       select order;

            return list.ToList().Count;
        }

        public int OrdersSentOrClosed(HostingUnit hostingUnit)
        {
            var list = from order in GetOrders()
                       where order.HostingUnitKey == hostingUnit.hostinUnitkey
                       select order;

            return list.ToList().Count;
        }

        /*----------------------Grouping-----------------*/
        public IEnumerable<IGrouping<Location, GuestRequest>> GuestRequestByLocation()
        {
            IEnumerable<IGrouping<Location, GuestRequest>> guestRequests = from guestRequest in GetGuestRequests()
                                                                           group guestRequest by guestRequest.location;
            return guestRequests;
        }
        public IEnumerable<IGrouping<int, GuestRequest>> GuestRequestByVacationers()
        {
            IEnumerable<IGrouping<int, GuestRequest>> guestRequests = from guestRequest in GetGuestRequests()
                                                                      group guestRequest by (guestRequest.Adults + guestRequest.Children);
            return guestRequests;
        }
        public IEnumerable<IGrouping<int, Host>> HostByHostingUnitNum()
        {
            IEnumerable<IGrouping<int, Host>> hosts = from host in GetHosts()
                                                      group host by host.hostingUnits.Count;

            return hosts;
        }
        public IEnumerable<IGrouping<Location, HostingUnit>> HostingUnitByLocation()
        {
            IEnumerable<IGrouping<Location, HostingUnit>> hostingUnits = from hostingUnit in getHostingUnits()
                                                                         group hostingUnit by hostingUnit.location;
            return hostingUnits;
        }

        //-----------funk----------

        public HostingUnit GetHostingUnitByKey(int key)
        {
                var varHostingUnit = from hostingUnit in getHostingUnits()
                                 where hostingUnit.hostinUnitkey == key
                                 select hostingUnit;

            if (!varHostingUnit.Any())
                throw new BLexception.HostingUnitDoesntExistException();

            return varHostingUnit.ToList()[0];
        }

        public GuestRequest GetGuestRequestByKey(int key)
        {
            var varGuestRequest = from guestRequest in GetGuestRequests()
                                  where guestRequest.GuestRequestKey == key
                                  select guestRequest;

            if (!varGuestRequest.Any())
                throw new BLexception.GuestRequestDoesntExistException();

            return varGuestRequest.ToList()[0];
        }
    }
}

