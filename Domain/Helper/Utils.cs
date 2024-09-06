using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Helper;

public static class Utils
{
    public static string RemoveAccents(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;

        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in from c in normalizedString
                 let unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c)
                 where unicodeCategory != UnicodeCategory.NonSpacingMark
                 select c)
            stringBuilder.Append(c);

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
    
    public static string RemoveSpecialCharacters(string input)
    {
        return Regex.Replace(input, @"[^a-zA-Z0-9]", "");
    }
    
    public static string ReplaceSpecialCharactersWithUnderscore(string input)
    {
        return Regex.Replace(input, @"[^a-zA-Z0-9]", "_");
    }
}