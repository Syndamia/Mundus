using Mundus.Views.Dialogs;
using Gtk;

namespace Mundus.Data.Dialogues {
    public static class DI { //stands for Dialogue Instances
        public static ExitDialog DExit { get; private set; }

        public static void CreateInstances() {
            DExit = new ExitDialog();

            HideAll();
        }

        //Gtk opens all dialog (window) instances in the project automatically, unless they are hidden
        private static void HideAll() {
            DExit.Hide();
        }
    }
}
