namespace GameFramework.Localisation {
    using UnityEngine;

    [AddComponentMenu("Localisation/Localise Audio")]
    public class LocaliseAudio : RunOnMessage<LocalisationChangedMessage> {
        public LocalisableAudio _localisableAudio;

        AudioSource _audioSource;

        public override void Awake() {
            _audioSource = GetComponent<AudioSource>();

            OnLocalise();
            base.Awake();
        }

        void OnLocalise() {
            _audioSource.clip = _localisableAudio.GetAudioClip(GlobalLocalisation.Language);
        }

        public override bool RunMethod(LocalisationChangedMessage message) {
            throw new System.NotImplementedException();
        }
    }
}