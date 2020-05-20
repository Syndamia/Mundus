namespace MundusTests.DataTests.SuperLayers 
{
    using System.Linq;
    using Mundus.Data;
    using Mundus.Data.SuperLayers;
    using Mundus.Data.SuperLayers.DBTables;
    using NUnit.Framework;

    [TestFixture]
    public static class LandContextTests 
    {
        [Test]
        public static void AddsCorrectValues() 
        {
            var mob = new LMPlacedTile("mob_stock", 0, 1000, 1000);
            var structure = new LSPlacedTile("structure_stock", 0, 2000, 1000);
            var ground = new LGPlacedTile("ground_stock", 3000, 4000);

             

             DataBaseContexts.LContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
             DataBaseContexts.LContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
             DataBaseContexts.LContext.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
             DataBaseContexts.LContext.SaveChanges();

            Assert.AreEqual(mob.stock_id,  DataBaseContexts.LContext.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't add the mob correctly");
            Assert.AreEqual(structure.stock_id,  DataBaseContexts.LContext.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't add the structure correctly");
            Assert.AreEqual(ground.stock_id,  DataBaseContexts.LContext.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't add the ground correctly");
        }

        [Test]
        public static void ConsideredAliveAfterSmallDamage() 
        {
            var mob = new LMPlacedTile("mob_stock", 10, 1000, 1001);
            var structure = new LSPlacedTile("structure_stock", 4, 2000, 1001);

             

             DataBaseContexts.LContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
             DataBaseContexts.LContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
             DataBaseContexts.LContext.SaveChanges();

            Assert.IsTrue( DataBaseContexts.LContext.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 1), "Mob is considered dead (health <= 0), but it shouldnt be");
            Assert.IsTrue( DataBaseContexts.LContext.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 1), "Structure is considered dead (health <= 0), but it shouldn't be");
        }

        [Test]
        public static void ConsideredDeadAfterBigDamage() 
        {
            var mob = new LMPlacedTile("mob_stock", 10, 1000, 1000);
            var structure = new LSPlacedTile("structure_stock", 4, 2000, 1000);

             

             DataBaseContexts.LContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
             DataBaseContexts.LContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
             DataBaseContexts.LContext.SaveChanges();

            Assert.IsFalse( DataBaseContexts.LContext.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 20), "Mob is considered alive (health > 0), but it shouldnt be");
            Assert.IsFalse( DataBaseContexts.LContext.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 20), "Structure is considered alive (health > 0), but it shouldn't be");
        }

        [Test]
        public static void DamagesCorrectly() 
        {
            var mob = new LMPlacedTile("mob_stock", 10, 1000, 1002);
            var structure = new LSPlacedTile("structure_stock", 4, 2000, 1002);

             DataBaseContexts.LContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
             DataBaseContexts.LContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
             DataBaseContexts.LContext.SaveChanges();

             DataBaseContexts.LContext.TakeDamageMobAtPosition(mob.YPos, mob.XPos, 3);
             DataBaseContexts.LContext.TakeDamageStructureAtPosition(structure.YPos, structure.XPos, 1);

            Assert.AreEqual(7,  DataBaseContexts.LContext.LMobLayer.First(x => x.YPos == mob.YPos && x.XPos == mob.XPos).Health, "Mobs recieve incorrect amount of damage");
            Assert.AreEqual(3,  DataBaseContexts.LContext.LStructureLayer.First(x => x.YPos == structure.YPos && x.XPos == structure.XPos).Health, "Structures recieve incorrect amount of damage");
        }

        [Test]
        public static void GetsCorrectStocks() 
        {
            var mob = new LMPlacedTile("mob_stock", 0, 1000, 1000);
            var structure = new LSPlacedTile("structure_stock", 0, 2000, 1000);
            var ground = new LGPlacedTile("ground_stock", 3000, 4000);

             

             DataBaseContexts.LContext.LMobLayer.Add(mob);
             DataBaseContexts.LContext.LStructureLayer.Add(structure);
             DataBaseContexts.LContext.LGroundLayer.Add(ground);
             DataBaseContexts.LContext.SaveChanges();

            Assert.AreEqual(mob.stock_id,  DataBaseContexts.LContext.GetMobLayerStock(mob.YPos, mob.XPos), "Doesn't get the correct mob layer stock");
            Assert.AreEqual(structure.stock_id,  DataBaseContexts.LContext.GetStructureLayerStock(structure.YPos,structure.XPos), "Doesn't get the correct structure layer stock");
            Assert.AreEqual(ground.stock_id,  DataBaseContexts.LContext.GetGroundLayerStock(ground.YPos, ground.XPos), "Doesn't get the correct ground layer stock");
        }

        [Test]
        public static void RemovesCorrectValues() 
        {
            var mob = new LMPlacedTile("mob_stock", 0, 1000, 1000);
            var structure = new LSPlacedTile("structure_stock", 0, 2000, 1000);
            var ground = new LGPlacedTile("ground_stock", 3000, 4000);

             

             DataBaseContexts.LContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
             DataBaseContexts.LContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
             DataBaseContexts.LContext.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
             DataBaseContexts.LContext.SaveChanges();

             DataBaseContexts.LContext.RemoveMobFromPosition(mob.YPos, mob.XPos);
             DataBaseContexts.LContext.RemoveStructureFromPosition(structure.YPos, structure.XPos);
             DataBaseContexts.LContext.RemoveGroundFromPosition(ground.YPos, ground.XPos);
             DataBaseContexts.LContext.SaveChanges();

            Assert.AreEqual(null,  DataBaseContexts.LContext.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't remove the mob correctly");
            Assert.AreEqual(null,  DataBaseContexts.LContext.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't remove the structure correctly");
            Assert.AreEqual(null,  DataBaseContexts.LContext.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't remove the ground correctly");
        }


        [Test]
        public static void SetsCorrectValues() 
        {
            var mob = new LMPlacedTile("mob_stock", 0, 1000, 1000);
            var newMob = new LMPlacedTile("new_mob_stock", 1, 1000, 1000);
            var structure = new LSPlacedTile("structure_stock", 0, 2000, 1000);
            var newStructure = new LSPlacedTile("new_structure_stock", 1, 2000, 1000);
            var ground = new LGPlacedTile("ground_stock", 3000, 4000);
            var newGround = new LGPlacedTile("new_ground_stock", 3000, 4000);

             

             DataBaseContexts.LContext.AddMobAtPosition(mob.stock_id, mob.Health, mob.YPos, mob.XPos);
             DataBaseContexts.LContext.AddStructureAtPosition(structure.stock_id, structure.Health, structure.YPos, structure.XPos);
             DataBaseContexts.LContext.AddGroundAtPosition(ground.stock_id, ground.YPos, ground.XPos);
             DataBaseContexts.LContext.SaveChanges();

             DataBaseContexts.LContext.SetMobAtPosition(newMob.stock_id, newMob.Health, newMob.YPos, newMob.XPos);
             DataBaseContexts.LContext.SetStructureAtPosition(newStructure.stock_id, newStructure.Health, newStructure.YPos, newStructure.XPos);
             DataBaseContexts.LContext.SetGroundAtPosition(newGround.stock_id, newGround.YPos, newGround.XPos);
             DataBaseContexts.LContext.SaveChanges();

            Assert.AreEqual(newMob.stock_id,  DataBaseContexts.LContext.GetMobLayerStock(mob.YPos, mob.XPos), "Didn't set the mob correctly");
            Assert.AreEqual(newStructure.stock_id,  DataBaseContexts.LContext.GetStructureLayerStock(structure.YPos, structure.XPos), "Didn't set the structure correctly");
            Assert.AreEqual(newGround.stock_id,  DataBaseContexts.LContext.GetGroundLayerStock(ground.YPos, ground.XPos), "Didn't set the ground correctly");
        }

        //[Test]
        //public static void TruncatesTablesOnInitialization() 
        //{
             

        //    Assert.AreEqual(0,  DataBaseContexts.LContext.LMobLayer.Count(), "LMobLayer table isn't properly truncated upon LandContext initialization");
        //    Assert.AreEqual(0,  DataBaseContexts.LContext.LStructureLayer.Count(), "LStructureLayer table isn't properly truncated upon LandContext initialization");
        //    Assert.AreEqual(0,  DataBaseContexts.LContext.LGroundLayer.Count(), "LGroungLayer table isn't properly truncated upon LandContext initialization");
        //}
    }
}
