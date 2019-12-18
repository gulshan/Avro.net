using System.Collections.Generic;

namespace OkkhorLib
{
    internal class Pattern
    {
        public string Find { get; private set; }
        private string Replace { get; set; }
        private string ConsonantReplace { get; set; }

        public string GetReplacement(bool isPrefixConsonant) =>
            isPrefixConsonant ? ConsonantReplace : Replace;

        private static Pattern Simple(string find, string replace) =>
            new Pattern
            {
                Find = find,
                Replace = replace,
                ConsonantReplace = replace
            };

        private static Pattern New(string find, string replace, string consonantReplace) =>
            new Pattern
            {
                Find = find,
                Replace = replace,
                ConsonantReplace = consonantReplace
            };

        public static List<Pattern> PHONETIC_PATTERNS = new List<Pattern>
        {
            New("o", "অ", ""),
            New("a", "আ", "া"),
            New("i", "ই", "ি"),
            New("ii", "ঈ", "ী"),
            New("u", "উ", "ু"),
            New("uu", "ঊ", "ূ"),
            New("rri", "ঋ", "ৃ"),
            New("e", "এ", "ে"),
            New("oi", "ঐ", "ৈ"),
            New("`o", "ও", "ো"),
            New("ou", "ঔ", "ৌ"),
            New("k", "ক", "্ক"),
            New("kh", "খ", "্খ"),
            New("g", "গ", "্গ"),
            New("gh", "ঘ", "্ঘ"),
            New("`ng", "ঙ", "্ঙ"),
            New("c", "চ", "্চ"),
            New("ch", "ছ", "্ছ"),
            New("j", "জ", "্জ"),
            New("jh", "ঝ", "্ঝ"),
            New("n`g", "ঞ", "্ঞ"),
            New("`t", "ট", "্ট"),
            New("`th", "ঠ", "্ঠ"),
            New("`d", "ড", "্ড"),
            New("`dh", "ঢ", "্ঢ"),
            New("`n", "ণ", "্ণ"),
            New("t", "ত", "্ত"),
            New("th", "থ", "্থ"),
            New("d", "দ", "্দ"),
            New("dh", "ধ", "্ধ"),
            New("n", "ন", "্ন"),
            New("p", "প", "্প"),
            New("f", "ফ", "্ফ"),
            New("b", "ব", "্ব"),
            New("v", "ভ", "্ভ"),
            New("m", "ম", "্ম"),
            New("z", "য", "্য"),
            New("y", "য়", "্য"),
            New("r", "র", "্র"),
            New("ry", "র‍্য", "্র্য"),
            New("l", "ল", "্ল"),
            New("sh", "শ", "্শ"),
            New("x", "ষ", "্ষ"),
            New("s", "স", "্স"),
            New("h", "হ", "্হ"),
            New("w", "ও", "্ব"),
            Simple("a`y", "অ্যা"),
            Simple("ng", "ং"),
            Simple("`r", "ড়"),
            Simple("`rh", "ঢ়"),
            Simple("gg", "জ্ঞ"),
            Simple("t``", "ৎ"),
            Simple("q", "ক্ব"),
            Simple(":`", ":"),
            Simple(":", "ঃ"),
            Simple("^`", "^"),
            Simple("^", "ঁ"),
            Simple("$", "৳"),
            Simple("`", ""),
            Simple("0", "০"),
            Simple("1", "১"),
            Simple("2", "২"),
            Simple("3", "৩"),
            Simple("4", "৪"),
            Simple("5", "৫"),
            Simple("6", "৬"),
            Simple("7", "৭"),
            Simple("8", "৮"),
            Simple("9", "৯"),
            Simple("...", "..."),
            Simple(".`", "."),
            Simple("..", "।।"),
            Simple(".", "।"),
        };
    }
}
