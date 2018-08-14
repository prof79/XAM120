// PhoneDialer.UWP.cs

using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Xamarin.Forms;
using Phoneword.Core;

[assembly: Dependency(typeof(Phoneword.UWP.PhoneDialer))]

namespace Phoneword.UWP
{
    public class PhoneDialer : IDialer
    {
        /// <summary>
        /// Dial the phone.
        /// </summary>
        /// <param name="number">
        /// The phone number to dial.
        /// </param>
        public Task<bool> DialAsync(string number)
        {
            if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.Calls.CallsPhoneContract", 1, 0))
            {
                Windows
                    .ApplicationModel
                    .Calls
                    .PhoneCallManager
                    .ShowPhoneCallUI(number, "Phoneword");

                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
