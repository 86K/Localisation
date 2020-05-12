/*
*R0-V1.0
*Modify Date:2020-04-30
*Modifier:ZoJet
*/

namespace GameFramework.Localisation {
    using System.Diagnostics;
    using UnityEngine;

    public class BaseMessage : MonoBehaviour {
        public enum SendModeType { SendToAll, SendToFirst }

        public string Name;
        public SendModeType SendMode;

#if UNITY_EDITOR
        public bool DontShowInEditorLogInternal;         // only needed for editor mode.
#endif

        public BaseMessage() {
            Name = GetType().Name;
            SendMode = SendModeType.SendToAll;
        }


        /// <summary>
        /// Hide this message so that it isn't displayed in the editor logs. (Editor only method)
        /// </summary>
        /// Use this method rather than setting the property so that it will be easily compiled out in non editor mode.
        [Conditional("UNITY_EDITOR")]
        public void DontShowInEditorLog() {
#if UNITY_EDITOR
            DontShowInEditorLogInternal = true;
#endif
        }
    }
}