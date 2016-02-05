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
@property (nonatomic, assign) id <XMCustomViewDelegate,EZAudioPlayerDelegate,EZRecorderDelegate> delegate;


-(void) customizeViewWithText:(NSString *)message;
-(void) StartMicrophone:(NSString *)message;
-(void) StopMicrophone:(NSString *)message;
-(void) ClearPlot:(NSString *)message;
-(float) StartPlayBack:(NSString *)message;
-(void) ContinuePlayBack:(NSString *)message;
-(void) StopPlayBack:(NSString *)message;
-(void) ChangeVolume:(float)message;
-(void) SeekToFrame:(float)message;
-(NSTimeInterval) CurrentPlayBackTime:(NSString *)message;
@end
