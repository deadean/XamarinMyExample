//
//  XMCustomView.m
//  XMBindingLibrarySample
//
//  Created by Anuj Bhatia on 1/18/12.
//  Copyright (c) 2012 __MyCompanyName__. All rights reserved.
//

#import "XMCustomView.h"

@interface XMCustomView ()
@property (nonatomic, assign) BOOL isCustomized;
@property (nonatomic,weak) IBOutlet EZAudioPlot *audioPlot;
@property (nonatomic,strong) EZMicrophone *microphone;
@end


@implementation XMCustomView

@synthesize name = _name, delegate = _delegate, isCustomized = _isCustomized;


-(id) init
{
    if(self = [super init]) {
        // do initialization hurr
        self.isCustomized = false;
        self.microphone = [EZMicrophone microphoneWithDelegate:self];
        
    }
    
    self.frame = [super bounds];
    
    return self;
}

-(void) touchesBegan:(NSSet *)touches withEvent:(UIEvent *)event
{
    [self.delegate viewWasTouched:self];
}

-(void) StartMicrophone:(NSString *)message
{
    //self.superview.backgroundColor = [UIColor yellowColor];
    //self.backgroundColor = [UIColor colorWithWhite:0.0 alpha:0.0];
    //self.alpha = 0.0;
    
    EZAudioPlot *plot = [[EZAudioPlot alloc] init];
    //plot.backgroundColor = [UIColor colorWithWhite:0.0 alpha:0.0];
    //plot.alpha = 0.5;
    plot.backgroundColor = [UIColor grayColor];
    plot.color           = [UIColor colorWithRed:1.0 green:1.0 blue:1.0 alpha:1.0];
    
    plot.plotType = EZPlotTypeRolling;
    
    plot.shouldMirror = YES;
    plot.shouldFill = YES;
    plot.frame = [super bounds];
    [plot sizeToFit];
    
    
    
    [self addSubview:plot];
    self.audioPlot = plot;
    
    [self.microphone startFetchingAudio];
}

-(void) StopMicrophone:(NSString *)message
{
    [self.microphone stopFetchingAudio];
}

-(void) customizeViewWithText:(NSString *)message
{
    if(self.isCustomized == false && [message length] > 0) {
        
        EZAudioPlot *plot = [[EZAudioPlot alloc] init];
        plot.backgroundColor = [UIColor colorWithRed:0.984 green:0.471 blue:0.525 alpha:1.0];
        plot.color           = [UIColor colorWithRed:1.0 green:1.0 blue:1.0 alpha:1.0];
        
        plot.plotType = EZPlotTypeRolling;

        plot.shouldMirror = YES;
        plot.shouldFill = YES;
        plot.frame = [super bounds];
        
        
        
        [self addSubview:plot];
        self.audioPlot = plot;
        
        [self.microphone startFetchingAudio];
        
    }
}

#pragma mark - EZMicrophoneDelegate
#warning Thread Safety
// Note that any callback that provides streamed audio data (like streaming microphone input) happens on a separate audio thread that should not be blocked. When we feed audio data into any of the UI components we need to explicity create a GCD block on the main thread to properly get the UI to work.
-(void)microphone:(EZMicrophone *)microphone
 hasAudioReceived:(float **)buffer
   withBufferSize:(UInt32)bufferSize
withNumberOfChannels:(UInt32)numberOfChannels {
    // Getting audio data as an array of float buffer arrays. What does that mean? Because the audio is coming in as a stereo signal the data is split into a left and right channel. So buffer[0] corresponds to the float* data for the left channel while buffer[1] corresponds to the float* data for the right channel.
    
    // See the Thread Safety warning above, but in a nutshell these callbacks happen on a separate audio thread. We wrap any UI updating in a GCD block on the main thread to avoid blocking that audio flow.
    dispatch_async(dispatch_get_main_queue(),^{
        // All the audio plot needs is the buffer data (float*) and the size. Internally the audio plot will handle all the drawing related code, history management, and freeing its own resources. Hence, one badass line of code gets you a pretty plot :)
        [self.audioPlot updateBuffer:buffer[0] withBufferSize:bufferSize];
    });
}

-(void)microphone:(EZMicrophone *)microphone hasAudioStreamBasicDescription:(AudioStreamBasicDescription)audioStreamBasicDescription {
    // The AudioStreamBasicDescription of the microphone stream. This is useful when configuring the EZRecorder or telling another component what audio format type to expect.
    // Here's a print function to allow you to inspect it a little easier
    [EZAudio printASBD:audioStreamBasicDescription];
}

-(void)microphone:(EZMicrophone *)microphone
    hasBufferList:(AudioBufferList *)bufferList
   withBufferSize:(UInt32)bufferSize
withNumberOfChannels:(UInt32)numberOfChannels {
    // Getting audio data as a buffer list that can be directly fed into the EZRecorder or EZOutput. Say whattt...
}

@end
