// IDialer.cs

using System.Threading.Tasks;

namespace Phoneword.Core
{
    public interface IDialer
    {
        #region Methods

        /// <summary>
        /// Dial the phone.
        /// </summary>
        /// <param name="number">
        /// The phone number to dial.
        /// </param>
        Task<bool> DialAsync(string number);

        #endregion
    }
}
