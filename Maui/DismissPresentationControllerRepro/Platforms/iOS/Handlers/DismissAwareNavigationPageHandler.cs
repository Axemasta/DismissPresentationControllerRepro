using Microsoft.Maui.Controls.Handlers.Compatibility;
namespace DismissPresentationControllerRepro.Handlers;

public class DismissAwareNavigationPageHandler : NavigationRenderer
{
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        
        Action dismissAction = () =>
        {
            Debug.WriteLine("Presentation controller did dismiss (UINavigationController)");
        };

        if (PresentationController != null)
        {
            Debug.WriteLine("Adding dismiss aware presentation delegate to navigation page");
            PresentationController.Delegate = new DismissAwareUIPresentationControllerDelegate(dismissAction);
        }
    }
}