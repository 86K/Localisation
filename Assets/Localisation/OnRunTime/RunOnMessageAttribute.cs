/*
*R0-V1.0
*Modify Date:2020-04-30
*Modifier:ZoJet
*/

namespace GameFramework.Localisation {
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class RunOnMessageAttribute : System.Attribute {
        /// <summary>
        /// List of options for when RunOnMessage should subscribe / unsubscribe for messages.
        /// </summary>
        public enum SubscribeTypeOptions { AwakeDestroy, StartDestroy, EnableDisable }

        /// <summary>
        /// How RunOnMessage should subscribe / unsubscribe for messages.
        /// </summary>
        public SubscribeTypeOptions SubscribeType { get; set; }

        public RunOnMessageAttribute(SubscribeTypeOptions subscribeType) {
            SubscribeType = subscribeType;
        }
    }
}