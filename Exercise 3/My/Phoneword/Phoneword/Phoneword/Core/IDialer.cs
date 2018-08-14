// IDialer.cs

using System.Threading.Tasks;

namespace Phoneword.Core
{
    public interface IDialer
    {
        #region Methods

        Task<bool> DialAsync(string number);

        #endregion
    }
}
