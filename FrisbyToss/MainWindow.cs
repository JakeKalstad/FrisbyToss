using System;
using Gtk;
using FrisbyToss;
using System.Threading;
using System.Threading.Tasks;

public partial class MainWindow: Gtk.Window
{	
	private readonly string TestRunCMD = @"jasmine-node --verbose {0}";
	private readonly string SpeedLbl = @"Speed (ms): {0}";

	bool progress_timeout()
	{
		double new_val;

		if (progressbar1.Visible)
			progressbar1.Pulse();
		else {
			/* Calculate the value of the progress bar using the
             * value range set in the adjustment object */
			new_val = progressbar1.Fraction + 0.01;
			if (new_val > 1.0)
				new_val = 0.0;

			/* Set the new value */
			progressbar1.Fraction = new_val;
		}

		/* As this is a timeout function, return TRUE so that it
         * continues to get called */

		return true;
	}
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		ThreadPool.SetMinThreads (5, 5);
		Build ();
        
	}

	protected void run_tests (object sender, EventArgs e)
	{
		progressbar1.Visible = true;
		GLib.Timeout.Add(100, new GLib.TimeoutHandler (progress_timeout));
		Task.Factory.StartNew (() => { 
			return  new FrisbyRunner ().RunFrisby (this.filechooserbutton3.Filename); 
		}).ContinueWith (t => {
			progressbar1.Visible = false;
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
