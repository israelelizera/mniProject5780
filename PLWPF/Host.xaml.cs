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
    /// Interaction logic for Host.xaml
    /// </summary>
    public partial class Host : Window
    {
        public Host()
        {
            InitializeComponent();
        }

        private void Add_hosting_unit_Click(object sender, RoutedEventArgs e)
        {
            new AddHostingUnit().Show();
            Close();
        }

        private void cencel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void Add_order_Click(object sender, RoutedEventArgs e)
        {
            new AddOrder().Show();
            Close();
        }

        private void Update_order_Click(object sender, RoutedEventArgs e)
        {
            new UpdateOrder().Show();
            Close();
        }
    }
}
