namespace MundusTests.DataTests.SuperLayers 
{
    using System.Linq;
    using Mundus.Data;
    using Mundus.Data.SuperLayers.DBTables;
    using NUnit.Framework;

    [TestFixture]
    public static class SkyContextTests 
    {
        [Test]
        public static void AddsCorrectValues() 
        {
            var mob = new SMPlacedTile("mob_stock", 0, 1000, 1000);
            var structure = new SSPlacedTile("structure_stock", 0, 2000, 1000);
            var ground = new SGPlacedTile("ground_stock", 3000, 4000);

            DataBaseContexts.SContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            DataBaseContexts.SContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            DataBaseContexts.SContext.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            DataBaseContexts.SContext.SaveChanges();

            Assert.AreEqual(mob.stock_id, DataBaseContexts.SContext.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't add the mob correctly");
            Assert.AreEqual(structure.stock_id, DataBaseContexts.SContext.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't add the structure correctly");
            Assert.AreEqual(ground.stock_id, DataBaseContexts.SContext.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't add the ground correctly");
        }

        [Test]
        public static void ConsideredAliveAfterSmallDamage() 
        {
            var mob = new SMPlacedTile("mob_stock", 10, 1000, 1001);
            var structure = new SSPlacedTile("structure_stock", 4, 2000, 1001);

            DataBaseContexts.SContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            DataBaseContexts.SContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            DataBaseContexts.SContext.SaveChanges();

            Assert.IsTrue(DataBaseContexts.SContext.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 3), "Mob is considered dead (health <= 0), but it shouldnt be");
            Assert.IsTrue(DataBaseContexts.SContext.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 2), "Structure is considered dead (health <= 0), but it shouldn't be");
        }

        [Test]
        public static void ConsideredDeadAfterBigDamage() 
        {
            var mob = new SMPlacedTile("mob_stock", 10, 1000, 1000);
            var structure = new SSPlacedTile("structure_stock", 4, 2000, 1000);

            DataBaseContexts.SContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            DataBaseContexts.SContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            DataBaseContexts.SContext.SaveChanges();

            Assert.IsFalse(DataBaseContexts.SContext.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 20), "Mob is considered alive (health > 0), but it shouldnt be");
            Assert.IsFalse(DataBaseContexts.SContext.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 20), "Structure is considered alive (health > 0), but it shouldn't be");
        }

        [Test]
        public static void DamagesCorrectly() 
        {
            var mob = new SMPlacedTile("mob_stock", 10, 1000, 1002);
            var structure = new SSPlacedTile("structure_stock", 4, 2000, 1002);

            DataBaseContexts.SContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            DataBaseContexts.SContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            DataBaseContexts.SContext.SaveChanges();

            DataBaseContexts.SContext.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 3);
            DataBaseContexts.SContext.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 1);

            Assert.AreEqual(7, DataBaseContexts.SContext.SMobLayer.First(x => x.YPos == mob.YPos && x.XPos == mob.XPos).Health, "Mobs recieve incorrect amount of damage");
            Assert.AreEqual(3, DataBaseContexts.SContext.SStructureLayer.First(x => x.YPos == structure.YPos && x.XPos == structure.XPos).Health, "Structures recieve incorrect amount of damage");
        }

        [Test]
        public static void GetsCorrectStocks() 
        {
            var mob = new SMPlacedTile("mob_stock", 0, 1000, 1000);
            var structure = new SSPlacedTile("structure_stock", 0, 2000, 1000);
            var ground = new SGPlacedTile("ground_stock", 3000, 4000);

            DataBaseContexts.SContext.SMobLayer.Add(mob);
            DataBaseContexts.SContext.SStructureLayer.Add(structure);
            DataBaseContexts.SContext.SGroundLayer.Add(ground);
            DataBaseContexts.SContext.SaveChanges();

            Assert.AreEqual(mob.stock_id, DataBaseContexts.SContext.GetMobLayerStock(mob.YPos, mob.XPos), "Doesn't get the correct mob layer stock");
            Assert.AreEqual(structure.stock_id, DataBaseContexts.SContext.GetStructureLayerStock(structure.YPos, structure.XPos), "Doesn't get the correct structure layer stock");
            Assert.AreEqual(ground.stock_id, DataBaseContexts.SContext.GetGroundLayerStock(ground.YPos, ground.XPos), "Doesn't get the correct ground layer stock");
        }

        [Test]
        public static void RemovesCorrectValues() 
        {
            var mob = new SMPlacedTile("mob_stock", 0, 1000, 1000);
            var structure = new SSPlacedTile("structure_stock", 0, 2000, 1000);
            var ground = new SGPlacedTile("ground_stock", 3000, 4000);

            DataBaseContexts.SContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            DataBaseContexts.SContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            DataBaseContexts.SContext.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            DataBaseContexts.SContext.SaveChanges();

            DataBaseContexts.SContext.RemoveMobFromPosition(mob.YPos, mob.XPos);
            DataBaseContexts.SContext.RemoveStructureFromPosition(structure.YPos, structure.XPos);
            DataBaseContexts.SContext.RemoveGroundFromPosition(ground.YPos, ground.XPos);
            DataBaseContexts.SContext.SaveChanges();

            Assert.AreEqual(null, DataBaseContexts.SContext.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't remove the mob correctly");
            Assert.AreEqual(null, DataBaseContexts.SContext.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't remove the structure correctly");
            Assert.AreEqual(null, DataBaseContexts.SContext.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't remove the ground correctly");
        }

        [Test]
        public static void SetsCorrectValues() 
        {
            var mob = new SMPlacedTile("mob_stock", 0, 1000, 1000);
            var newMob = new SMPlacedTile("new_mob_stock", 1, 1000, 1000);
            var structure = new SSPlacedTile("structure_stock", 0, 2000, 1000);
            var newStructure = new SSPlacedTile("new_structure_stock", 1, 2000, 1000);
            var ground = new SGPlacedTile("ground_stock", 3000, 4000);
            var newGround = new SGPlacedTile("new_ground_stock", 3000, 4000);

            DataBaseContexts.SContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            DataBaseContexts.SContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            DataBaseContexts.SContext.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            DataBaseContexts.SContext.SaveChanges();

            DataBaseContexts.SContext.SetMobAtPosition(newMob.stock_id, newMob.Health, newMob.YPos, newMob.XPos);
            DataBaseContexts.SContext.SetStructureAtPosition(newStructure.stock_id, newStructure.Health, newStructure.YPos, newStructure.XPos);
            DataBaseContexts.SContext.SetGroundAtPosition(newGround.stock_id, newGround.YPos, newGround.XPos);
            DataBaseContexts.SContext.SaveChanges();

            Assert.AreEqual(newMob.stock_id, DataBaseContexts.SContext.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't set the mob correctly");
            Assert.AreEqual(newStructure.stock_id, DataBaseContexts.SContext.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't set the structure correctly");
            Assert.AreEqual(newGround.stock_id, DataBaseContexts.SContext.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't set the ground correctly");
        }
    }
}
