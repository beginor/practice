//
//  BindingObject+BindingObjectCategory.m
//  Binding
//
//  Created by beginor on 7/21/13.
//  Copyright (c) 2013 gdeic. All rights reserved.
//

#import "BindingObject+Extension.h"

@implementation BindingObject (Extension)

- (NSString *) stringCategoryMethod {
	return @"return of string category method";
}

- (NSArray *) stringArrayCategoryMethod {
	NSArray * result = [[NSArray alloc] initWithObjects:@"return of string array category method", nil];
	return result;
}

@end
