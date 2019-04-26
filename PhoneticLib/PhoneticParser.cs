using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace PhoneticLib
{
    public class PhoneticParser
    {
        ParseData data;

        public PhoneticParser()
        {
            var jsonText = File.ReadAllText(@"data.json");
            data = JsonConvert.DeserializeObject<ParseData>(jsonText, new MatchConverter());
        }

        private static bool isCaseSensitive(char c) => ParseData.CaseSensitive.Contains(char.ToLower(c));

        public string Parse(string rawInput)
        {
            var input = new string(rawInput
                .Select(c => isCaseSensitive(c) ? c : char.ToLower(c))
                .ToArray());

            var output = "";
            var prefix = ' ';
            var suffix = ' ';

            while (input.Length > 0)
            {
                string replace = null;

                var patternMatch = data.Patterns
                                .Where(p => input.StartsWith(p.Find))
                                .MaxBy(p => p.Find.Length);

                if (patternMatch != null)
                {
                    if (input.Length > patternMatch.Find.Length)
                        suffix = input[patternMatch.Find.Length];
                    else
                        suffix = ' ';

                    if (patternMatch.Rules != null)
                    {
                        foreach (var rule in patternMatch.Rules)
                        {
                            if (rule.Matches.All(match => match.DoesMatch(prefix, suffix)))
                            {
                                replace = rule.Replace;
                                break;
                            }
                        }
                    }

                    if (replace == null)
                    {
                        replace = patternMatch.Replace;
                    }

                    output += replace;
                    prefix = patternMatch.Find[patternMatch.Find.Length - 1];
                    input = input.Substring(patternMatch.Find.Length);
                    replace = null;
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
    }
}