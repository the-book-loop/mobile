namespace mobile.Views;

public partial class LandingPage : ContentPage
{
    private bool isAnimating = false;

    public LandingPage()
    {
        InitializeComponent();

        BookLogo.Opacity = 1;
        CreateAccountButton.Opacity = 1;
        SignInButton.Opacity = 1;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        isAnimating = false;
        WaveRow.Height = new GridLength(0.7, GridUnitType.Star);
        ContentRow.Height = new GridLength(0.3, GridUnitType.Star);
        FadeInElements();
    }
    private async void FadeInElements()
    {
        if (isAnimating) return;
        isAnimating = true;

        BookLogo.Opacity = 0;
        CreateAccountButton.Opacity = 0;
        SignInButton.Opacity = 0;

        await Task.WhenAll(
            BookLogo.FadeTo(1, 500, Easing.CubicInOut),
            CreateAccountButton.FadeTo(1, 500, Easing.CubicInOut),
            SignInButton.FadeTo(1, 500, Easing.CubicInOut)
        );

        isAnimating = false;
    }
    private void OnCreateAccountClicked(object sender, EventArgs e)
    {
       AnimateFadeAndWave(nameof(CreateAccountPage));
    }

    private void OnSignInClicked(object sender, EventArgs e)
    {
        AnimateFadeAndWave(nameof(LoginPage));
    }

    private async void AnimateFadeAndWave(string route)
    {
        if (isAnimating) return;
        isAnimating = true;

        await Task.WhenAll(
            BookLogo.FadeTo(0, 300, Easing.CubicInOut),
            CreateAccountButton.FadeTo(0, 300, Easing.CubicInOut),
            SignInButton.FadeTo(0, 300, Easing.CubicInOut)
        );

        var animation = new Animation(v =>
        {
            WaveRow.Height = new GridLength(v, GridUnitType.Star);
            ContentRow.Height = new GridLength(1 - v, GridUnitType.Star);
        }, WaveRow.Height.Value, 0.2);

        animation.Commit(this, "WaveUpAnimation", 16, 900, Easing.CubicInOut, async (finalValue, isCompleted) =>
        { 
            await Shell.Current.GoToAsync(route, animate: false);
        });
    }

    private void OnButtonPressed(object sender, EventArgs e)
    {
        var button = (Button)sender;
        button.Style = (Style)Resources["PrimaryButton"];
        button.ScaleTo(0.97, 100, Easing.CubicOut);
    }

    private void OnButtonReleased(object sender, EventArgs e)
    {
        var button = (Button)sender;
        button.Style = (Style)Resources["SecondaryButton"];
        button.ScaleTo(1, 100, Easing.CubicIn);
    }
}
