
// This file has been generated by the GUI designer. Do not modify.
namespace Mundus.Views.Windows
{
	public partial class MainWindow
	{
		private global::Gtk.VBox vboxUI;

		private global::Gtk.Label lblTitle;

		private global::Gtk.Label lblBuild;

		private global::Gtk.HSeparator hSeparator;

		private global::Gtk.Button btnLoadGame;

		private global::Gtk.Button btnNewGame;

		private global::Gtk.Button btnTutorial;

		private global::Gtk.Button btnSettings;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Mundus.Views.Windows.MainWindow
			this.Name = "Mundus.Views.Windows.MainWindow";
			this.Title = "Mundus";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Resizable = false;
			this.AllowGrow = false;
			// Container child Mundus.Views.Windows.MainWindow.Gtk.Container+ContainerChild
			this.vboxUI = new global::Gtk.VBox();
			this.vboxUI.Name = "vboxUI";
			// Container child vboxUI.Gtk.Box+BoxChild
			this.lblTitle = new global::Gtk.Label();
			this.lblTitle.WidthRequest = 300;
			this.lblTitle.HeightRequest = 100;
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.LabelProp = "Mundus (replace with picture)";
			this.lblTitle.Justify = ((global::Gtk.Justification)(3));
			this.vboxUI.Add(this.lblTitle);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vboxUI[this.lblTitle]));
			w1.Position = 0;
			// Container child vboxUI.Gtk.Box+BoxChild
			this.lblBuild = new global::Gtk.Label();
			this.lblBuild.WidthRequest = 300;
			this.lblBuild.HeightRequest = 20;
			this.lblBuild.Name = "lblBuild";
			this.lblBuild.LabelProp = "Build 16-04-2020 No2";
			this.lblBuild.Justify = ((global::Gtk.Justification)(2));
			this.vboxUI.Add(this.lblBuild);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vboxUI[this.lblBuild]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vboxUI.Gtk.Box+BoxChild
			this.hSeparator = new global::Gtk.HSeparator();
			this.hSeparator.HeightRequest = 5;
			this.hSeparator.Name = "hSeparator";
			this.vboxUI.Add(this.hSeparator);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vboxUI[this.hSeparator]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vboxUI.Gtk.Box+BoxChild
			this.btnLoadGame = new global::Gtk.Button();
			this.btnLoadGame.WidthRequest = 300;
			this.btnLoadGame.HeightRequest = 90;
			this.btnLoadGame.CanFocus = true;
			this.btnLoadGame.Name = "btnLoadGame";
			this.btnLoadGame.UseUnderline = true;
			this.btnLoadGame.Xalign = 0.49F;
			this.btnLoadGame.BorderWidth = ((uint)(7));
			this.btnLoadGame.Label = "Load Game";
			this.vboxUI.Add(this.btnLoadGame);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vboxUI[this.btnLoadGame]));
			w4.Position = 3;
			// Container child vboxUI.Gtk.Box+BoxChild
			this.btnNewGame = new global::Gtk.Button();
			this.btnNewGame.WidthRequest = 300;
			this.btnNewGame.HeightRequest = 90;
			this.btnNewGame.CanFocus = true;
			this.btnNewGame.Name = "btnNewGame";
			this.btnNewGame.UseUnderline = true;
			this.btnNewGame.BorderWidth = ((uint)(7));
			this.btnNewGame.Label = "New Game";
			this.vboxUI.Add(this.btnNewGame);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vboxUI[this.btnNewGame]));
			w5.Position = 4;
			// Container child vboxUI.Gtk.Box+BoxChild
			this.btnTutorial = new global::Gtk.Button();
			this.btnTutorial.WidthRequest = 300;
			this.btnTutorial.HeightRequest = 90;
			this.btnTutorial.CanFocus = true;
			this.btnTutorial.Name = "btnTutorial";
			this.btnTutorial.UseUnderline = true;
			this.btnTutorial.BorderWidth = ((uint)(7));
			this.btnTutorial.Label = "Tutorial";
			this.vboxUI.Add(this.btnTutorial);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vboxUI[this.btnTutorial]));
			w6.Position = 5;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vboxUI.Gtk.Box+BoxChild
			this.btnSettings = new global::Gtk.Button();
			this.btnSettings.WidthRequest = 300;
			this.btnSettings.HeightRequest = 90;
			this.btnSettings.CanFocus = true;
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.UseUnderline = true;
			this.btnSettings.BorderWidth = ((uint)(7));
			this.btnSettings.Label = "Settings";
			this.vboxUI.Add(this.btnSettings);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vboxUI[this.btnSettings]));
			w7.Position = 6;
			w7.Expand = false;
			w7.Fill = false;
			this.Add(this.vboxUI);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 300;
			this.DefaultHeight = 485;
			this.Show();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
			this.btnNewGame.Clicked += new global::System.EventHandler(this.OnBtnNewGameClicked);
			this.btnTutorial.Clicked += new global::System.EventHandler(this.OnBtnTutorialClicked);
			this.btnSettings.Clicked += new global::System.EventHandler(this.OnBtnSettingsClicked);
		}
	}
}
