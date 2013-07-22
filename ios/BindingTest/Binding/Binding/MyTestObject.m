//
//  MyTestObject.m
//  Binding
//
//  Created by beginor on 7/22/13.
//  Copyright (c) 2013 gdeic. All rights reserved.
//

#import "MyTestObject.h"
#import "BindingObject.h"
#import "BindingObject+Category.h"

@implementation MyTestObject

- (void) doTest {
	BindingObject *obj = [[BindingObject alloc] init];
	NSString * strResult = [obj stringMethod];
	
}

- (void) doTest2 {
	BindingObject *obj = [[BindingObject alloc] init];
	NSString *strCatResult = [obj stringCategoryMethod];
}
@end
