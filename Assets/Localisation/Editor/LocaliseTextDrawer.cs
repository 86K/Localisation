/*
*R0-V1.0
*Modify Date:2020-04-30
*Modifier:ZoJet
*/

namespace GameFramework.Localisation {
    using UnityEditor;

    [CustomPropertyDrawer(typeof(LocalisableText))]
    public class LocaliseTextDrawer : LocaliseDrawer {
        internal override string _localisedItemPropertyName {
            get {
                return "LocalisedTexts";
            }
        }

        internal override string _localisedItemTypeName {
            get {
                return "String";
            }
        }

        internal override string _rootPropertyName {
            get {
                return "Localisation Texts";
            }
        }

        internal override string _addLocalisedItemContent {
            get {
                return "Add Localistion Text";
            }
        }
    }
}