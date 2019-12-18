using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OkkhorLib
{
    public static class Parser
    {
        private const string CONSONANT_CHARS = "bcdfghjklmnpqrstvwxyz";

        private static bool IsConsonant(char c) =>
            CONSONANT_CHARS.Contains(char.ToLower(c));

        private static string Normalize(string raw)
        {
            var result = new StringBuilder(raw.Length + 1);
            foreach (char c in raw)
            {
                if (char.IsUpper(c))
                {
                    result.Append('`');
                    result.Append(char.ToLower(c));
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        public static string Parse(string rawInput)
        {
            var input = Normalize(rawInput);
            var output = new StringBuilder(input.Length);
            var prefix = ' ';

            while (input.Length > 0)
            {
                var match = Pattern.PHONETIC_PATTERNS
                                .Where(p => input.StartsWith(p.Find))
                                .MaxBy(p => p.Find.Length);
                if (match != null)
                {
                    output.Append(match.GetReplacement(IsConsonant(prefix)));
                    prefix = match.Find[match.Find.Length - 1];
                    input = input.Substring(match.Find.Length);
                }
                else
                {
                    output.Append(input[0]);
                    prefix = input[0];
                    input = input.Substring(1);
                }
            }

            return output.ToString();
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