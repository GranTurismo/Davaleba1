using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Davaleba1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = Application.ProductName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MenuStrip menu = new MenuStrip()
            {
                Text = "FontSize"
            };
            GenerateFontSizeItem(menu);
            GenerateFontFamilies(menu);
            MainMenuStrip = menu;
            Controls.Add(menu);
        }

        private void GenerateFontFamilies(MenuStrip menu)
        {
            var menuItem = new ToolStripMenuItem("Font Family");
            menuItem.DropDownItems.AddRange(GenerateFonts().ToArray());
            menu.Items.Add(menuItem);
        }

        private IEnumerable<ToolStripItem> GenerateFonts()
        {
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            foreach (var item in installedFontCollection.Families)
            {
                ToolStripItem toolStripItem = new ToolStripButton(item.Name);
                toolStripItem.Click += ToolStripItem_Click;
                yield return toolStripItem;
            }
        }

        private void ToolStripItem_Click(object sender, EventArgs e)//მოდის ფონტებიდან
        {
            ToolStripItem item = sender as ToolStripItem;
            Font font = new Font(item.Text,textBox1.Font.Size);
            textBox1.Font = font;
            item.Select();
        }

        private void GenerateFontSizeItem(MenuStrip menu)
        {
            var menuItem = new ToolStripMenuItem("Font Size");
            menuItem.DropDownItems.AddRange(GenerateFontSizes().ToArray());
            menu.Items.Add(menuItem);
        }

        private IEnumerable<ToolStripItem> GenerateFontSizes()
        {
            for (int i = 8; i < 78; i += 6)
            {
                ToolStripItem toolStripItem = new ToolStripButton()
                {
                    Text = $"{i}px",
                    Tag = i,
                };
                toolStripItem.Click += NewObj_Click;
                yield return toolStripItem;
            }
        }

        private void NewObj_Click(object sender, EventArgs e)//მოდის ზომებიდან
        {
            ToolStripItem item = sender as ToolStripItem;
            double fontSize = double.Parse(item.Tag.ToString());
            textBox1.Font = new Font(textBox1.Font.FontFamily,(float)fontSize);
            item.Select();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//ეს ისე
        {

        }
    }
}
