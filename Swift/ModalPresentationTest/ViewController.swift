//
//  ViewController.swift
//  ModalPresentationTest
//
//  Created by Alex Duffell on 01/02/2024.
//

import UIKit

class ViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }
    
    @IBAction func ShowModalButton(_ sender: UIButton) {
     
        let storyboard = UIStoryboard(name: "Main", bundle:nil)
        
        let modalVc = storyboard.instantiateViewController(withIdentifier: "modalViewController")
        
        present(modalVc, animated: true)
    }
    
    @IBAction func ShowNavModalButton(_ sender: UIButton) {
        let storyboard = UIStoryboard(name: "Main", bundle:nil)
        
        let modalVc = storyboard.instantiateViewController(withIdentifier: "modalViewController")
        
        let navController = UINavigationController(rootViewController: modalVc)
        
        present(navController, animated: true)
    }
}

