using System.Linq;
using System.Windows.Forms;

namespace TextEditor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainText = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileFromDatabaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileToDatabaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainText
            // 
            this.MainText.AccessibleName = "MainText";
            this.MainText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainText.Location = new System.Drawing.Point(15, 33);
            this.MainText.Margin = new System.Windows.Forms.Padding(6);
            this.MainText.MaxLength = 10000000;
            this.MainText.Multiline = true;
            this.MainText.Name = "MainText";
            this.MainText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MainText.Size = new System.Drawing.Size(1547, 535);
            this.MainText.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1577, 27);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileMenuItem,
            this.SaveFileMenuItem,
            this.OpenFileFromDatabaseMenuItem,
            this.SaveFileToDatabaseMenuItem});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(53, 19);
            this.Menu.Text = "Меню";
            // 
            // OpenFileMenuItem
            // 
            this.OpenFileMenuItem.Name = "OpenFileMenuItem";
            this.OpenFileMenuItem.Size = new System.Drawing.Size(200, 22);
            this.OpenFileMenuItem.Text = "Открыть файл";
            this.OpenFileMenuItem.Click += new System.EventHandler(this.LoadFileFromDisk);
            // 
            // SaveFileMenuItem
            // 
            this.SaveFileMenuItem.Name = "SaveFileMenuItem";
            this.SaveFileMenuItem.Size = new System.Drawing.Size(200, 22);
            this.SaveFileMenuItem.Text = "Сохранить файл";
            this.SaveFileMenuItem.Click += new System.EventHandler(this.SaveFileToDisk);
            // 
            // OpenFileFromDatabaseMenuItem
            // 
            this.OpenFileFromDatabaseMenuItem.Name = "OpenFileFromDatabaseMenuItem";
            this.OpenFileFromDatabaseMenuItem.Size = new System.Drawing.Size(200, 22);
            this.OpenFileFromDatabaseMenuItem.Text = "Открыть файл из базы";
            this.OpenFileFromDatabaseMenuItem.Click += new System.EventHandler(this.LoadFileFromDatabase);
            // 
            // SaveFileToDatabaseMenuItem
            // 
            this.SaveFileToDatabaseMenuItem.Name = "SaveFileToDatabaseMenuItem";
            this.SaveFileToDatabaseMenuItem.Size = new System.Drawing.Size(200, 22);
            this.SaveFileToDatabaseMenuItem.Text = "Сохранить файл в базу";
            this.SaveFileToDatabaseMenuItem.Click += new System.EventHandler(this.SaveFileToDatabase);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1577, 583);
            this.Controls.Add(this.MainText);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MainText;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem OpenFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileFromDatabaseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileToDatabaseMenuItem;
    }
}

