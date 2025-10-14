using mobile.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace mobile.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged();
                SetupAboutText();
            }
        }

        private string _displayedAbout;
        public string DisplayedAbout
        {
            get => _displayedAbout;
            private set
            {
                _displayedAbout = value;
                OnPropertyChanged();
            }
        }

        private bool _isAboutExpanded;
        public bool IsAboutExpanded
        {
            get => _isAboutExpanded;
            set
            {
                _isAboutExpanded = value;
                OnPropertyChanged();
                UpdateDisplayedAboutText();
            }
        }

        public ICommand MyBooksCommand { get; }
        public ICommand EditProfileCommand { get; }
        public ICommand BooksWishlistCommand { get; }
        public ICommand MySharedBooksCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand ToggleAboutCommand { get; }

        public AccountViewModel()
        {
            MyBooksCommand = new Command(async () => await Shell.Current.GoToAsync("MyBooksPage"));
            EditProfileCommand = new Command(async () => await Application.Current.MainPage.DisplayAlert("Not Implemented", "Edit Profile functionality will be added soon.", "OK"));
            BooksWishlistCommand = new Command(async () => await Application.Current.MainPage.DisplayAlert("Not Implemented", "Wishlist functionality will be added soon.", "OK"));
            MySharedBooksCommand = new Command(async () => await Application.Current.MainPage.DisplayAlert("Not Implemented", "Shared Books functionality will be added soon.", "OK"));
            LogoutCommand = new Command(async () => await Shell.Current.GoToAsync("//LandingPage"));
            ToggleAboutCommand = new Command(() => IsAboutExpanded = !IsAboutExpanded);

            LoadCurrentUser();
        }

        private void LoadCurrentUser()
        {
            CurrentUser = new User
            {
                Id = Guid.NewGuid(),
                FullName = "Charlotte Gabbard",
                Username = "@charlotte_g",
                Location = "Kharkiv, Ukraine",
                ProfilePictureUrl = "profile_placeholder.png",
                About = "I've been an avid reader for 5 years and I'm always looking for the next great story. My favorite genres are fantasy, science fiction, and historical novels. Let's trade books and discover new worlds together!",
                Rating = 4.8,
                FavoriteGenres = new List<string> { "Fantasy", "Sci-Fi", "Historical", "Mystery" }
            };
        }

        private void SetupAboutText()
        {
            IsAboutExpanded = false;
        }

        private void UpdateDisplayedAboutText()
        {
            if (CurrentUser == null || string.IsNullOrEmpty(CurrentUser.About))
            {
                DisplayedAbout = string.Empty;
                return;
            }

            if (IsAboutExpanded || CurrentUser.About.Length <= 100)
            {
                DisplayedAbout = CurrentUser.About;
            }
            else
            {
                DisplayedAbout = $"{CurrentUser.About.Substring(0, 100)}...More";
            }
        }
    }
}

