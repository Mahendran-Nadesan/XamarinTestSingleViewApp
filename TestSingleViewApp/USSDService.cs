using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Preferences;

using TestSingleViewApp;

namespace TestSingleViewApp
{
    class USSDService : Service

    {
        public static string TAG = "USSDNetworkService";
        private string msgUSSDRunning = null;
        private bool change = false;
        public static char mRetVal;
        private static bool mActive = false;

        private Android.Telephony.
        public override IBinder OnBind(Intent intent)
        {
            ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(BaseContext);
            var editor = preferences.Edit();
            editor.PutBoolean(TAG, true);
            editor.Commit();
            msgUSSDRunning = GetString(TestSingleViewApp.Resource.String.result);
            return mBinder;
        }

    }
}