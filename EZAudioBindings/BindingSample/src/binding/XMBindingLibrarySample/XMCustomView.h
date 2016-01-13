//
//  XMCustomView.h
//  XMBindingLibrarySample
//
//  Created by Anuj Bhatia on 1/18/12.
//  Copyright (c) 2012 __MyCompanyName__. All rights reserved.
//

#import "XMCustomViewDelegate.h"
#import "EZAudio.h"
@interface XMCustomView : UIView<EZMicrophoneDelegate>
{
    
}

@property (nonatomic, strong) NSString* name;
@property (nonatomic, assign) id <XMCustomViewDelegate> delegate;


-(void) customizeViewWithText:(NSString *)message;
-(void) StartMicrophone:(NSString *)message;
-(void) StopMicrophone:(NSString *)message;

@end
