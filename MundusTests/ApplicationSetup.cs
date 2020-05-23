using Gtk;
using Mundus.Data;
using Mundus.Service.Windows;
using NUnit.Framework;

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
