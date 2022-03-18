namespace GameFramework.Localisation {
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class LocalisableImage {
        [Serializable]
        public class LocalisedImage {
            [SerializeField] internal SystemLanguage Name;
            [SerializeField] internal Sprite Sprite;

            public LocalisedImage(SystemLanguage name) {
                Name = name;
            }
        }

        [SerializeField] List<LocalisedImage> LocalisedImages = new List<LocalisedImage> {
        new LocalisedImage(SystemLanguage.ChineseSimplified),
        new LocalisedImage(SystemLanguage.English),
    };

        public Sprite GetSprite(string name) {
            foreach(LocalisedImage localisedImage in LocalisedImages) {
                if(localisedImage.Name.ToString() == name) {
                    return localisedImage.Sprite;
                }
            }

            return LocalisedImages[0].Sprite;
        }

        public Sprite GetSprite(SystemLanguage name) {
            foreach(LocalisedImage localisedImage in LocalisedImages) {
                if(localisedImage.Name == name) {
                    return localisedImage.Sprite;
                }
            }
            return LocalisedImages[0].Sprite;
        }
    }
}