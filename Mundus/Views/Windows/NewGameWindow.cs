namespace Mundus.Views.Windows 
{
    using System;
    using Gtk;
    using Mundus.Service;
    using Mundus.Service.Windows;

    public partial class NewGameWindow : Gtk.Window 
    {
        public NewGameWindow() : base(Gtk.WindowType.Toplevel) 
        {
            this.Build();
        }

        public void SetDefaults() 
        {
            rbSurvival.Active = true;
            rbEasy.Active = true;
            rbSmall.Active = true;

            this.SetMapSize();

            rbMSmall.Sensitive = false;
            rbMMedium.Sensitive = false;
            rbMLarge.Sensitive = false;
        }

        /// <summary>
        /// Hides this screen, generates map and initializes the game window
        /// </summary>
        public void OnBtnGenerateClicked(object sender, EventArgs e) 
        {
            // TODO: save settings somewhere

            this.Hide();
            this.ScreenInventorySetup();
            this.GenerateMap();
            GameGenerator.GameWindowInitialize();
        }

        /// <summary>
        /// Every time the window is closed, this gets called (hides the window)
        /// </summary>
        protected void OnDeleteEvent(object sender, DeleteEventArgs a) 
        {
            this.OnBtnBackClicked(this, null);
            a.RetVal = true;
        }

        protected void OnBtnBackClicked(object sender, EventArgs e) 
        {
            WindowController.ShowMainWindow(this);
        }

        /// <summary>
        /// You can choose your Map size only in creative, it is predetermined by screen and inventory size in survival.
        /// </summary>
        protected void OnRbCreativeToggled(object sender, EventArgs e) 
        {
            if (this.rbCreative.Active) 
            {
                this.rbMSmall.Sensitive = true;
                this.rbMMedium.Sensitive = true;
                this.rbMLarge.Sensitive = true;
            } 
            else 
            {
                this.rbMSmall.Sensitive = false;
                this.rbMMedium.Sensitive = false;
                this.rbMLarge.Sensitive = false;

                this.SetMapSize(); // in case (in creative) you selected screen & inventory and map sizes that are invalid in survival
            }
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

        /* Automatically set map sizes from screen & inventory size only in survival mode */

        protected void OnRbSmallToggled(object sender, EventArgs e) 
        {
            if (rbSurvival.Active) 
            {
                this.SetMapSize();
            }
        }

        protected void OnRbMediumToggled(object sender, EventArgs e) 
        {
            if (rbSurvival.Active) 
            {
                this.SetMapSize();
            }
        }

        protected void OnRbLargeToggled(object sender, EventArgs e) 
        {
            if (rbSurvival.Active) 
            {
                this.SetMapSize();
            }
        }

        /// <summary>
        /// Sets map size from screen and inventory size
        /// </summary>
        private void SetMapSize() 
        {
            if (rbSmall.Active) 
            {
                rbMLarge.Active = true;
            } 
            else if (rbMedium.Active) 
            {
                rbMMedium.Active = true;
            } 
            else if (rbLarge.Active) 
            {
                rbMSmall.Active = true;
            }
        }

        /// <summary>
        /// Calls GameGenerator to generate the map depending on the selected map size button
        /// </summary>
        private void GenerateMap() 
        {
            string size = null;

            if (rbMSmall.Active) 
            {
                size = "small";
            }
            else if (rbMMedium.Active) 
            {
                size = "medium";
            }
            else if (rbMLarge.Active) 
            {
                size = "large";
            }
            else 
            {
                throw new ArgumentException("No map size was selected");
            }

            GameGenerator.GenerateMap(size);
        }

        /// <summary>
        /// Does the inital steps that are required by all windows upon game generation
        /// </summary>
        private void ScreenInventorySetup() 
        {
            string gameWindow;

            if (rbSmall.Active) 
            {
                gameWindow = "small";
            }
            else if (rbMedium.Active) 
            {
                gameWindow = "medium";
            } 
            else if (rbLarge.Active) 
            {
                gameWindow = "large";
            } 
            else 
            {
                throw new ArgumentException("No screen & inventory size was selected");
            }

            GameGenerator.GameWindowSizeSetup(gameWindow);
        }
    }
}
