using System.Windows;

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

        private void guest_request_Click(object sender, RoutedEventArgs e)
        {
            new AddGuestRequest().Show();
            Close();
        }
    }
}
