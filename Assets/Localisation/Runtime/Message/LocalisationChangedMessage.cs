namespace GameFramework.Localisation {
    public class LocalisationChangedMessage : BaseMessage {
        public readonly string OldLocalisation;
        public readonly string NewLocalisation;

        public LocalisationChangedMessage(string newLocalisation, string oldLocalisation) {
            NewLocalisation = newLocalisation;
            OldLocalisation = oldLocalisation;
        }

        public override string ToString() {
            return string.Format("Old Localisation {0}, New Localisation {1}", OldLocalisation, NewLocalisation);
        }
    }
}