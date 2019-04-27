namespace PhoneticLib
{
    public class PhoneticEditor
    {
        private readonly PhoneticParser parser = new PhoneticParser();
        private string inputBuffer = "";
        private int lastOutputLength = 0;
        private int lastCursorPosition = 0;

        public (string output, int replaceLength) PutNewChar(int cursorPosition, char newChar)
        {
            if (char.IsWhiteSpace(newChar))
            {
                inputBuffer = "";
                lastOutputLength = 0;
                lastCursorPosition = cursorPosition;
                return (null, 0);
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
            var output = parser.Parse(inputBuffer);
            var replaceLen = lastOutputLength + 1;

            lastOutputLength = output.Length;
            lastCursorPosition = cursorPosition - replaceLen + output.Length;

            return (output, replaceLen);
        }
    }
}