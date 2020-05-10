using System;
using System.Collections.Generic;
using Mundus.Data;

namespace Mundus.Service {
    public static class LogController {
        public static void AddMessage(string logMessage) {
            DataBaseContext.GELContext.AddMessage(logMessage);
        }

        public static string GetMessagage(int index) {
            return (0 <= index && index < GetCount()) ? DataBaseContext.GELContext.GetMessage(index + 1) : null;
        }

        public static int GetCount() {
            return DataBaseContext.GELContext.GetCount();
        }
    }
}