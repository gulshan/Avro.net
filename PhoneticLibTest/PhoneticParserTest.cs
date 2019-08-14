using PhoneticLib;
using Xunit;

namespace PhoneticLibTest
{
    public class PhoneticParserTest
    {
        private readonly PhoneticParser parser = new PhoneticParser();

        [Fact]
        private void TestSentences()
        {
            //Goal: Test Sentence conversion
            Assert.Equal("আমি বাংলায় গান গাই", parser.Parse("ami banglay gan gai"));
            Assert.Equal("আমাদের ভালোবাসা হয়ে গেল ঘাস, খেয়ে গেল গরু আর দিয়ে গেল বাঁশ",
                parser.Parse("amader valObasa hoye gel ghas, kheye gel goru ar diye gelo ba^sh"));
        }

        [Fact]
        public void BasicTest1()
        {
            Assert.Equal("ভ্ল", parser.Parse("bhl"));
            Assert.Equal("ব্জ", parser.Parse("bj"));
            Assert.Equal("ব্দ", parser.Parse("bd"));
            Assert.Equal("ব্ব", parser.Parse("bb"));
            Assert.Equal("ব্ল", parser.Parse("bl"));
            Assert.Equal("ভ", parser.Parse("bh"));
            Assert.Equal("ভ্ল", parser.Parse("vl"));
            Assert.Equal("ব", parser.Parse("b"));
            Assert.Equal("ভ", parser.Parse("v"));
            Assert.Equal("চ্ঞ", parser.Parse("cNG"));
            Assert.Equal("চ্ছ", parser.Parse("cch"));
            Assert.Equal("চ্চ", parser.Parse("cc"));
            Assert.Equal("ছ", parser.Parse("ch"));
            Assert.Equal("চ", parser.Parse("c"));
            Assert.Equal("ধ্ন", parser.Parse("dhn"));
            Assert.Equal("ধ্ম", parser.Parse("dhm"));
            Assert.Equal("দ্ঘ", parser.Parse("dgh"));
            Assert.Equal("দ্ধ", parser.Parse("ddh"));
            Assert.Equal("দ্ভ", parser.Parse("dbh"));
            Assert.Equal("দ্ভ", parser.Parse("dv"));
            Assert.Equal("দ্ম", parser.Parse("dm"));
            Assert.Equal("ড্ড", parser.Parse("DD"));
            Assert.Equal("ঢ", parser.Parse("Dh"));
            Assert.Equal("ধ", parser.Parse("dh"));
            Assert.Equal("দ্গ", parser.Parse("dg"));
            Assert.Equal("দ্দ", parser.Parse("dd"));
            Assert.Equal("ড", parser.Parse("D"));
            Assert.Equal("দ", parser.Parse("d"));
        }

        [Fact]
        public void BasicTest2()
        {
            Assert.Equal("...", parser.Parse("..."));
            Assert.Equal(".", parser.Parse(".`"));
            Assert.Equal("।।", parser.Parse(".."));
            Assert.Equal("।", parser.Parse("."));
            Assert.Equal("ঘ্ন", parser.Parse("ghn"));
            Assert.Equal("ঘ্ন", parser.Parse("Ghn"));
            Assert.Equal("গ্ধ", parser.Parse("gdh"));
            Assert.Equal("গ্ণ", parser.Parse("gN"));
            Assert.Equal("গ্ণ", parser.Parse("GN"));
            Assert.Equal("গ্ন", parser.Parse("gn"));
            Assert.Equal("গ্ম", parser.Parse("gm"));
            Assert.Equal("গ্ম", parser.Parse("Gm"));
            Assert.Equal("গ্ল", parser.Parse("gl"));
            Assert.Equal("গ্ল", parser.Parse("Gl"));
            Assert.Equal("জ্ঞ", parser.Parse("gg"));
            Assert.Equal("জ্ঞ", parser.Parse("GG"));
            Assert.Equal("জ্ঞ", parser.Parse("Gg"));
            Assert.Equal("জ্ঞ", parser.Parse("gG"));
            Assert.Equal("ঘ", parser.Parse("gh"));
            Assert.Equal("ঘ", parser.Parse("Gh"));
            Assert.Equal("গ", parser.Parse("g"));
            Assert.Equal("হ্ণ", parser.Parse("hN"));
            Assert.Equal("হ্ন", parser.Parse("hn"));
            Assert.Equal("হ্ম", parser.Parse("hm"));
            Assert.Equal("হ্ল", parser.Parse("hl"));
            Assert.Equal("হ", parser.Parse("h"));
        }

        [Fact]
        public void BasicTest3()
        {
            Assert.Equal("জ্ঝ", parser.Parse("jjh"));
            Assert.Equal("জ্ঞ", parser.Parse("jNG"));
            Assert.Equal("ঝ", parser.Parse("jh"));
            Assert.Equal("জ্জ", parser.Parse("jj"));
            Assert.Equal("জ", parser.Parse("j"));
            Assert.Equal("জ", parser.Parse("J"));
            Assert.Equal("ক্ষ্ণ", parser.Parse("kkhN"));
            Assert.Equal("ক্ষ্ণ", parser.Parse("kShN"));
            Assert.Equal("ক্ষ্ম", parser.Parse("kkhm"));
            Assert.Equal("ক্ষ্ম", parser.Parse("kShm"));
            Assert.Equal("ক্ষ্ণ", parser.Parse("kxN"));
            Assert.Equal("ক্ষ্ম", parser.Parse("kxm"));
            Assert.Equal("ক্ষ", parser.Parse("kkh"));
            Assert.Equal("ক্ষ", parser.Parse("kSh"));
            Assert.Equal("কশ", parser.Parse("ksh"));
            Assert.Equal("ক্ষ", parser.Parse("kx"));
            Assert.Equal("ক্ক", parser.Parse("kk"));
            Assert.Equal("ক্ট", parser.Parse("kT"));
            Assert.Equal("ক্ত", parser.Parse("kt"));
            Assert.Equal("ক্ল", parser.Parse("kl"));
            Assert.Equal("ক্স", parser.Parse("ks"));
            Assert.Equal("খ", parser.Parse("kh"));
            Assert.Equal("ক", parser.Parse("k"));
            Assert.Equal("ল্ভ", parser.Parse("lbh"));
            Assert.Equal("ল্ধ", parser.Parse("ldh"));
            Assert.Equal("লখ", parser.Parse("lkh"));
            Assert.Equal("লঘ", parser.Parse("lgh"));
            Assert.Equal("লফ", parser.Parse("lph"));
            Assert.Equal("ল্ক", parser.Parse("lk"));
            Assert.Equal("ল্গ", parser.Parse("lg"));
            Assert.Equal("ল্ট", parser.Parse("lT"));
            Assert.Equal("ল্ড", parser.Parse("lD"));
            Assert.Equal("ল্প", parser.Parse("lp"));
            Assert.Equal("ল্ভ", parser.Parse("lv"));
            Assert.Equal("ল্ম", parser.Parse("lm"));
            Assert.Equal("ল্ল", parser.Parse("ll"));
            Assert.Equal("ল্ব", parser.Parse("lb"));
            Assert.Equal("ল", parser.Parse("l"));
        }

        [Fact]
        public void BasicTest4()
        {
            Assert.Equal("ম্থ", parser.Parse("mth"));
            Assert.Equal("ম্ফ", parser.Parse("mph"));
            Assert.Equal("ম্ভ", parser.Parse("mbh"));
            Assert.Equal("মপ্ল", parser.Parse("mpl"));
            Assert.Equal("ম্ন", parser.Parse("mn"));
            Assert.Equal("ম্প", parser.Parse("mp"));
            Assert.Equal("ম্ভ", parser.Parse("mv"));
            Assert.Equal("ম্ম", parser.Parse("mm"));
            Assert.Equal("ম্ল", parser.Parse("ml"));
            Assert.Equal("ম্ব", parser.Parse("mb"));
            Assert.Equal("ম্ফ", parser.Parse("mf"));
            Assert.Equal("ম", parser.Parse("m"));
            Assert.Equal("০", parser.Parse("0"));
            Assert.Equal("১", parser.Parse("1"));
            Assert.Equal("২", parser.Parse("2"));
            Assert.Equal("৩", parser.Parse("3"));
            Assert.Equal("৪", parser.Parse("4"));
            Assert.Equal("৫", parser.Parse("5"));
            Assert.Equal("৬", parser.Parse("6"));
            Assert.Equal("৭", parser.Parse("7"));
            Assert.Equal("৮", parser.Parse("8"));
            Assert.Equal("৯", parser.Parse("9"));
            Assert.Equal("ঙ্ক্ষ", parser.Parse("NgkSh"));
            Assert.Equal("ঙ্ক্ষ", parser.Parse("Ngkkh"));
            Assert.Equal("ঞ্ছ", parser.Parse("NGch"));
            Assert.Equal("ঙ্ঘ", parser.Parse("Nggh"));
            Assert.Equal("ঙ্খ", parser.Parse("Ngkh"));
            Assert.Equal("ঞ্ঝ", parser.Parse("NGjh"));
            Assert.Equal("ঙ্গৌ", parser.Parse("ngOU"));
            Assert.Equal("ঙ্গৈ", parser.Parse("ngOI"));
            Assert.Equal("ঙ্ক্ষ", parser.Parse("Ngkx"));
            Assert.Equal("ঞ্চ", parser.Parse("NGc"));
            Assert.Equal("ঞ্ছ", parser.Parse("nch"));
            Assert.Equal("ঞ্ঝ", parser.Parse("njh"));
            Assert.Equal("ঙ্ঘ", parser.Parse("ngh"));
            Assert.Equal("ঙ্ক", parser.Parse("Ngk"));
            Assert.Equal("ঙ্ষ", parser.Parse("Ngx"));
            Assert.Equal("ঙ্গ", parser.Parse("Ngg"));
            Assert.Equal("ঙ্ম", parser.Parse("Ngm"));
            Assert.Equal("ঞ্জ", parser.Parse("NGj"));
            Assert.Equal("ন্ধ", parser.Parse("ndh"));
            Assert.Equal("ন্ঠ", parser.Parse("nTh"));
            Assert.Equal("ণ্ঠ", parser.Parse("NTh"));
            Assert.Equal("ন্থ", parser.Parse("nth"));
            Assert.Equal("ঙ্খ", parser.Parse("nkh"));
            Assert.Equal("ঙ্গ", parser.Parse("ngo"));
            Assert.Equal("ঙ্গা", parser.Parse("nga"));
            Assert.Equal("ঙ্গি", parser.Parse("ngi"));
            Assert.Equal("ঙ্গী", parser.Parse("ngI"));
            Assert.Equal("ঙ্গু", parser.Parse("ngu"));
            Assert.Equal("ঙ্গূ", parser.Parse("ngU"));
            Assert.Equal("ঙ্গে", parser.Parse("nge"));
            Assert.Equal("ঙ্গো", parser.Parse("ngO"));
            Assert.Equal("ণ্ঢ", parser.Parse("NDh"));
            Assert.Equal("নশ", parser.Parse("nsh"));
            Assert.Equal("ঙর", parser.Parse("Ngr"));
            Assert.Equal("ঞর", parser.Parse("NGr"));
            Assert.Equal("ংর", parser.Parse("ngr"));
            Assert.Equal("ঞ্জ", parser.Parse("nj"));
            Assert.Equal("ঙ", parser.Parse("Ng"));
            Assert.Equal("ঞ", parser.Parse("NG"));
            Assert.Equal("ঙ্ক", parser.Parse("nk"));
            Assert.Equal("ং", parser.Parse("ng"));
            Assert.Equal("ন্ন", parser.Parse("nn"));
            Assert.Equal("ণ্ণ", parser.Parse("NN"));
            Assert.Equal("ণ্ন", parser.Parse("Nn"));
            Assert.Equal("ন্ম", parser.Parse("nm"));
            Assert.Equal("ণ্ম", parser.Parse("Nm"));
            Assert.Equal("ন্দ", parser.Parse("nd"));
            Assert.Equal("ন্ট", parser.Parse("nT"));
            Assert.Equal("ণ্ট", parser.Parse("NT"));
            Assert.Equal("ন্ড", parser.Parse("nD"));
            Assert.Equal("ণ্ড", parser.Parse("ND"));
            Assert.Equal("ন্ত", parser.Parse("nt"));
            Assert.Equal("ন্স", parser.Parse("ns"));
            Assert.Equal("ঞ্চ", parser.Parse("nc"));
            Assert.Equal("ন", parser.Parse("n"));
            Assert.Equal("ণ", parser.Parse("N"));
        }

        [Fact]
        public void BasicTest5()
        {
            Assert.Equal("ৈ", parser.Parse("OI`"));
            Assert.Equal("ৌ", parser.Parse("OU`"));
            Assert.Equal("ো", parser.Parse("O`"));
            Assert.Equal("ঐ", parser.Parse("OI"));
            Assert.Equal("কৈ", parser.Parse("kOI"));
            Assert.Equal(" ঐ", parser.Parse(" OI"));
            Assert.Equal("(ঐ", parser.Parse("(OI"));
            Assert.Equal("।ঐ", parser.Parse(".OI"));
            Assert.Equal("ঔ", parser.Parse("OU"));
            Assert.Equal("কৌ", parser.Parse("kOU"));
            Assert.Equal(" ঔ", parser.Parse(" OU"));
            Assert.Equal("-ঔ", parser.Parse("-OU"));
            Assert.Equal("্‌ঔ", parser.Parse(",,OU"));
            Assert.Equal("ও", parser.Parse("O"));
            Assert.Equal("পো", parser.Parse("pO"));
            Assert.Equal(" ও", parser.Parse(" O"));
            Assert.Equal("ইও", parser.Parse("iO"));
            Assert.Equal("ও", parser.Parse("`O"));
            Assert.Equal("ফ্ল", parser.Parse("phl"));
            Assert.Equal("প্ট", parser.Parse("pT"));
            Assert.Equal("প্ত", parser.Parse("pt"));
            Assert.Equal("প্ন", parser.Parse("pn"));
            Assert.Equal("প্প", parser.Parse("pp"));
            Assert.Equal("প্ল", parser.Parse("pl"));
            Assert.Equal("প্স", parser.Parse("ps"));
            Assert.Equal("ফ", parser.Parse("ph"));
            Assert.Equal("ফ্ল", parser.Parse("fl"));
            Assert.Equal("ফ", parser.Parse("f"));
            Assert.Equal("প", parser.Parse("p"));
            Assert.Equal("ৃ", parser.Parse("rri`"));
            Assert.Equal("ঋ", parser.Parse("rri"));
            Assert.Equal("কৃ", parser.Parse("krri"));
            Assert.Equal("ঈঋ", parser.Parse("Irri"));
            Assert.Equal("ঁঋ", parser.Parse("^rri"));
            Assert.Equal("ঃঋ", parser.Parse(":rri"));
            Assert.Equal("র‍্য", parser.Parse("rZ"));
        }

        [Fact]
        public void BasicTest6()
        {
            Assert.Equal("ক্র্য", parser.Parse("krZ"));
            Assert.Equal("রর‍্য", parser.Parse("rrZ"));
            Assert.Equal("ইয়র‍্য", parser.Parse("yrZ"));
            Assert.Equal("ওর‍্য", parser.Parse("wrZ"));
            Assert.Equal("এক্সর‍্য", parser.Parse("xrZ"));
            Assert.Equal("ইর‍্য", parser.Parse("irZ"));
            Assert.Equal("-র‍্য", parser.Parse("-rZ"));
            Assert.Equal("ররর‍্য", parser.Parse("rrrZ"));
            Assert.Equal("র‍্য", parser.Parse("ry"));
            Assert.Equal("ক্র্য", parser.Parse("qry"));
            Assert.Equal("রর‍্য", parser.Parse("rry"));
            Assert.Equal("ইয়র‍্য", parser.Parse("yry"));
            Assert.Equal("ওর‍্য", parser.Parse("wry"));
            Assert.Equal("এক্সর‍্য", parser.Parse("xry"));
            Assert.Equal("০র‍্য", parser.Parse("0ry"));
            Assert.Equal("রররর‍্য", parser.Parse("rrrry"));
            Assert.Equal("ড়্র্য", parser.Parse("Rry"));
            Assert.Equal("রর", parser.Parse("rr"));
            Assert.Equal("আরর", parser.Parse("arr"));
            Assert.Equal("আর্ক", parser.Parse("arrk"));
            Assert.Equal("আররা", parser.Parse("arra"));
            Assert.Equal("আরর", parser.Parse("arr"));
            Assert.Equal("আরর!", parser.Parse("arr!"));
            Assert.Equal("ক্রর", parser.Parse("krr"));
            Assert.Equal("ক্ররা", parser.Parse("krra"));
            Assert.Equal("ড়্গ", parser.Parse("Rg"));
            Assert.Equal("ঢ়", parser.Parse("Rh"));
            Assert.Equal("ড়", parser.Parse("R"));
            Assert.Equal("র", parser.Parse("r"));
            Assert.Equal("অর", parser.Parse("or"));
            Assert.Equal("ম্র", parser.Parse("mr"));
            Assert.Equal("১র", parser.Parse("1r"));
            Assert.Equal("+র", parser.Parse("+r"));
            Assert.Equal("রর", parser.Parse("rr"));
            Assert.Equal("ইয়র", parser.Parse("yr"));
            Assert.Equal("ওর", parser.Parse("wr"));
            Assert.Equal("এক্সর", parser.Parse("xr"));
            Assert.Equal("য্র", parser.Parse("zr"));
            Assert.Equal("ম্রি", parser.Parse("mri"));
        }

        [Fact]
        public void BasicTest7()
        {
            Assert.Equal("শ্ছ", parser.Parse("shch"));
            Assert.Equal("ষ্ঠ", parser.Parse("ShTh"));
            Assert.Equal("ষ্ফ", parser.Parse("Shph"));
            Assert.Equal("শ্ছ", parser.Parse("Sch"));
            Assert.Equal("স্ক্ল", parser.Parse("skl"));
            Assert.Equal("স্খ", parser.Parse("skh"));
            Assert.Equal("স্থ", parser.Parse("sth"));
            Assert.Equal("স্ফ", parser.Parse("sph"));
            Assert.Equal("শ্চ", parser.Parse("shc"));
            Assert.Equal("শ্ত", parser.Parse("sht"));
            Assert.Equal("শ্ন", parser.Parse("shn"));
            Assert.Equal("শ্ম", parser.Parse("shm"));
            Assert.Equal("শ্ল", parser.Parse("shl"));
            Assert.Equal("ষ্ক", parser.Parse("Shk"));
            Assert.Equal("ষ্ট", parser.Parse("ShT"));
            Assert.Equal("ষ্ণ", parser.Parse("ShN"));
            Assert.Equal("ষ্প", parser.Parse("Shp"));
            Assert.Equal("ষ্ফ", parser.Parse("Shf"));
            Assert.Equal("ষ্ম", parser.Parse("Shm"));
            Assert.Equal("স্প্ল", parser.Parse("spl"));
            Assert.Equal("স্ক", parser.Parse("sk"));
            Assert.Equal("শ্চ", parser.Parse("Sc"));
            Assert.Equal("স্ট", parser.Parse("sT"));
            Assert.Equal("স্ত", parser.Parse("st"));
            Assert.Equal("স্ন", parser.Parse("sn"));
            Assert.Equal("স্প", parser.Parse("sp"));
            Assert.Equal("স্ফ", parser.Parse("sf"));
            Assert.Equal("স্ম", parser.Parse("sm"));
            Assert.Equal("স্ল", parser.Parse("sl"));
            Assert.Equal("শ", parser.Parse("sh"));
            Assert.Equal("শ্চ", parser.Parse("Sc"));
            Assert.Equal("শ্ত", parser.Parse("St"));
            Assert.Equal("শ্ন", parser.Parse("Sn"));
            Assert.Equal("শ্ম", parser.Parse("Sm"));
            Assert.Equal("শ্ল", parser.Parse("Sl"));
            Assert.Equal("ষ", parser.Parse("Sh"));
            Assert.Equal("স", parser.Parse("s"));
            Assert.Equal("শ", parser.Parse("S"));
            Assert.Equal("উ", parser.Parse("oo"));
            Assert.Equal("ওও", parser.Parse("OO"));
            Assert.Equal("ু", parser.Parse("oo`"));
            Assert.Equal("কু", parser.Parse("koo"));
            Assert.Equal("উঅ", parser.Parse("ooo"));
            Assert.Equal("!উ", parser.Parse("!oo"));
            Assert.Equal("!উঅ", parser.Parse("!ooo"));
            Assert.Equal("আউ", parser.Parse("aoo"));
            Assert.Equal("উপ", parser.Parse("oop"));
            Assert.Equal("উ", parser.Parse("ooo`"));
            Assert.Equal("", parser.Parse("o`"));
            Assert.Equal("অ্য", parser.Parse("oZ"));
            Assert.Equal("অয়", parser.Parse("oY"));
            Assert.Equal("অ", parser.Parse("o"));
            Assert.Equal("!অ", parser.Parse("!o"));
            Assert.Equal("ঁঅ", parser.Parse("^o"));
            Assert.Equal("*অ", parser.Parse("*o"));
            Assert.Equal("ইও", parser.Parse("io"));
            Assert.Equal("ইয়", parser.Parse("yo"));
            Assert.Equal("ন", parser.Parse("no"));
            Assert.Equal("ত্থ", parser.Parse("tth"));
            Assert.Equal("ৎ", parser.Parse("t``"));
            Assert.Equal("ৎ", parser.Parse("`t``"));
            Assert.Equal("ৎৎ", parser.Parse("t``t``"));
            Assert.Equal("ৎ", parser.Parse("t```"));
            Assert.Equal("ট্ট", parser.Parse("TT"));
            Assert.Equal("ট্ম", parser.Parse("Tm"));
            Assert.Equal("ঠ", parser.Parse("Th"));
            Assert.Equal("ত্ন", parser.Parse("tn"));
            Assert.Equal("ত্ম", parser.Parse("tm"));
            Assert.Equal("থ", parser.Parse("th"));
            Assert.Equal("ত্ত", parser.Parse("tt"));
            Assert.Equal("ট", parser.Parse("T"));
            Assert.Equal("ত", parser.Parse("t"));
        }

        [Fact]
        public void BasicTest8()
        {
            Assert.Equal("অ্যা", parser.Parse("aZ"));
            Assert.Equal("আঅ্যা", parser.Parse("aaZ"));
            Assert.Equal("অ্যা", parser.Parse("AZ"));
            Assert.Equal("া", parser.Parse("a`"));
            Assert.Equal("া", parser.Parse("a``"));
            Assert.Equal("কা", parser.Parse("ka`"));
            Assert.Equal("া", parser.Parse("A`"));
            Assert.Equal("আ", parser.Parse("a"));
            Assert.Equal("আ", parser.Parse("`a"));
            Assert.Equal("কআ", parser.Parse("k`a"));
            Assert.Equal("ইয়া", parser.Parse("ia"));
            Assert.Equal("আআআা", parser.Parse("aaaa`"));
            Assert.Equal("ি", parser.Parse("i`"));
            Assert.Equal("ই", parser.Parse("i"));
            Assert.Equal("ই", parser.Parse("`i"));
            Assert.Equal("হি", parser.Parse("hi"));
            Assert.Equal("ইহ", parser.Parse("ih"));
            Assert.Equal("িহ", parser.Parse("i`h"));
            Assert.Equal("ী", parser.Parse("I`"));
            Assert.Equal("ঈ", parser.Parse("I"));
            Assert.Equal("চী", parser.Parse("cI"));
            Assert.Equal("ঈক্স", parser.Parse("Ix"));
            Assert.Equal("ঈঈ", parser.Parse("II"));
            Assert.Equal("০ঈ", parser.Parse("0I"));
            Assert.Equal("অঈ", parser.Parse("oI"));
            Assert.Equal("ু", parser.Parse("u`"));
            Assert.Equal("উ", parser.Parse("u"));
            Assert.Equal("কু", parser.Parse("ku"));
            Assert.Equal("উক", parser.Parse("uk"));
            Assert.Equal("উউ", parser.Parse("uu"));
            Assert.Equal("ইউ", parser.Parse("iu"));
            Assert.Equal("&উ", parser.Parse("&u"));
            Assert.Equal("উ&", parser.Parse("u&"));
            Assert.Equal("ূ", parser.Parse("U`"));
            Assert.Equal("ঊ", parser.Parse("U"));
            Assert.Equal("ইয়ূ", parser.Parse("yU"));
            Assert.Equal("ঊয়", parser.Parse("Uy"));
            Assert.Equal("ঁঊ", parser.Parse("^U"));
            Assert.Equal("ঊঁ", parser.Parse("U^"));
            Assert.Equal("ঈ", parser.Parse("EE"));
            Assert.Equal("ঈ", parser.Parse("ee"));
            Assert.Equal("ঈ", parser.Parse("Ee"));
            Assert.Equal("ঈ", parser.Parse("eE"));
            Assert.Equal("ী", parser.Parse("ee`"));
            Assert.Equal("কী", parser.Parse("kee"));
            Assert.Equal("ঈক", parser.Parse("eek"));
            Assert.Equal("০ঈ", parser.Parse("0ee"));
            Assert.Equal("ঈ৮", parser.Parse("ee8"));
            Assert.Equal("(ঈ)", parser.Parse("(ee)"));
            Assert.Equal("ে", parser.Parse("e`"));
            Assert.Equal("এ", parser.Parse("e"));
            Assert.Equal("কে", parser.Parse("ke"));
            Assert.Equal("ওয়ে", parser.Parse("we"));
            Assert.Equal("#এ#", parser.Parse("#e#"));
            Assert.Equal("ে", parser.Parse("`e`"));
            Assert.Equal("য", parser.Parse("z"));
            Assert.Equal("্য", parser.Parse("Z"));
            Assert.Equal("র‍্য", parser.Parse("rZ"));
            Assert.Equal("ক্যশ", parser.Parse("kZS"));
            Assert.Equal("ইয়", parser.Parse("y"));
            Assert.Equal("অয়", parser.Parse("oy"));
            Assert.Equal("ক্য", parser.Parse("ky"));
            Assert.Equal("ইয়া", parser.Parse("ya"));
            Assert.Equal("ইয়াআ", parser.Parse("yaa"));
            Assert.Equal("য়", parser.Parse("Y"));
            Assert.Equal("য়য়", parser.Parse("YY"));
            Assert.Equal("ইয়", parser.Parse("iY"));
            Assert.Equal("কয়", parser.Parse("kY"));
            Assert.Equal("ক", parser.Parse("q"));
            Assert.Equal("ক", parser.Parse("Q"));
            Assert.Equal("ও", parser.Parse("w"));
            Assert.Equal("ওয়া", parser.Parse("wa"));
            Assert.Equal("-ওয়া-", parser.Parse("-wa-"));
            Assert.Equal("ওয়ু", parser.Parse("woo"));
            Assert.Equal("ওরে", parser.Parse("wre"));
            Assert.Equal("ক্ব", parser.Parse("kw"));
            Assert.Equal("এক্স", parser.Parse("x"));
            Assert.Equal("এক্স", parser.Parse("ex"));
            Assert.Equal("বক্স", parser.Parse("bx"));
            Assert.Equal(":", parser.Parse(":`"));
            Assert.Equal("ঃ", parser.Parse(":"));
            Assert.Equal("^", parser.Parse("^`"));
            Assert.Equal("ঁ", parser.Parse("^"));
            Assert.Equal("কঁ", parser.Parse("k^"));
            Assert.Equal("কঁই", parser.Parse("k^i"));
            Assert.Equal("কিঁ", parser.Parse("ki^"));
            Assert.Equal("্‌", parser.Parse(",,"));
            Assert.Equal("্‌,", parser.Parse(",,,"));
            Assert.Equal("্‌,", parser.Parse(",,`,"));
            Assert.Equal("্‌", parser.Parse("`,,"));
            Assert.Equal(",,", parser.Parse(",`,"));
            Assert.Equal("৳", parser.Parse("$"));
            Assert.Equal("", parser.Parse("`"));
            Assert.Equal("ব্ধ", parser.Parse("bdh"));
        }
    }
}
