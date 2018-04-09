// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace MyShop
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string NeedSyncReviewKey = "need_sync_review";
        private static readonly bool NeedSyncReviewDefault = false;

        private const string LastSyncKey = "last_sync";
        private static readonly DateTime LastSyncDefault = DateTime.Now.AddDays(-30);



        #endregion

#if DEBUG
        //always refresh in debug
        public static bool NeedsSync
        {
            get { return true; }
        }
#else
		public static bool NeedsSync
		{
			get { return LastSync < DateTime.Now.AddDays (-3); }
		}
#endif

        public static DateTime LastSync
        {
            get
            {
                return AppSettings.GetValueOrDefault(LastSyncKey, LastSyncDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LastSyncKey, value);
            }
        }

        public static bool NeedSyncReview
        {
            get
            {
                return AppSettings.GetValueOrDefault(NeedSyncReviewKey, NeedSyncReviewDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(NeedSyncReviewKey, value);
            }
        }

    }
}