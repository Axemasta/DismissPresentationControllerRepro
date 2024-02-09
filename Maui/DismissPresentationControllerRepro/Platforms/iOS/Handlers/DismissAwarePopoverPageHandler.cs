using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;
namespace DismissPresentationControllerRepro.Handlers;

public class DismissAwarePopoverPageHandler : PageHandler
{
    class PopoverPageViewController(IView page, IMauiContext mauiContext) : PageViewController(page, mauiContext)
    {
        public override void ViewDidLoad()
        {
            Debug.WriteLine("Handler view controller connected");
            
            if (PresentationController != null)
            {
                Action dismissAction = () =>
                {
                    Debug.WriteLine("Presentation controller did dismiss (UIViewController)");
                };
                
                Debug.WriteLine("Attaching UIAdaptivePresentationControllerDelegate to parent navigation controller");
                PresentationController.Delegate = new DismissAwareUIPresentationControllerDelegate(dismissAction);
            }
            
            base.ViewDidLoad();
        }

        public override void WillMoveToParentViewController(UIViewController? parent)
        {
            base.WillMoveToParentViewController(parent);
            
            if (parent is NavigationRenderer && parent?.NavigationController?.PresentationController != null)
            {
                Action dismissAction = () =>
                {
                    Debug.WriteLine("Presentation controller did dismiss (UIViewController parent UINavigationController)");
                };
                
                Debug.WriteLine("Attaching UIAdaptivePresentationControllerDelegate to parent navigation controller via child uiviewcontroller");
                parent.NavigationController.PresentationController.Delegate = new DismissAwareUIPresentationControllerDelegate(dismissAction);
            }
            
        }
    }

    protected override Microsoft.Maui.Platform.ContentView CreatePlatformView()
    {
        _ = VirtualView ?? throw new InvalidOperationException($"{nameof(VirtualView)} must be set to create a LayoutView");
        _ = MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} cannot be null");

        if (ViewController == null)
            ViewController = new PopoverPageViewController(VirtualView, MauiContext);

        if (ViewController is PageViewController pc && pc.CurrentPlatformView is Microsoft.Maui.Platform.ContentView pv)
            return pv;

        if (ViewController.View is Microsoft.Maui.Platform.ContentView cv)
            return cv;

        throw new InvalidOperationException($"PageViewController.View must be a {nameof(Microsoft.Maui.Platform.ContentView)}");
    }
}