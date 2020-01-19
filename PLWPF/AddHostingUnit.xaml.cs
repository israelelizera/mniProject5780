using System;
using System.Windows;
using System.Windows.Controls;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddHostingUnit.xaml
    /// </summary>
    public partial class AddHostingUnit : Window
    {
        BE.HostingUnit HostingUnit;
        BL.IBL bL;
        public AddHostingUnit()
        {
            InitializeComponent();

            HostingUnit = new BE.HostingUnit();
            bL = new BL.BL_imp();

            HostingUnitDetails.DataContext = HostingUnit;

            Location.ItemsSource = Enum.GetValues(typeof(BE.Location));
            KindOfUnit.ItemsSource = Enum.GetValues(typeof(BE.KindOfUnit));

            Location.SelectedIndex = 0;
            KindOfUnit.SelectedIndex = 0;          
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;

            try
            {
                bL.addHostingUnit(HostingUnit);

                HostingUnit = new BE.HostingUnit();
                HostingUnitDetails.DataContext = HostingUnit;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                success = false;
            }

            if (success)
            {
                new Host().Show();
                Close();
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            new Host().Show();
            Close();
        }
    }
}
