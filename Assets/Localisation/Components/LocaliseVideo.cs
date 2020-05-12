/*
*R0-V1.0
*Modify Date:2020-05-05
*Modifier:ZoJet
*Description:
*/

namespace GameFramework.Localisation {
    using UnityEngine;
    using UnityEngine.Video;

    [AddComponentMenu("Localisation/Localise Video")]
    public class LocaliseVideo : RunOnMessage<LocalisationChangedMessage> {
        public LocalisableVideo _localisableVideo;

        VideoPlayer _videoPlayer;

        public override void Awake() {
            _videoPlayer = GetComponent<VideoPlayer>();

            OnLocalise();
            base.Awake();
        }

        void OnLocalise() {
            _videoPlayer.clip = _localisableVideo.GetVideoClip(GlobalLocalisation.Language);
        }

        public override System.Boolean RunMethod(LocalisationChangedMessage message) {
            throw new System.NotImplementedException();
        }
    }
}