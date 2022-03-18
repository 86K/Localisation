namespace GameFramework.Localisation {
    using UnityEngine;

    public static class PreferencesFactory {
        /// <summary>
        /// Get the current IPreferences instance, setting it up if not already set.
        /// </summary>
        static IPreferences Instance {
            get {
#if PREFS_EDITOR
                if (_instance == null)
                    _instance = new PrefsEditorHandler();
#else
                if(_instance == null)
                    _instance = new PlayerPrefsHandler();
#endif
                return _instance;
            }
        }
        static IPreferences _instance;

        /// <summary>
        /// Flag indicating whether the current implementation supports secure prefs.
        /// </summary>
        public static bool SupportsSecurePrefs {
            get {
                return Instance.SupportsSecurePrefs;
            }
        }

        /// <summary>
        /// Flag indicating whether to use secure prefs.
        /// 
        /// Note: All prefs used through this interface must adhere to this flag unless overwritten by the individual Get/Set calls.
        /// </summary>
        public static bool UseSecurePrefs {
            get {
                return Instance.UseSecurePrefs;
            }
            set {
                Instance.UseSecurePrefs = value;
            }
        }

        /// <summary>
        /// Flag indicating whether to migrate unsecure values automatically (only when UseSecurePrefs is set).
        /// </summary>
        public static bool AutoConvertUnsecurePrefs {
            get {
                return Instance.AutoConvertUnsecurePrefs;
            }
            set {
                Instance.AutoConvertUnsecurePrefs = value;
            }
        }

        /// <summary>
        /// The pass phrase that should be used. Be sure to override this with your own value.
        /// </summary>
        public static string PassPhrase {
            set {
                Instance.PassPhrase = value;
            }
        }

        /// <summary>
        /// Factory method for the similar method in PlayerPrefs.
        /// </summary>
        public static void DeleteAll() {
            Instance.DeleteAll();
        }

        /// <summary>
        /// Factory method for the similar method in PlayerPrefs.
        /// </summary>
        public static void DeleteKey(string key) {
            Instance.DeleteKey(key);
        }

        /// <summary>
        /// Factory method for the similar method in PlayerPrefs.
        /// </summary>
        /// This method adds the optional useSecurePrefs parameter which will override the global encryption setting
        /// (assuming that the backend implementation supports this functionality).
        public static float GetFloat(string key, float defaultValue = 0.0f, bool? useSecurePrefs = null) {
            return Instance.GetFloat(key, defaultValue, useSecurePrefs);
        }

        /// <summary>
        /// Factory method for the similar method in PlayerPrefs.
        /// </summary>
        /// This method adds the optional useSecurePrefs parameter which will override the global encryption setting
        /// (assuming that the backend implementation supports this functionality).
        public static int GetInt(string key, int defaultValue = 0, bool? useSecurePrefs = null) {
            return Instance.GetInt(key, defaultValue, useSecurePrefs);
        }

        /// <summary>
        /// Factory method for the similar method in PlayerPrefs.
        /// </summary>
        /// This method adds the optional useSecurePrefs parameter which will override the global encryption setting
        /// (assuming that the backend implementation supports this functionality).
        public static string GetString(string key, string defaultValue = "", bool? useSecurePrefs = null) {
            return Instance.GetString(key, defaultValue, useSecurePrefs);
        }

        /// <summary>
        /// Factory method for getting boolean preferences
        /// </summary>
        public static bool GetBool(string key, bool defaultValue = false, bool? useSecurePrefs = null) {
            return Instance.GetBool(key, defaultValue, useSecurePrefs);
        }

        /// <summary>
        /// Factory method for getting Vector2 preferences
        /// </summary>
        public static Vector2? GetVector2(string key, Vector2? defaultValue = null, bool? useSecurePrefs = null) {
            return Instance.GetVector2(key, defaultValue, useSecurePrefs);
        }

        /// <summary>
        /// Factory method for getting Vector3 preferences
        /// </summary>
        public static Vector3? GetVector3(string key, Vector3? defaultValue = null, bool? useSecurePrefs = null) {
            return Instance.GetVector3(key, defaultValue, useSecurePrefs);
        }

        /// <summary>
        /// Factory method for getting Color preferences
        /// </summary>
        public static Color? GetColor(string key, Color? defaultValue = null, bool? useSecurePrefs = null) {
            return Instance.GetColor(key, defaultValue, useSecurePrefs);
        }

        /// <summary>
        /// Factory method for the similar method in PlayerPrefs.
        /// </summary>
        public static bool HasKey(string key) {
            return Instance.HasKey(key);
        }

        /// <summary>
        /// Factory method for the similar method in PlayerPrefs.
        /// </summary>
        public static void Save() {
            Instance.Save();
        }

        /// <summary>
        /// Factory method for the similar method in PlayerPrefs.
        /// </summary>
        /// This method adds the optional useSecurePrefs parameter which will override the global encryption setting
        /// (assuming that the backend implementation supports this functionality).
        public static void SetFloat(string key, float value, bool? useSecurePrefs = null) {
            Instance.SetFloat(key, value, useSecurePrefs);
        }

        /// <summary>
        /// Factory method for the similar method in PlayerPrefs.
        /// </summary>
        /// This method adds the optional useSecurePrefs parameter which will override the global encryption setting
        /// (assuming that the backend implementation supports this functionality).
        public static void SetInt(string key, int value, bool? useSecurePrefs = null) {
            Instance.SetInt(key, value, useSecurePrefs);
        }

        /// <summary>
        /// Factory method for the similar method in PlayerPrefs.
        /// </summary>
        /// This method adds the optional useSecurePrefs parameter which will override the global encryption setting
        /// (assuming that the backend implementation supports this functionality).
        public static void SetString(string key, string value, bool? useSecurePrefs = null) {
            Instance.SetString(key, value, useSecurePrefs);
        }

        /// <summary>
        /// Factory method for setting boolean preferences
        /// </summary>
        public static void SetBool(string key, bool value, bool? useSecurePrefs = null) {
            Instance.SetBool(key, value, useSecurePrefs);
        }

        /// <summary>
        /// Factory method for setting Vector2 preferences
        /// </summary>
        public static void SetVector2(string key, Vector2 value, bool? useSecurePrefs = null) {
            Instance.SetVector2(key, value, useSecurePrefs);
        }

        /// <summary>
        /// Factory method for setting Vector3 preferences
        /// </summary>
        public static void SetVector3(string key, Vector3 value, bool? useSecurePrefs = null) {
            Instance.SetVector3(key, value, useSecurePrefs);
        }

        /// <summary>
        /// Factory method for setting Color preferences
        /// </summary>
        public static void SetColor(string key, Color value, bool? useSecurePrefs = null) {
            Instance.SetColor(key, value, useSecurePrefs);
        }

        #region Flags
        /// <summary>
        /// Check for the presence of a given flag with teh given key and set if not set.
        /// </summary>
        /// You can also optionally specify a key that should already be set before this method will set the flag and return true.
        /// <param name="key"></param>
        /// <param name="setAfterKey"></param>
        /// <returns></returns>
        public static bool CheckAndSetFlag(string key, string setAfterKey = null) {
            if(string.IsNullOrEmpty(setAfterKey) || IsFlagSet(setAfterKey)) {
                if(!IsFlagSet(key)) {
                    SetFlag(key);
                    Save();

                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Returns whether a flag with the given key is set
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsFlagSet(string key) {
            return GetInt(key, 0) == 1;
        }


        /// <summary>
        /// Sets a flag with the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static void SetFlag(string key) {
            SetInt(key, 1);
        }


        /// <summary>
        /// Clear a given flag with the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static void ClearFlag(string key) {
            DeleteKey(key);
        }


        #endregion Flags

    }
}