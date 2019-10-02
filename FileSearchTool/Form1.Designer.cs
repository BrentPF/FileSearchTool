namespace FileSearchTool
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.folderBrowserDialogButton = new System.Windows.Forms.Button();
			this.searchText = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.pathList = new System.Windows.Forms.ListBox();
			this.folderLabel = new System.Windows.Forms.Label();
			this.searchButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// folderBrowserDialogButton
			// 
			this.folderBrowserDialogButton.Location = new System.Drawing.Point(12, 38);
			this.folderBrowserDialogButton.Name = "folderBrowserDialogButton";
			this.folderBrowserDialogButton.Size = new System.Drawing.Size(95, 22);
			this.folderBrowserDialogButton.TabIndex = 0;
			this.folderBrowserDialogButton.Text = "Select Folder";
			this.folderBrowserDialogButton.UseVisualStyleBackColor = true;
			this.folderBrowserDialogButton.Click += new System.EventHandler(this.Button1_Click);
			// 
			// searchText
			// 
			this.searchText.Location = new System.Drawing.Point(113, 12);
			this.searchText.Name = "searchText";
			this.searchText.Size = new System.Drawing.Size(532, 20);
			this.searchText.TabIndex = 1;
			// 
			// pathList
			// 
			this.pathList.FormattingEnabled = true;
			this.pathList.Location = new System.Drawing.Point(12, 75);
			this.pathList.Name = "pathList";
			this.pathList.Size = new System.Drawing.Size(633, 277);
			this.pathList.TabIndex = 2;
			// 
			// folderLabel
			// 
			this.folderLabel.AutoEllipsis = true;
			this.folderLabel.BackColor = System.Drawing.Color.White;
			this.folderLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.folderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.folderLabel.Location = new System.Drawing.Point(113, 38);
			this.folderLabel.Name = "folderLabel";
			this.folderLabel.Size = new System.Drawing.Size(532, 22);
			this.folderLabel.TabIndex = 3;
			// 
			// searchButton
			// 
			this.searchButton.Location = new System.Drawing.Point(12, 12);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(95, 20);
			this.searchButton.TabIndex = 4;
			this.searchButton.Text = "Search";
			this.searchButton.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(657, 372);
			this.Controls.Add(this.searchButton);
			this.Controls.Add(this.folderLabel);
			this.Controls.Add(this.pathList);
			this.Controls.Add(this.searchText);
			this.Controls.Add(this.folderBrowserDialogButton);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button folderBrowserDialogButton;
		private System.Windows.Forms.TextBox searchText;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.ListBox pathList;
		private System.Windows.Forms.Label folderLabel;
		private System.Windows.Forms.Button searchButton;
	}
}

