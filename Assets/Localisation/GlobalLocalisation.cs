/*
*R0-V1.0
*Modify Date:2020-04-30
*Modifier:ZoJet
*/

namespace GameFramework.Localisation {
    using System.Collections.Generic;
    using UnityEngine;

    public class GlobalLocalisation {
        public static readonly Messenger _messenger = new Messenger();

        //Filter out unsupported languages.
        private static List<SystemLanguage> SupportedLanguages = new List<SystemLanguage> {
        SystemLanguage.ChineseSimplified,
        SystemLanguage.English,
    };

        public static string Language {
            get {
                return _language;
            }
            set {
                var oldLanguage = _language;
                if(oldLanguage == value) {
                    return;
                }

                if(!SupportedLanguages.Exists(a => a.ToString().Equals(value))) {
                    Debug.LogFormat("Language: {0} not exist", value.ToString());
                    return;
                }

                _language = value;
                PreferencesFactory.SetString("Language", Language, false);
            }
        }
        static string _language;

        public static void Load() {
            _language = null;

            var prefsLanguage = PreferencesFactory.GetString("Language", useSecurePrefs: false);
            Language = prefsLanguage;
        }

        public static bool SafeAddListener<T>(Messenger.MessageListenerDelegate handler) where T : BaseMessage {
            if(_messenger == null)
                return false;
            _messenger.AddListener<T>(handler);
            return true;
        }

        public static bool SafeRemoveListener<T>(Messenger.MessageListenerDelegate handler) where T : BaseMessage {
            if(_messenger == null)
                return false;
            _messenger.RemoveListener<T>(handler);
            return true;
        }
    }
}
