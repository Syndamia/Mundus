using Gtk;
using System;
using Mundus.Service.Crafting;
using Mundus.Service.Tiles.Items;

namespace Mundus.Views.Windows {
    public partial class CraftingWindow : Gtk.Window {
        public CraftingRecipe[] Recipes { get; set; }
        private int recipeIndex;

        public CraftingWindow() : base( Gtk.WindowType.Toplevel ) {
            this.Build();
        }

        protected void OnDeleteEvent(object o, DeleteEventArgs args) {
            args.RetVal = true;
            this.Hide();
        }

        /// <summary>
        /// Resets visuals and prepares avalable recipes for current items in inventory
        /// </summary>
        public void Initialize() {
            Reset();
            CraftingController.FindAvalableItems();
            this.Recipes = CraftingController.GetAvalableRecipies();
            recipeIndex = 0;
            PrintRecipe();
            UpdateNextPrevBtns();
        }

        private void PrintRecipe() {
            if (Recipes.Length > 0) {
                CraftingRecipe recipe = Recipes[recipeIndex];
                btnCraft.Sensitive = true;

                imgItem.SetFromStock(recipe.ResultItem.stock_id, IconSize.Dnd);
                lblInfo.Text = recipe.ResultItem.ToString();

                lblC1.Text = recipe.Count1 + "";
                imgI1.SetFromStock(recipe.ReqItem1.stock_id, IconSize.Dnd);

                if (recipe.ReqItem2 != null) {
                    lblC2.Text = recipe.Count2 + "";
                    imgI2.SetFromStock(recipe.ReqItem2.stock_id, IconSize.Dnd);
                }

                if (recipe.ReqItem3 != null) {
                    lblC3.Text = recipe.Count3 + "";
                    imgI3.SetFromStock(recipe.ReqItem3.stock_id, IconSize.Dnd);
                }

                if (recipe.ReqItem4 != null) {
                    lblC4.Text = recipe.Count4 + "";
                    imgI4.SetFromStock(recipe.ReqItem4.stock_id, IconSize.Dnd);
                }

                if (recipe.ReqItem5 != null) {
                    lblC5.Text = recipe.Count5 + "";
                    imgI5.SetFromStock(recipe.ReqItem5.stock_id, IconSize.Dnd);
                }
            }
        }



        protected void OnBtnPrevClicked(object sender, System.EventArgs e) {
            recipeIndex--;
            PrintRecipe();
            UpdateNextPrevBtns();
        }
        protected void OnBtnNextClicked(object sender, System.EventArgs e) {
            recipeIndex++;
            PrintRecipe();
            UpdateNextPrevBtns();
        }

        private void UpdateNextPrevBtns() {
            btnNext.Sensitive = recipeIndex < Recipes.Length - 1;
            btnPrev.Sensitive = recipeIndex > 0;
        }

        private void Reset() {
            lblC1.Text = "0";
            lblC2.Text = "0";
            lblC3.Text = "0";
            lblC4.Text = "0";
            lblC5.Text = "0";

            imgI1.SetFromStock("empty", IconSize.Dnd);
            imgI2.SetFromStock("empty", IconSize.Dnd);
            imgI3.SetFromStock("empty", IconSize.Dnd);
            imgI4.SetFromStock("empty", IconSize.Dnd);
            imgI5.SetFromStock("empty", IconSize.Dnd);

            imgItem.SetFromStock("empty", IconSize.Dnd);
            lblInfo.Text = null;
            btnPrev.Sensitive = false;
            btnNext.Sensitive = false;
            btnCraft.Sensitive = false;
        }

        protected void OnBtnCraftClicked(object sender, EventArgs e) {
            CraftingController.CraftItem(Recipes[recipeIndex]);
            this.Hide();
        }
    }
}
