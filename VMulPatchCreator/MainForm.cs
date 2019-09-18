using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMulPatchCreator
{
    public partial class MainForm : Form
    {
        public List<ConfigItem> FConfigItems;
        private ConfigItem FConfigItem;


        public MainForm()
        {
            InitializeComponent();

            FConfigItems = new List<ConfigItem>();

            rbSingle_CheckedChanged(null, null);
        }

        private void ClearAllTextboxs()
        {
            for (int i = 0; i < flowPanel.Controls.Count; i++)
            {
                for (int y = 0; y < flowPanel.Controls[i].Controls.Count; y++)
                {
                    if (flowPanel.Controls[i].Controls[y] is TextBox)
                        (flowPanel.Controls[i].Controls[y] as TextBox).Text = "";
                }
            }
        }

        private void rbSingle_CheckedChanged(object sender, EventArgs e)
        {
            pnlSingle.Visible = true;
            pnlMultiple.Visible = false;
            pnlRange.Visible = false;
            ClearAllTextboxs();
        }

        private void rbMultiple_CheckedChanged(object sender, EventArgs e)
        {
            pnlSingle.Visible = false;
            pnlMultiple.Visible = true;
            pnlRange.Visible = false;
            ClearAllTextboxs();
        }

        private void rbRange_CheckedChanged(object sender, EventArgs e)
        {
            pnlSingle.Visible = false;
            pnlMultiple.Visible = false;
            pnlRange.Visible = true;
            ClearAllTextboxs();
        }

        private void btnSelectBitmap_Click(object sender, EventArgs e)
        {
            OpenFileDialog lDialog = new OpenFileDialog();
            lDialog.Filter = "Bitmap files (*.bmp)|*.bmp";
            if (lDialog.ShowDialog() == DialogResult.OK)
            {
                FConfigItem = new ConfigItem();

                Bitmap lImage = new Bitmap(lDialog.FileName);
                FConfigItem.UOBitmap = lImage;
                if (lImage.Width > pbImage.Width && lImage.Height > pbImage.Height)
                    pbImage.Image = ResizeBitmap(lImage, pbImage.Width, pbImage.Height);
                else
                    pbImage.Image = lImage;
                btnAddConfigItem.Enabled = true;
            }
        }

        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(bmp, 0, 0, width, height);
            return result;
        }

        private void btnAddConfigItem_Click(object sender, EventArgs e)
        {
            if (rbSingle.Checked)
            {
                FConfigItem.ConfigFlag = ConfigMode.Individually;
                string lValue = tbSignle.Text.Remove(0, 2);
                FConfigItem.UOPositions.Add(ushort.Parse(lValue, System.Globalization.NumberStyles.AllowHexSpecifier));
            }
            else if (rbMultiple.Checked)
            {
                FConfigItem.ConfigFlag = ConfigMode.Multiple;
                for (int i = 0; i < tbMultiple.Lines.Length; i++)
                {
                    string lValue = tbMultiple.Lines[i].Remove(0, 2);
                    FConfigItem.UOPositions.Add(ushort.Parse(lValue, System.Globalization.NumberStyles.AllowHexSpecifier));
                }
            }
            else if (rbRange.Checked)
            {
                FConfigItem.ConfigFlag = ConfigMode.Range;
                string lFValue = tbRange_1.Text.Remove(0, 2);
                string lSValue = tbRange_2.Text.Remove(0, 2);
                ushort lFirts = ushort.Parse(lFValue, System.Globalization.NumberStyles.AllowHexSpecifier);
                ushort lSecond = ushort.Parse(lSValue, System.Globalization.NumberStyles.AllowHexSpecifier);
                for (ushort i = lFirts; i <= lSecond; i++)
                    FConfigItem.UOPositions.Add(i);
            }

            if (rbArt.Checked)
                FConfigItem.Flag = FileRecognization.Art;
            else if (rbArtLand.Checked)
                FConfigItem.Flag = FileRecognization.ArtLand;
            else if (rbGump.Checked)
                FConfigItem.Flag = FileRecognization.Gump;
            else if (rbText.Checked)
                FConfigItem.Flag = FileRecognization.Texture;

            FConfigItems.Add(new ConfigItem(FConfigItem));

            lboxAddedConfigItems.Items.Add(FConfigItem.Flag.ToString() + " " + FConfigItem.ConfigFlag.ToString());

            FConfigItem.Clear();
            FConfigItem = null;
            btnAddConfigItem.Enabled = false;
            btnMakePatch.Enabled = true;
        }

        private void btnMakePatch_Click(object sender, EventArgs e)
        {
            BinaryWriter lBinWriter = new BinaryWriter(File.Open("Patch.pvmul", FileMode.Create));

            foreach (ConfigItem lItem in FConfigItems)
            {

                byte[] lImgArray = ImageToByte(lItem.UOBitmap);

                // header
                // 1byte flag, 1byte flag, 2byte posCount, 4byte bitmaplenght
                byte lFlag = (byte)lItem.Flag;
                byte lConFlag = (byte)lItem.ConfigFlag;
                ushort lPosCount = (ushort)lItem.UOPositions.Count;
                int lBitmapLength = (int)lImgArray.Length;

                lBinWriter.Write((byte)lFlag);
                lBinWriter.Write((byte)lConFlag);
                lBinWriter.Write((ushort)lPosCount);
                lBinWriter.Write((int)lBitmapLength);

                // data
                foreach (ushort lPos in lItem.UOPositions)
                    lBinWriter.Write((ushort)lPos);

                foreach (byte lByte in lImgArray)
                    lBinWriter.Write((byte)lByte);
            }

            lBinWriter.Close();
            MessageBox.Show("Patch created as 'Patch.pvmul' in application directory.");
        }

        public byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
