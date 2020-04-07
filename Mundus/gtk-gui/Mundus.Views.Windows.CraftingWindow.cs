
// This file has been generated by the GUI designer. Do not modify.
namespace Mundus.Views.Windows
{
	public partial class CraftingWindow
	{
		private global::Gtk.Table tbUI;

		private global::Gtk.Button btnCraft;

		private global::Gtk.Button btnNext;

		private global::Gtk.Button btnPrev;

		private global::Gtk.Image imgI1;

		private global::Gtk.Image imgI2;

		private global::Gtk.Image imgI3;

		private global::Gtk.Image imgI4;

		private global::Gtk.Image imgI5;

		private global::Gtk.Image imgItem;

		private global::Gtk.Image imgM1;

		private global::Gtk.Image imgM2;

		private global::Gtk.Image imgM3;

		private global::Gtk.Image imgM4;

		private global::Gtk.Image imgM5;

		private global::Gtk.Label lblBlank1;

		private global::Gtk.Label lblBlank2;

		private global::Gtk.Label lblBlank3;

		private global::Gtk.Label lblBlank4;

		private global::Gtk.Label lblBlank5;

		private global::Gtk.Label lblBlank6;

		private global::Gtk.Label lblBlank7;

		private global::Gtk.Label lblC1;

		private global::Gtk.Label lblC2;

		private global::Gtk.Label lblC3;

		private global::Gtk.Label lblC4;

		private global::Gtk.Label lblC5;

		private global::Gtk.Label lblInfo;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Mundus.Views.Windows.CraftingWindow
			this.Name = "Mundus.Views.Windows.CraftingWindow";
			this.Title = "CraftingWindow";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Mundus.Views.Windows.CraftingWindow.Gtk.Container+ContainerChild
			this.tbUI = new global::Gtk.Table(((uint)(11)), ((uint)(7)), false);
			this.tbUI.Name = "tbUI";
			// Container child tbUI.Gtk.Table+TableChild
			this.btnCraft = new global::Gtk.Button();
			this.btnCraft.HeightRequest = 50;
			this.btnCraft.Sensitive = false;
			this.btnCraft.CanFocus = true;
			this.btnCraft.Name = "btnCraft";
			this.btnCraft.UseUnderline = true;
			this.btnCraft.Label = "Craft";
			this.tbUI.Add(this.btnCraft);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.tbUI[this.btnCraft]));
			w1.TopAttach = ((uint)(9));
			w1.BottomAttach = ((uint)(10));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(6));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.btnNext = new global::Gtk.Button();
			this.btnNext.Sensitive = false;
			this.btnNext.CanFocus = true;
			this.btnNext.Name = "btnNext";
			this.btnNext.UseUnderline = true;
			this.btnNext.Label = "Next";
			this.tbUI.Add(this.btnNext);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.tbUI[this.btnNext]));
			w2.TopAttach = ((uint)(7));
			w2.BottomAttach = ((uint)(8));
			w2.LeftAttach = ((uint)(4));
			w2.RightAttach = ((uint)(5));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.btnPrev = new global::Gtk.Button();
			this.btnPrev.WidthRequest = 50;
			this.btnPrev.HeightRequest = 50;
			this.btnPrev.Sensitive = false;
			this.btnPrev.CanFocus = true;
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.UseUnderline = true;
			this.btnPrev.Label = "Prev";
			this.tbUI.Add(this.btnPrev);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.tbUI[this.btnPrev]));
			w3.TopAttach = ((uint)(7));
			w3.BottomAttach = ((uint)(8));
			w3.LeftAttach = ((uint)(2));
			w3.RightAttach = ((uint)(3));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.imgI1 = new global::Gtk.Image();
			this.imgI1.WidthRequest = 50;
			this.imgI1.HeightRequest = 50;
			this.imgI1.Name = "imgI1";
			this.tbUI.Add(this.imgI1);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.tbUI[this.imgI1]));
			w4.TopAttach = ((uint)(1));
			w4.BottomAttach = ((uint)(2));
			w4.LeftAttach = ((uint)(4));
			w4.RightAttach = ((uint)(5));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.imgI2 = new global::Gtk.Image();
			this.imgI2.WidthRequest = 50;
			this.imgI2.HeightRequest = 50;
			this.imgI2.Name = "imgI2";
			this.tbUI.Add(this.imgI2);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.tbUI[this.imgI2]));
			w5.TopAttach = ((uint)(2));
			w5.BottomAttach = ((uint)(3));
			w5.LeftAttach = ((uint)(4));
			w5.RightAttach = ((uint)(5));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.imgI3 = new global::Gtk.Image();
			this.imgI3.WidthRequest = 50;
			this.imgI3.HeightRequest = 50;
			this.imgI3.Name = "imgI3";
			this.tbUI.Add(this.imgI3);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.tbUI[this.imgI3]));
			w6.TopAttach = ((uint)(3));
			w6.BottomAttach = ((uint)(4));
			w6.LeftAttach = ((uint)(4));
			w6.RightAttach = ((uint)(5));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.imgI4 = new global::Gtk.Image();
			this.imgI4.WidthRequest = 50;
			this.imgI4.HeightRequest = 50;
			this.imgI4.Name = "imgI4";
			this.tbUI.Add(this.imgI4);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.tbUI[this.imgI4]));
			w7.TopAttach = ((uint)(4));
			w7.BottomAttach = ((uint)(5));
			w7.LeftAttach = ((uint)(4));
			w7.RightAttach = ((uint)(5));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.imgI5 = new global::Gtk.Image();
			this.imgI5.WidthRequest = 50;
			this.imgI5.HeightRequest = 50;
			this.imgI5.Name = "imgI5";
			this.tbUI.Add(this.imgI5);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.tbUI[this.imgI5]));
			w8.TopAttach = ((uint)(5));
			w8.BottomAttach = ((uint)(6));
			w8.LeftAttach = ((uint)(4));
			w8.RightAttach = ((uint)(5));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.imgItem = new global::Gtk.Image();
			this.imgItem.WidthRequest = 50;
			this.imgItem.HeightRequest = 50;
			this.imgItem.Name = "imgItem";
			this.tbUI.Add(this.imgItem);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.tbUI[this.imgItem]));
			w9.TopAttach = ((uint)(7));
			w9.BottomAttach = ((uint)(8));
			w9.LeftAttach = ((uint)(3));
			w9.RightAttach = ((uint)(4));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.imgM1 = new global::Gtk.Image();
			this.imgM1.WidthRequest = 50;
			this.imgM1.HeightRequest = 50;
			this.imgM1.Name = "imgM1";
			this.imgM1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "blank_multiplication", global::Gtk.IconSize.Dnd);
			this.tbUI.Add(this.imgM1);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.tbUI[this.imgM1]));
			w10.TopAttach = ((uint)(1));
			w10.BottomAttach = ((uint)(2));
			w10.LeftAttach = ((uint)(3));
			w10.RightAttach = ((uint)(4));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.imgM2 = new global::Gtk.Image();
			this.imgM2.WidthRequest = 50;
			this.imgM2.HeightRequest = 50;
			this.imgM2.Name = "imgM2";
			this.imgM2.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "blank_multiplication", global::Gtk.IconSize.Dnd);
			this.tbUI.Add(this.imgM2);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.tbUI[this.imgM2]));
			w11.TopAttach = ((uint)(2));
			w11.BottomAttach = ((uint)(3));
			w11.LeftAttach = ((uint)(3));
			w11.RightAttach = ((uint)(4));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.imgM3 = new global::Gtk.Image();
			this.imgM3.WidthRequest = 50;
			this.imgM3.HeightRequest = 50;
			this.imgM3.Name = "imgM3";
			this.imgM3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "blank_multiplication", global::Gtk.IconSize.Dnd);
			this.tbUI.Add(this.imgM3);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.tbUI[this.imgM3]));
			w12.TopAttach = ((uint)(3));
			w12.BottomAttach = ((uint)(4));
			w12.LeftAttach = ((uint)(3));
			w12.RightAttach = ((uint)(4));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.imgM4 = new global::Gtk.Image();
			this.imgM4.WidthRequest = 50;
			this.imgM4.HeightRequest = 50;
			this.imgM4.Name = "imgM4";
			this.imgM4.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "blank_multiplication", global::Gtk.IconSize.Dnd);
			this.tbUI.Add(this.imgM4);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.tbUI[this.imgM4]));
			w13.TopAttach = ((uint)(4));
			w13.BottomAttach = ((uint)(5));
			w13.LeftAttach = ((uint)(3));
			w13.RightAttach = ((uint)(4));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.imgM5 = new global::Gtk.Image();
			this.imgM5.WidthRequest = 50;
			this.imgM5.HeightRequest = 50;
			this.imgM5.Name = "imgM5";
			this.imgM5.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "blank_multiplication", global::Gtk.IconSize.Dnd);
			this.tbUI.Add(this.imgM5);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.tbUI[this.imgM5]));
			w14.TopAttach = ((uint)(5));
			w14.BottomAttach = ((uint)(6));
			w14.LeftAttach = ((uint)(3));
			w14.RightAttach = ((uint)(4));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblBlank1 = new global::Gtk.Label();
			this.lblBlank1.WidthRequest = 10;
			this.lblBlank1.HeightRequest = 50;
			this.lblBlank1.Name = "lblBlank1";
			this.tbUI.Add(this.lblBlank1);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblBlank1]));
			w15.TopAttach = ((uint)(5));
			w15.BottomAttach = ((uint)(6));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblBlank2 = new global::Gtk.Label();
			this.lblBlank2.WidthRequest = 10;
			this.lblBlank2.HeightRequest = 50;
			this.lblBlank2.Name = "lblBlank2";
			this.tbUI.Add(this.lblBlank2);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblBlank2]));
			w16.TopAttach = ((uint)(5));
			w16.BottomAttach = ((uint)(6));
			w16.LeftAttach = ((uint)(6));
			w16.RightAttach = ((uint)(7));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblBlank3 = new global::Gtk.Label();
			this.lblBlank3.WidthRequest = 50;
			this.lblBlank3.HeightRequest = 10;
			this.lblBlank3.Name = "lblBlank3";
			this.tbUI.Add(this.lblBlank3);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblBlank3]));
			w17.LeftAttach = ((uint)(3));
			w17.RightAttach = ((uint)(4));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblBlank4 = new global::Gtk.Label();
			this.lblBlank4.WidthRequest = 50;
			this.lblBlank4.HeightRequest = 10;
			this.lblBlank4.Name = "lblBlank4";
			this.tbUI.Add(this.lblBlank4);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblBlank4]));
			w18.TopAttach = ((uint)(10));
			w18.BottomAttach = ((uint)(11));
			w18.LeftAttach = ((uint)(3));
			w18.RightAttach = ((uint)(4));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblBlank5 = new global::Gtk.Label();
			this.lblBlank5.WidthRequest = 50;
			this.lblBlank5.HeightRequest = 50;
			this.lblBlank5.Name = "lblBlank5";
			this.tbUI.Add(this.lblBlank5);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblBlank5]));
			w19.TopAttach = ((uint)(5));
			w19.BottomAttach = ((uint)(6));
			w19.LeftAttach = ((uint)(1));
			w19.RightAttach = ((uint)(2));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblBlank6 = new global::Gtk.Label();
			this.lblBlank6.WidthRequest = 50;
			this.lblBlank6.HeightRequest = 50;
			this.lblBlank6.Name = "lblBlank6";
			this.tbUI.Add(this.lblBlank6);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblBlank6]));
			w20.TopAttach = ((uint)(5));
			w20.BottomAttach = ((uint)(6));
			w20.LeftAttach = ((uint)(5));
			w20.RightAttach = ((uint)(6));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblBlank7 = new global::Gtk.Label();
			this.lblBlank7.WidthRequest = 50;
			this.lblBlank7.HeightRequest = 50;
			this.lblBlank7.Name = "lblBlank7";
			this.tbUI.Add(this.lblBlank7);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblBlank7]));
			w21.TopAttach = ((uint)(6));
			w21.BottomAttach = ((uint)(7));
			w21.LeftAttach = ((uint)(3));
			w21.RightAttach = ((uint)(4));
			w21.XOptions = ((global::Gtk.AttachOptions)(4));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblC1 = new global::Gtk.Label();
			this.lblC1.Name = "lblC1";
			this.lblC1.LabelProp = "0";
			this.lblC1.Justify = ((global::Gtk.Justification)(2));
			this.tbUI.Add(this.lblC1);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblC1]));
			w22.TopAttach = ((uint)(1));
			w22.BottomAttach = ((uint)(2));
			w22.LeftAttach = ((uint)(2));
			w22.RightAttach = ((uint)(3));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblC2 = new global::Gtk.Label();
			this.lblC2.Name = "lblC2";
			this.lblC2.LabelProp = "0";
			this.lblC2.Justify = ((global::Gtk.Justification)(2));
			this.tbUI.Add(this.lblC2);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblC2]));
			w23.TopAttach = ((uint)(2));
			w23.BottomAttach = ((uint)(3));
			w23.LeftAttach = ((uint)(2));
			w23.RightAttach = ((uint)(3));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblC3 = new global::Gtk.Label();
			this.lblC3.Name = "lblC3";
			this.lblC3.LabelProp = "0";
			this.tbUI.Add(this.lblC3);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblC3]));
			w24.TopAttach = ((uint)(3));
			w24.BottomAttach = ((uint)(4));
			w24.LeftAttach = ((uint)(2));
			w24.RightAttach = ((uint)(3));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblC4 = new global::Gtk.Label();
			this.lblC4.Name = "lblC4";
			this.lblC4.LabelProp = "0";
			this.lblC4.Justify = ((global::Gtk.Justification)(2));
			this.tbUI.Add(this.lblC4);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblC4]));
			w25.TopAttach = ((uint)(4));
			w25.BottomAttach = ((uint)(5));
			w25.LeftAttach = ((uint)(2));
			w25.RightAttach = ((uint)(3));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblC5 = new global::Gtk.Label();
			this.lblC5.Name = "lblC5";
			this.lblC5.LabelProp = "0";
			this.lblC5.Justify = ((global::Gtk.Justification)(2));
			this.tbUI.Add(this.lblC5);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblC5]));
			w26.TopAttach = ((uint)(5));
			w26.BottomAttach = ((uint)(6));
			w26.LeftAttach = ((uint)(2));
			w26.RightAttach = ((uint)(3));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tbUI.Gtk.Table+TableChild
			this.lblInfo = new global::Gtk.Label();
			this.lblInfo.WidthRequest = 250;
			this.lblInfo.HeightRequest = 50;
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Justify = ((global::Gtk.Justification)(2));
			this.tbUI.Add(this.lblInfo);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.tbUI[this.lblInfo]));
			w27.TopAttach = ((uint)(8));
			w27.BottomAttach = ((uint)(9));
			w27.LeftAttach = ((uint)(1));
			w27.RightAttach = ((uint)(6));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.tbUI);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 270;
			this.DefaultHeight = 470;
			this.Show();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
			this.btnPrev.Clicked += new global::System.EventHandler(this.OnBtnPrevClicked);
			this.btnNext.Clicked += new global::System.EventHandler(this.OnBtnNextClicked);
			this.btnCraft.Clicked += new global::System.EventHandler(this.OnBtnCraftClicked);
		}
	}
}
