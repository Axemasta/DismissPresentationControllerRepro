using System.Diagnostics;
namespace ModalPresentationTest.ViewControllers;

public partial class PopoverViewController(IntPtr handle) : UIViewController(handle), IUIAdaptivePresentationControllerDelegate
{
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        if (NavigationController is not null)
        {
            if (NavigationController.PresentationController is not null)
            {
                Debug.WriteLine("Setting navigation controller presentation delegate");
                NavigationController.PresentationController.Delegate = this;
            }
        }
        else
        {
            if (PresentationController is not null)
            {
                Debug.WriteLine("Setting presentation controller delegate");
                PresentationController.Delegate = this;
            }
        }
    }
    
    [Export("presentationControllerDidDismiss:")]
    public void DidDismiss(UIPresentationController presentationController)
    {
        Debug.WriteLine("Presentation controller dismissed");
    }
}