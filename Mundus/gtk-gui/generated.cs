
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
				global::Gtk.IconSet w5 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.Blanks.blank.png"));
				w1.Add("blank", w5);
				global::Gtk.IconSet w6 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.Blanks.blank_hand.png"));
				w1.Add("blank_hand", w6);
				global::Gtk.IconSet w7 = new global::Gtk.IconSet(global::Gdk.Pixbuf.LoadFromResource("Mundus.Icons.Blanks.blank_gear.png"));
				w1.Add("blank_gear", w7);
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
