using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FrisbyToss
{
	public class Test : Gtk.TreeNode
	{
		public int MS { get { return Int32.Parse (Regex.Match (Speed, @"\d+").Value ); } }
		[Gtk.TreeNodeValue (Column=0)]
		public string Title { get; set; }
		[Gtk.TreeNodeValue (Column=1)]
		public string Message { get;set; }
		[Gtk.TreeNodeValue (Column=2)]
		public string Stack { get;set; }
		[Gtk.TreeNodeValue (Column=3)]
		public bool Passed { get; set; }
		[Gtk.TreeNodeValue (Column=4)]
		public string Speed { get; set; }

		public Test (string data)
		{
			var dashIndx = data.IndexOf ("-");
			Title = data.Substring(12, dashIndx -12).Trim();
			Speed = data.Substring (dashIndx + 1, data.IndexOf ("\n") - dashIndx - 2).Trim();
			Message = data.Substring(data.IndexOf("\t"), data.Length - data.IndexOf("\t") - 7).Trim();
			//Stack = data.Substring(data.IndexOf("");
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
			List<string> blocks = new List<string> ();
			while (data.Length > 0) {
				var lastBlock = -1;
				if (data.StartsWith ("Failure")) {
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
				blocks.Add (data.Substring (indx, lastBlock));
				lastBlock += 2;
				data = data.Substring (lastBlock, data.Length - lastBlock);
			}

			var tests = blocks.Where (l => !l.StartsWith ("Failure")).Select (l => new Test (l)).ToList ();
			var failedTests = blocks.Where (l => l.StartsWith ("Failure")).SelectMany (l => 
			{
				return l.Split (new [] { "Frisby Test: " }, StringSplitOptions.RemoveEmptyEntries)
						.Select (s => s.Substring (0, s.IndexOf ('\n')));
			}).Distinct ().ToList ();

			tests.ForEach (t => {
				var test = failedTests.FirstOrDefault (s => s.Trim () == t.Title);
				if (test == null) {
					t.Passed = true;
				} else {
					var token = string.Format ("Frisby Test: {0}", t.Title);
					var indx = data.IndexOf (string.Format ("Frisby Test: {0}", t.Title));
					indx += token.Length;
					var frame = data.Substring (indx, data.Substring (indx, data.Length - indx).IndexOf ("Frisby Test:"));
					t.Stack = frame.Substring(data.IndexOf("Stacktrace:"));
				}
				this.Add (t);
			});
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

