using System.Collections.Generic;

namespace BL.Interfaces
{
    public interface IReplacerService
    {
        string Replacer(string inputString, Dictionary<string, string> dictionary);
    }
}
