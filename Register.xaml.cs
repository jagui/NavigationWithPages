using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NavigationWithPages
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        private readonly Users _users;

        public Register(Users users)
        {
            _users = users;
            InitializeComponent();
            Loaded += delegate { Username.Focus(); };
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            var username = Username.Text;
            if (String.IsNullOrWhiteSpace(username)) return;

            if (_users.Exists(username))
            {
                ExistingUser(username, _users);
            }
            else
            {
                var nextPage = new SetPassword(username, _users);
                nextPage.Return += AddUser;
                NavigationService.Navigate(nextPage);
            }
        }

        private void ExistingUser(string username, Users users)
        {
            var nextPage = new Login(username, _users);
            NavigationService.Navigate(nextPage);
        }

        private void AddUser(object sender, ReturnEventArgs<string> e)
        {
            var username = e.Result;
            ExistingUser(username, _users);
        }
    }
}
