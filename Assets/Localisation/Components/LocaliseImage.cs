/*
*R0-V1.0
*Modify Date:2020-04-30
*Modifier:ZoJet
*/

namespace GameFramework.Localisation {
    using UnityEngine;
    using UnityEngine.UI;

    [AddComponentMenu("Localisation/Localise Image")]
    public class LocaliseImage : RunOnMessage<LocalisationChangedMessage> {
        public LocalisableImage _localisableImage;

        Image _image;

        public override void Awake() {
            _image = GetComponent<Image>();
            OnLocalise();

            base.Awake();
        }

        void OnLocalise() {
            _image.sprite = _localisableImage.GetSprite(GlobalLocalisation.Language);
        }

        public override bool RunMethod(LocalisationChangedMessage message) {
            OnLocalise();
            return true;
        }
    }
}