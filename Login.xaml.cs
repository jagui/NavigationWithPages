using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NavigationWithPages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : PageFunction<bool>
    {
        private readonly string _username;
        private readonly Users _users;

        public Login(string username, Users users)
        {
            _username = username;
            _users = users;
            InitializeComponent();
            Username.Text = _username;
            KeepAlive = true; 
            Loaded += delegate { Password.Focus(); };
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            var password = Password.Password;
            if (String.IsNullOrWhiteSpace(password)) return;

            PageFunction<bool> nextPage;
            if (_users.Login(_username, password))
            {
                nextPage = new Ok();
            }
            else
            {
                nextPage = new Fail();
            }
            nextPage.Return += NextPageOnReturn;
            NavigationService.Navigate(nextPage);
        }

        private void NextPageOnReturn(object sender, ReturnEventArgs<bool> returnEventArgs)
        {
            if (returnEventArgs.Result)
            {
                OnReturn(returnEventArgs);
            }
        }
    }
}
