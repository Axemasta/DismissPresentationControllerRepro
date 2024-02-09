using DismissPresentationControllerRepro.Pages.Base;
namespace DismissPresentationControllerRepro.Pages;

public partial class PopoverPage : PopoverPageBase
{
    public PopoverPage()
    {
        InitializeComponent();
    }

    private void OnClose(object? sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}