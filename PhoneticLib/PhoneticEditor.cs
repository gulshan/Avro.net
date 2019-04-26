namespace PhoneticLib
{
    public class PhoneticEditor
    {
        public struct Result
        {
            public string output;
            public int replaceStartPosition;
            public int newCursorPosition;

            internal Result(string outputText, int replaceStart, int cursor) =>
                (output, replaceStartPosition, newCursorPosition) = (outputText, replaceStart, cursor);
        }

        private readonly PhoneticParser parser = new PhoneticParser();
        private string inputBuffer = "";
        private string outputBuffer = "";
        private int cursorPosition = 0;

        public Result PutNewChar(int givenCursorPosition, char newChar)
        {
            if (char.IsWhiteSpace(newChar))
            {
                inputBuffer = "";
                outputBuffer = "";
                cursorPosition = givenCursorPosition;
                return new Result(null, cursorPosition, cursorPosition);
            }

            var previousOutputBufflen = 0;
            if (givenCursorPosition == cursorPosition + 1)
            {
                inputBuffer += newChar;
                previousOutputBufflen = outputBuffer.Length;
            }
            else
            {
                inputBuffer = "" + newChar;
            }
            outputBuffer = parser.Parse(inputBuffer);
            var replaceStartPosition = givenCursorPosition - previousOutputBufflen - 1;
            cursorPosition = givenCursorPosition - 1 - previousOutputBufflen + outputBuffer.Length;
            return new Result(outputBuffer, replaceStartPosition, cursorPosition);
        }
    }
}