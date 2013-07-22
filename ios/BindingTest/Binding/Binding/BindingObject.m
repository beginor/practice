//
//  Binding.m
//  Binding
//
//  Created by beginor on 7/21/13.
//  Copyright (c) 2013 gdeic. All rights reserved.
//

#import "BindingObject.h"

@implementation BindingObject

- (void) voidMethod {
	
}

- (NSString *)stringMethod {
	return @"return of string method.";
}

- (NSArray *) stringArrayMethod {
	NSArray *arr = [NSArray arrayWithObject:@"return of string array method."];
	//[NSArray arrayWithObject:@"Hello,world"];
	return arr;
}
@end
