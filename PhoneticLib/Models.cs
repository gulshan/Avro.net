using System.Collections.Generic;

namespace PhoneticLib
{
    internal enum MatchScope
    {
        Prefix, Suffix
    }

    internal enum MatchType
    {
        Vowel, Consonant, Punctuation, Exact
    }

    internal class Match
    {
        public MatchScope Scope { get; set; }
        public MatchType Type { get; set; }
        public string Value { get; set; }
        public bool ShouldMatch { get; set; }
    }

    internal class Rule
    {
        public List<Match> Matches { get; set; }
        public string Replace { get; set; }
    }

    internal class Pattern
    {
        public string Find { get; set; }
        public string Replace { get; set; }
        public List<Rule> Rules { get; set; }
    }

    internal class ParseData
    {
        public List<Pattern> Patterns { get; set; }
        public const string Vowels = "aeiou";
        public const string Consonants = "bcdfghjklmnpqrstvwxyz";
        public const string CaseSensitive = "oiudgjnrstyz";
    }
}
