using System;

namespace FrisbyToss
{
	public class FrisbyRunner
	{
		private readonly string CMD = @"/usr/bin/jasmine-node";
		private readonly string ARGS = @"--verbose {0}";
		public FrisbyRunner ()
		{

		}

		public string RunFrisby(string folder) {
			System.Diagnostics.Process proc = new System.Diagnostics.Process();
			proc.StartInfo.UseShellExecute = false;
			proc.StartInfo.RedirectStandardOutput = true;
			proc.StartInfo.FileName = CMD;
			proc.StartInfo.Arguments = string.Format (ARGS, folder);
			proc.Start();
			string data = proc.StandardOutput.ReadToEnd();
			proc.WaitForExit ();
			return data;
		}
	}
}

