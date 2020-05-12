/*
*R0-V1.0
*Modify Date:2020-04-30
*Modifier:ZoJet
*/

namespace GameFramework.Localisation {
    using UnityEditor;

    [CustomPropertyDrawer(typeof(LocalisableImage))]
    public class LocaliseImageDrawer : LocaliseDrawer {
        internal override string _localisedItemPropertyName {
            get {
                return "LocalisedImages";
            }
        }

        internal override string _localisedItemTypeName {
            get {
                return "Sprite";
            }
        }

        internal override string _rootPropertyName {
            get {
                return "Localisation Images";
            }
        }

        internal override string _addLocalisedItemContent {
            get {
                return "Add Localition Image";
            }
        }
    }
}