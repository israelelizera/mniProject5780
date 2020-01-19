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
    /// Interaction logic for Guest.xaml
    /// </summary>
    public partial class Guest : Window
    {
        public Guest()
        {
            InitializeComponent();
        }

        private void AddGuestRequest_Click(object sender, RoutedEventArgs e)
        {
            new AddGuestRequest().Show();
            Close();
        }

        private void LookingForHostingUnit_Click(object sender, RoutedEventArgs e)
        {
           new  PLWPF.freeHostingUnits().Show();
            Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
