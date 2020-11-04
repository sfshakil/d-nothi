namespace dNothi.Utility
{
    public class StringStream
    {
        private readonly string _input;
        private int _startIndex;

        public StringStream(string input)
        {
            _input = input;
            _startIndex = 0;
        }

        public string Next(int length)
        {
            var substring = _input.Substring(_startIndex, length);
            _startIndex += length;
            return substring;
        }
    }
}