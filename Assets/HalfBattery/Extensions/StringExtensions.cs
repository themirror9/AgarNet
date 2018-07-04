public static class StringExtensions
{

    public static string RemoveLast(this string text, string occurence)
    {
        if (text.Length < 1) return text;
        return text.Remove(text.LastIndexOf(occurence), occurence.Length);
    }

}
