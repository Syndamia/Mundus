namespace Mundus.Service 
{
    using Mundus.Data;

    public static class GameEventLogController 
    {
        public static void AddMessage(string logMessage) 
        {
            DataBaseContexts.GELContext.AddMessage(logMessage);
        }

        public static string GetMessagage(int index) 
        {
            return (index >= 0 && index < GetCount()) ? DataBaseContexts.GELContext.GetMessage(index + 1) : null;
        }

        public static int GetCount() 
        {
            return DataBaseContexts.GELContext.GetCount();
        }
    }
}