namespace OkkhorLib
{
    public class PhoneticEditor
    {
        private string inputBuffer = "";
        private int lastOutputLength = 0;
        private int lastCursorPosition = 0;

        public void Reset()
        {
            inputBuffer = "";
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

            if (cursorPosition == lastCursorPosition + 1)
            {
                inputBuffer += newChar;
            }
            else
            {
                inputBuffer = "" + newChar;
                lastOutputLength = 0;
            }
            var output = Parser.Parse(inputBuffer);
            var replaceLen = lastOutputLength + 1;

            lastOutputLength = output.Length;
            lastCursorPosition = cursorPosition - replaceLen + output.Length;

            return (output, replaceLen);
        }
    }
}