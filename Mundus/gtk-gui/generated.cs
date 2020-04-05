
// This file has been generated by the GUI designer. Do not modify.
namespace Stetic
{
	internal class Gui
	{
		private static bool initialized;

		internal static void Initialize(Gtk.Widget iconRenderer)
		{
			if ((Stetic.Gui.initialized == false))
			{
				Stetic.Gui.initialized = true;
				global::Gtk.IconFactory w1 = new global::Gtk.IconFactory();
				global::Gtk.IconSet w2 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.Land.Ground.grass.png"));
				w1.Add("grass", w2);
				global::Gtk.IconSet w3 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.Land.Items.boulder.png"));
				w1.Add("boulder", w3);
				global::Gtk.IconSet w4 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.player.png"));
				w1.Add("player", w4);
				global::Gtk.IconSet w5 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.UI.Blanks.blank.png"));
				w1.Add("blank", w5);
				global::Gtk.IconSet w6 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.UI.Blanks.blank_hand.png"));
				w1.Add("blank_hand", w6);
				global::Gtk.IconSet w7 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.UI.Blanks.blank_gear.png"));
				w1.Add("blank_gear", w7);
				global::Gtk.IconSet w8 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.Land.Materials.land_rock.png"));
				w1.Add("land_rock", w8);
				global::Gtk.IconSet w9 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.Land.Items.tree.png"));
				w1.Add("tree", w9);
				global::Gtk.IconSet w10 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.Land.Ground.water.png"));
				w1.Add("water", w10);
				global::Gtk.IconSet w11 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.UI.Blanks.empty.png"));
				w1.Add("empty", w11);
				global::Gtk.IconSet w12 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.UI.Hearth.4-4.png"));
				w1.Add("hearth_4-4", w12);
				global::Gtk.IconSet w13 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.UI.Hearth.3-4.png"));
				w1.Add("hearth_3-4", w13);
				global::Gtk.IconSet w14 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.UI.Hearth.2-4.png"));
				w1.Add("hearth_2-4", w14);
				global::Gtk.IconSet w15 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.UI.Hearth.1-4.png"));
				w1.Add("hearth_1-4", w15);
				global::Gtk.IconSet w16 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.Land.Materials.stick.png"));
				w1.Add("stick", w16);
				global::Gtk.IconSet w17 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.Land.Tools.stone_pickaxe.png"));
				w1.Add("stone_pickaxe", w17);
				w1.AddDefault();
			}
		}
	}

	internal class ActionGroups
	{
		public static Gtk.ActionGroup GetActionGroup(System.Type type)
		{
			return Stetic.ActionGroups.GetActionGroup(type.FullName);
		}

		public static Gtk.ActionGroup GetActionGroup(string name)
		{
			return null;
		}
	}
}
