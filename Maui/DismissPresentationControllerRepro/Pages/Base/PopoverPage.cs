using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using NavigationPage = Microsoft.Maui.Controls.NavigationPage;
namespace DismissPresentationControllerRepro.Pages.Base;

public abstract class PopoverPageBase : ContentPage
{
    protected PopoverPageBase()
    {
        On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.PageSheet);
    }
    
    protected override void OnParentChanged()
    {
        base.OnParentChanged();

        if (Parent is NavigationPage navigationPage)
        {
            // Incase the page is wrapped in a navigation page, we run into this issue https://github.com/dotnet/maui/issues/20284
            navigationPage.On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.PageSheet);
        }
    }
}