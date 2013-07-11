//
//  ViewController.m
//  AnimationObjC
//
//  Created by gdeic on 6/23/13.
//  Copyright (c) 2013 gdeic. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@property BOOL displayPrimary;

@end

@implementation ViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
	self.displayPrimary = YES;
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)dealloc {
    [_secondView release];
    [super dealloc];
}

- (IBAction)switchBarBtnItemClick:(id)sender {
	UIView *fromView = (self.displayPrimary ? self.view : self.secondView);
	UIView *toView = (self.displayPrimary ? self.secondView : self.view);
	UIViewAnimationOptions option = (self.displayPrimary ? UIViewAnimationOptionTransitionFlipFromRight : UIViewAnimationOptionTransitionFlipFromLeft);
	[UIView transitionFromView:fromView toView:toView duration:1.0 options:option
						 completion:^(BOOL finished) {
							 if (finished) {
								 self.displayPrimary = !self.displayPrimary;
							 }
						 }
	];
}
@end
