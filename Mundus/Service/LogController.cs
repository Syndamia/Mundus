using System;
using System.Collections.Generic;
using Mundus.Data;

namespace Mundus.Service {
    public static class LogController {
        public static void Initialize() {
            Log.LogMessages = new List<string>();
        }

        public static void AddMessage(string logMessage) {
            Log.LogMessages.Add(logMessage);
        }

        public static string GetMessagage(int index) {
            return (0 <= index && index < GetCount()) ? Log.LogMessages[index] : null;
        }

        public static int GetCount() {
            return Log.LogMessages.Count;
        }
    }
}