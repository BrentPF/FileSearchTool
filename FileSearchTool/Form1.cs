using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace FileSearchTool
{
	public partial class Form1 : Form
	{

		private List<string> filePaths = new List<string>();

		public Form1()
		{
			InitializeComponent();
		}

		private void folderBrowserDialogButton_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				folderLabel.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private bool parseFiles(string expression, string path) {
			if (path.Contains(expression))
			{
				return true;
			}
			else if (path.Contains(".xlsx") || path.Contains(".xlsx"))
			{
				Excel.Application xlApp = new Excel.Application();
				Excel.Workbooks xlWorkbooks = xlApp.Workbooks;
				Excel.Workbook xlWorkbook = null;
				try
				{
					xlWorkbook = xlWorkbooks.Open(path);
				}
				catch
				{
					GC.Collect();
					GC.WaitForPendingFinalizers();
					xlWorkbooks.Close();
					xlApp.Quit();
					return false;
				}

				foreach (Excel.Worksheet xlWorksheet in xlWorkbook.Worksheets) {
					var xlUsedRange = xlWorksheet.UsedRange;
					var iTotalColumns = xlUsedRange.Columns.Count;
					var iTotalRows = xlUsedRange.Rows.Count;

					//These two lines do the magic.
					xlWorksheet.Columns.ClearFormats();
					xlWorksheet.Rows.ClearFormats();

					xlUsedRange = xlWorksheet.UsedRange;
					iTotalColumns = xlUsedRange.Columns.Count;
					iTotalRows = xlUsedRange.Rows.Count;
					var cellRange = xlWorksheet.Range[xlWorksheet.Cells[1, 1], xlWorksheet.Cells[iTotalRows, iTotalColumns]];

					var cellValue = cellRange.Find(
						What: expression,

						LookIn: Excel.XlFindLookIn.xlValues,

						LookAt: Excel.XlLookAt.xlPart

						);

					if (cellValue != null)
					{
						GC.Collect();
						GC.WaitForPendingFinalizers();
						xlWorkbook.Close(SaveChanges: false);
						xlWorkbooks.Close();
						xlApp.Quit();
						return true;
					}
				}
				GC.Collect();
				GC.WaitForPendingFinalizers();
				xlWorkbook.Close(SaveChanges: false);
				xlWorkbooks.Close();
				xlApp.Quit();
				return false;
			}
			else if (path.Contains(".docx") || path.Contains(".doc"))
			{
				var wdApp = new Word.Application();
				var wdDocs = wdApp.Documents;
				var wdDoc = wdDocs.Open(path);
				var wdRange = wdDoc.Content;
				string body = wdRange.Text;
				if (body.Contains(expression))
				{
					wdDoc.Close(SaveChanges: false);
					wdApp.Quit();
					return true;
				} 
				
				wdDoc.Close(SaveChanges: false);
				wdApp.Quit();
				return false;
			}

			return false;
		}

		private void SearchAllFiles(string folder, List<string> paths, string[] extensions)
		{
			foreach (string file in Directory.GetFiles(folder))
			{
				foreach (string ext in extensions) {
					var extRegex = new Regex(ext);
					if (extRegex.IsMatch(file)) {
						paths.Add(file);
					}
				}
			}
			foreach (string subDir in Directory.GetDirectories(folder))
			{
				try
				{
					SearchAllFiles(subDir, paths, extensions);
				}
				catch
				{
					// swallow, log, whatever
				}
			}
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(this.searchText.Text) && !String.IsNullOrEmpty(this.folderLabel.Text)) {
				this.pathList.Items.Clear();
				this.searchProgressBar.Value = 0;
				this.searchProgressLabel.Text = "Gathering files from selected folder.";
				this.pathList.Items.Add("Gathering files...");
				this.searchButton.Enabled = false;
				this.folderBrowserDialogButton.Enabled = false;
				this.searchText.Enabled = false;
				this.folderLabel.Enabled = false;

				filePaths.Clear();

				try {
					backgroundWorker2.RunWorkerAsync(argument: this.folderLabel.Text);
				}
				catch (Exception err) {
					this.pathList.Items.Clear();
					this.searchProgressBar.Value = 0;
					this.searchProgressLabel.Text = "An error has occured.";
					this.pathList.Items.Add("An error during execution: " + err.Message);
					this.searchButton.Enabled = true;
					this.folderBrowserDialogButton.Enabled = true;
					this.searchText.Enabled = true;
					this.folderLabel.Enabled = true;
				}
				
				
			}
		}

		private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Worker called");
			List<object> argList = e.Argument as List<object>;
			string exp = argList[0].ToString();
			List<string> filePaths = argList[1] as List<string>;
			foreach (string docPath in filePaths)
			{
				System.Diagnostics.Debug.WriteLine("Now servicing: " + docPath);
				try {
					if (parseFiles(exp, docPath))
					{
						string[] res = { docPath, docPath };
						backgroundWorker1.ReportProgress(1, res);
					}
					else
					{
						string[] res = { null, docPath };
						backgroundWorker1.ReportProgress(1, res);
					}
				} catch {
					backgroundWorker1.ReportProgress(1, null);
				} 
				System.Diagnostics.Debug.WriteLine("File serviced: " + docPath);
			}

		}

		// This event handler updates the progress bar.
		private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.UserState != null)
			{
				string[] res = e.UserState as string[];
				this.searchProgressBar.PerformStep();
				this.searchProgressLabel.Text = "Processed (" + (searchProgressBar.Value) + " of " + searchProgressBar.Maximum + ") - " + res[1];
				System.Diagnostics.Debug.WriteLine("Progress reported: " + this.searchProgressBar.Value);
				if (res[0] != null)
				{
					this.pathList.Items.Add(res[1]);
				}
				else {
					System.Diagnostics.Debug.WriteLine("FAILURE CAUGHT!!!!!!!!!!!!! " + res[1]);
				}
			}
			else {
				System.Diagnostics.Debug.WriteLine("EXCEPTION CAUGHT!!!");
				this.searchProgressBar.PerformStep();
				this.pathList.Items.Add("An unknown error occured while parsing.");
			}

			if (this.searchProgressBar.Maximum == this.searchProgressBar.Value)
			{
				this.pathList.Items.Add("Search completed.");
				this.searchProgressLabel.Text = "Document search complete.";
				this.searchButton.Enabled = true;
				this.folderBrowserDialogButton.Enabled = true;
				this.searchText.Enabled = true;
				this.folderLabel.Enabled = true;
			}

		}

		private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			string exp = this.searchText.Text;
			this.pathList.Items.Add("Parsing files: matches and errors messages will be listed below (click to copy to clipboard)...");
			// Set Minimum to 1 to represent the first file being copied.
			this.searchProgressBar.Minimum = 0;
			// Set Maximum to the total number of files to copy.
			this.searchProgressBar.Maximum = filePaths.Count;
			// Set the Step property to a value of 1 to represent each file being copied.
			this.searchProgressBar.Step = 1;
			//Document parse and add to list
			this.searchProgressLabel.Text = "Processing " + filePaths.Count + " files...";
			List<object> arguments = new List<object>();
			arguments.Add(exp);
			arguments.Add(filePaths);
			backgroundWorker1.RunWorkerAsync(argument: arguments);
		}

		private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
		{
			//Allowed extensions
			string[] extensions = { ".*\\.docx?$", ".*\\.xlsx?$", ".*\\.pdf$" };

			SearchAllFiles(e.Argument.ToString(), filePaths, extensions);
			// Set Minimum to 1 to represent the first file being copied.
		}

		private void PathList_Click(object sender, EventArgs e)
		{
			if (this.pathList.SelectedItems.Count == 1)
			{
				string path = this.pathList.SelectedItem.ToString();
				Clipboard.SetData(DataFormats.StringFormat, path);
				this.searchProgressLabel.Text = "Copied to clipboard: " + path;
			}
		}
	}
}
