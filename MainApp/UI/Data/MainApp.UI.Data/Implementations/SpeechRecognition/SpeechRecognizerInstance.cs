using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoTransfer.Data.Interfaces.SpeechRecognition;

namespace PhotoTransfer.UI.Data.Implementations.SpeechRecognition
{
	public sealed class SpeechRecognizerInstance : ISpeechRecognizer
	{
		public SpeechRecognizerInstance(object speechRecognizer)
		{
			SpeechRecognizer = speechRecognizer;
		}
		public object SpeechRecognizer { get; private set; }
	}
}
