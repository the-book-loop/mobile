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
            SignUpCommand = new Command(OnSignUp);
        }

        private async void OnLogin()
        {
            //TODO: API request

            // Temporarily
            await App.Current.MainPage.DisplayAlert("Success", "You have logged in!", "OK");
            await Shell.Current.GoToAsync("///MainApp");
        }

        private async void OnSignUp()
        {
            // registerPage
           // await Shell.Current.GoToAsync($"../{nameof(CreateAccountPage)}");
        }
    }
}
