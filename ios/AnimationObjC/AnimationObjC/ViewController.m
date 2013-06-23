//
//  ViewController.m
//  AnimationObjC
//
//  Created by gdeic on 6/23/13.
//  Copyright (c) 2013 gdeic. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
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
	[UIView animateWithDuration:1.0
								 delay:0.0
							  options:UIViewAnimationOptionCurveEaseIn
						  animations:^{
							  self.firstView.alpha = 0.0;
						  }
						  completion:^(BOOL finished){
							  [UIView animateWithDuration:1.0
															delay:1.0
														 options:UIViewAnimationOptionCurveEaseOut animations:^{
															 self.firstView.alpha = 1.0;
														 }
													 completion:nil];
						  }];
}
@end
