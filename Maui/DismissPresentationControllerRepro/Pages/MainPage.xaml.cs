namespace DismissPresentationControllerRepro.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OpenNormalModal(object? sender, EventArgs e)
    {
        var page = new NavigationPage(new NormalModalPage());
        Navigation.PushModalAsync(page);
    }

    private void OpenPopoverModal(object? sender, EventArgs e)
    {
        var page = new PopoverPage();
        Navigation.PushModalAsync(page);
    }

    private void OpenPopoverNavModal(object? sender, EventArgs e)
    {
        var page = new NavigationPage(new PopoverPage());
        Navigation.PushModalAsync(page);
    }
}