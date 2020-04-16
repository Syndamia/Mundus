
// This file has been generated by the GUI designer. Do not modify.
namespace Mundus.Views.Windows
{
	public partial class SettingsWindow
	{
		private global::Gtk.Table tbUI;

		private global::Gtk.HSeparator hSeparator;

		private global::Gtk.Label lblBlank1;

		private global::Gtk.Label lblBlank3;

		private global::Gtk.Label lblBlank4;

		private global::Gtk.Label lblBlank5;

		private global::Gtk.Label lblTitle;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Mundus.Views.Windows.SettingsWindow
			this.Name = "Mundus.Views.Windows.SettingsWindow";
			this.Title = "Settings";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Resizable = false;
			this.AllowGrow = false;
			// Container child Mundus.Views.Windows.SettingsWindow.Gtk.Container+ContainerChild
			this.tbUI = new global::Gtk.Table(((uint)(4)), ((uint)(6)), false);
			this.tbUI.Name = "tbUI";
			this.tbUI.RowSpacing = ((uint)(3));
			this.tbUI.ColumnSpacing = ((uint)(3));
			// Container child tbUI.Gtk.Table+TableChild
			this.hSeparator = new global::Gtk.HSeparator();
			this.hSeparator.HeightRequest = 5;
			this.hSeparator.Name = "hSeparator";
			this.tbUI.Add(this.hSeparator);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.tbUI[this.hSeparator]));
			w1.TopAttach = ((uint)(1));
			w1.BottomAttach = ((uint)(2));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(5));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblBlank1 = new global::Gtk.Label();
			this.lblBlank1.WidthRequest = 40;
			this.lblBlank1.Name = "lblBlank1";
			this.tbUI.Add(this.lblBlank1);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblBlank1]));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblBlank3 = new global::Gtk.Label();
			this.lblBlank3.WidthRequest = 40;
			this.lblBlank3.Name = "lblBlank3";
			this.tbUI.Add(this.lblBlank3);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblBlank3]));
			w3.LeftAttach = ((uint)(4));
			w3.RightAttach = ((uint)(5));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblBlank4 = new global::Gtk.Label();
			this.lblBlank4.WidthRequest = 5;
			this.lblBlank4.HeightRequest = 50;
			this.lblBlank4.Name = "lblBlank4";
			this.tbUI.Add(this.lblBlank4);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblBlank4]));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblBlank5 = new global::Gtk.Label();
			this.lblBlank5.WidthRequest = 5;
			this.lblBlank5.HeightRequest = 50;
			this.lblBlank5.Name = "lblBlank5";
			this.tbUI.Add(this.lblBlank5);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblBlank5]));
			w5.LeftAttach = ((uint)(5));
			w5.RightAttach = ((uint)(6));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblTitle = new global::Gtk.Label();
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.LabelProp = "Settings (replace with picture)";
			this.tbUI.Add(this.lblTitle);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblTitle]));
			w6.LeftAttach = ((uint)(2));
			w6.RightAttach = ((uint)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.tbUI);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 333;
			this.DefaultHeight = 300;
			this.Show();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		}
	}
}
