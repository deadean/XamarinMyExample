using System;

using UIKit;
using MediaPlayer;
using Foundation;
using AVFoundation;
using System.IO;


namespace MPMediaPickerControlleriOSExample
{
	public partial class ViewController : UIViewController
	{
		private MPMusicPlayerController musicPlayer;
		private MPMediaPickerController mediaPicker;

		public ViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad ()
		{
			//bool isExist = File.Exists ("file:///var/mobile/Containers/Data/Application/F7D65ABE-BC1E-4623-8B9D-E6D7D1D66BCA/Documents/3177cb69-c923-46cd-a786-cbc96f70e4cd.m4a");
			base.ViewDidLoad ();
			this.mediaPicker = new
				MPMediaPickerController (MPMediaType.Music);
			this.mediaPicker.ItemsPicked += MediaPicker_ItemsPicked;
			this.mediaPicker.DidCancel += MediaPicker_DidCancel;
			this.musicPlayer =
				MPMusicPlayerController.ApplicationMusicPlayer;
			this.btnSelect.TouchUpInside += async (s, e) => {
				await this.PresentViewControllerAsync (this.mediaPicker,
					true);
			};
			this.btnPlay.TouchUpInside += (s, e) => {
				try {
					//this.musicPlayer.NowPlayingItem = new MPMediaItem(){};
					this.musicPlayer.Play ();
					//var test = this.musicPlayer.NowPlayingItem;
					//var mediatype = this.musicPlayer.NowPlayingItem.MediaType;
					//var diatype = this.musicPlayer.NowPlayingItem.

					//NSUrl url = this.musicPlayer.NowPlayingItem.ValueForProperty (MPMediaItem.AssetURLProperty) as NSUrl;

				} catch (Exception ex) {
					
				}
			};
			this.btnStop.TouchUpInside += (s, e) => {
				this.musicPlayer.Stop ();
			};
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		private void PrintITunesSongs ()
		{
			try {
				MediaPlayer.MPMediaQuery mq = new MediaPlayer.MPMediaQuery ();
				var value = Foundation.NSNumber.FromInt32 ((int)MediaPlayer.MPMediaType.Music);
				var type = MediaPlayer.MPMediaItem.MediaTypeProperty;
				var predicate = MediaPlayer.MPMediaPropertyPredicate.PredicateWithValue (value, type);
				mq.AddFilterPredicate (predicate);

				foreach (var item in mq.Items) {

					if (item.Artist != null) {
						Console.WriteLine (item.Artist);
					}
					if (item.Genre != null) {
						Console.WriteLine (item.Genre);
					}
					if (item.AssetURL != null) {
						Console.WriteLine (item.AssetURL);
					}

				}
			} catch (Exception ex) {
			}
		}

		private async void MediaPicker_ItemsPicked (object sender,
		                                            ItemsPickedEventArgs e)
		{
			PrintITunesSongs ();
			foreach (var item in e.MediaItemCollection.Items) {
				var url = item.AssetURL;
				if (url != null) {
					Export (url);
					return;
				}
				System.Diagnostics.Debug.WriteLine (item.AlbumArtist + item.AlbumTitle + item.Artist + item.AssetURL + item.DebugDescription + item.Description + item.MediaType + item.PlaybackDuration + item.Title + item.ToString ());
			}


//			for (MPMediaItem *theItem in mediaItemCollection.items) {
//				NSURL *url = [theItem valueForProperty:MPMediaItemPropertyAssetURL];
//				AVURLAsset *songAsset = [AVURLAsset URLAssetWithURL:url options:nil];
//				AVAssetExportSession *exporter = [[AVAssetExportSession alloc] initWithAsset: songAsset presetName: AVAssetExportPresetPassthrough];
//				exporter.outputFileType = @"com.apple.coreaudio-format";
//				NSString *fname = [[NSString stringWithFormat:@"%d",i] stringByAppendingString:@".caf"];
//				++i;
//				NSString *exportFile = [tempPath stringByAppendingPathComponent: fname];
//				exporter.outputURL = [NSURL fileURLWithPath:exportFile];
//				[exporter exportAsynchronouslyWithCompletionHandler:^{
//					//Code for completion Handler
//				}];
//			}

			this.musicPlayer.SetQueue (e.MediaItemCollection);
			await this.DismissViewControllerAsync (true);
		}

		private async void MediaPicker_DidCancel (object sender,
		                                          EventArgs e)
		{
			await this.mediaPicker.DismissViewControllerAsync (true);
		}

		private void Export (NSUrl url)
		{
			var assetURL = url;
			NSDictionary dictionary = null;
			var assetExtension = url.Path.Split ('.') [1];

			var songAsset = new AVUrlAsset (assetURL, dictionary);
			var exporter = new AVAssetExportSession (songAsset, AVAssetExportSession.PresetPassthrough.ToString ());
			exporter.OutputFileType = (assetExtension == "mp3") ? "com.apple.quicktime-movie" : AVFileType.AppleM4A;
			var filePath = Environment.GetFolderPath (Environment.SpecialFolder.LocalApplicationData) + "/"+Guid.NewGuid ().ToString () + "." + assetExtension;
			var exportUrl = NSUrl.FromFilename (filePath);

			exporter.OutputUrl = exportUrl;


			exporter.ExportAsynchronously (() => {
				var exportStatus = exporter.Status;
				switch (exportStatus) {
				case AVAssetExportSessionStatus.Unknown:
				case AVAssetExportSessionStatus.Completed: 
					{
						var mediaStream = new FileStream (exportUrl.AbsoluteString, FileMode.Open);
						//mediaAvailable (mediaStream);
						break;
					}
				case AVAssetExportSessionStatus.Waiting:
				case AVAssetExportSessionStatus.Cancelled:
				case AVAssetExportSessionStatus.Exporting:
				case AVAssetExportSessionStatus.Failed: 
				default:
					{
						var exportError = exporter.Error;
//							if(assumeCancelled != null)
//							{
//								assumeCancelled();
//							}
						break;
					}
				}
			});
		}
	}
}
