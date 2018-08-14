// PhoneDialer.Droid.cs

using System.Linq;
using System.Threading.Tasks;
using Android.Content;
using Android.Telephony;
using Xamarin.Forms;
using Uri = Android.Net.Uri;
using Phoneword.Core;

[assembly: Dependency(typeof(Phoneword.Droid.PhoneDialer))]

namespace Phoneword.Droid
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
            var context = Android.App.Application.Context;

            if (context != null)
            {
                var intent = new Intent(Intent.ActionCall);

                intent.SetData(Uri.Parse("tel:" + number));

                if (IsIntentAvailable(context, intent))
                {
                    context.StartActivity(intent);

                    return Task.FromResult(true);
                }
            }

            return Task.FromResult(false);
        }

        /// <summary>
        /// Checks if an intent can be handled.
        /// </summary>
        /// <param name="context">
        /// The context of the Android application.
        /// </param>
        /// <param name="intent">
        /// The intent to verify.
        /// </param>
        public static bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;

            var list = packageManager.QueryIntentServices(intent, 0)
                .Union(packageManager.QueryIntentActivities(intent, 0));

            if (list.Any())
            {
                return true;
            }

            var mgr = TelephonyManager.FromContext(context);

            return mgr.PhoneType != PhoneType.None;
        }
    }
}
