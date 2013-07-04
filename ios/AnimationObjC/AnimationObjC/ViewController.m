//
//  ViewController.m
//  AnimationObjC
//
//  Created by gdeic on 6/23/13.
//  Copyright (c) 2013 gdeic. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@property UIView *currentView;
@property UIView *swapView;

@end

@implementation ViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
	self.currentView = self.firstView;
	self.swapView = self.secondView;
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)dealloc {
    [_secondView release];
    [_firstView release];
    [super dealloc];
}

- (IBAction)switchBarBtnItemClick:(id)sender {
	[UIView transitionWithView:self.view
							duration:1.0
							 options:UIViewAnimationOptionTransitionCurlUp
						 animations:^{
							 self.currentView.hidden = YES;
							 self.swapView.hidden = NO;
						 }
						 completion:^(BOOL finished) {
							 UIView *tmp = self.currentView;
							 self.currentView = self.swapView;
							 self.swapView = tmp;
						 }
	 ];
}
@end
