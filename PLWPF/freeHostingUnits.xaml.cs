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
    /// Interaction logic for freeHostingUnits.xaml
    /// </summary>
    public partial class freeHostingUnits : Window
    {
        public BL.IBL bL = new BL.BL_imp();
        public freeHostingUnits()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bL.freeHostingUnits(Convert.ToDateTime(this.startDatePicker.SelectedDate), Convert.ToInt32(this.NumberOfDaysBox.Text));
        }
    }
}
