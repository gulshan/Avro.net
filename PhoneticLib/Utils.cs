using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PhoneticLib
{
    internal static class LinqUtils
    {
        public static T MaxBy<T>(this IEnumerable<T> source, Func<T, int> selector) where T : class
        {
            if (source.Any())
            {
                return source.Aggregate((agg, next) =>
                    selector(next) > selector(agg) ? next : agg);
            }
            return default;
        }
    }

    internal static class MatchUtils
    {
        private static bool IsVowel(char c) => ParseData.Vowels.Contains(char.ToLower(c));
        private static bool IsConsonant(char c) => ParseData.Consonants.Contains(char.ToLower(c));
        private static bool IsPunctuation(char c) => !IsVowel(c) && !IsConsonant(c);
        private static bool IsExact(char value, string matchWith) => value == matchWith[0];

        public static bool DoesMatch(this Match match, char prefix, char suffix)
        {
            var matchChar = (match.Scope == MatchScope.Prefix) ? prefix : suffix;

            var doesMatch = match.Type switch
            {
                MatchType.Vowel => IsVowel(matchChar),
                MatchType.Consonant => IsConsonant(matchChar),
                MatchType.Punctuation => IsPunctuation(matchChar),
                MatchType.Exact => IsExact(matchChar, match.Value),
                _ => false
            };

            return doesMatch == match.ShouldMatch;
        }
    }

    internal class MatchConverter : JsonConverter<Match>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, Match value, JsonSerializer serializer) =>
            throw new NotImplementedException();

        public override Match ReadJson(JsonReader reader, Type objectType, Match existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var token = JToken.ReadFrom(reader);

            var scopJson = (string)token["scope"];
            var scope = (scopJson == "suffix") ? MatchScope.Suffix : MatchScope.Prefix;

            var typeJson = (string)token["type"];
            var shouldMatch = true;

            if (typeJson.StartsWith("!"))
            {
                shouldMatch = false;
                typeJson = typeJson.Substring(1);
            }

            var type = typeJson switch
            {
                "vowel" => MatchType.Vowel,
                "consonant" => MatchType.Consonant,
                "punctuation" => MatchType.Punctuation,
                "exact" => MatchType.Exact,
                _ => throw new JsonException("Invalid value")
            };

            var value = (type == MatchType.Exact) ? (string)token["value"] : null;

            return new Match
            {
                Scope = scope,
                Type = type,
                ShouldMatch = shouldMatch,
                Value = value
            };
        }
    }
}