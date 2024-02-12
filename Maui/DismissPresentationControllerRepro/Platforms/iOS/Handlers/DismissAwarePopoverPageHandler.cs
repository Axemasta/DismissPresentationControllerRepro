using System.Reflection;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;
namespace DismissPresentationControllerRepro.Handlers;

public class DismissAwarePopoverPageHandler : PageHandler
{
    class PopoverPageViewController(IView page, IMauiContext mauiContext) : PageViewController(page, mauiContext)
    {
        Action dismissAction => () =>
        {
            Debug.WriteLine("Presentation controller did dismiss");
        };
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            Debug.WriteLine("Handler view controller connected");
        }

        public override void WillMoveToParentViewController(UIViewController? parent)
        {
            base.WillMoveToParentViewController(parent);
            
            if (parent.TryGetNavigationRenderer(out var navigationRenderer) && navigationRenderer?.PresentationController != null)
            {
                Debug.WriteLine("Setting presentation controller delegate for navigation controller");
                navigationRenderer.PresentationController.Delegate = new DismissAwareUIPresentationControllerDelegate(dismissAction);
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

public static class UIViewControllerExtension
{
    public static bool TryGetNavigationRenderer(this UIViewController? viewController, out NavigationRenderer? navigationRenderer)
    {
        navigationRenderer = null;

        if (viewController is null)
        {
            return false;
        }
        
        var vcType = viewController.GetType();

        if (!vcType.Name.Equals("ParentingViewController"))
        {
            return false;
        }

        try
        {
            var navigationRendererField = vcType.GetField("_navigation", BindingFlags.NonPublic | BindingFlags.Instance);

            if (navigationRendererField is null)
            {
                return false;
            }
            
            var weakNavigationRendererReference = navigationRendererField.GetValue(viewController) as WeakReference<NavigationRenderer>;

            if (weakNavigationRendererReference is null)
            {
                return false;
            }
            
            var retrieved = weakNavigationRendererReference.TryGetTarget(out navigationRenderer);

            return retrieved;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exception occurred getting navigation renderer for view controller: {vcType.Name}", ex);
            return false;
        }
    }
}