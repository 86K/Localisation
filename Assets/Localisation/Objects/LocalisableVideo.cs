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
    using UnityEngine.Video;

    [Serializable]
    public class LocalisableVideo {
        [Serializable]
        public class LocalisedVideo {
            [SerializeField] internal SystemLanguage Name;
            [SerializeField] internal VideoClip Video;

            public LocalisedVideo(SystemLanguage name) {
                Name = name;
            }
        }

        [SerializeField]
        public List<LocalisedVideo> LocalisedVideos = new List<LocalisedVideo> {
        new LocalisedVideo(SystemLanguage.ChineseSimplified),
        new LocalisedVideo(SystemLanguage.English),
    };

        public VideoClip GetVideoClip(string name) {
            foreach(LocalisedVideo localisedVideo in LocalisedVideos) {
                if(localisedVideo.Name.ToString() == name) {
                    return localisedVideo.Video;
                }
            }
            return LocalisedVideos[0].Video;
        }

        public VideoClip GetVideoClip(SystemLanguage name) {
            foreach(LocalisedVideo localisedVideo in LocalisedVideos) {
                if(localisedVideo.Name == name) {
                    return localisedVideo.Video;
                }
            }
            return LocalisedVideos[0].Video;
        }
    }
}