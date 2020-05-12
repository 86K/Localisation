using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace GameFramework.Localisation {
    public enum LogEntryType { AddListener, RemoveListener, Send }

    [System.Serializable]
    public class MessageLog : ScriptableObject {
        public List<MessageLogEntry> LogEntries = new List<MessageLogEntry>();
        public bool ClearOnPlay = true;
        public System.Action LogEntryAdded;

        public Dictionary<string, MessageStatistics> Statistics = new Dictionary<string, MessageStatistics>();

        public static MessageLog Create() {
            var messageLog = FindObjectOfType<MessageLog>() ?? CreateInstance<MessageLog>();

            return messageLog;
        }

        void OnEnable() {
            hideFlags = HideFlags.HideAndDontSave;
            foreach(var messageLogEntry in LogEntries)
                UpdateStatistics(messageLogEntry);
        }


        public void AddLogEntry(MessageLogEntry messageLogEntry) {
            LogEntries.Add(messageLogEntry);
            UpdateStatistics(messageLogEntry);
            if(LogEntryAdded != null)
                LogEntryAdded();
        }


        void UpdateStatistics(MessageLogEntry messageLogEntry) {
            MessageStatistics count;
            var isExisting = Statistics.TryGetValue(messageLogEntry.MessageType, out count);
            if(!isExisting)
                count = new MessageStatistics();

            if(messageLogEntry.LogEntryType == LogEntryType.Send)
                count.MessageCount++;
            else if(messageLogEntry.LogEntryType == LogEntryType.AddListener)
                count.HandlerCount++;
            else if(messageLogEntry.LogEntryType == LogEntryType.RemoveListener)
                count.HandlerCount--;

            if(isExisting)
                Statistics[messageLogEntry.MessageType] = count;
            else
                Statistics.Add(messageLogEntry.MessageType, count);
        }


        public void Clear() {
            LogEntries.Clear();
        }
    }

    [System.Serializable]
    public class MessageLogEntry {
        public LogEntryType LogEntryType;
        public System.DateTime Time;
        public string MessageType;
        public string Contents;
        public string Message;
        public StackTrace StackTrace;

        public MessageLogEntry() { }

        public MessageLogEntry(LogEntryType logEntryType, string messageType, string contents = null, string message = null, StackTrace stackTrace = null) {
            LogEntryType = logEntryType;
            Time = System.DateTime.Now;
            MessageType = messageType;
            Contents = contents;
            Message = message;
            StackTrace = stackTrace;
        }
    }

    public class MessageStatistics {
        public int MessageCount;
        public int HandlerCount;
    }

    public static class MessageLogHandler {
        public static MessageLog MessageLog { get; set; }

        [Conditional("UNITY_EDITOR")]
        public static void AddLogEntry(LogEntryType logEntryType, string messageType, string contents = null, string message = null) {
            if(MessageLog != null) {
                MessageLog.AddLogEntry(new MessageLogEntry(logEntryType, messageType, contents, message, new StackTrace(true)));
            }
        }
    }
}