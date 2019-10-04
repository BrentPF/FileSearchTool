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
            this.searchProgressBar = new System.Windows.Forms.ProgressBar();
            this.searchProgressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // folderBrowserDialogButton
            // 
            this.folderBrowserDialogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderBrowserDialogButton.Location = new System.Drawing.Point(12, 41);
            this.folderBrowserDialogButton.Name = "folderBrowserDialogButton";
            this.folderBrowserDialogButton.Size = new System.Drawing.Size(95, 22);
            this.folderBrowserDialogButton.TabIndex = 0;
            this.folderBrowserDialogButton.Text = "Select Folder";
            this.folderBrowserDialogButton.UseVisualStyleBackColor = true;
            this.folderBrowserDialogButton.Click += new System.EventHandler(this.folderBrowserDialogButton_Click);
            // 
            // searchText
            // 
            this.searchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchText.Location = new System.Drawing.Point(113, 12);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(532, 26);
            this.searchText.TabIndex = 1;
            // 
            // pathList
            // 
            this.pathList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathList.FormattingEnabled = true;
            this.pathList.ItemHeight = 20;
            this.pathList.Location = new System.Drawing.Point(12, 96);
            this.pathList.Name = "pathList";
            this.pathList.Size = new System.Drawing.Size(633, 224);
            this.pathList.TabIndex = 2;
            // 
            // folderLabel
            // 
            this.folderLabel.AutoEllipsis = true;
            this.folderLabel.BackColor = System.Drawing.Color.White;
            this.folderLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.folderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderLabel.Location = new System.Drawing.Point(113, 41);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(532, 22);
            this.folderLabel.TabIndex = 3;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(12, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(95, 23);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // searchProgressBar
            // 
            this.searchProgressBar.Location = new System.Drawing.Point(12, 326);
            this.searchProgressBar.Name = "searchProgressBar";
            this.searchProgressBar.Size = new System.Drawing.Size(633, 28);
            this.searchProgressBar.TabIndex = 5;
            // 
            // searchProgressLabel
            // 
            this.searchProgressLabel.AutoSize = true;
            this.searchProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchProgressLabel.Location = new System.Drawing.Point(12, 77);
            this.searchProgressLabel.Name = "searchProgressLabel";
            this.searchProgressLabel.Size = new System.Drawing.Size(325, 16);
            this.searchProgressLabel.TabIndex = 6;
            this.searchProgressLabel.Text = "Please enter a search term and select a parent folder.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 365);
            this.Controls.Add(this.searchProgressLabel);
            this.Controls.Add(this.searchProgressBar);
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
		private System.Windows.Forms.ProgressBar searchProgressBar;
		private System.Windows.Forms.Label searchProgressLabel;
	}
}

