﻿using System;
using System.Collections.Generic;
using System.Text;
using BE;
namespace DAL
{
    public interface IDAL
    {
        //GuestRequest
        void addGuestRequest(GuestRequest guestRequest);
        void updateGuestRequest(GuestRequest guestRequest, GuestRequest guestRequestUpdate);
        void deleteGuestRequest(GuestRequest guestRequest);

        //HostingUnit
        void addHostingUnit(HostingUnit hostingUnit);
        void deleteHostingUnit(HostingUnit hostingUnit);
        void updateHostingUnit(HostingUnit hostingUnit, HostingUnit hostingUnitUpdate);

        //Order
        void addOrder(Order order);
        void updateOrder(Order order, Order orderUpdate);

        //get List
        List<HostingUnit> getHostingUnits();
        List<GuestRequest> GetGuestRequests();
        List<Order> GetOrders();
        List<Host> GetHosts();
    }
}
