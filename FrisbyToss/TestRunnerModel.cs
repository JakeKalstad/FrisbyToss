using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FrisbyToss
{
	public class Test : Gtk.TreeNode
	{
		public string Speed { get; set; }
		public int MS { get { return Int32.Parse (Regex.Match (Speed, @"\d+").Value ); } }
		[Gtk.TreeNodeValue (Column=0)]
		public string Title { get; set; }
		[Gtk.TreeNodeValue (Column=1)]
		public string Message { get;set; }
		[Gtk.TreeNodeValue (Column=2)]
		public string Stack { get;set; }

		public Test (string data)
		{
			var dashIndx = data.IndexOf ("-");
			Title = data.Substring(12, dashIndx -12);
			Speed = data.Substring (dashIndx + 1, data.IndexOf ("\n") - dashIndx - 2);
			Message = data.Substring(data.IndexOf("\t"), data.Length - data.IndexOf("\t") - 7);
			Stack = "fsd";
		}
	}

	public class Tests : List<Test> 
	{
		public Tests (string data)
		{
			ParseData (data);
		}

		public int TotalTime ()
		{
			return this.Select (t => t.MS).Sum ();
		}

		private void ParseData(string data) {
			List<string> blocks = new List<string>();
			while (data.Length > 0) {
				var lastBlock = -1;
				if (data.StartsWith ("Failures:")) {
					blocks.Add (data);
					break;
				} else {
					lastBlock = data.IndexOf ("\n\n");
				}
				if (lastBlock == -1)
					break;
				var indx = 0;
				if (data.IndexOf ('\n') == 0)
					indx = 1;
				blocks.Add(data.Substring (indx, lastBlock));
				lastBlock += 2;
				data = data.Substring(lastBlock, data.Length - lastBlock);
			}
			blocks.Where(l => !l.StartsWith("Failure")).ToList().ForEach (l => this.Add (new Test(l)));
		}
		private Gtk.NodeStore store;
		private Gtk.NodeStore Store {
			get {
				store = new Gtk.NodeStore (typeof(Test));
				this.ForEach (t => store.AddNode (t));
				return store;
			}
		}

		public Gtk.NodeStore ToStore() {
			return Store;
		}
	}

	public class TestRunnerModel
	{
		public string Folder { get; set; }
		public Tests Tests { get; set; }
		public TestRunnerModel ()
		{

		}
	}
}

