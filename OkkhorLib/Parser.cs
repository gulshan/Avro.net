using System;
using System.Linq;
using System.Collections.Generic;

namespace OkkhorLib
{
    public static class Parser
    {
        private const string CASE_SENSITIVE_CHARS = "oiudgjnrstyz";
        private const string CONSONANT_CHARS = "bcdfghjklmnpqrstvwxyz";

        private static bool IsConsonant(char c) =>
            CONSONANT_CHARS.Contains(char.ToLower(c));

        private static bool IsCaseSensitive(char c) =>
            CASE_SENSITIVE_CHARS.Contains(char.ToLower(c));

        private static string Normalize(string raw) =>
            new string(raw.Select(c => IsCaseSensitive(c) ? c : char.ToLower(c)).ToArray());

        public static string Parse(string rawInput)
        {
            var input = Normalize(rawInput);
            var output = "";
            var prefix = ' ';

            while (input.Length > 0)
            {
                var match = Pattern.PHONETIC_PATTERNS
                                .Where(p => input.StartsWith(p.Find))
                                .MaxBy(p => p.Find.Length);
                if (match != null)
                {
                    output += match.GetReplacement(IsConsonant(prefix));
                    prefix = match.Find[match.Find.Length - 1];
                    input = input.Substring(match.Find.Length);
                }
                else
                {
                    output += input[0];
                    prefix = input[0];
                    input = input.Substring(1);
                }
            }

            return output;
        }

        static T MaxBy<T>(this IEnumerable<T> source, Func<T, int> selector) where T : class
        {
            if (source.Any())
            {
                return source.Aggregate((agg, next) =>
                    selector(next) > selector(agg) ? next : agg);
            }
            return default;
        }
    }
}