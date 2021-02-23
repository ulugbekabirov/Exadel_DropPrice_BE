using System.Collections.Generic;

namespace BL.EmailService
{
    public interface IReplacerService
    {
        string Replacer(string inputString, Dictionary<string, string> dictionary);
    }
}
