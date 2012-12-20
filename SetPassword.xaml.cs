using System;
using System.Windows;
using System.Windows.Navigation;

namespace NavigationWithPages
{
    /// <summary>
    /// Interaction logic for SetPassword.xaml
    /// </summary>
    public partial class SetPassword : PageFunction<string>
    {
        private readonly string _username;
        private readonly Users _users;

        public SetPassword(string username, Users users)
        {
            InitializeComponent();
            _username = username;
            _users = users;
            Username.Text = _username;
            KeepAlive = true;
            Loaded += delegate { Password.Focus(); };
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            var password = Password.Password;
            if (String.IsNullOrWhiteSpace(password)) return;

            _users.Add(new User { Username = _username, Password = password });
            OnReturn(new ReturnEventArgs<string>(_username));
        }
    }
}
