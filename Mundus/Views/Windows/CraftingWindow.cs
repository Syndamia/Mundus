namespace Mundus.Views.Windows 
{
    using System;
    using Gtk;
    using Mundus.Service.Tiles.Crafting;

    public partial class CraftingWindow : Gtk.Window
    {
        /// <summary>
        /// All the crafting recipes (gets set at Initialize())
        /// </summary>
        private CraftingRecipe[] recipes;

        /// <summary>
        /// Used to track which recipe should be displayed
        /// </summary>
        private int recipeIndex;

        public CraftingWindow() : base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        /// <summary>
        /// Resets visuals and prepares avalable recipes for current items in inventory
        /// </summary>
        public void Initialize() 
        {
            this.Reset();

            this.recipes = CraftingController.GetAvalableRecipes();
            this.recipeIndex = 0;

            this.PrintRecipe();
            this.UpdateNextPrevBtns();
        }

        /// <summary>
        /// Every time the window is closed, this gets called (hides the window)
        /// </summary>
        protected void OnDeleteEvent(object o, DeleteEventArgs args) 
        {
            args.RetVal = true;
            this.Hide();
        }

        /// <summary>
        /// Selects the previous avalable recipe and updates
        /// </summary>
        protected void OnBtnPrevClicked(object sender, System.EventArgs e) 
        {
            this.recipeIndex--;
            this.PrintRecipe();

            this.UpdateNextPrevBtns();
        }

        /// <summary>
        /// Selects the following avalable recipe and updates
        /// </summary>
        protected void OnBtnNextClicked(object sender, System.EventArgs e) 
        {
            this.recipeIndex++;
            this.PrintRecipe();

            this.UpdateNextPrevBtns();
        }

        /// <summary>
        /// Crafts the item (calls CraftingController and hides the window)
        /// </summary>
        protected void OnBtnCraftClicked(object sender, EventArgs e) {
            CraftingController.CraftItemPlayer(this.recipes[this.recipeIndex]);
            this.Hide();
        }

        /// <summary>
        /// Sets information values for the currently selected recipe
        /// </summary>
        private void PrintRecipe() 
        {
            if (this.recipes.Length > 0) 
            {
                this.ClearScreen();
                CraftingRecipe recipe = this.recipes[this.recipeIndex];
                this.btnCraft.Sensitive = true;

                this.imgItem.SetFromStock(recipe.ResultItem, IconSize.Dnd);
                this.lblInfo.Text = recipe.ResultItem.ToString();

                this.lblC1.Text = recipe.Count1 + string.Empty;
                this.imgI1.SetFromStock(recipe.ReqItem1, IconSize.Dnd);

                if (recipe.ReqItem2 != null) 
                {
                    this.lblC2.Text = recipe.Count2 + string.Empty;
                    this.imgI2.SetFromStock(recipe.ReqItem2, IconSize.Dnd);
                }

                if (recipe.ReqItem3 != null) 
                {
                    this.lblC3.Text = recipe.Count3 + string.Empty;
                    this.imgI3.SetFromStock(recipe.ReqItem3, IconSize.Dnd);
                }

                if (recipe.ReqItem4 != null) 
                {
                    this.lblC4.Text = recipe.Count4 + string.Empty;
                    this.imgI4.SetFromStock(recipe.ReqItem4, IconSize.Dnd);
                }

                if (recipe.ReqItem5 != null) 
                {
                    this.lblC5.Text = recipe.Count5 + string.Empty;
                    this.imgI5.SetFromStock(recipe.ReqItem5, IconSize.Dnd);
                }
            }
        }

        /// <summary>
        /// Updates the btnNext and btnPrev sensitivity
        /// </summary>
        private void UpdateNextPrevBtns() 
        {
            this.btnNext.Sensitive = this.recipeIndex < this.recipes.Length - 1;
            this.btnPrev.Sensitive = this.recipeIndex > 0;
        }

        /// <summary>
        /// Sets default empty values for required items and their amounts
        /// </summary>
        private void ClearScreen() 
        {
            this.lblC1.Text = "0";
            this.lblC2.Text = "0";
            this.lblC3.Text = "0";
            this.lblC4.Text = "0";
            this.lblC5.Text = "0";

            this.imgI1.SetFromStock("empty", IconSize.Dnd);
            this.imgI2.SetFromStock("empty", IconSize.Dnd);
            this.imgI3.SetFromStock("empty", IconSize.Dnd);
            this.imgI4.SetFromStock("empty", IconSize.Dnd);
            this.imgI5.SetFromStock("empty", IconSize.Dnd);
        }

        /// <summary>
        /// Sets default empty values for the whole window
        /// </summary>
        private void Reset() 
        {
            this.ClearScreen();

            this.imgItem.SetFromStock("empty", IconSize.Dnd);
            this.lblInfo.Text = null;

            this.btnPrev.Sensitive = false;
            this.btnNext.Sensitive = false;
            this.btnCraft.Sensitive = false;
        }
    }
}
