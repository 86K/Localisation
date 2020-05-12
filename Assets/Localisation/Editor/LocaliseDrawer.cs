/*
*R0-V1.0
*Modify Date:2020-05-05
*Modifier:ZoJet
*Description:
*/

namespace GameFramework.Localisation {
    using UnityEditor;
    using UnityEngine;

    public abstract class LocaliseDrawer : PropertyDrawer {
        readonly float _propertyRowHeight = EditorGUIUtility.singleLineHeight + 2;

        internal abstract string _localisedItemPropertyName { get; }
        internal abstract string _localisedItemTypeName { get; }
        internal abstract string _rootPropertyName { get; }
        internal abstract string _addLocalisedItemContent { get; }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var localisedItemsProperty = property.FindPropertyRelative(_localisedItemPropertyName);

            var rowPosition = new Rect(position) {
                height = EditorGUIUtility.singleLineHeight
            };

            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.indentLevel += 1;

            property.isExpanded = EditorGUI.Foldout(rowPosition, property.isExpanded, _rootPropertyName);
            rowPosition.y += _propertyRowHeight;

            if(property.isExpanded) {
                if(localisedItemsProperty.arraySize > 0) {
                    for(var i = 0; i < localisedItemsProperty.arraySize - 1; i++) {
                        EditorGUI.indentLevel += 1;
                        var deleteLocalisationContent = new GUIContent("-");
                        var deleteButtonSize = EditorStyles.miniButtonLeft.CalcSize(deleteLocalisationContent);
                        var deleteButtonContentRect = new Rect(rowPosition) {
                            width = deleteButtonSize.x + 8f,
                        };
                        deleteButtonContentRect.x = deleteButtonContentRect.width + 8f;
                        if(GUI.Button(deleteButtonContentRect, deleteLocalisationContent, EditorStyles.miniButton)) {
                            localisedItemsProperty.DeleteArrayElementAtIndex(i);
                        }

                        var arrayProperty = localisedItemsProperty.GetArrayElementAtIndex(i);
                        var languageProperty = arrayProperty.FindPropertyRelative("Name");
                        var itemProperty = arrayProperty.FindPropertyRelative(_localisedItemTypeName);

                        var contentRect = new Rect(rowPosition) {
                            width = (rowPosition.width - 16f) / 2,
                        };
                        contentRect.x += deleteButtonContentRect.width / 2 + 5f;

                        EditorGUI.PropertyField(contentRect, languageProperty, GUIContent.none);
                        contentRect.x += contentRect.width - 25f;

                        EditorGUI.PropertyField(contentRect, itemProperty, GUIContent.none);
                        rowPosition.y += EditorGUIUtility.singleLineHeight + 2;

                        EditorGUI.indentLevel -= 1;
                    }
                }

                var addLocalisationContent = new GUIContent(_addLocalisedItemContent);
                var addButtonSize = EditorStyles.miniButton.CalcSize(addLocalisationContent);
                var addButtonContenRect = new Rect(rowPosition) {
                    width = addButtonSize.x + 10,
                    x = rowPosition.center.x - ((addButtonSize.x + 10) / 2)
                };
                if(GUI.Button(addButtonContenRect, addLocalisationContent, EditorStyles.miniButton)) {
                    localisedItemsProperty.arraySize++;
                }
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var localisedItemsProperty = property.FindPropertyRelative(_localisedItemPropertyName);
            if(property.isExpanded) {
                return (localisedItemsProperty.arraySize + 2) * _propertyRowHeight;
            } else {
                return EditorGUIUtility.singleLineHeight;
            }
        }
    }
}