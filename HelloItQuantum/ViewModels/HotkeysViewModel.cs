using System;
using System.IO;
using System.Media;

namespace HelloItQuantum.ViewModels
{
	public class HotkeysViewModel : MainWindowViewModel
    {
        public void PlayTask()
        {
            string directory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))));
            string path = $"{directory}\\Assets\\voice1.wav";
            SoundPlayer snd = new SoundPlayer(path);
            snd.Play();
        }

    }
}