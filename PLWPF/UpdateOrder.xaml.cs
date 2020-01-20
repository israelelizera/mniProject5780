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
    /// Interaction logic for UpdateOrder.xaml
    /// </summary>
    public partial class UpdateOrder : Window
    {
        BL.IBL bL = new BL.BL_imp();
        BE.Order order = new BE.Order();
        public UpdateOrder()
        {
            InitializeComponent();
            this.DataContext = order;
            this.StatusBox.ItemsSource = Enum.GetValues(typeof(BE.StatusOrder));
            CreateDatePicker.SelectedDate = DateTime.Today;
            OrderDatePicker.SelectedDate = DateTime.Today;
        }



        private void UpdateButton_Click_1(object sender, RoutedEventArgs e)
        {
            bL.updateOrder(order);
            Close();
        }
    }
}
