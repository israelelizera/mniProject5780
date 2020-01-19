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

            ChildrenAttractionBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            GardenBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            JacuzziBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            LocationBox.ItemsSource = Enum.GetValues(typeof(BE.Location));
            PoolBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            TypeBox.ItemsSource = Enum.GetValues(typeof(BE.KindOfUnit));

            ChildrenAttractionBox.SelectedIndex = 1;
            GardenBox.SelectedIndex = 1;
            JacuzziBox.SelectedIndex = 1;
            LocationBox.SelectedIndex = 1;
            PoolBox.SelectedIndex = 1;
            TypeBox.SelectedIndex = 1;

            EntryDatePicker.SelectedDate = DateTime.Now;
            ReleaseDatePicker.SelectedDate = DateTime.Now;           

            bL = new BL.BL_imp();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;

            try
            {
                guestRequest.RegistrationDate = DateTime.Now;
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
