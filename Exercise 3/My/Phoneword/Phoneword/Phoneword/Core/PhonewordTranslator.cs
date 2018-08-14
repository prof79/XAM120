// PhonewordTranslator.cs

using System;
using System.Text;

namespace Phoneword.Core
{
    public static class PhonewordTranslator
    {
        #region Public Methods

        public static string ToNumber(this string raw)
        {
            if (String.IsNullOrWhiteSpace(raw))
            {
                return null;
            }

            raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();

            foreach (var ch in raw)
            {
                if (" -0123456789".Contains(ch))
                {
                    newNumber.Append(ch);
                }
                else
                {
                    var result = TranslateToNumber(ch);

                    if (result != null)
                    {
                        newNumber.Append(result);
                    }
                    else
                    {
                        // Bad character?
                        return null;
                    }
                }
            }

            return newNumber.ToString();
        }

        #endregion

        #region Private Helper Methods

        private static bool Contains(this string keyString, char ch)
            => keyString.IndexOf(ch) >= 0;

        private static int? TranslateToNumber(this char ch)
        {
            for (var keyPadCharSetIndex = 0; keyPadCharSetIndex < keyPadCharSets.Length; ++keyPadCharSetIndex)
            {
                // Character argument has already been capitalized.
                if (keyPadCharSets[keyPadCharSetIndex].Contains(ch))
                {
                    // Characters start at key "2", see: https://en.wikipedia.org/wiki/Telephone_keypad
                    return keyPadCharSetIndex + 2;
                }
            }

            return null;
        }

        #endregion

        #region Fields

        /// <summary>
        /// Gets an array of letter groups assigned to number keys
        /// usually being used on common phone device keypads.
        /// </summary>
        private static readonly string[] keyPadCharSets =
        {
            "ABC",
            "DEF",
            "GHI",
            "JKL",
            "MNO",
            "PQRS",
            "TUV",
            "WXYZ"
        };

        #endregion
    }
}
