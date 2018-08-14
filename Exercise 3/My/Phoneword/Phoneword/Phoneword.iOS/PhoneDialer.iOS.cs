// PhoneDialer.iOS.cs

using System.Threading.Tasks;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Phoneword.Core;

[assembly: Dependency(typeof(Phoneword.iOS.PhoneDialer))]

namespace Phoneword.iOS
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
			return Task.FromResult(
				UIApplication.SharedApplication.OpenUrl(
				    new NSUrl("tel:" + number))
			);
		}
	}
}
