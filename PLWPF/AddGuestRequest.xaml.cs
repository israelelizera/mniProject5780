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
            PrivateNameBox.Text = string.Format(PrivateNameBox.Text);
            //FamilyNameBox.Text = string.Format(FamilyNameBox.Text);
            LocationBox.ItemsSource = Enum.GetValues(typeof(BE.Location));
            TypeBox.ItemsSource = Enum.GetValues(typeof(BE.KindOfUnit));
            PoolBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            JacuzziBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            GardenBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            ChildrenAttractionBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            EntryDatePicker.SelectedDate =Convert.ToDateTime(EntryDatePicker.SelectedDate);
            ReleaseDatePicker.SelectedDate = Convert.ToDateTime(ReleaseDatePicker.SelectedDate);
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


    }
}
