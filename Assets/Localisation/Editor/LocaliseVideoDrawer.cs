﻿/*
*R0-V1.0
*Modify Date:2020-05-05
*Modifier:ZoJet
*Description:
*/

namespace GameFramework.Localisation {
    using UnityEditor;

    [CustomPropertyDrawer(typeof(LocalisableVideo))]
    public class LocaliseVideoDrawer : LocaliseDrawer {

        internal override string _localisedItemPropertyName {
            get {
                return "LocalisedVideos";
            }
        }

        internal override string _localisedItemTypeName {
            get {
                return "Video";
            }
        }

        internal override string _rootPropertyName {
            get {
                return "Localisation Videos";
            }
        }

        internal override string _addLocalisedItemContent {
            get {
                return "Add Localistion Video";
            }
        }
    }
}