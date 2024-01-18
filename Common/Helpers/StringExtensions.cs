using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class StringExtensions
    {
        public static bool IsAllLetters(this string str)
            => (str != null) && str.All(c => char.IsLetter(c));

        public static bool IsAllNumbers(this string str)
            => (str != null) && str.All(c => char.IsDigit(c));

        public static bool AreNullOrEmpty(params string[] strings)
            => (strings == null) || strings.Any(s => string.IsNullOrEmpty(s));
    }
}
