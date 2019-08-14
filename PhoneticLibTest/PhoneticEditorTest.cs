using PhoneticLib;
using Xunit;

namespace PhoneticLibTest
{
    public class PhoneticEditorTest
    {
        private readonly PhoneticEditor editor = new PhoneticEditor();

        [Fact]
        private void Test1()
        {
            editor.Reset();
            editor.PutNewChar('k', 1);
            editor.PutNewChar('o', 2);
            editor.PutNewChar('r', 2);

            var result = editor.PutNewChar('r', 3);
            Assert.Equal(expected: "করর", result.output);

            result = editor.PutNewChar('m', 4);
            Assert.Equal(expected: "কর্ম", result.output);

            result = editor.PutNewChar(' ');
            Assert.Null(result.output);
        }
    }
}
