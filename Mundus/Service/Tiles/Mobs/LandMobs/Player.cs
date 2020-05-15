namespace Mundus.Service.Tiles.Mobs.LandMobs 
{
    using System;
    using Mundus.Data.SuperLayers;
    using Mundus.Data.Windows;
    using Mundus.Service.Tiles.Items.Types;

    public class Player : MobTile 
    {
        /// <summary>
        /// Note: player has an rndMovementQualifier of -1 and drops first item in the hotbar
        /// </summary>
        public Player(string stock_id, int defence, ISuperLayerContext currentSuperLayer)
                      : base(stock_id, WI.SelWin.Size * 4, defence, currentSuperLayer, WI.SelWin.Size, null, -1) 
        {
            this.Energy = WI.SelWin.Size * 6;
            this.DroppedUponDeath = (Material)this.Inventory.Hotbar[0];
        }

        public double Energy { get; private set; }

        /// <summary>
        /// Removes energy from player. If energy gets below 0 it will start taking health
        /// </summary>
        /// <param name="value">Energy points to drain from player (will do nothing if value less than 0</param>
        public void DrainEnergy(double value) 
        {
            if (value > 0) 
            {
                this.Energy -= value;

                if (this.Energy < 0) 
                {
                    this.TakeDamage((int)Math.Ceiling(Math.Abs(this.Energy)));
                    this.Energy = 0;
                }
            }
        }

        /// <summary>
        /// Restores energy from player. If energy is maxed out (WI.SelWin.Size * 6) it starts healing the player
        /// </summary>
        /// <param name="value">Energy points to restore energy (will do nothing if value less than 0</param>
        public void RestoreEnergy(double value) 
        {
            if (value > 0) 
            {
                this.Energy += value;

                if (this.Energy > WI.SelWin.Size * 6) 
                {
                    this.Heal((int)Math.Ceiling(Energy - WI.SelWin.Size * 6));
                    this.Energy = WI.SelWin.Size * 6;
                }
            }
        }
    }
}
