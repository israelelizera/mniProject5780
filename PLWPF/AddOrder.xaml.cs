using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        BL.IBL BL = new BL.BL_imp();
        BE.Order order = new BE.Order();
        public AddOrder()
        {
            InitializeComponent();
            this.DataContext = order;
          /*  order.HostingUnitKey = Convert.ToInt32( this.HostingUnitKeyBox.Text);
            order.GuestRequestKey= Convert.ToInt32(this.GuestRequestKeyBox.Text);
            order.OrderKey = Convert.ToInt32(this.OrderKeyBox.Text);*/
            this.StatusBox.ItemsSource = Enum.GetValues(typeof(BE.StatusOrder));
            CreateDatePicker.SelectedDate = DateTime.Today;
            OrderDatePicker.SelectedDate = DateTime.Today;
        }



        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            BL.addOrder(order);
            Close();
        }
    }
}
