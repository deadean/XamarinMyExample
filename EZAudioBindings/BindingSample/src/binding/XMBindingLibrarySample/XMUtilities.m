//
//  XMUtilities.m
//  XMBindingLibrarySample
//
//  Created by Anuj Bhatia on 1/18/12.
//  Copyright (c) 2012 __MyCompanyName__. All rights reserved.
//

#import "XMUtilities.h"

@implementation XMUtilities
@synthesize microphone;

@synthesize audioPlot;

#pragma mark - Initialization


#pragma mark - Initialize View Controller Here


#pragma mark - Actions
-(void)changePlotType:(id)sender {
    NSInteger selectedSegment = [sender selectedSegmentIndex];
    switch(selectedSegment){
        case 0:
            [self drawBufferPlot];
            break;
        case 1:
            [self drawRollingPlot];
            break;
        default:
            break;
    }
}


#pragma mark - Action Extensions
/*
 Give the visualization of the current buffer (this is almost exactly the openFrameworks audio input eample)
 */
-(void)drawBufferPlot {
    // Change the plot type to the buffer plot
    self.audioPlot.plotType = EZPlotTypeBuffer;
    // Don't mirror over the x-axis
    self.audioPlot.shouldMirror = NO;
    // Don't fill
    self.audioPlot.shouldFill = NO;
}

/*
 Give the classic mirrored, rolling waveform look
 */
-(void)drawRollingPlot {
    self.audioPlot.plotType = EZPlotTypeRolling;
    self.audioPlot.shouldFill = YES;
    self.audioPlot.shouldMirror = YES;
}-(id) init
{
    if(self = [super init]) {
        if(self){
            
        }
        [self initializeViewController];
        [self.microphone startFetchingAudio];        // do initialization here after super init nil check!
    }
    
    return self;
    
    
}

-(void)initializeViewController {
    // Create an instance of the microphone and tell it to use this view controller instance as the delegate
    self.microphone = [EZMicrophone microphoneWithDelegate:self];
    
}

-(void) dealloc
{
    // this is an ARC project so we don't have to dealloc
    // we dont even have to call [super dealloc];
    // old habits die hard, Yippee-ki-yay!
}

// This is an example of a class method. It will echo the message you give it.
// Obj-C class methods are like C# static methods, but different.

+(NSString *) echo:(NSString *)message
{
    if([message length] == 0) {
        
        return [NSString stringWithFormat:@"Dude %@, you didnt give me a message!", @"bro"];
    }
    
    return [NSString stringWithFormat:@"%@", message];
}

// This is an example of an instance method.

-(NSObject *) hello:(NSString *)name
{
    /*
     Customizing the audio plot's look
     */
    // Background color
    self.audioPlot.backgroundColor = [UIColor colorWithRed:0.984 green:0.471 blue:0.525 alpha:1.0];
    // Waveform color
    self.audioPlot.color           = [UIColor colorWithRed:1.0 green:1.0 blue:1.0 alpha:1.0];
    // Plot type
    self.audioPlot.plotType        = EZPlotTypeBuffer;
    
    /*
     Start the microphone
     */
    [self.microphone startFetchingAudio];    if([name length] == 0) {
        //return [NSString stringWithFormat:@"Dude %@, you didnt give me a name!", @"bro"];
    }
    
    //return [NSString stringWithFormat:@"*Waves* Hello %@! Welcome to the Xamarin binding sample!", name];
    return self.audioPlot;
}


-(NSObject *) hello1:(NSString *)name
{
    /*
     Customizing the audio plot's look
     */
    // Background color
    self.audioPlot.backgroundColor = [UIColor colorWithRed:0.984 green:0.471 blue:0.525 alpha:1.0];
    // Waveform color
    self.audioPlot.color           = [UIColor colorWithRed:1.0 green:1.0 blue:1.0 alpha:1.0];
    // Plot type
    self.audioPlot.plotType        = EZPlotTypeBuffer;
    
    /*
     Start the microphone
     */
    [self.microphone startFetchingAudio];    if([name length] == 0) {
        //return [NSString stringWithFormat:@"Dude %@, you didnt give me a name!", @"bro"];
    }
    
    //return [NSString stringWithFormat:@"*Waves* Hello %@! Welcome to the Xamarin binding sample!", name];
    return self.audioPlot;
}
-(NSInteger) add:(NSInteger)operandUn and:(NSInteger) operandDeux
{
    return operandUn + operandDeux;
}

-(NSInteger) multiply:(NSInteger)operandUn and:(NSInteger)operandDeux
{
    return operandUn * operandDeux;
}

// This is an example of how to set a block function for later use.
-(void) setCallback:(XMUtilityCallback) callback
{
	_callback = [callback copy];
}

// This is an example of how to invoke a block function.
-(void) invokeCallback:(NSString *) message
{
	_callback (message);
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
        //[self.audioPlot updateBuffer:buffer[0] withBufferSize:bufferSize];
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
