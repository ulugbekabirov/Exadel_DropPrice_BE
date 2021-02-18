using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shared.EmailService
{
    public interface IReplacerService
    {
        string Replacer(string inputString, Dictionary<string, string> dictionary);
    }
}
