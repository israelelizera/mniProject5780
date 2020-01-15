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
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddGuestRequest.xaml
    /// </summary>
    public partial class AddGuestRequest : Window
    {
        BE.GuestRequest guestRequest;
        BL.IBL bL;
        public AddGuestRequest()
        {
            InitializeComponent();
            guestRequest = new GuestRequest();
            this.GuestRequestDetails.DataContext = guestRequest;
            bL = new BL.BL_imp();
            this.LocationBox.ItemsSource = Enum.GetValues(typeof(BE.Location));
            this.TypeBox.ItemsSource = Enum.GetValues(typeof(BE.KindOfUnit));
            this.PoolBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            this.JacuzziBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            this.GardenBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            this.ChildrenAttractionBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bL.addGuestRequest(guestRequest);
                guestRequest = new GuestRequest();
                this.DataContext = guestRequest;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // guestRequestViewSource.Source = [generic data source]
        }
    }
}
