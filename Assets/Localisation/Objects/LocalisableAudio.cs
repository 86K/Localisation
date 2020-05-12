/*
*R0-V1.0
*Modify Date:2020-05-05
*Modifier:ZoJet
*Description:
*/

namespace GameFramework.Localisation {
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class LocalisableAudio {
        [Serializable]
        public class LocalisedAudio {
            [SerializeField] internal SystemLanguage Name;
            [SerializeField] internal AudioClip Audio;

            public LocalisedAudio(SystemLanguage name) {
                Name = name;
            }
        }

        [SerializeField]
        public List<LocalisedAudio> LocalisedAudios = new List<LocalisedAudio> {
        new LocalisedAudio(SystemLanguage.ChineseSimplified),
        new LocalisedAudio(SystemLanguage.English),
    };

        public AudioClip GetAudioClip(string name) {
            foreach(LocalisedAudio localisedAudio in LocalisedAudios) {
                if(localisedAudio.Name.ToString() == name) {
                    return localisedAudio.Audio;
                }
            }
            return LocalisedAudios[0].Audio;
        }

        public AudioClip GetAudioClip(SystemLanguage name) {
            foreach(LocalisedAudio localisedAudio in LocalisedAudios) {
                if(localisedAudio.Name == name) {
                    return localisedAudio.Audio;
                }
            }
            return LocalisedAudios[0].Audio;
        }
    }
}