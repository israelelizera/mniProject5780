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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;

            try
            {
                HostingUnit.HostingUnitName = HostingUnitName.Text;
                HostingUnit.location = (BE.Location)Location.SelectedIndex;
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
            catch (FormatException)
            {
                MessageBox.Show("check your input and try again");
                success = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                success = false;
            }

            if (success)
            {
                MessageBox.Show("The addition was successful!");
                new Host().Show();
                Close();
            }

        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            HostingUnit = new BE.HostingUnit();
            HostingUnitName.ClearValue(TextBox.TextProperty);
            new Host().Show();
            Close();
        }
    }
}
