namespace Utils
{
    public static class StringExtension
    {
        /// <summary>
        /// Remove trailling spaces and lower the string. 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Clean(this string str)
        {
            return str.ToLower().Trim();
        }
    }
}
