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
@property (nonatomic,weak) IBOutlet EZAudioPlot *playingAudioPlot;
@property (nonatomic, strong) EZAudioPlayer *player;
@property (nonatomic,strong) EZMicrophone *microphone;
@end


@implementation XMCustomView

@synthesize name = _name, delegate = _delegate, isCustomized = _isCustomized;


-(id) init
{
    if(self = [super init]) {
        // do initialization hurr
        self.isCustomized = false;
        
        AVAudioSession *session = [AVAudioSession sharedInstance];
        NSError *error;
        [session setCategory:AVAudioSessionCategoryPlayAndRecord error:&error];
        if (error)
        {
            NSLog(@"Error setting up audio session category: %@", error.localizedDescription);
        }
        [session setActive:YES error:&error];
        if (error)
        {
            NSLog(@"Error setting up audio session active: %@", error.localizedDescription);
        }
        
        self.microphone = [EZMicrophone microphoneWithDelegate:self];
        
        [session overrideOutputAudioPort:AVAudioSessionPortOverrideSpeaker error:&error];
        if (error)
        {
            NSLog(@"Error overriding output to the speaker: %@", error.localizedDescription);
        }
        
        
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
    @try {
        //self.superview.backgroundColor = [UIColor yellowColor];
        //self.backgroundColor = [UIColor colorWithWhite:0.0 alpha:0.0];
        //self.alpha = 0.0;
        
        EZAudioPlot *plot = [[EZAudioPlot alloc] init];
        //plot.backgroundColor = [UIColor colorWithWhite:0.0 alpha:0.0];
        //plot.alpha = 0.5;
        plot.backgroundColor = [UIColor colorWithRed:1.0 green:1.0 blue:1.0 alpha:1.0]; //[UIColor lightGrayColor];
        plot.color           = [UIColor blueColor];
        //plot.set setRollingHistoryLength:(int)value
        plot.plotType = EZPlotTypeRolling;
        
        plot.shouldMirror = YES;
        plot.shouldFill = YES;
        plot.frame = [super bounds];
        [plot sizeToFit];
        
        EZAudioPlot *plot1 = [[EZAudioPlot alloc] init];
        plot1.backgroundColor = [UIColor colorWithRed:0.51 green:0.51 blue:0.51 alpha:1.0];
        plot1.shouldMirror = YES;
        plot1.shouldFill = YES;
        plot1.frame = [super bounds];
        [plot1 sizeToFit];
        plot1.color           = [UIColor blueColor];
        self.playingAudioPlot = plot1;
        
        self.player = [EZAudioPlayer audioPlayerWithDelegate:self];
        
        [self addSubview:plot];
        [self addSubview:plot1];
        plot1.hidden = true;
        self.audioPlot = plot;
        
        [self.microphone startFetchingAudio];
        
    }
    @catch (NSException * e) {
        NSLog(@"Exception: %@", e);
    }
    
}

-(void) ClearPlot:(NSString *)message
{
    [self.audioPlot removeFromSuperview];
}

-(void) StopMicrophone:(NSString *)message
{
    [self.microphone stopFetchingAudio];
    
}

-(float) StartPlayBack:(NSString *)message
{
    @try {
        NSLog(@"Start playback");
        NSLog(@"message: %@", message);
        NSLog(@"Start playback...");
        NSURL *url = [NSURL fileURLWithPath:message];
        EZAudioFile *audioFile = [EZAudioFile audioFileWithURL:url];
        [self.player playAudioFile:audioFile];
        self.audioPlot.hidden = true;
        self.playingAudioPlot.hidden = false;
        return audioFile.totalFrames;
    }
    @catch (NSException *exception) {
        NSLog(@"Exception: %@", exception);
    }
    @finally {
        
    }
}

-(void) ContinuePlayBack:(NSString *)message
{
    @try {
        NSLog(@"Continue playback");
        [self.player play];
    }
    @catch (NSException *exception) {
        NSLog(@"Exception: %@", exception);
    }
    @finally {
        
    }
}

-(void) StopPlayBack:(NSString *)message
{
    @try {
        NSLog(@"Stop playback");
        NSLog(@"message: %@", message);
        [self.player pause];
    }
    @catch (NSException *exception) {
        NSLog(@"Exception: %@", exception);
    }
    @finally {
        
    }
}

-(void) ChangeVolume:(float)message
{
    @try {
        NSLog(@"ChangeVolume");
        [self.player setVolume:message];
    }
    @catch (NSException *exception) {
        NSLog(@"Exception: %@", exception);
    }
    @finally {
        
    }
}

-(void) SeekToFrame:(float)message
{
    @try {
        NSLog(@"SeekToFrame");
        [self.player seekToFrame:(SInt64)(message*self.player.totalFrames)];
    }
    @catch (NSException *exception) {
        NSLog(@"Exception: %@", exception);
    }
    @finally {
        
    }
}

-(NSTimeInterval) CurrentPlayBackTime:(NSString *)message
{
    @try {
        //NSLog(@"CurrentPlayBackTime");
        //NSLog(@"total frames: %i", self.player.totalFrames);
        return self.player.currentTime;
    }
    @catch (NSException *exception) {
        NSLog(@"Exception: %@", exception);
    }
    @finally {
        
    }
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

//------------------------------------------------------------------------------
#pragma mark - EZAudioPlayerDelegate
//------------------------------------------------------------------------------

- (void) audioPlayer:(EZAudioPlayer *)audioPlayer
         playedAudio:(float **)buffer
      withBufferSize:(UInt32)bufferSize
withNumberOfChannels:(UInt32)numberOfChannels
         inAudioFile:(EZAudioFile *)audioFile
{
    __weak typeof (self) weakSelf = self;
    dispatch_async(dispatch_get_main_queue(), ^{
        [weakSelf.playingAudioPlot updateBuffer:buffer[0]
                                 withBufferSize:bufferSize];
    });
}

//------------------------------------------------------------------------------

- (void)audioPlayer:(EZAudioPlayer *)audioPlayer
    updatedPosition:(SInt64)framePosition
        inAudioFile:(EZAudioFile *)audioFile
{
    __weak typeof (self) weakSelf = self;
    dispatch_async(dispatch_get_main_queue(), ^{
        //weakSelf.currentTimeLabel.text = [audioPlayer formattedCurrentTime];
    });
}

//------------------------------------------------------------------------------
#pragma mark - Utility
//------------------------------------------------------------------------------

- (NSArray *)applicationDocuments
{
    return NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
}

//------------------------------------------------------------------------------

- (NSString *)applicationDocumentsDirectory
{
    NSArray *paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
    NSString *basePath = ([paths count] > 0) ? [paths objectAtIndex:0] : nil;
    return basePath;
}

//------------------------------------------------------------------------------

- (void)playerDidReachEndOfFile:(NSNotification *)notification
{
    __weak typeof (self) weakSelf = self;
    dispatch_async(dispatch_get_main_queue(), ^{
        [weakSelf.playingAudioPlot clear];
    });
}

@end
