using System; 
using System.Collections.Generic; 

namespace languagedetector.net
{
    public class LanguageResult : ILanguageResult
    {
        public LanguageResult(string languageCode, java.util.ArrayList probabilities)
        {
            Probabilities = new List<Tuple<string, double>>();
            this.LanguageCode = languageCode;
            for (int i = 0; i < probabilities.size(); ++i)
            {
                string[] values = probabilities.get(i).ToString().Split(':');
                if (values.Length == 2
                 && values[0].Length > 0
                 && values[1].Length > 0)
                {
                    Probabilities.Add(new Tuple<string, double>(values[0],
                        double.Parse(values[1],
                            System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture)));
                }
            }
        }

        public string LanguageCode { get; }
        public IList<Tuple<string, double>> Probabilities { get; }

        public override string ToString()
        {
            return LanguageCode;
        }
    }
}
