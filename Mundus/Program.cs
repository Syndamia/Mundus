namespace Mundus 
{
    using Gtk;
    using Mundus.Data;
    using Mundus.Service.Dialogs;
    using Mundus.Service.Tiles;
    using Mundus.Service.Windows;

    public static class MainClass 
    {
        public static void Main(string[] args) 
        {
            DataBaseContexts.CreateInstances();
            RecipeController.AddAllRecipes();
            Application.Init();

            // All windows and dialogues that are used by user (instances) are saved and created in WindowInstances.cs
            WI.CreateInstances();
            DI.CreateInstances();

            WI.WMain.Show();
            Application.Run();
        }
    }
}
