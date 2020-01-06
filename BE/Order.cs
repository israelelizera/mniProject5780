using System;
using System.Collections.Generic;
using System.Text;

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

        public override string ToString() { return null; }
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
