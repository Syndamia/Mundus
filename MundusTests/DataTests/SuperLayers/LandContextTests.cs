using System;
using System.Linq;
using Mundus.Data.SuperLayers;
using Mundus.Data.SuperLayers.DBTables;
using NUnit.Framework;

namespace MundusTests.DataTests.SuperLayers {
    [TestFixture]
    public static class LandContextTests {
        [Test]
        public static void AddsCorrectValues() {
            var mob = new LMPlacedTile("mob_stock", 0, 1, 1);
            var structure = new LSPlacedTile("structure_stock", 0, 2, 1);
            var ground = new LGPlacedTile("ground_stock", 3, 4);

            LandContext lc = new LandContext();

            lc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            lc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            lc.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            lc.SaveChanges();

            Assert.AreEqual(mob.stock_id, lc.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't add the mob correctly");
            Assert.AreEqual(structure.stock_id, lc.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't add the structure correctly");
            Assert.AreEqual(ground.stock_id, lc.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't add the ground correctly");
        }

        [Test]
        public static void ConsideredAliveAfterSmallDamage() {
            var mob = new LMPlacedTile("mob_stock", 10, 1, 1);
            var structure = new LSPlacedTile("structure_stock", 4, 2, 1);

            LandContext lc = new LandContext();

            lc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            lc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            lc.SaveChanges();

            Assert.IsTrue(lc.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 3), "Mob is considered dead (health <= 0), but it shouldnt be");
            Assert.IsTrue(lc.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 2), "Structure is considered dead (health <= 0), but it shouldn't be");
        }

        [Test]
        public static void ConsideredDeadAfterBigDamage() {
            var mob = new LMPlacedTile("mob_stock", 10, 1, 1);
            var structure = new LSPlacedTile("structure_stock", 4, 2, 1);

            LandContext lc = new LandContext();

            lc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            lc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            lc.SaveChanges();

            Assert.IsFalse(lc.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 20), "Mob is considered alive (health > 0), but it shouldnt be");
            Assert.IsFalse(lc.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 20), "Structure is considered alive (health > 0), but it shouldn't be");
        }

        [Test]
        public static void DamagesCorrectly() {
            var mob = new LMPlacedTile("mob_stock", 10, 1, 1);
            var structure = new LSPlacedTile("structure_stock", 4, 2, 1);

            LandContext lc = new LandContext();

            lc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            lc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            lc.SaveChanges();

            lc.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 3);
            lc.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 1);

            Assert.AreEqual(7, lc.LMobLayer.First(x => x.YPos == mob.YPos && x.XPos == mob.XPos).Health, "Mobs recieve incorrect amount of damage");
            Assert.AreEqual(3, lc.LStructureLayer.First(x => x.YPos == structure.YPos && x.XPos == structure.XPos).Health, "Structures recieve incorrect amount of damage");
        }

        [Test]
        public static void GetsCorrectStocks() {
            var mob = new LMPlacedTile("mob_stock", 0, 1, 1);
            var structure = new LSPlacedTile("structure_stock", 0, 2, 1);
            var ground = new LGPlacedTile("ground_stock", 3, 4);

            LandContext lc = new LandContext();

            lc.LMobLayer.Add(mob);
            lc.LStructureLayer.Add(structure);
            lc.LGroundLayer.Add(ground);
            lc.SaveChanges();

            Assert.AreEqual(mob.stock_id, lc.GetMobLayerStock(mob.YPos, mob.XPos), "Doesn't get the correct mob layer stock");
            Assert.AreEqual(structure.stock_id, lc.GetStructureLayerStock(structure.YPos,structure.XPos), "Doesn't get the correct structure layer stock");
            Assert.AreEqual(ground.stock_id, lc.GetGroundLayerStock(ground.YPos, ground.XPos), "Doesn't get the correct ground layer stock");
        }

        [Test]
        public static void RemovesCorrectValues() {
            var mob = new LMPlacedTile("mob_stock", 0, 1, 1);
            var structure = new LSPlacedTile("structure_stock", 0, 2, 1);
            var ground = new LGPlacedTile("ground_stock", 3, 4);

            LandContext lc = new LandContext();

            lc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            lc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            lc.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            lc.SaveChanges();

            lc.RemoveMobFromPosition(mob.YPos, mob.XPos);
            lc.RemoveStructureFromPosition(structure.YPos, structure.XPos);
            lc.RemoveGroundFromPosition(ground.YPos, ground.XPos);
            lc.SaveChanges();

            Assert.AreEqual(null, lc.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't remove the mob correctly");
            Assert.AreEqual(null, lc.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't remove the structure correctly");
            Assert.AreEqual(null, lc.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't remove the ground correctly");
        }


        [Test]
        public static void SetsCorrectValues() {
            var mob = new LMPlacedTile("mob_stock", 0, 1, 1);
            var newMob = new LMPlacedTile("new_mob_stock", 1, 1, 1);
            var structure = new LSPlacedTile("structure_stock", 0, 2, 1);
            var newStructure = new LSPlacedTile("new_structure_stock", 1, 2, 1);
            var ground = new LGPlacedTile("ground_stock", 3, 4);
            var newGround = new LGPlacedTile("new_ground_stock", 3, 4);

            LandContext lc = new LandContext();

            lc.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
            lc.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
            lc.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
            lc.SaveChanges();

            lc.SetMobAtPosition(newMob.stock_id, newMob.Health, newMob.YPos, newMob.XPos);
            lc.SetStructureAtPosition(newStructure.stock_id, newStructure.Health, newStructure.YPos, newStructure.XPos);
            lc.SetGroundAtPosition(newGround.stock_id, newGround.YPos, newGround.XPos);
            lc.SaveChanges();

            Assert.AreEqual(newMob.stock_id, lc.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't set the mob correctly");
            Assert.AreEqual(newStructure.stock_id, lc.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't set the structure correctly");
            Assert.AreEqual(newGround.stock_id, lc.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't set the ground correctly");
        }

        [Test]
        public static void TruncatesTablesOnInitialization() {
            LandContext lc = new LandContext();

            Assert.AreEqual(0, lc.LMobLayer.Count(), "LMobLayer table isn't properly truncated upon LandContext initialization");
            Assert.AreEqual(0, lc.LStructureLayer.Count(), "LStructureLayer table isn't properly truncated upon LandContext initialization");
            Assert.AreEqual(0, lc.LGroundLayer.Count(), "LGroungLayer table isn't properly truncated upon LandContext initialization");
        }
    }
}
