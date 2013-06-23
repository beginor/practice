//
//  ViewController.h
//  AnimationObjC
//
//  Created by gdeic on 6/23/13.
//  Copyright (c) 2013 gdeic. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ViewController : UIViewController

@property (retain, nonatomic) IBOutlet UIView *secondView;
@property (retain, nonatomic) IBOutlet UIView *firstView;
- (IBAction)switchBarBtnItemClick:(id)sender;
@end
