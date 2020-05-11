using System;
using System.Collections.Generic;
using Mundus.Data;

namespace Mundus.Service {
    public static class GameEventLogController {
        public static void AddMessage(string logMessage) {
            DataBaseContexts.GELContext.AddMessage(logMessage);
        }

        public static string GetMessagage(int index) {
            return (0 <= index && index < GetCount()) ? DataBaseContexts.GELContext.GetMessage(index + 1) : null;
        }

        public static int GetCount() {
            return DataBaseContexts.GELContext.GetCount();
        }
    }
}