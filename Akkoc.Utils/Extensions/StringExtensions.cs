using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akkoc.Utils
{
    public static class StringExtensions
    {
        public static string ToLegalString(this string source)
        {
            return source.ToLower()
                .Replace(' ', '-')
                .Replace('ş', 's')
                .Replace('ç', 'c')
                .Replace('ö', 'o')
                .Replace('ğ', 'g')
                .Replace('ı', 'i')
                .Replace('ü', 'u')
                .Replace('/','_')
                .Replace('?','_');
        }

    }
}
