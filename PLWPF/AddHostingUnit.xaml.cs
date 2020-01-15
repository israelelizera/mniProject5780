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
            try
            {
                HostingUnit.HostingUnitName = HostingUnitName.Text;

                bL.addHostingUnit(HostingUnit);
                HostingUnit = new BE.HostingUnit();

                HostingUnitName.ClearValue(TextBox.TextProperty);
            }
            catch (FormatException)
            {
                MessageBox.Show("check your input and try again");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
            new MainWindow().Show();
        }
    }
}
