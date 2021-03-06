
// This file has been generated by the GUI designer. Do not modify.
public partial class MainWindow
{
	private global::Gtk.Frame frame2;
	private global::Gtk.Alignment GtkAlignment;
	private global::Gtk.Fixed fixed1;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.NodeView nodeview2;
	private global::Gtk.Button button4;
	private global::Gtk.FileChooserButton filechooserbutton3;
	private global::Gtk.Label speedLabel;
	private global::Gtk.Label label2;
	private global::Gtk.ProgressBar progressbar1;
	private global::Gtk.Label GtkLabel2;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("Frisby Toss");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.frame2 = new global::Gtk.Frame ();
		this.frame2.HeightRequest = 500;
		this.frame2.Name = "frame2";
		this.frame2.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child frame2.Gtk.Container+ContainerChild
		this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment.Name = "GtkAlignment";
		this.GtkAlignment.LeftPadding = ((uint)(12));
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		this.fixed1 = new global::Gtk.Fixed ();
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.nodeview2 = new global::Gtk.NodeView ();
		this.nodeview2.WidthRequest = 650;
		this.nodeview2.HeightRequest = 350;
		this.nodeview2.CanFocus = true;
		this.nodeview2.Name = "nodeview2";
		this.GtkScrolledWindow.Add (this.nodeview2);
		this.fixed1.Add (this.GtkScrolledWindow);
		global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.GtkScrolledWindow]));
		w2.X = -6;
		w2.Y = 6;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.button4 = new global::Gtk.Button ();
		this.button4.WidthRequest = 101;
		this.button4.CanFocus = true;
		this.button4.Name = "button4";
		this.button4.UseUnderline = true;
		this.button4.Label = global::Mono.Unix.Catalog.GetString ("Run Tests");
		this.fixed1.Add (this.button4);
		global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.button4]));
		w3.X = 545;
		w3.Y = 425;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.filechooserbutton3 = new global::Gtk.FileChooserButton (global::Mono.Unix.Catalog.GetString ("Choose Test Folder"), ((global::Gtk.FileChooserAction)(2)));
		this.filechooserbutton3.WidthRequest = 180;
		this.filechooserbutton3.Name = "filechooserbutton3";
		this.fixed1.Add (this.filechooserbutton3);
		global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.filechooserbutton3]));
		w4.X = 5;
		w4.Y = 425;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.speedLabel = new global::Gtk.Label ();
		this.speedLabel.Name = "speedLabel";
		this.fixed1.Add (this.speedLabel);
		global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.speedLabel]));
		w5.X = 20;
		w5.Y = 381;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.label2 = new global::Gtk.Label ();
		this.label2.Name = "label2";
		this.fixed1.Add (this.label2);
		global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label2]));
		w6.X = 20;
		w6.Y = 403;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.progressbar1 = new global::Gtk.ProgressBar ();
		this.progressbar1.WidthRequest = 235;
		this.progressbar1.HeightRequest = 25;
		this.progressbar1.Name = "progressbar1";
		this.fixed1.Add (this.progressbar1);
		global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.progressbar1]));
		w7.X = 221;
		w7.Y = 158;
		this.GtkAlignment.Add (this.fixed1);
		this.frame2.Add (this.GtkAlignment);
		this.GtkLabel2 = new global::Gtk.Label ();
		this.GtkLabel2.Name = "GtkLabel2";
		this.GtkLabel2.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Toss The Frisby</b>");
		this.GtkLabel2.UseMarkup = true;
		this.frame2.LabelWidget = this.GtkLabel2;
		this.Add (this.frame2);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 688;
		this.DefaultHeight = 500;
		this.progressbar1.Hide ();
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.button4.Clicked += new global::System.EventHandler (this.run_tests);
	}
}
