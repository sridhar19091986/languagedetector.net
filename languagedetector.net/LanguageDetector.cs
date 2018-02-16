using com.cybozu.labs.langdetect;
using System;
using System.Threading.Tasks;

namespace languagedetector.net
{
    public class LanguageDetector : ILanguageDetector
    {
        private Detector detector;
        private readonly object syncLock;

        public LanguageDetector()
        {
            syncLock = new object();
        }

        public LanguageDetector(string profilesDirectory)
            : this()
        {
            LoadProfile(profilesDirectory);
        }

        public ILanguageResult Detect(string input)
        {
            lock (syncLock)
            {
                if (null != detector)
                {
                    detector.append(input);
                    return new LanguageResult(detector.detect(), detector.getProbabilities());
                }
                else
                {
                    throw new NullReferenceException("The detector has not been instantiated properly.  Please call the LoadProfile() method to instantiate it with a specified profiles directory.");
                }
            }
        }

        public async Task<ILanguageResult> DetectAsync(string input)
        {
            var task = Task.Run(() => Detect(input));
            await task;
            return task.Result;
        }

        public void LoadProfile(string profilesDirectoryPath)
        {
            if (!System.IO.Directory.Exists(profilesDirectoryPath))
            {
                throw new System.IO.DirectoryNotFoundException(string.Format("The directory {0} does not exist.", profilesDirectoryPath));
            }

            lock (syncLock)
            {
                DetectorFactory.loadProfile(profilesDirectoryPath);
                detector = DetectorFactory.create();
            }
        }
    }
}
