using System;
using Mundus.Data;
using NUnit.Framework;

namespace MundusTests.DataTests {
    [TestFixture]
    public static class DataBaseContextsTests {
        [Test]
        public static void CreatesInstances() {
            DataBaseContexts.CreateInstances();

            Assert.AreNotEqual(null, DataBaseContexts.SContext, "Doesn't create SContext instance");
            Assert.AreNotEqual(null, DataBaseContexts.LContext, "Doesn't create LContext instance");
            Assert.AreNotEqual(null, DataBaseContexts.UContext, "Doesn't create UContext instance");
            Assert.AreNotEqual(null, DataBaseContexts.CTContext, "Doesn't create CTContext instance");
            Assert.AreNotEqual(null, DataBaseContexts.GELContext, "Doesn't create GELContext instance");
            Assert.AreNotEqual(null, DataBaseContexts.SuperLayerContexts, "Doesn't create SuperLayerContexts instance");
        }
    }
}
