namespace MundusTests.DataTests.SuperLayers 
{
    using System.Linq;
    using Mundus.Data.SuperLayers;
    using Mundus.Data.SuperLayers.DBTables;
    using NUnit.Framework;

    [TestFixture]
    public static class SkyContextTests 
    {
        [Test]
        public static void AddsCorrectValues() 
        {
            var mob = new SMPlacedTile("mob_stock", 0, 1, 1);
            var structure = new SSPlacedTile("structure_stock", 0, 2, 1);
            var ground = new SGPlacedTile("ground_stock", 3, 4);

            SkyContext sc = new SkyContext();

            sc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            sc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            sc.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            sc.SaveChanges();

            Assert.AreEqual(mob.stock_id, sc.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't add the mob correctly");
            Assert.AreEqual(structure.stock_id, sc.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't add the structure correctly");
            Assert.AreEqual(ground.stock_id, sc.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't add the ground correctly");
        }

        [Test]
        public static void ConsideredAliveAfterSmallDamage() 
        {
            var mob = new SMPlacedTile("mob_stock", 10, 1, 1);
            var structure = new SSPlacedTile("structure_stock", 4, 2, 1);

            SkyContext sc = new SkyContext();

            sc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            sc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            sc.SaveChanges();

            Assert.IsTrue(sc.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 3), "Mob is considered dead (health <= 0), but it shouldnt be");
            Assert.IsTrue(sc.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 2), "Structure is considered dead (health <= 0), but it shouldn't be");
        }

        [Test]
        public static void ConsideredDeadAfterBigDamage() 
        {
            var mob = new SMPlacedTile("mob_stock", 10, 1, 1);
            var structure = new SSPlacedTile("structure_stock", 4, 2, 1);

            SkyContext sc = new SkyContext();

            sc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            sc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            sc.SaveChanges();

            Assert.IsFalse(sc.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 20), "Mob is considered alive (health > 0), but it shouldnt be");
            Assert.IsFalse(sc.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 20), "Structure is considered alive (health > 0), but it shouldn't be");
        }

        [Test]
        public static void DamagesCorrectly() 
        {
            var mob = new SMPlacedTile("mob_stock", 10, 1, 1);
            var structure = new SSPlacedTile("structure_stock", 4, 2, 1);

            SkyContext sc = new SkyContext();

            sc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            sc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            sc.SaveChanges();

            sc.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 3);
            sc.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 1);

            Assert.AreEqual(7, sc.SMobLayer.First(x => x.YPos == mob.YPos && x.XPos == mob.XPos).Health, "Mobs recieve incorrect amount of damage");
            Assert.AreEqual(3, sc.SStructureLayer.First(x => x.YPos == structure.YPos && x.XPos == structure.XPos).Health, "Structures recieve incorrect amount of damage");
        }

        [Test]
        public static void GetsCorrectStocks() 
        {
            var mob = new SMPlacedTile("mob_stock", 0, 1, 1);
            var structure = new SSPlacedTile("structure_stock", 0, 2, 1);
            var ground = new SGPlacedTile("ground_stock", 3, 4);

            SkyContext sc = new SkyContext();

            sc.SMobLayer.Add(mob);
            sc.SStructureLayer.Add(structure);
            sc.SGroundLayer.Add(ground);
            sc.SaveChanges();

            Assert.AreEqual(mob.stock_id, sc.GetMobLayerStock(mob.YPos, mob.XPos), "Doesn't get the correct mob layer stock");
            Assert.AreEqual(structure.stock_id, sc.GetStructureLayerStock(structure.YPos, structure.XPos), "Doesn't get the correct structure layer stock");
            Assert.AreEqual(ground.stock_id, sc.GetGroundLayerStock(ground.YPos, ground.XPos), "Doesn't get the correct ground layer stock");
        }

        [Test]
        public static void RemovesCorrectValues() 
        {
            var mob = new SMPlacedTile("mob_stock", 0, 1, 1);
            var structure = new SSPlacedTile("structure_stock", 0, 2, 1);
            var ground = new SGPlacedTile("ground_stock", 3, 4);

            SkyContext sc = new SkyContext();

            sc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            sc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            sc.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            sc.SaveChanges();

            sc.RemoveMobFromPosition(mob.YPos, mob.XPos);
            sc.RemoveStructureFromPosition(structure.YPos, structure.XPos);
            sc.RemoveGroundFromPosition(ground.YPos, ground.XPos);
            sc.SaveChanges();

            Assert.AreEqual(null, sc.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't remove the mob correctly");
            Assert.AreEqual(null, sc.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't remove the structure correctly");
            Assert.AreEqual(null, sc.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't remove the ground correctly");
        }


        [Test]
        public static void SetsCorrectValues() 
        {
            var mob = new SMPlacedTile("mob_stock", 0, 1, 1);
            var newMob = new SMPlacedTile("new_mob_stock", 1, 1, 1);
            var structure = new SSPlacedTile("structure_stock", 0, 2, 1);
            var newStructure = new SSPlacedTile("new_structure_stock", 1, 2, 1);
            var ground = new SGPlacedTile("ground_stock", 3, 4);
            var newGround = new SGPlacedTile("new_ground_stock", 3, 4);

            SkyContext sc = new SkyContext();

            sc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            sc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            sc.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            sc.SaveChanges();

            sc.SetMobAtPosition(newMob.stock_id, newMob.Health, newMob.YPos, newMob.XPos);
            sc.SetStructureAtPosition(newStructure.stock_id, newStructure.Health, newStructure.YPos, newStructure.XPos);
            sc.SetGroundAtPosition(newGround.stock_id, newGround.YPos, newGround.XPos);
            sc.SaveChanges();

            Assert.AreEqual(newMob.stock_id, sc.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't set the mob correctly");
            Assert.AreEqual(newStructure.stock_id, sc.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't set the structure correctly");
            Assert.AreEqual(newGround.stock_id, sc.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't set the ground correctly");
        }

        [Test]
        public static void TruncatesTablesOnInitialization() 
        {
            SkyContext sc = new SkyContext();

            Assert.AreEqual(0, sc.SMobLayer.Count(), "SMobLayer table isn't properly truncated upon SkyContext initialization");
            Assert.AreEqual(0, sc.SStructureLayer.Count(), "SStructureLayer table isn't properly truncated upon SkyContext initialization");
            Assert.AreEqual(0, sc.SGroundLayer.Count(), "LGroungLayer table isn't properly truncated upon SkyContext initialization");
        }
    }
}
