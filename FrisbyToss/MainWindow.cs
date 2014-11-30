using System;
using Gtk;
using FrisbyToss;
using System.Threading;
using System.Threading.Tasks;

public partial class MainWindow: Gtk.Window
{	
	private readonly string TestRunCMD = @"jasmine-node --verbose {0}";
	private readonly string SpeedLbl = @"Speed (ms): {0}";

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		ThreadPool.SetMinThreads (5, 5);
		Build ();
	}

	protected void run_tests (object sender, EventArgs e)
	{
		Task.Factory.StartNew (() => { 
			return  new FrisbyRunner ().RunFrisby (this.filechooserbutton3.Filename); 
		}).ContinueWith (t => { 
			var tests = new Tests(t.Result); 
			speedLabel.Text = string.Format(SpeedLbl, tests.TotalTime());
			nodeview2.NodeStore = tests.ToStore();
			nodeview2.AppendColumn ("Title", new Gtk.CellRendererText (), "text", 0);
			nodeview2.AppendColumn ("Message", new Gtk.CellRendererText (), "text", 1);
			nodeview2.AppendColumn ("Stack", new Gtk.CellRendererText (), "text", 2);
			nodeview2.ShowAll ();
		});
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
