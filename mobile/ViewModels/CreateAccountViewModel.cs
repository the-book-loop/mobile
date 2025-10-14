
using mobile.Views;
using System.Windows.Input;

namespace mobile.ViewModels
{
    public class CreateAccountViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand CreateAccountCommand { get; }
 
        public CreateAccountViewModel()
        {
            CreateAccountCommand = new Command(OnCreateAccount);
        }

        private async void OnCreateAccount()
        {
            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            if (!Email.Contains("@") || !Email.Contains("."))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please enter a valid email address.", "OK");
                return;
            }

            await App.Current.MainPage.DisplayAlert("Success", "Account created!", "OK");

            await Shell.Current.GoToAsync("///MainApp");
        }

    }
}
