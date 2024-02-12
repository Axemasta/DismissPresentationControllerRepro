﻿// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace ModalPresentationTest.ViewControllers;

public partial class MainViewController : UIViewController
{
	public MainViewController(IntPtr handle) : base(handle)
	{
	}

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