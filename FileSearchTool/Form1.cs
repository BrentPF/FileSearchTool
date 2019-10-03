using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace FileSearchTool
{
	public partial class Form1 : Form
	{
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

			if (path.Contains(".xlsx"))
			{
				Excel.Application xlApp = new Excel.Application();
				Excel.Workbook xlWorkbook = null;
				try
				{
					xlWorkbook = xlApp.Workbooks.Open(path);
				}
				catch
				{
					GC.Collect();
					GC.WaitForPendingFinalizers();
					xlWorkbook.Close(SaveChanges: false);
					Marshal.ReleaseComObject(xlWorkbook);
					xlApp.Quit();
					Marshal.ReleaseComObject(xlApp);
					return false;
				}
				Excel.Worksheet xlWorksheet = xlWorkbook.Worksheets[1];

				var iTotalColumns = xlWorksheet.UsedRange.Columns.Count;
				var iTotalRows = xlWorksheet.UsedRange.Rows.Count;

				//These two lines do the magic.
				xlWorksheet.Columns.ClearFormats();
				xlWorksheet.Rows.ClearFormats();

				iTotalColumns = xlWorksheet.UsedRange.Columns.Count;
				iTotalRows = xlWorksheet.UsedRange.Rows.Count;
				Excel.Range cellRange = xlWorksheet.Range[xlWorksheet.Cells[1, 1], xlWorksheet.Cells[iTotalRows, iTotalColumns]];

				var cellValue = cellRange.Find(
					What: expression,

					LookIn: Excel.XlFindLookIn.xlValues,

					LookAt: Excel.XlLookAt.xlPart

					);

				GC.Collect();
				GC.WaitForPendingFinalizers();
				Marshal.ReleaseComObject(cellRange);
				Marshal.ReleaseComObject(xlWorksheet);
				xlWorkbook.Close(SaveChanges: false);
				Marshal.ReleaseComObject(xlWorkbook);
				xlApp.Quit();
				Marshal.ReleaseComObject(xlApp);

				if (cellValue == null)
				{
					return false;
				}
			}
			else if (path.Contains(".docx"))
			{
				var wdApp = new Word.Application();
				var wdDoc = wdApp.Documents.Open(path);
				string body = wdDoc.Content.Text;
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
			else if (path.Contains(".pdf")) {

			}

			return true;
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(this.searchText.Text) && !String.IsNullOrEmpty(this.folderLabel.Text)) {
				this.pathList.Items.Clear();
				this.searchProgressBar.Value = 0;
				this.pathList.Items.Add("Initiating search...");
				this.searchButton.Enabled = false;
				this.folderBrowserDialogButton.Enabled = false;
				this.searchText.Enabled = false;
				this.folderLabel.Enabled = false;

				//Allowed extensions
				string[] extensions = { "*.docx", "*.pdf", "*.xlsx" };
				string exp = this.searchText.Text;
				List<string> filePaths = new List<string>();

				//Filepath search
				foreach (string ext in extensions) {
					try
					{
						filePaths.AddRange(Directory.GetFiles(this.folderLabel.Text, ext, SearchOption.AllDirectories).ToList());
					}
					catch (Exception err){
						this.pathList.Items.Add(err.Message);
					}
				}
				// Set Minimum to 1 to represent the first file being copied.
				this.searchProgressBar.Minimum = 0;
				// Set Maximum to the total number of files to copy.
				this.searchProgressBar.Maximum = filePaths.Count;
				// Set the Step property to a value of 1 to represent each file being copied.
				this.searchProgressBar.Step = 1;
				//Document parse and add to list
				foreach (string docPath in filePaths) {
					this.searchProgressLabel.Text = "Processing: " + docPath;
					if (parseFiles(exp, docPath)) {
						this.pathList.Items.Add(docPath);
					}
					this.searchProgressBar.PerformStep();
				}

				this.pathList.Items.Add("Search completed.");
				this.searchProgressLabel.Text = "Document search complete.";
				this.searchButton.Enabled = true;
				this.folderBrowserDialogButton.Enabled = true;
				this.searchText.Enabled = true;
				this.folderLabel.Enabled = true;
			}
		}
	}
}
