namespace MundusTests.DataTests.SuperLayers 
{
    using System.Linq;
    using Mundus.Data.SuperLayers;
    using Mundus.Data.SuperLayers.DBTables;
    using NUnit.Framework;

    [TestFixture]
    public static class UndergroundContextTests 
    {
        [Test]
        public static void AddsCorrectValues() 
        {
            var mob = new UMPlacedTile("mob_stock", 0, 1, 1);
            var structure = new USPlacedTile("structure_stock", 0, 2, 1);
            var ground = new UGPlacedTile("ground_stock", 3, 4);

            UndergroundContext uc = new UndergroundContext();

            uc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            uc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            uc.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            uc.SaveChanges();

            Assert.AreEqual(mob.stock_id, uc.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't add the mob correctly");
            Assert.AreEqual(structure.stock_id, uc.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't add the structure correctly");
            Assert.AreEqual(ground.stock_id, uc.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't add the ground correctly");
        }

        [Test]
        public static void ConsideredAliveAfterSmallDamage() 
        {
            var mob = new UMPlacedTile("mob_stock", 10, 1, 1);
            var structure = new USPlacedTile("structure_stock", 4, 2, 1);

            UndergroundContext uc = new UndergroundContext();

            uc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            uc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            uc.SaveChanges();

            Assert.IsTrue(uc.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 3), "Mob is considered dead (health <= 0), but it shouldnt be");
            Assert.IsTrue(uc.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 2), "Structure is considered dead (health <= 0), but it shouldn't be");
        }

        [Test]
        public static void ConsideredDeadAfterBigDamage() 
        {
            var mob = new UMPlacedTile("mob_stock", 10, 1, 1);
            var structure = new USPlacedTile("structure_stock", 4, 2, 1);

            UndergroundContext uc = new UndergroundContext();

            uc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            uc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            uc.SaveChanges();

            Assert.IsFalse(uc.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 20), "Mob is considered alive (health > 0), but it shouldnt be");
            Assert.IsFalse(uc.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 20), "Structure is considered alive (health > 0), but it shouldn't be");
        }

        [Test]
        public static void DamagesCorrectly() 
        {
            var mob = new UMPlacedTile("mob_stock", 10, 1, 1);
            var structure = new USPlacedTile("structure_stock", 4, 2, 1);

            UndergroundContext uc = new UndergroundContext();

            uc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            uc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            uc.SaveChanges();

            uc.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 3);
            uc.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 1);

            Assert.AreEqual(7, uc.UMobLayer.First(x => x.YPos == mob.YPos && x.XPos == mob.XPos).Health, "Mobs recieve incorrect amount of damage");
            Assert.AreEqual(3, uc.UStructureLayer.First(x => x.YPos == structure.YPos && x.XPos == structure.XPos).Health, "Structures recieve incorrect amount of damage");
        }

        [Test]
        public static void GetsCorrectStocks() 
        {
            var mob = new UMPlacedTile("mob_stock", 0, 1, 1);
            var structure = new USPlacedTile("structure_stock", 0, 2, 1);
            var ground = new UGPlacedTile("ground_stock", 3, 4);

            UndergroundContext uc = new UndergroundContext();

            uc.UMobLayer.Add(mob);
            uc.UStructureLayer.Add(structure);
            uc.UGroundLayer.Add(ground);
            uc.SaveChanges();

            Assert.AreEqual(mob.stock_id, uc.GetMobLayerStock(mob.YPos, mob.XPos), "Doesn't get the correct mob layer stock");
            Assert.AreEqual(structure.stock_id, uc.GetStructureLayerStock(structure.YPos, structure.XPos), "Doesn't get the correct structure layer stock");
            Assert.AreEqual(ground.stock_id, uc.GetGroundLayerStock(ground.YPos, ground.XPos), "Doesn't get the correct ground layer stock");
        }

        [Test]
        public static void RemovesCorrectValues() 
        {
            var mob = new UMPlacedTile("mob_stock", 0, 1, 1);
            var structure = new USPlacedTile("structure_stock", 0, 2, 1);
            var ground = new UGPlacedTile("ground_stock", 3, 4);

            UndergroundContext uc = new UndergroundContext();

            uc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            uc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            uc.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            uc.SaveChanges();

            uc.RemoveMobFromPosition(mob.YPos, mob.XPos);
            uc.RemoveStructureFromPosition(structure.YPos, structure.XPos);
            uc.RemoveGroundFromPosition(ground.YPos, ground.XPos);
            uc.SaveChanges();

            Assert.AreEqual(null, uc.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't remove the mob correctly");
            Assert.AreEqual(null, uc.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't remove the structure correctly");
            Assert.AreEqual(null, uc.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't remove the ground correctly");
        }


        [Test]
        public static void SetsCorrectValues() 
        {
            var mob = new UMPlacedTile("mob_stock", 0, 1, 1);
            var newMob = new UMPlacedTile("new_mob_stock", 1, 1, 1);
            var structure = new USPlacedTile("structure_stock", 0, 2, 1);
            var newStructure = new USPlacedTile("new_structure_stock", 1, 2, 1);
            var ground = new UGPlacedTile("ground_stock", 3, 4);
            var newGround = new UGPlacedTile("new_ground_stock", 3, 4);

            UndergroundContext uc = new UndergroundContext();

            uc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            uc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            uc.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            uc.SaveChanges();

            uc.SetMobAtPosition(newMob.stock_id, newMob.Health, newMob.YPos, newMob.XPos);
            uc.SetStructureAtPosition(newStructure.stock_id, newStructure.Health, newStructure.YPos, newStructure.XPos);
            uc.SetGroundAtPosition(newGround.stock_id, newGround.YPos, newGround.XPos);
            uc.SaveChanges();

            Assert.AreEqual(newMob.stock_id, uc.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't set the mob correctly");
            Assert.AreEqual(newStructure.stock_id, uc.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't set the structure correctly");
            Assert.AreEqual(newGround.stock_id, uc.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't set the ground correctly");
        }

        [Test]
        public static void TruncatesTablesOnInitialization() 
        {
            UndergroundContext uc = new UndergroundContext();

            Assert.AreEqual(0, uc.UMobLayer.Count(), "UMobLayer table isn't properly truncated upon UndergroundContext initialization");
            Assert.AreEqual(0, uc.UStructureLayer.Count(), "UStructureLayer table isn't properly truncated upon UndergroundContext initialization");
            Assert.AreEqual(0, uc.UGroundLayer.Count(), "LGroungLayer table isn't properly truncated upon UndergroundContext initialization");
        }
    }
}
