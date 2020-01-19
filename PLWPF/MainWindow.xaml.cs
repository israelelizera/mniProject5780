using System.Windows;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();           
        }

        private void Host(object sender, RoutedEventArgs e)
        {
            new Host().Show();
            Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }




        private void guestRequest_Click(object sender, RoutedEventArgs e)
        {
            new AddGuestRequest().Show();
        }
    }
}
