using System;
using System.Windows;

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
            guestRequest = new BE.GuestRequest();
            GuestRequestDetails.DataContext = guestRequest;
            guestRequest.PrivateName=(this.PrivateNameBox.Text);
            this.ChildrenAttractionBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            this.GardenBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            this.JacuzziBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            this.LocationBox.ItemsSource = Enum.GetValues(typeof(BE.Location));
            this.PoolBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            this.TypeBox.ItemsSource = Enum.GetValues(typeof(BE.KindOfUnit));

            bL = new BL.BL_imp();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;

            try
            {
                bL.addGuestRequest(guestRequest);

                guestRequest = new BE.GuestRequest();
                GuestRequestDetails.DataContext = guestRequest;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                success = false;
            }

            if (success)
            {
                new MainWindow().Show();
                Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
