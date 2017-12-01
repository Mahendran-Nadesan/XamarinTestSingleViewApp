using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using Android.AccessibilityServices;
using Android.Widget;
using Android.Util;
using Java.Lang;
using Java.Util;

namespace TestSingleViewApp
{
    class USSDService2 : AccessibilityService
    // see https://stackoverflow.com/a/34132708/2953322
    {
        public static string TAG = "USSDNetworkService";

        public override void OnAccessibilityEvent(AccessibilityEvent e)
        {
            Log.Debug(TAG, "onAccessibilityEvent");

            AccessibilityNodeInfo source = e.Source;

            if (e.EventType == EventTypes.WindowStateChanged && ! e.ClassName.Contains("AlertDialog"))
            {
                return;
            }
            if (e.EventType == EventTypes.WindowContentChanged && (source == null || !source.ClassName.Equals("Android.Widget.TextView")))
            {
                return;
            }
            if (e.EventType == EventTypes.WindowContentChanged && System.String.IsNullOrEmpty(source.Text))
            {
                return;
            }

            ICharSequence eventText;

            if (e.EventType == EventTypes.WindowStateChanged)
            {
                eventText = (ICharSequence)e.Text;
            }
            else
            {
                eventText = (ICharSequence)Collections.SingletonList(source.Text);
            }

            string text = ProcessUSSDText(eventText);

        }

        private string ProcessUSSDText(ICharSequence eventText)
        {
            foreach (char s in eventText)
            {
                string text = s.ToString();
                
                if (true)
                {
                    return text;
                }
            }
            return null;
        }

        public override void OnInterrupt()
        {
            throw new NotImplementedException();
        }

        protected override void OnServiceConnected()
        {
            base.OnServiceConnected();
            Log.Debug(TAG, "onServiceConnected");
            AccessibilityServiceInfo info = new AccessibilityServiceInfo();
            info.Flags = AccessibilityServiceFlags.Default;
            info.PackageNames = new string[] { "com.android.phone" };
            info.EventTypes = EventTypes.WindowStateChanged | EventTypes.WindowsChanged;
            info.FeedbackType = Android.AccessibilityServices.FeedbackFlags.Generic;
            SetServiceInfo(info);
        }
    }
}