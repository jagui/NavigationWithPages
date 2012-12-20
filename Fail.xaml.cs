using System.Windows;
using System.Windows.Navigation;

namespace NavigationWithPages
{
    /// <summary>
    /// Interaction logic for Fail.xaml
    /// </summary>
    public partial class Fail : PageFunction<bool>
    {
        public Fail()
        {
            InitializeComponent();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            OnReturn(new ReturnEventArgs<bool>(false));
        }
    }
}
