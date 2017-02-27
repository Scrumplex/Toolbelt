using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Toolbelt.Properties;

namespace Toolbelt
{
    public partial class MainForm : Form
    {
        public ImageList ImageList;

        public string BasePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                 "\\Scrumplex\\Toolbelt";

        public MainForm()
        {
            ImageList = new ImageList();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(BasePath))
                Directory.CreateDirectory(BasePath);

            listViewTools.LargeImageList = ImageList;

            FindAndAddItems();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogAdd.ShowDialog() != DialogResult.OK) return;

            var sourcePath = folderBrowserDialogAdd.SelectedPath;
            var directoryName = new FileInfo(sourcePath).Name;
            var targetPath = BasePath + "\\" + directoryName;

            if (Directory.Exists(targetPath))
            {
                MessageBox.Show(Resources.Tool_already_added, @"Toolbelt");
                return;
            }

            CopyFolder(sourcePath, targetPath);

            var dialog = new AddDialog(targetPath);
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var tool = new Tool {Name = dialog.EntryName, Path = dialog.Path, MainExecutable = dialog.MainExecutable};

            File.WriteAllText(dialog.Path + "\\toolbelt.json", JsonConvert.SerializeObject(tool));
            FindAndAddItems();
        }

        private void listViewTools_DoubleClick(object sender, EventArgs e)
        {
            var toolItem = GetSelectedToolItem();
            if (toolItem == null)
                return;
            var info = new ProcessStartInfo(toolItem.Tool.MainExecutable)
            {
                WorkingDirectory = toolItem.Tool.Path
            };
            try
            {
                Process.Start(info);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void listViewTools_KeyDown(object sender, KeyEventArgs e)
        {
            var toolItem = GetSelectedToolItem();
            if (toolItem == null)
                return;
            Directory.Delete(toolItem.Tool.Path, true);
            FindAndAddItems();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var toolItem = GetSelectedToolItem();
            if (toolItem == null)
                return;
            Directory.Delete(toolItem.Tool.Path, true);
            FindAndAddItems();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var toolItem = GetSelectedToolItem();
            if (toolItem == null)
                return;
            var dialog = new AddDialog(toolItem.Tool);
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var tool = new Tool {Name = dialog.EntryName, Path = dialog.Path, MainExecutable = dialog.MainExecutable};

            File.WriteAllText(dialog.Path + "\\toolbelt.json", JsonConvert.SerializeObject(tool));
            FindAndAddItems();
        }

        private void FindAndAddItems()
        {
            listViewTools.Clear();
            foreach (var path in Directory.GetDirectories(BasePath))
            {
                var jsonPath = path + "\\toolbelt.json";

                if (!File.Exists(jsonPath))
                    continue;
                var tool = JsonConvert.DeserializeObject<Tool>(File.ReadAllText(jsonPath));
                var toolItem = new ToolItem(ImageList, tool);
                listViewTools.Items.Add(toolItem);
            }
            listViewTools.Refresh();
        }

        private static void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            var files = Directory.GetFiles(sourceFolder);
            foreach (var file in files)
            {
                var name = Path.GetFileName(file);
                if (name == null) continue;
                var dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            var folders = Directory.GetDirectories(sourceFolder);
            foreach (var folder in folders)
            {
                var name = Path.GetFileName(folder);
                if (name == null) continue;
                var dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }

        private ToolItem GetSelectedToolItem()
        {
            var items = listViewTools.SelectedItems;
            if (items.Count == 0)
                return null;
            var item = items[0];
            var toolItem = item as ToolItem;
            return toolItem;
        }

        private void listViewTools_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTools.SelectedItems.Count == 0)
            {
                buttonDelete.Enabled = false;
                buttonEdit.Enabled = false;
            }
            else
            {
                buttonDelete.Enabled = true;
                buttonEdit.Enabled = true;
            }
        }
    }

    public class Tool
    {
        public int Version = 1;
        public string Name { get; set; }
        public string Path { get; set; }
        public string MainExecutable { get; set; }
    }

    internal class ToolItem : ListViewItem
    {
        public readonly Tool Tool;

        internal ToolItem(ImageList imageList, Tool tool)
        {
            Tool = tool;
            Text = tool.Name;

            var extractedIcon = Icon.ExtractAssociatedIcon(tool.MainExecutable);
            if (extractedIcon == null)
                return;

            var mainIcon = extractedIcon.ToBitmap();
            imageList.Images.Add(tool.Path, mainIcon);
            ImageKey = tool.Path;
        }
    }
}