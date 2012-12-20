using System.Windows;
using System.Windows.Navigation;

namespace NavigationWithPages
{
    /// <summary>
    /// Interaction logic for Ok.xaml
    /// </summary>
    public partial class Ok : PageFunction<bool>
    {
        public Ok()
        {
            InitializeComponent();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            OnReturn(new ReturnEventArgs<bool>(true));
        }
    }
}
