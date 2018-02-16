using System.Threading.Tasks;

namespace languagedetector.net
{
    public interface ILanguageDetector
    {
        ILanguageResult Detect(string input);
        Task<ILanguageResult> DetectAsync(string input);
        void LoadProfile(string profilesDirectoryPath);
    }
}
