using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace GameFramework.Localisation {
    public class Messenger {
        public delegate bool MessageListenerDelegate(BaseMessage message);

        readonly Dictionary<string, List<MessageListenerDelegate>> _listeners = new Dictionary<string, List<MessageListenerDelegate>>();

        readonly Queue<BaseMessage> _messageQueue = new Queue<BaseMessage>();

        public void ProcessQueue() {
            while(_messageQueue.Count > 0) {
                BaseMessage msg = _messageQueue.Dequeue();
                TriggerMessage(msg);
            }
        }

        public void AddListener(Type messageType, MessageListenerDelegate handler) {
            var messageName = messageType.Name;
            if(!_listeners.ContainsKey(messageName)) {
                _listeners.Add(messageName, new List<MessageListenerDelegate>());
            }

            List<MessageListenerDelegate> listenerList = _listeners[messageName];
            Assert.IsFalse(listenerList.Contains(handler), "You should not add the same listener multiple times for " + messageName);
            listenerList.Add(handler);

            MessageLogHandler.AddLogEntry(LogEntryType.AddListener, messageName);
        }

        public void RemoveListener(Type messageType, MessageListenerDelegate handler) {
            var messageName = messageType.Name;
            Assert.IsTrue(_listeners.ContainsKey(messageName), "You are trying to remove a handler that a message type that isn't registered for " + messageName);

            List<MessageListenerDelegate> listenerList = _listeners[messageName];
            Assert.IsTrue(listenerList.Contains(handler), "You are trying to remove a handler that isn't registered for " + messageName);
            listenerList.Remove(handler);

            MessageLogHandler.AddLogEntry(LogEntryType.RemoveListener, messageName);
        }

        public void AddListener<T>(MessageListenerDelegate handler) where T : BaseMessage {
            var messageType = typeof(T);
            AddListener(messageType, handler);
        }

        public void RemoveListener<T>(MessageListenerDelegate handler) where T : BaseMessage {
            var messageType = typeof(T);
            RemoveListener(messageType, handler);
        }

        public bool QueueMessage(BaseMessage msg) {
            // if no listeners then just return.
            if(!_listeners.ContainsKey(msg.Name)) {
                AddSendLogEntry(msg, "No listeners are setup. Discarding message!");
                return false;
            }

            _messageQueue.Enqueue(msg);
            return true;
        }

        public bool TriggerMessage(BaseMessage msg) {
            if(!_listeners.ContainsKey(msg.Name)) {
                AddSendLogEntry(msg, "No listeners are setup. Discarding message!");
                return false;
            }

            List<MessageListenerDelegate> listenerList = _listeners[msg.Name];
            for(int i = 0; i < listenerList.Count; ++i) {
                var sent = listenerList[i](msg);

                if(msg.SendMode == BaseMessage.SendModeType.SendToFirst && sent) {
                    AddSendLogEntry(msg, "Sent to first listener.");
                    return true;
                }
            }
            AddSendLogEntry(msg, "Sent to " + listenerList.Count + " listeners.");
            return true;
        }

        static void AddSendLogEntry(BaseMessage msg, string message) {
#if UNITY_EDITOR
            if(!msg.DontShowInEditorLogInternal)
                MessageLogHandler.AddLogEntry(LogEntryType.Send, msg.Name, msg.ToString(), message);
#endif
        }
    }
}