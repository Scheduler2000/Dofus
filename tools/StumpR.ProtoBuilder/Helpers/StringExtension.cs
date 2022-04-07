namespace StumpR.ProtoBuilder.Helpers;

public static class StringExtension
{
    public static string Capitalize(this string s)
    {
        return string.Concat(s[..1].ToUpper(), s.AsSpan(1, s.Length - 1));
    }

    public static string Decapitalize(this string s)
    {
        return string.Concat(s[..1].ToLower(), s.AsSpan(1, s.Length - 1));
    }

    public static string NormalizePackageImport(this string package)
    {
        package = Capitalize(package);

        if (!package.Contains('.')) return package;

        var characters = package.ToCharArray();

        for (var i = 0; i < characters.Length - 1; i++)
            if (characters[i] == '.')
                characters[i + 1] = char.ToUpper(characters[i + 1]);

        return new string(characters);
    }

    public static string RemoveCharactersFromTheEnd(this string str, char stop)
    {
        var count = 1;

        for (var i = str.Length - 1; i > 0; i--)
        {
            if (str[i] == stop) break;
            count++;
        }

        return str.Substring(0, str.Length - count);
    }
}