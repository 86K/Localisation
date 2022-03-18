namespace GameFramework.Localisation {
    using UnityEngine;
    using UnityEngine.UI;

    [AddComponentMenu("Localisation/Localise Text")]
    public class LocaliseText : RunOnMessage<LocalisationChangedMessage> {
        public LocalisableText _localisableText;

        Text _text;

        public override void Awake() {
            _text = GetComponent<Text>();

            OnLocalise();
            base.Awake();
        }

        void OnLocalise() {
            _text.text = _localisableText.GetString(GlobalLocalisation.Language);
        }

        public override bool RunMethod(LocalisationChangedMessage message) {
            OnLocalise();
            return true;
        }
    }
}