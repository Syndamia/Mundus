using System;
using Mundus.Data;
using Mundus.Data.Windows;
using Mundus.Service.Tiles.Items.Types;
using Mundus.Service.Tiles.Mobs;
using NUnit.Framework;

namespace MundusTests.ServiceTests.Tiles.Mobs {
    [TestFixture]
    public static class MobTileTests {
        [Test]
        public static void InstantiatesProperly() {
            MobTile mob = new MobTile("test", 10, 3, DataBaseContexts.SContext, 7, new Material("test_material"), 9);

            Assert.AreEqual("test", mob.stock_id);
            Assert.AreEqual(10, mob.Health);
            Assert.AreEqual(3, mob.Defense);
            Assert.AreEqual(DataBaseContexts.SContext, mob.CurrSuperLayer);
            Assert.AreEqual(7, mob.Inventory.Hotbar.Length);
            Assert.AreEqual("test_material", mob.DroppedUponDeath.stock_id);
            Assert.AreEqual(9, mob.RndMovementRate);
        }

        [Test]
        [TestCase(10, 3)]
        [TestCase(19, 11)]
        public static void AliveAfterTakingSmallDamage(int health, int damage) {
            MobTile mob = new MobTile("test", health, 3, DataBaseContexts.SContext);

            Assert.IsTrue(mob.TakeDamage(damage));
        }

        [Test]
        [TestCase(10, 10)]
        [TestCase(13, 20)]
        public static void DeadAfterTakingBigDamage(int health, int damage) {
            MobTile mob = new MobTile("test", health, 3, DataBaseContexts.SContext);

            Assert.IsFalse(mob.TakeDamage(damage));
        }

        [Test]
        [TestCase(10, 10)]
        [TestCase(13, 20)]
        public static void HealsProperly(int health, int healByPoints) {
            MobTile mob = new MobTile("test", health, 3, DataBaseContexts.SContext);

            mob.Heal(healByPoints);

            if (health + healByPoints > WI.SelWin.Size * 4) {
                Assert.AreEqual(WI.SelWin.Size, mob.Health);
            }
            else {

                Assert.AreEqual(health + healByPoints, mob.Health);
            }

        }
    }
}
