using System.Collections.Generic;

namespace BL.Interfaces
{
    public interface IReplacerService
    {
        string Replace(string inputString, Dictionary<string, string> dictionary);
    }
}
