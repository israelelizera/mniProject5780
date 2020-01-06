﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;

namespace BL
{
    class BL_imp : IBL
    {
        IDAL dal = FactoryDal.getDal();

        //------------------------GuestRequest------------------------------
        public void addGuestRequest(GuestRequest guestRequest)
        {
            //Logical Enforcement
            if (guestRequest.ReleaseDate <= guestRequest.EntryDate || guestRequest.ReleaseDate < DateTime.Now)
                throw new BLexception.InvalidDatesException();

            if (guestRequest.PrivateName == "" || guestRequest.PrivateName == null)
                throw new BLexception.PrivateNameMissingException();

            if (guestRequest.FamilyName == "" || guestRequest.FamilyName == null)
                throw new BLexception.FamilyNameMissingException();

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
                throw new BLexception.PrivateNameMissingException();

            if (guestRequest.FamilyName == "" || guestRequest.FamilyName == null)
                throw new BLexception.FamilyNameMissingException();

            if (guestRequest.MailAddress == "" || guestRequest.MailAddress == null || !BLexception.IsValidEmail(guestRequest.MailAddress))
                throw new BLexception.InvalidMailAddressEception();

            if (guestRequest.Adults < 0 || guestRequest.Children < 0 || guestRequest.Adults + guestRequest.Children == 0)
                throw new BLexception.InvalidNumberVacationersException();

            try
            {
                dal.updateGuestRequest(guestRequest, guestRequestUpdate);
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
                throw new BLexception.HostingUnitNameMissingException();

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
                throw new BLexception.HostingUnitNameMissingException();
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
            var hostingUnitOreder = from order in GetOrders()
                                    where (order.HostingUnitKey == hostingUnit.HostingUnitKey) &&
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
            if (order.status == StatusOrder.ClosedForCustomerResponse)
                throw new BLexception.CloseOrderException();

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
        public List<GuestRequest> GetGuestRequests()
        {
            return dal.GetGuestRequests();
        }
        public List<HostingUnit> getHostingUnits()
        {
            return dal.getHostingUnits();
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

        public List<HostingUnit> freeHostingUnits(DateTime dateTime, int day)
        {
            if (day <= 0)
                throw new BLexception.CantUndeZeroException();

            var list = from unit in getHostingUnits()
                       where unit.AvailableOnDate(dateTime, day)
                       select unit;

            return list.ToList();
        }

        public List<GuestRequest> guestRequests(Func<GuestRequest, bool> func)
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
                       where order.HostingUnitKey == hostingUnit.HostingUnitKey
                       select order;

            return list.ToList().Count;
        }

        public List<Order> timePast(int day)
        {
            var list = from order in GetOrders()
                       where (DateTime.Now - order.OrderDate).Days > day
                       select order;

            return list.ToList();
        }

        /*----------------------Grouping-----------------*/
        public IEnumerable<IGrouping<Location, GuestRequest>> GuestRequestByLocation()
        {
            IEnumerable<IGrouping<Location, GuestRequest>> guestRequests = from guestRequest in GetGuestRequests()
                                                                           group guestRequest by guestRequest.location;
            return guestRequests;
        }

        public IEnumerable<IGrouping<Location, HostingUnit>> HostingUnitByLocation()
        {
            IEnumerable<IGrouping<Location, HostingUnit>> hostingUnits = from hostingUnit in getHostingUnits()
                                                                         group hostingUnit by hostingUnit.location;
            return hostingUnits;
        }

        public IEnumerable<IGrouping<int, GuestRequest>> GuestRequestByVacationers()
        {
            IEnumerable<IGrouping<int, GuestRequest>> guestRequests = from guestRequest in GetGuestRequests()
                                                                      group guestRequest by (guestRequest.Adults + guestRequest.Children);
            return guestRequests;
        }
        public IEnumerable<IGrouping<int, Host>> HostByhostingUnitNum()
        {
            IEnumerable<IGrouping<int, Host>> hosts = from host in dal.GetHosts()
                                                      group host by host.hostingUnits.Count;

            return hosts;
        }
    }
}

