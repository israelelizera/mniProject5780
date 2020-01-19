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


            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;

            try
            {
                HostingUnit.HostingUnitName = HostingUnitName.Text;
                HostingUnit.Location = (BE.Location)Location.SelectedIndex;
                HostingUnit.Type = (BE.KindOfUnit)KindOfUnit.SelectedIndex;
                HostingUnit.capacity = int.Parse(capacity.Text);
                HostingUnit.Pool = (bool)pool.IsChecked;
                HostingUnit.ChildrensAttractions = (bool)ChildrensAttractions.IsChecked;
                HostingUnit.Garden = (bool)Garden.IsChecked;
                HostingUnit.Jacuzzi = (bool)Jacuzzi.IsChecked;
                bL.addHostingUnit(HostingUnit);
                HostingUnit = new BE.HostingUnit();

                HostingUnitName.ClearValue(TextBox.TextProperty);
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
