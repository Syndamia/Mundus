namespace Mundus.Data.Dialogues 
{
    using Mundus.Views.Dialogs;

    /// <summary>
    /// Dialog Instances
    /// Stores and creates all needed dialogs
    /// </summary>
    public static class DI 
    {
        /// <summary>
        /// Gets the exit dialoge
        /// </summary>
        public static ExitDialog DExit { get; private set; }

        /// <summary>
        /// Creates all dialog instances
        /// </summary>
        public static void CreateInstances() 
        {
            DExit = new ExitDialog();

            HideAll();
        }

        /// <summary>
        /// Hides all dialogs
        /// Gtk opens all dialog (window) instances in the project automatically,
        /// so you need to manually hide them
        /// </summary>
        private static void HideAll() 
        {
            DExit.Hide();
        }
    }
}