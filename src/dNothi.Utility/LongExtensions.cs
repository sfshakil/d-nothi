namespace dNothi.Utility
{
    public static class LongExtensions
    {
        public static string LongToStringWithLeftPad(this long number, int totalWidth)
        {
            return number.ToString().PadLeft(totalWidth, '0');
        }
    }
}