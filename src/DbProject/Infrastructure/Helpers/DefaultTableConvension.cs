using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DbProject.Helper
{
    public static class DefaultTableConvension
    {
        private static bool IsVowel(this char c) =>
             char.IsLetter(c) && "aeiouAEIOU".IndexOf(c) < 0;

        public static string GetColumnPrefix(string columnName)
        {
            string res = string.Empty;
            string namePart;

            while (!columnName.Equals(string.Empty))
            {
                namePart = columnName.FirstOrDefault() + string.Concat(columnName.Skip(1).TakeWhile(s => !char.IsUpper(s)));
                var regex = new Regex(Regex.Escape(namePart));
                columnName = regex.Replace(columnName, string.Empty, 1);

                for (int i = 1; i < namePart.Length; i++)
                {
                    if (i == namePart.Count() - 1 || namePart[i + 1].IsVowel())
                    {
                        int symbolsToTake = i == namePart.Count() - 1 ? i+1 : i+2;
                        res += namePart.Substring(0, symbolsToTake).ToUpper();
                        break;
                    }
                }
            }
            
            return res;
        }
    }
}
