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

- (void) callDelegate1Method {
	if (self.delegate1 != nil) {
		[self.delegate1 performSelector:NSSelectorFromString(@"stringProtocolMethod:") withObject:@"Hello, delegate method 1 !"];
	}
}

- (void) callDelegate2Method {
	if (self.delegate2 != nil) {
		[self.delegate2 stringProtocolMethod:@"Hello, delegate method 2 !"];
	}
}
@end
