using System.Globalization;
using System.Linq;
using System.Text;

namespace Renaissance.WorldEditor.Utils
{
    public static class StringExtensions
    {
        public static bool HasAccents(this string source)
            => source.Normalize(NormalizationForm.FormD)
                     .Any(x => CharUnicodeInfo.GetUnicodeCategory(x) == UnicodeCategory.NonSpacingMark);

        public static string RemoveAccents(this string source)
            => string.Concat(
                source.Normalize(NormalizationForm.FormD)
                      .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                                   UnicodeCategory.NonSpacingMark)
                ).Normalize(NormalizationForm.FormC);

    }
}
