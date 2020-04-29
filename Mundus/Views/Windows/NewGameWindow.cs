using System;
using Gtk;
using Mundus.Service;

namespace Mundus.Views.Windows {
    public partial class NewGameWindow : Gtk.Window {
        public NewGameWindow() : base( Gtk.WindowType.Toplevel ) {
            this.Build();
        }

        private void OnDeleteEvent(object sender, DeleteEventArgs a) {
            this.OnBtnBackClicked(this, null);
            a.RetVal = true;
        }

        private void OnBtnBackClicked(object sender, EventArgs e) {
            WindowController.ShowMainWindow(this);
        }

        /// <summary>
        /// You can choose your Map size only in creative, it is predetermined by screen & inventory size in survival.
        /// </summary>

        private void OnRbCreativeToggled(object sender, EventArgs e) {
            if (rbCreative.Active) {
                rbMSmall.Sensitive = true;
                rbMMedium.Sensitive = true;
                rbMLarge.Sensitive = true;
            } else {
                rbMSmall.Sensitive = false;
                rbMMedium.Sensitive = false;
                rbMLarge.Sensitive = false;
                this.SetMapSize(); //in case (in creative) you selected screen & inventory and map sizes that are invalid in survival
            }
        }

        public void SetDefaults() {
            rbSurvival.Active = true;
            rbEasy.Active = true;
            rbSmall.Active = true;
            SetMapSize();

            rbMSmall.Sensitive = false;
            rbMMedium.Sensitive = false;
            rbMLarge.Sensitive = false;
        }

        //Automatically set map sizes from screen & inventory size only in survival mode
        private void OnRbSmallToggled(object sender, EventArgs e) {
            if (rbSurvival.Active) {
                this.SetMapSize();
            }
        }
        private void OnRbMediumToggled(object sender, EventArgs e) {
            if (rbSurvival.Active) {
                this.SetMapSize();
            }
        }
        private void OnRbLargeToggled(object sender, EventArgs e) {
            if (rbSurvival.Active) {
                this.SetMapSize();
            }
        }

        //Sets map size from screen & inventory size
        private void SetMapSize() {
            if (rbSmall.Active) {
                rbMLarge.Active = true;
            } 
            else if (rbMedium.Active) {
                rbMMedium.Active = true;
            } 
            else if (rbLarge.Active) {
                rbMSmall.Active = true;
            }
        }

        private void OnBtnGenerateClicked(object sender, EventArgs e) {
            //TODO: save settings somewhere

            this.Hide();
            this.ScreenInventorySetup();
            this.GenerateMap();
            GameGenerator.GameWindowInitialize();
        }

        // Calls GameGenerator to generate the map depending on the selected map size button
        private void GenerateMap() {
            string size;
            if (rbMSmall.Active) {
                size = "small";
            }
            else if (rbMMedium.Active) {
                size = "medium";
            }
            else if (rbMLarge.Active) {
                size = "large";
            }
            else {
                throw new ArgumentException("No map size was selected");
            }
            GameGenerator.GenerateMap(size);
        }

        // Does the inital steps that are required by all windows upon game generation
        private void ScreenInventorySetup() {
            string gameWindow;

            if (rbSmall.Active) {
                gameWindow = "small";
            }
            else if (rbMedium.Active) {
                gameWindow = "medium";
            } 
            else if (rbLarge.Active) {
                gameWindow = "large";
            } 
            else {
                throw new ArgumentException("No screen & inventory size was selected");
            }

            GameGenerator.GameWindowSizeSetup(gameWindow);
        }

        protected void OnRbPeacefulToggled(object sender, EventArgs e) {
            GameGenerator.SetDifficulty("peaceful");
        }

        protected void OnRbEasyToggled(object sender, EventArgs e) {
            GameGenerator.SetDifficulty("easy");
        }

        protected void OnRbNormalToggled(object sender, EventArgs e) {
            GameGenerator.SetDifficulty("normal");
        }

        protected void OnRbHardToggled(object sender, EventArgs e) {
            GameGenerator.SetDifficulty("hard");
        }

        protected void OnRbInsaneToggled(object sender, EventArgs e) {
            GameGenerator.SetDifficulty("insane");
        }
    }
}
