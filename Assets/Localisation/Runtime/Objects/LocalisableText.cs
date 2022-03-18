namespace GameFramework.Localisation {
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class LocalisableText {
        [Serializable]
        public class LocalisedText {
            [SerializeField] internal SystemLanguage Name;
            [SerializeField] internal string String;

            public LocalisedText(SystemLanguage name) {
                Name = name;
            }
        }

        [SerializeField]
        public List<LocalisedText> LocalisedTexts = new List<LocalisedText> {
        new LocalisedText(SystemLanguage.ChineseSimplified),
        new LocalisedText(SystemLanguage.English),
    };

        public string GetString(string name) {
            foreach(LocalisedText localisedText in LocalisedTexts) {
                if(localisedText.Name.ToString() == name) {
                    return localisedText.String;
                }
            }
            return LocalisedTexts[0].String;
        }

        public string GetString(SystemLanguage name) {
            foreach(LocalisedText localisedText in LocalisedTexts) {
                if(localisedText.Name == name) {
                    return localisedText.String;
                }
            }
            return LocalisedTexts[0].String;
        }
    }
}