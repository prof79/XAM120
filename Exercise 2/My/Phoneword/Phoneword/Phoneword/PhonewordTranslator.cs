// PhonewordTranslator.cs

using System;
using System.Collections.Generic;
using System.Text;

namespace Phoneword
{
    public static class PhonewordTranslator
    {
        #region Public Methods

        public static string ToNumber(this string raw)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Helper Methods

        private static bool Contains(this string keyString, char c)
        {
            throw new NotImplementedException();
        }

        private static int? TranslateToNumber(this char c)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Fields

        /// <summary>
        /// Gets an array of letter groups usually being used on
        /// common phone devices.
        /// </summary>
        private static readonly string[] digits =
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
