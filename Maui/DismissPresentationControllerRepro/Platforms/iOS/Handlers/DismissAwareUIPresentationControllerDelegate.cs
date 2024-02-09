using Foundation;
using UIKit;
namespace DismissPresentationControllerRepro.Handlers;

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