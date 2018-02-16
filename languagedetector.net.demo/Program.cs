using System; 

namespace languagedetector.net.demo
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting app...");

            ILanguageDetector languageDetector = new LanguageDetector();
            languageDetector.LoadProfile(@"~/../../../../languagedetector.net/profiles/profiles/");
            var language = languageDetector.Detect("This is a test to test the language."); 
            Console.WriteLine("Language picked up: {0}", language.LanguageCode);

            Console.WriteLine("Done...Press any key to quit");
            Console.ReadKey();
        }
    }
}
