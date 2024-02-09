using DismissPresentationControllerRepro.Pages;
namespace DismissPresentationControllerRepro;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
    }
}