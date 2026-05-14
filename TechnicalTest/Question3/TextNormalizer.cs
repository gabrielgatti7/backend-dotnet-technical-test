namespace TechnicalTest.Question3;

public static class TextNormalizer
{
    public static string NormalizeExclamationAndQuestionMark(string text)
    {
        string normalized = string.Empty;
        char previuos = default;
        foreach (char c in text)
        {
            if ((c == '!' || c == '?') && c == previuos)
            {
                continue;
            }
            normalized += c;
            previuos = c;
        }

        return normalized;
    }
}
