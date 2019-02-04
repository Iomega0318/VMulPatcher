using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultima;

namespace VMulPatcher
{
    public partial class MainForm : Form
    {
        private ArtNonStatic FArt;

        public MainForm()
        {
            InitializeComponent();
            FArt = new ArtNonStatic();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int lLen = FArt.GetMaxItemID();
            for (int i = 0; i < lLen; i++)
            {
                lbSlots.Items.Add("0x" + i.ToString("X4"));
            }
        }

        private void lbSlots_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lIndex = (sender as ListBox).SelectedIndex;
            if (lIndex < 0 || lIndex > 0xFFFF)
                return;
            pbImage.Image = FArt.GetStatic(lIndex);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("Exported"))
                Directory.CreateDirectory("Exported");
            Bitmap lImage = Art.GetStatic(lbSlots.SelectedIndex);
            lImage.Save(Path.Combine("Exported", lbSlots.SelectedItem.ToString() + ".bmp"));
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog lDialog = new OpenFileDialog();
            lDialog.Filter = "Bitmap files (*.bmp)|*.bmp";
            if (lDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap lImage = new Bitmap(lDialog.FileName);
                FArt.ReplaceStatic(lbSlots.SelectedIndex, lImage);
            }
            lbSlots.SetSelected(lbSlots.SelectedIndex, true);
        }

        private void btnBuildMUL_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = FArt.GetIdxLength();
            progressBar1.Value = 0;
            FArt.SavingEvent += Art_SavingEvent;
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                FArt.Save("Patched");
                MessageBox.Show("MULs builded!");
            }).Start();
        }

        private void Art_SavingEvent(object sender, EventArgs e)
        {
            progressBar1.BeginInvoke((MethodInvoker)delegate ()
            {
                progressBar1.Value = (int)(sender);
                btnBuildMUL.Text = (sender).ToString();
            });

        }
    }
}
