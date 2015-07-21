using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoTransfer.Data.Interfaces.SpeechRecognition;

namespace PhotoTransfer.UI.Common.Interfaces.SpeechRecognitionService
{
	public interface ISpeechRecognitionService
	{
		Task<string> TryToRecognizeSpeech();
		ISpeechRecognizer SpeechRecognizerInstance { get; }
	}
}
