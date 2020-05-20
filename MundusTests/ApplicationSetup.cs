using Mundus.Data;
using Mundus.Data.Windows;
using NUnit.Framework;
using Gtk;

[SetUpFixture]
public static class ApplicationSetup {
    [OneTimeSetUp]
    public static void SetUp() {
        Application.Init();
        WI.CreateInstances();
        DataBaseContexts.CreateInstances();
        WI.WNewGame.OnBtnGenerateClicked(null, null);
    }

    [OneTimeTearDown]
    public static void TearDown() {
        Application.Quit();
    }
}
