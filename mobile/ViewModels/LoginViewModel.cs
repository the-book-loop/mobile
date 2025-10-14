using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand SignUpCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        private async void OnLogin()
        {
            //TODO: API request
        
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please enter both username and password", "OK");
                return;
            }

            // Тимчасово — успішний логін
            await App.Current.MainPage.DisplayAlert("Success", $"Welcome, {Username}!", "OK");

            // Перехід на головний екран
            await Shell.Current.GoToAsync("///MainApp");
        }
    }
}
