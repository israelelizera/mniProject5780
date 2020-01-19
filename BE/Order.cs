using System;
using System.Collections.Generic;
using System.Text;
using BE;
namespace BE
{
    /// <summary>
    /// this class reporesent an order of client
    /// </summary>
    public class Order
    {
        public int HostingUnitKey;
        public int GuestRequestKey;
        public int OrderKey;
        public StatusOrder status;
        public DateTime CreateDate;
        public DateTime OrderDate;

        public override string ToString() {
            return ("HostingUnitKey: "+HostingUnitKey+"\n"+ "GuestRequestKey: "+ GuestRequestKey+"\n"
                + "OrderKey: "+ OrderKey+"\n"+ "status: "+status+"\n"+ "CreateDate: "+ CreateDate+"\n"+
              "OrderDate: "+ OrderDate+"\n");
        }
        public virtual bool Equals(Order order)
        {
            return (HostingUnitKey == order.HostingUnitKey &&
                GuestRequestKey == order.GuestRequestKey &&
                OrderKey == order.OrderKey &&
                status == order.status &&
                CreateDate == order.CreateDate &&
                OrderDate == order.OrderDate);

        }
    }
}
