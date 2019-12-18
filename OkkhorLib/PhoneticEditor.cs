using System.Text;

namespace OkkhorLib
{
    public class PhoneticEditor
    {
        private StringBuilder inputBuffer = new StringBuilder(16);
        private int lastOutputLength = 0;
        private int lastCursorPosition = 0;

        public void Reset()
        {
            inputBuffer.Clear();
            lastOutputLength = 0;
            lastCursorPosition = 0;
        }

        public (string output, int replaceLength) PutNewChar(char newChar, int cursorPosition = 0)
        {
            if (char.IsWhiteSpace(newChar))
            {
                Reset();
                return default;
            }

            if (cursorPosition != lastCursorPosition + 1)
            {
                inputBuffer.Clear();
                lastOutputLength = 0;
            }

            inputBuffer.Append(newChar);
            var output = Parser.Parse(inputBuffer.ToString());
            var replaceLen = lastOutputLength + 1;

            lastOutputLength = output.Length;
            lastCursorPosition = cursorPosition - replaceLen + output.Length;

            return (output, replaceLen);
        }
    }
}