//
//  ModalViewController.swift
//  ModalPresentationTest
//
//  Created by Alex Duffell on 09/02/2024.
//

import UIKit

class ModalViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
        
        if (navigationController != nil) {
            self.navigationController?.presentationController?.delegate = self
        }
        else {
            self.presentationController?.delegate = self
        }
    }
}

extension ModalViewController : UIAdaptivePresentationControllerDelegate {
 
    func presentationControllerDidDismiss(_ presentationController: UIPresentationController) {
        print("Modal was dismissed")
    }
}
