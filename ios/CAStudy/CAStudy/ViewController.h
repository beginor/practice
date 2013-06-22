//
//  ViewController.h
//  CAStudy
//
//  Created by gdeic on 2/7/12.
//  Copyright (c) 2012 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ViewController : UIViewController

@property (weak, nonatomic) IBOutlet UIToolbar *toolbar;

@property (weak, nonatomic) IBOutlet UIImageView *firstView;
@property (weak, nonatomic) IBOutlet UIView *secondView;
- (IBAction)animateItemClick:(id)sender;
@end
