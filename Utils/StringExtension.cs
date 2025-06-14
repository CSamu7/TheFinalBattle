namespace Utils
{
    public static class StringExtension
    {
        public static string Clean(this string str)
        {
            return str.ToLower().Trim();
        }
    }
}
