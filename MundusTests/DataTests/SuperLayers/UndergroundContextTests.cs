namespace MundusTests.DataTests.SuperLayers 
{
    using System.Linq;
    using Mundus.Data;
    using Mundus.Data.SuperLayers.DBTables;
    using NUnit.Framework;

    [TestFixture]
    public static class UndergroundContextTests 
    {
        [Test]
        public static void AddsCorrectValues() 
        {
            var mob = new UMPlacedTile("mob_stock", 0, 1000, 1000);
            var structure = new USPlacedTile("structure_stock", 0, 2000, 1000);
            var ground = new UGPlacedTile("ground_stock", 3000, 4000);             

            DataBaseContexts.UContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            DataBaseContexts.UContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            DataBaseContexts.UContext.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            DataBaseContexts.UContext.SaveChanges();

            Assert.AreEqual(mob.stock_id, DataBaseContexts.UContext.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't add the mob correctly");
            Assert.AreEqual(structure.stock_id, DataBaseContexts.UContext.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't add the structure correctly");
            Assert.AreEqual(ground.stock_id, DataBaseContexts.UContext.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't add the ground correctly");
        }

        [Test]
        public static void ConsideredAliveAfterSmallDamage() 
        {
            var mob = new UMPlacedTile("mob_stock", 10, 1000, 1001);
            var structure = new USPlacedTile("structure_stock", 4, 2000, 1001);

            DataBaseContexts.UContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            DataBaseContexts.UContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            DataBaseContexts.UContext.SaveChanges();

            Assert.IsTrue(DataBaseContexts.UContext.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 3), "Mob is considered dead (health <= 0), but it shouldnt be");
            Assert.IsTrue(DataBaseContexts.UContext.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 2), "Structure is considered dead (health <= 0), but it shouldn't be");
        }

        [Test]
        public static void ConsideredDeadAfterBigDamage() 
        {
            var mob = new UMPlacedTile("mob_stock", 10, 1000, 1000);
            var structure = new USPlacedTile("structure_stock", 4, 2000, 1000);

            DataBaseContexts.UContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            DataBaseContexts.UContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            DataBaseContexts.UContext.SaveChanges();

            Assert.IsFalse(DataBaseContexts.UContext.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 20), "Mob is considered alive (health > 0), but it shouldnt be");
            Assert.IsFalse(DataBaseContexts.UContext.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 20), "Structure is considered alive (health > 0), but it shouldn't be");
        }

        [Test]
        public static void DamagesCorrectly() 
        {
            var mob = new UMPlacedTile("mob_stock", 10, 1000, 1002);
            var structure = new USPlacedTile("structure_stock", 4, 2000, 1002);

            DataBaseContexts.UContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            DataBaseContexts.UContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            DataBaseContexts.UContext.SaveChanges();

            DataBaseContexts.UContext.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 3);
            DataBaseContexts.UContext.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 1);

            Assert.AreEqual(7, DataBaseContexts.UContext.UMobLayer.First(x => x.YPos == mob.YPos && x.XPos == mob.XPos).Health, "Mobs recieve incorrect amount of damage");
            Assert.AreEqual(3, DataBaseContexts.UContext.UStructureLayer.First(x => x.YPos == structure.YPos && x.XPos == structure.XPos).Health, "Structures recieve incorrect amount of damage");
        }

        [Test]
        public static void GetsCorrectStocks() 
        {
            var mob = new UMPlacedTile("mob_stock", 0, 1000, 1000);
            var structure = new USPlacedTile("structure_stock", 0, 2000, 1000);
            var ground = new UGPlacedTile("ground_stock", 3000, 4000);

            DataBaseContexts.UContext.UMobLayer.Add(mob);
            DataBaseContexts.UContext.UStructureLayer.Add(structure);
            DataBaseContexts.UContext.UGroundLayer.Add(ground);
            DataBaseContexts.UContext.SaveChanges();

            Assert.AreEqual(mob.stock_id, DataBaseContexts.UContext.GetMobLayerStock(mob.YPos, mob.XPos), "Doesn't get the correct mob layer stock");
            Assert.AreEqual(structure.stock_id, DataBaseContexts.UContext.GetStructureLayerStock(structure.YPos, structure.XPos), "Doesn't get the correct structure layer stock");
            Assert.AreEqual(ground.stock_id, DataBaseContexts.UContext.GetGroundLayerStock(ground.YPos, ground.XPos), "Doesn't get the correct ground layer stock");
        }

        [Test]
        public static void RemovesCorrectValues() 
        {
            var mob = new UMPlacedTile("mob_stock", 0, 1000, 1000);
            var structure = new USPlacedTile("structure_stock", 0, 2000, 1000);
            var ground = new UGPlacedTile("ground_stock", 3000, 4000);

            DataBaseContexts.UContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            DataBaseContexts.UContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            DataBaseContexts.UContext.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            DataBaseContexts.UContext.SaveChanges();

            DataBaseContexts.UContext.RemoveMobFromPosition(mob.YPos, mob.XPos);
            DataBaseContexts.UContext.RemoveStructureFromPosition(structure.YPos, structure.XPos);
            DataBaseContexts.UContext.RemoveGroundFromPosition(ground.YPos, ground.XPos);
            DataBaseContexts.UContext.SaveChanges();

            Assert.AreEqual(null, DataBaseContexts.UContext.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't remove the mob correctly");
            Assert.AreEqual(null, DataBaseContexts.UContext.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't remove the structure correctly");
            Assert.AreEqual(null, DataBaseContexts.UContext.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't remove the ground correctly");
        }

        [Test]
        public static void SetsCorrectValues() 
        {
            var mob = new UMPlacedTile("mob_stock", 0, 1000, 1000);
            var newMob = new UMPlacedTile("new_mob_stock", 1, 1000, 1000);
            var structure = new USPlacedTile("structure_stock", 0, 2000, 1000);
            var newStructure = new USPlacedTile("new_structure_stock", 1, 2000, 1000);
            var ground = new UGPlacedTile("ground_stock", 3000, 4000);
            var newGround = new UGPlacedTile("new_ground_stock", 3000, 4000);

            DataBaseContexts.UContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            DataBaseContexts.UContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            DataBaseContexts.UContext.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            DataBaseContexts.UContext.SaveChanges();

            DataBaseContexts.UContext.SetMobAtPosition(newMob.stock_id, newMob.Health, newMob.YPos, newMob.XPos);
            DataBaseContexts.UContext.SetStructureAtPosition(newStructure.stock_id, newStructure.Health, newStructure.YPos, newStructure.XPos);
            DataBaseContexts.UContext.SetGroundAtPosition(newGround.stock_id, newGround.YPos, newGround.XPos);
            DataBaseContexts.UContext.SaveChanges();

            Assert.AreEqual(newMob.stock_id, DataBaseContexts.UContext.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't set the mob correctly");
            Assert.AreEqual(newStructure.stock_id, DataBaseContexts.UContext.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't set the structure correctly");
            Assert.AreEqual(newGround.stock_id, DataBaseContexts.UContext.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't set the ground correctly");
        }
    }
}
