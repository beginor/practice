//
//  Binding.h
//  Binding
//
//  Created by beginor on 7/21/13.
//  Copyright (c) 2013 gdeic. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "BindingProtocol.h"

@interface BindingObject : NSObject

- (void) voidMethod;

- (NSString *) stringMethod;

- (NSArray *) stringArrayMethod;

- (void) callDelegate1Method;

- (void) callDelegate2Method;

@property (nonatomic, assign) id delegate1;

@property (nonatomic, assign) id<BindingProtocol> delegate2;

@end
