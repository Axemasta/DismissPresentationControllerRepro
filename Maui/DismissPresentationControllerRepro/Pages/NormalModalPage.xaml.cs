namespace DismissPresentationControllerRepro.Pages;

public partial class NormalModalPage : ContentPage
{
    public NormalModalPage()
    {
        InitializeComponent();
    }

    private void OnClose(object? sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}