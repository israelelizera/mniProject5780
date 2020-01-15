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
using BE;

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
            guestRequest = new GuestRequest();
            bL = new BL.BL_imp();
        }
    }
}
