using Microsoft.Maui.Controls;
using mobile.ViewModels;
namespace mobile.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var waveAnimation = new Animation(v =>
        {
            WaveRow.Height = new GridLength(v, GridUnitType.Star);
            ContentRow.Height = new GridLength(1 - v, GridUnitType.Star);
        }, WaveRow.Height.Value, 0.2);

        waveAnimation.Commit(this, "WaveDownAnimation", 16, 600, Easing.CubicOut, (finalValue, isCompleted) =>
        {
            FadeInElement(WelcomeLabel, 0);
            FadeInElement(InfoLabel, 100);
            FadeInElement(UsernameBorder, 200);
            FadeInElement(PasswordBorder, 300);
            FadeInElement(LoginButton, 400);
            FadeInElement(BackButton, 500);
            FadeInElement(SignUp, 500);
        });
    }

    private async void FadeInElement(VisualElement element, int delay)
    {
        element.Opacity = 0;
        element.Scale = 0.95;

        if (delay > 0)
            await Task.Delay(delay);

        await element.FadeTo(1, 400, Easing.CubicInOut);
        await element.ScaleTo(1, 400, Easing.CubicOut);
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Task.WhenAll(
       WelcomeLabel.FadeTo(0, 300, Easing.CubicInOut),
       InfoLabel.FadeTo(0, 300, Easing.CubicInOut),
       UsernameBorder.FadeTo(0, 300, Easing.CubicInOut),
       PasswordBorder.FadeTo(0, 300, Easing.CubicInOut),
       LoginButton.FadeTo(0, 300, Easing.CubicInOut),
       BackButton.FadeTo(0, 300, Easing.CubicInOut),
       SignUp.FadeTo(0, 300, Easing.CubicInOut)
        );

        var animation = new Animation(v =>
        {
            WaveRow.Height = new GridLength(v, GridUnitType.Star);
            ContentRow.Height = new GridLength(1 - v, GridUnitType.Star);
        }, WaveRow.Height.Value, 0.7);

        animation.Commit(this, "WaveUpAnimation", 16, 900, Easing.CubicInOut, async (finalValue, isCompleted) =>
        {
            await Shell.Current.GoToAsync("///LandingPage", animate: false);
        });
    }
    private async void GoToCreateAccount(object sender, TappedEventArgs e)
    {
        await Task.WhenAll(
       WelcomeLabel.FadeTo(0, 300, Easing.CubicInOut),
       InfoLabel.FadeTo(0, 300, Easing.CubicInOut),
       UsernameBorder.FadeTo(0, 300, Easing.CubicInOut),
       PasswordBorder.FadeTo(0, 300, Easing.CubicInOut),
       LoginButton.FadeTo(0, 300, Easing.CubicInOut),
       BackButton.FadeTo(0, 300, Easing.CubicInOut),
       SignUp.FadeTo(0, 300, Easing.CubicInOut)
        );

        await Shell.Current.GoToAsync(nameof(CreateAccountPage), animate: false);
    }
}
