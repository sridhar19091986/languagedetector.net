using System;
using System.Collections.Generic;

namespace languagedetector.net
{
    public interface ILanguageResult
    {
        string LanguageCode { get; }
        IList<Tuple<string, double>> Probabilities { get; }
    }
}
