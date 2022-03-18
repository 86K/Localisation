namespace GameFramework.Localisation {
    using UnityEngine;

    public abstract class RunOnMessage<T> : MonoBehaviour where T : BaseMessage {
        protected RunOnMessageAttribute.SubscribeTypeOptions SubscribeType = RunOnMessageAttribute.SubscribeTypeOptions.EnableDisable;
        bool _isListenerAdded = false;

        protected RunOnMessage() {
#if NETFX_CORE
            var runOnMessageAttribute = typeof(RunOnMessage<T>).GetTypeInfo().GetCustomAttribute<RunOnMessageAttribute>();
#else
            var runOnMessageAttribute = (RunOnMessageAttribute)System.Attribute.GetCustomAttribute(typeof(RunOnMessage<T>), typeof(RunOnMessageAttribute));
#endif
            if(runOnMessageAttribute != null)
                SubscribeType = runOnMessageAttribute.SubscribeType;
        }

        public virtual void Awake() {
            if(SubscribeType == RunOnMessageAttribute.SubscribeTypeOptions.AwakeDestroy) {
                _isListenerAdded = GlobalLocalisation.SafeAddListener<T>(MessageListener);
            }
        }

        public virtual void Start() {
            if(SubscribeType == RunOnMessageAttribute.SubscribeTypeOptions.StartDestroy) {
                _isListenerAdded = GlobalLocalisation.SafeAddListener<T>(MessageListener);
            }
        }

        public virtual void OnEnable() {
            if(SubscribeType == RunOnMessageAttribute.SubscribeTypeOptions.EnableDisable) {
                _isListenerAdded = GlobalLocalisation.SafeAddListener<T>(MessageListener);
            }
        }

        public virtual void OnDisable() {
            if(SubscribeType == RunOnMessageAttribute.SubscribeTypeOptions.EnableDisable && _isListenerAdded) {
                GlobalLocalisation.SafeRemoveListener<T>(MessageListener);
            }
        }


        public virtual void OnDestroy() {
            if((SubscribeType == RunOnMessageAttribute.SubscribeTypeOptions.AwakeDestroy ||
                SubscribeType == RunOnMessageAttribute.SubscribeTypeOptions.StartDestroy) && _isListenerAdded) {
                GlobalLocalisation.SafeRemoveListener<T>(MessageListener);
            }
        }

        bool MessageListener(BaseMessage message) {
            return RunMethod(message as T);
        }

        public abstract bool RunMethod(T message);
    }
}