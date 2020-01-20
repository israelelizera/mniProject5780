using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace BL
{
   public interface IBL
    {
        //------------------------GuestRequest------------------------------
        void addGuestRequest(GuestRequest guestRequest);
        void updateGuestRequest(GuestRequest guestRequest, GuestRequest guestRequestUpdate);
        void deleteGuestRequest(GuestRequest guestRequest);

        //-----------------------HostingUnit--------------------------------
        void addHostingUnit(HostingUnit hostingUnit);
        void updateHostingUnit(HostingUnit hostingUnit);
        void deleteHostingUnit(HostingUnit hostingUnit);

        //-----------------------Order--------------------------------
        void addOrder(Order order);
        //void updateOrder(Order order, Order orderUpdate);
        void updateOrder(Order order);

        //-----------------------gets--------------------------------
        List<HostingUnit> getHostingUnits();
        List<GuestRequest> GetGuestRequests();
        List<Order> GetOrders();
        List<Host> GetHosts();

        /*---------------------------------------------------------------------------------*/

        /// <summary>
        /// A function that accepts a date and number of vacation days
        /// and returns the list of all available units on that date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        List<HostingUnit> freeHostingUnits(DateTime dateTime, int day);

        /// <summary>
        ///The function returns the number of days that have passed from the first date to the second.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        int daysBetween(DateTime date1, DateTime date2);

        /// <summary>
        /// The function returns the days between teh date and today.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        int daysBetween(DateTime date);

        /// <summary>
        /// A function that accepts several days,
        ///and returns all orders that have elapsed since they were created / since the customer sent an email,
        ///greater than or equal to the number of days the function received
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        List<Order> timePast(int day);

        /// <summary>
        /// A function can return all client requirements that are appropriate for a particular condition
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        List<GuestRequest> GetGuestRequestByFunc(Func<GuestRequest, bool> func);

        /// <summary>
        /// A function that accepts customer demand and returns the number of orders sent to it
        /// </summary>
        /// <param name="guestRequest"></param>
        /// <returns></returns>
        int numOfOrders(GuestRequest guestRequest);

        /// <summary>
        /// A function that accepts a hosting unit
        ///and returns the number of invitations sent / the number of orders successfully closed for that unit
        /// </summary>
        /// <param name="guestRequest"></param>
        /// <returns></returns>
        int OrdersSentOrClosed(HostingUnit guestRequest);

        //-----------------------Grouping--------------------

        /// <summary>
        /// Customer requirements list is grouped by the resort Location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        IEnumerable<IGrouping<Location, GuestRequest>> GuestRequestByLocation();

        /// <summary>       
        ///  Customer requirements list is grouped according to the number of holidaymakers
        /// </summary>
        /// <param name="Vacationers"></param>
        /// <returns></returns>
        IEnumerable<IGrouping<int, GuestRequest>> GuestRequestByVacationers();

        /// <summary>
        /// Grouping hosts list by number of hosting units
        /// </summary>
        /// <param name="hostingUnit"></param>
        /// <returns></returns>
        IEnumerable<IGrouping<int, Host>> HostByHostingUnitNum();

        /// <summary>
        /// List of hosting units grouped by the resort location
        /// </summary>
        /// <param name="hostingUnit"></param>
        /// <returns></returns>
        IEnumerable<IGrouping<Location, HostingUnit>> HostingUnitByLocation();
    }
}
