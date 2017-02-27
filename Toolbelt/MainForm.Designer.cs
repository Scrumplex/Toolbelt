using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Toolbelt
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewTools = new System.Windows.Forms.ListView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelProgramName = new System.Windows.Forms.Label();
            this.folderBrowserDialogAdd = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.listViewTools);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 287);
            this.panel1.TabIndex = 0;
            // 
            // listViewTools
            // 
            this.listViewTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTools.Location = new System.Drawing.Point(0, 0);
            this.listViewTools.MultiSelect = false;
            this.listViewTools.Name = "listViewTools";
            this.listViewTools.Size = new System.Drawing.Size(343, 287);
            this.listViewTools.TabIndex = 4;
            this.listViewTools.UseCompatibleStateImageBehavior = false;
            this.listViewTools.SelectedIndexChanged += new System.EventHandler(this.listViewTools_SelectedIndexChanged);
            this.listViewTools.DoubleClick += new System.EventHandler(this.listViewTools_DoubleClick);
            this.listViewTools.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewTools_KeyDown);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(361, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(111, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelProgramName
            // 
            this.labelProgramName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProgramName.AutoSize = true;
            this.labelProgramName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgramName.Location = new System.Drawing.Point(408, 281);
            this.labelProgramName.Name = "labelProgramName";
            this.labelProgramName.Size = new System.Drawing.Size(64, 21);
            this.labelProgramName.TabIndex = 2;
            this.labelProgramName.Text = "Toolbelt";
            // 
            // folderBrowserDialogAdd
            // 
            this.folderBrowserDialogAdd.Description = "Select Folder containing all necessary files.";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(361, 41);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(111, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Location = new System.Drawing.Point(361, 70);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(111, 23);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelProgramName);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toolbelt";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Button buttonAdd;
        private ListView listViewTools;
        private Label labelProgramName;
        private FolderBrowserDialog folderBrowserDialogAdd;
        private Button buttonDelete;
        private Button buttonEdit;
    }
}

