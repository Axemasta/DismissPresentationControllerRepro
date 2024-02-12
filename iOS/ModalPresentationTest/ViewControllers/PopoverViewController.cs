using System.Diagnostics;
namespace ModalPresentationTest.ViewControllers;

public partial class PopoverViewController(IntPtr handle) : UIViewController(handle)
{
    Action dismissAction => () =>
    {
        Debug.WriteLine("Presentation controller did dismiss");
    };
    
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        if (NavigationController is not null)
        {
            if (NavigationController.PresentationController is not null)
            {
                Debug.WriteLine("Setting navigation controller presentation delegate");
                NavigationController.PresentationController.Delegate = new DismissAwareUIPresentationControllerDelegate(dismissAction);
            }
        }
        else
        {
            if (PresentationController is not null)
            {
                Debug.WriteLine("Setting presentation controller delegate");
                PresentationController.Delegate = new DismissAwareUIPresentationControllerDelegate(dismissAction);
            }
        }
    }
}

public class DismissAwareUIPresentationControllerDelegate : UIAdaptivePresentationControllerDelegate
{
    Action dismissHandler;

    internal DismissAwareUIPresentationControllerDelegate(Action dismissHandler)
        => this.dismissHandler = dismissHandler;

    [Export("presentationControllerDidDismiss:")]
    public override void DidDismiss(UIPresentationController presentationController)
    {
        dismissHandler?.Invoke();
    }
}