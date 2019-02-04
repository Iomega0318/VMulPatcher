using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMulPatcher
{
    public partial class DebugForm : Form
    {
        public DebugForm(int index)
        {
            InitializeComponent();
            pictureBox1.Image = Ultima.Art.GetStatic(index);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Ultima.Art.GetStatic(Convert.ToInt32(textBox1.Text));
        }
    }
}
