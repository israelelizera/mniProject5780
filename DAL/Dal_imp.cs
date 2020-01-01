﻿using System;
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
            if(guestRequest.EntryDate>guestRequest.ReleaseDate)
            DS.DataSource.guestRequests.Add(Cloning.Clone(guestRequest));
            else 
             throw new System.ArgumentException("release date must be after entry date");        
        }
        public void updateGuestRequest(int guestRequestKey, GuestRequestStatus guestRequestStatus)
        {
            int counter = 0;
            var match = from guest in DS.DataSource.guestRequests
                        where guestRequestKey == guest.GuestRequestKey
                        select guest;

            int count =match.ToList().RemoveAll(guest=>guestRequestKey==guest.GuestRequestKey);
            if(count==0)
                throw new 
            match.ToList()[0].status = guestRequestStatus;
            DataSource.guestRequests.Add(match.ToList[0]);
            

        }
        public void deleteGuestRequest(GuestRequest guestRequest)
        {
            int counter = 0;
            var match = from guest in DS.DataSource.guestRequests
                        where guestRequest.Equals(guest)
                        select guest;
            foreach (GuestRequest item in DS.DataSource.guestRequests)
            {

                if (item.Equals(match))
                    DS.DataSource.guestRequests.RemoveAt(counter);
                ++counter;
            }
            return;
        }

        //HostingUnit
        public void addHostingUnit(HostingUnit hostingUnit)
        {
            var match = from hostU in DS.DataSource.hostingUnits
                        let equal = isEquals(hostU.GetHost().getHostKey(), hostingUnit.GetHost().getHostKey())
                        where equal
                        select hostU;
            if (match.Any())
                throw new System.ArgumentException("there's no two persons with the same id");
            else
            {
                DS.DataSource.hostingUnits.Add(hostingUnit);
            }

        }
        public void updateHostingUnit(HostingUnit hostingUnit, HostingUnit hostingUnitUpdate)
        {
            int counter = 0;
            var match = from hostU in DS.DataSource.hostingUnits
                        where hostingUnit.Equals(hostU)
                        select (hostU);
            foreach (HostingUnit item in DS.DataSource.hostingUnits)
            {

                if (item.Equals(match))
                    DS.DataSource.hostingUnits.Insert(counter, hostingUnitUpdate);
                ++counter;
            }
            return;
        }
        public void deleteHostingUnit(HostingUnit hostingUnit)
        {
            int counter = 0;
            var match = from hostingU in DS.DataSource.hostingUnits
                        where hostingUnit.Equals(hostingU)
                        select hostingU;
            foreach (HostingUnit item in DS.DataSource.hostingUnits)
            {

                if (item.Equals(match))
                    DS.DataSource.hostingUnits.RemoveAt(counter);
                ++counter;
            }
            throw dalExeptionItemDoesntexist();

        }

        //Order
        public void addOrder(Order order)
        {
            DS.DataSource.orders.Add(order);
        }
        public void updateOrder(Order order, Order orderUpdate)
        {
            
            int counter = 0;
            var match = from ord in DS.DataSource.orders
                        where order.Equals(ord)
                       select  (temp=ord.status);
            foreach (Order item in DS.DataSource.orders)
            {

                if (item.Equals(match))
                   DS.DataSource.orders.ElementAt(counter).status=match;
                ++counter;
            }
            return;
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
            return DS.DataSource.hosts;
        }

        public bool isEquals(int a, int b)
        {
            return a == b;
        }


    }
}
