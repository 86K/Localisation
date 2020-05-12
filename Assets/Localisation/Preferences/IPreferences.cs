namespace GameFramework.Localisation {
    using UnityEngine;

    public interface IPreferences {
        /// <summary>
        /// Flag indicating whether the current factory implementation supports secure prefs.
        /// </summary>
        bool SupportsSecurePrefs { get; }

        /// <summary>
        /// Flag indicating whether to use secure prefs.
        /// </summary>
        bool UseSecurePrefs { get; set; }

        /// <summary>
        /// Flag indicating whether to migrate unsecure values automatically (only when UseSecurePrefs is set).
        /// </summary>
        bool AutoConvertUnsecurePrefs { get; set; }

        /// <summary>
        /// The pass phrase that should be used. Be sure to override this with your own value.
        /// </summary>
        string PassPhrase { set; }

        /// <summary>
        /// For the similar method in PlayerPrefs.
        /// </summary>
        void DeleteAll();

        /// <summary>
        /// For the similar method in PlayerPrefs.
        /// </summary>
        void DeleteKey(string key, bool? useSecurePrefs = null);

        /// <summary>
        /// For the similar method in PlayerPrefs.
        /// </summary>
        float GetFloat(string key, float defaultValue = 0.0f, bool? useSecurePrefs = null);

        /// <summary>
        /// For the similar method in PlayerPrefs.
        /// </summary>
        int GetInt(string key, int defaultValue = 0, bool? useSecurePrefs = null);

        /// <summary>
        /// For the similar method in PlayerPrefs.
        /// </summary>
        string GetString(string key, string defaultValue = "", bool? useSecurePrefs = null);

        /// <summary>
        /// Get boolean preferences
        /// </summary>
        bool GetBool(string key, bool defaultValue = false, bool? useSecurePrefs = null);

        /// <summary>
        /// Get Vector2 preferences
        /// </summary>
        Vector2? GetVector2(string key, Vector2? defaultValue = null, bool? useSecurePrefs = null);

        /// <summary>
        /// Get Vector3 preferences
        /// </summary>
        Vector3? GetVector3(string key, Vector3? defaultValue = null, bool? useSecurePrefs = null);

        /// <summary>
        /// Get Color preferences
        /// </summary>
        Color? GetColor(string key, Color? defaultValue = null, bool? useSecurePrefs = null);

        /// <summary>
        /// For the similar method in PlayerPrefs.
        /// </summary>
        bool HasKey(string key, bool? useSecurePrefs = null);

        /// <summary>
        /// For the similar method in PlayerPrefs.
        /// </summary>
        void Save();

        /// <summary>
        /// For the similar method in PlayerPrefs.
        /// </summary>
        void SetFloat(string key, float value, bool? useSecurePrefs = null);

        /// <summary>
        /// For the similar method in PlayerPrefs.
        /// </summary>
        void SetInt(string key, int value, bool? useSecurePrefs = null);

        /// <summary>
        /// For the similar method in PlayerPrefs.
        /// </summary>
        void SetString(string key, string value, bool? useSecurePrefs = null);

        /// <summary>
        /// Set boolean preferences
        /// </summary>
        void SetBool(string key, bool value, bool? useSecurePrefs = null);

        /// <summary>
        /// Set Vector2 preferences
        /// </summary>
        void SetVector2(string key, Vector2 value, bool? useSecurePrefs = null);

        /// <summary>
        /// Set Vector3 preferences
        /// </summary>
        void SetVector3(string key, Vector3 value, bool? useSecurePrefs = null);

        /// <summary>
        /// Set Color preferences
        /// </summary>
        void SetColor(string key, Color value, bool? useSecurePrefs = null);
    }
}