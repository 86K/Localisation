/*
*R0-V1.0
*Modify Date:2020-05-05
*Modifier:ZoJet
*Description:
*/

namespace GameFramework.Localisation {
    using UnityEditor;

    [CustomPropertyDrawer(typeof(LocalisableAudio))]
    public class LocaliseAudioDrawer : LocaliseDrawer {
        internal override string _localisedItemPropertyName {
            get {
                return "LocalisedAudios";
            }
        }

        internal override string _localisedItemTypeName {
            get {
                return "Audio";
            }
        }

        internal override string _rootPropertyName {
            get {
                return "Localisation Audios";
            }
        }

        internal override string _addLocalisedItemContent {
            get {
                return "Add Localistion Audio";
            }
        }
    }
}