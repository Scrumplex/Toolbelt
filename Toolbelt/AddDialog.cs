using System;
using System.IO;
using System.Windows.Forms;
using Toolbelt.Properties;

namespace Toolbelt
{
    public partial class AddDialog : Form
    {
        public string Path;
        public string EntryName;
        public string MainExecutable;

        public AddDialog(string sourcePath)
        {
            Path = sourcePath;
            InitializeComponent();
        }

        public AddDialog(Tool tool)
        {
            Path = tool.Path;
            MainExecutable = tool.MainExecutable;
            EntryName = tool.Name;
            InitializeComponent();
        }

        private void AddDialog_Load(object sender, EventArgs e)
        {
            var exeFiles = Directory.GetFiles(Path, "*.exe");
            if (exeFiles.Length == 0)
            {
                MessageBox.Show(Resources.lang_No_executables_found);
                DialogResult = DialogResult.Abort;
                Close();
                return;
            }
            comboBoxExecutable.Items.AddRange(exeFiles);
            comboBoxExecutable.SelectedIndex = 0;
            textBoxName.Text = EntryName ?? new FileInfo(Path).Name;
        }

        private void comboBoxExecutable_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainExecutable = comboBoxExecutable.Text;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            EntryName = textBoxName.Text;
        }
    }
}