using mobile.Views;

namespace mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(CreateAccountPage), typeof(CreateAccountPage));
            Routing.RegisterRoute(nameof(AccountPage), typeof(AccountPage));
            Routing.RegisterRoute(nameof(MyBooksPage), typeof(MyBooksPage));
            Routing.RegisterRoute(nameof(AddBookPage), typeof(AddBookPage));
        }
    }
}
