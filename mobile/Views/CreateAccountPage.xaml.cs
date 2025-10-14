namespace mobile.Views;

public partial class CreateAccountPage : ContentPage
{
    public CreateAccountPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        WaveRow.Height = new GridLength(0.2, GridUnitType.Star);
        var waveAnimation = new Animation(v =>
        {
            WaveRow.Height = new GridLength(v, GridUnitType.Star);
            ContentRow.Height = new GridLength(1 - v, GridUnitType.Star);
        }, WaveRow.Height.Value, 0.2);

        waveAnimation.Commit(this, "WaveDownAnimation", 16, 600, Easing.CubicOut, (finalValue, isCompleted) =>
        {
            FadeInElement(WelcomeLabel, 0);
            FadeInElement(InfoLabel, 50);
            FadeInElement(UsernameBorder, 150);
            FadeInElement(EmailBorder, 200);
            FadeInElement(PasswordBorder, 250);
            FadeInElement(CreateButton, 350);
            FadeInElement(BackButton, 400);
            FadeInElement(SignInLayout, 400);
        });
    }

    private async void FadeInElement(VisualElement element, int delay)
    {
        element.Opacity = 0;
        element.Scale = 0.95;

        if (delay > 0)
            await Task.Delay(delay);

        await Task.WhenAll(
            element.FadeTo(1, 400, Easing.CubicInOut),
            element.ScaleTo(1, 400, Easing.CubicOut)
        );
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Task.WhenAll(
            WelcomeLabel.FadeTo(0, 250, Easing.CubicInOut),
            InfoLabel.FadeTo(0, 250, Easing.CubicInOut),
            UsernameBorder.FadeTo(0, 250, Easing.CubicInOut),
            EmailBorder.FadeTo(0, 250, Easing.CubicInOut),
            PasswordBorder.FadeTo(0, 250, Easing.CubicInOut),
            CreateButton.FadeTo(0, 250, Easing.CubicInOut),
            BackButton.FadeTo(0, 250, Easing.CubicInOut),
            SignInLayout.FadeTo(0, 250, Easing.CubicInOut)
        );

        var animation = new Animation(v =>
        {
            WaveRow.Height = new GridLength(v, GridUnitType.Star);
            ContentRow.Height = new GridLength(1 - v, GridUnitType.Star);
        }, WaveRow.Height.Value, 0.7);

        animation.Commit(this, "WaveUpAnimation", 16, 600, Easing.CubicInOut, async (finalValue, isCompleted) =>
        {
            await Shell.Current.GoToAsync("///LandingPage", animate: false);
        });
    }

    private async void GoToSignIn(object sender, TappedEventArgs e)
    {
        await Task.WhenAll(
            WelcomeLabel.FadeTo(0, 250, Easing.CubicInOut),
            InfoLabel.FadeTo(0, 250, Easing.CubicInOut),
            UsernameBorder.FadeTo(0, 250, Easing.CubicInOut),
            EmailBorder.FadeTo(0, 250, Easing.CubicInOut),
            PasswordBorder.FadeTo(0, 250, Easing.CubicInOut),
            CreateButton.FadeTo(0, 250, Easing.CubicInOut),
            BackButton.FadeTo(0, 250, Easing.CubicInOut),
            SignInLayout.FadeTo(0, 250, Easing.CubicInOut)
        );
        await Shell.Current.GoToAsync(nameof(LoginPage), animate: false);
    }
}

