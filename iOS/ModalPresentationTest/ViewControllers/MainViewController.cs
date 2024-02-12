namespace ModalPresentationTest.ViewControllers;

public partial class MainViewController(IntPtr handle) : UIViewController(handle)
{
	partial void ShowModal(UIButton sender)
	{
		var storyboard = UIStoryboard.FromName("Main", null) 
						?? throw new InvalidOperationException("Unable to find storyboard");

		var popoverVc = storyboard.InstantiateViewController("popoverViewController");

		PresentViewController(popoverVc, true, null);
	}

	partial void ShowNavModal(UIButton sender)
	{
		var storyboard = UIStoryboard.FromName("Main", null) 
						?? throw new InvalidOperationException("Unable to find storyboard");

		var popoverVc = storyboard.InstantiateViewController("popoverViewController");

		var navController = new UINavigationController(popoverVc);

		popoverVc.Title = "Modal Popover";

		PresentViewController(navController, true, null);
	}
}