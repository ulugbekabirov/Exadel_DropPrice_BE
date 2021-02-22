using DAL.Entities;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shared.EmailService
{
    public class ReplacerService : IReplacerService
    {
        private const string REGEX_TOKEN_FINDER = @"##([^\s#]+)##";

        public ReplacerService()
        {
        }

        private string Format(string format, Dictionary<string, string> args)
        {
            return Regex.Replace(format, REGEX_TOKEN_FINDER, match => FormatMatchEvaluator(match, args));
        }

        private static string FormatMatchEvaluator(Match m, Dictionary<string, string> lookup)
        {
            var key = m.Groups[1].Value;
            if (!lookup.ContainsKey(key))
            {
                return m.Value;
            }
            return lookup[key];
        }

        public string Replacer(string inputString, Dictionary<string, string> dictionary)
        {

            var outputString = Format(inputString, dictionary);

            return outputString;
        }
    }
}
