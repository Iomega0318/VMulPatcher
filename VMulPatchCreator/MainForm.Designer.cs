namespace VMulPatchCreator
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
            this.btnAddConfigItem = new System.Windows.Forms.Button();
            this.grpboxNew = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.rbGump = new System.Windows.Forms.RadioButton();
            this.rbArtLand = new System.Windows.Forms.RadioButton();
            this.rbArt = new System.Windows.Forms.RadioButton();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSingle = new System.Windows.Forms.Panel();
            this.tbSignle = new System.Windows.Forms.TextBox();
            this.pnlMultiple = new System.Windows.Forms.Panel();
            this.tbMultiple = new System.Windows.Forms.TextBox();
            this.pnlRange = new System.Windows.Forms.Panel();
            this.tbRange_2 = new System.Windows.Forms.TextBox();
            this.tbRange_1 = new System.Windows.Forms.TextBox();
            this.rbRange = new System.Windows.Forms.RadioButton();
            this.rbMultiple = new System.Windows.Forms.RadioButton();
            this.rbSingle = new System.Windows.Forms.RadioButton();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnSelectBitmap = new System.Windows.Forms.Button();
            this.lboxAddedConfigItems = new System.Windows.Forms.ListBox();
            this.btnMakePatch = new System.Windows.Forms.Button();
            this.grpboxNew.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowPanel.SuspendLayout();
            this.pnlSingle.SuspendLayout();
            this.pnlMultiple.SuspendLayout();
            this.pnlRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddConfigItem
            // 
            this.btnAddConfigItem.Enabled = false;
            this.btnAddConfigItem.Location = new System.Drawing.Point(6, 169);
            this.btnAddConfigItem.Name = "btnAddConfigItem";
            this.btnAddConfigItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddConfigItem.TabIndex = 0;
            this.btnAddConfigItem.Text = "Add";
            this.btnAddConfigItem.UseVisualStyleBackColor = true;
            this.btnAddConfigItem.Click += new System.EventHandler(this.btnAddConfigItem_Click);
            // 
            // grpboxNew
            // 
            this.grpboxNew.Controls.Add(this.panel1);
            this.grpboxNew.Controls.Add(this.flowPanel);
            this.grpboxNew.Controls.Add(this.btnAddConfigItem);
            this.grpboxNew.Controls.Add(this.rbRange);
            this.grpboxNew.Controls.Add(this.rbMultiple);
            this.grpboxNew.Controls.Add(this.rbSingle);
            this.grpboxNew.Controls.Add(this.pbImage);
            this.grpboxNew.Controls.Add(this.btnSelectBitmap);
            this.grpboxNew.Location = new System.Drawing.Point(12, 12);
            this.grpboxNew.Name = "grpboxNew";
            this.grpboxNew.Size = new System.Drawing.Size(324, 199);
            this.grpboxNew.TabIndex = 1;
            this.grpboxNew.TabStop = false;
            this.grpboxNew.Text = "Create new";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbText);
            this.panel1.Controls.Add(this.rbGump);
            this.panel1.Controls.Add(this.rbArtLand);
            this.panel1.Controls.Add(this.rbArt);
            this.panel1.Location = new System.Drawing.Point(84, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 22);
            this.panel1.TabIndex = 7;
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Location = new System.Drawing.Point(174, 3);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(61, 17);
            this.rbText.TabIndex = 11;
            this.rbText.Text = "Texture";
            this.rbText.UseVisualStyleBackColor = true;
            // 
            // rbGump
            // 
            this.rbGump.AutoSize = true;
            this.rbGump.Location = new System.Drawing.Point(115, 2);
            this.rbGump.Name = "rbGump";
            this.rbGump.Size = new System.Drawing.Size(53, 17);
            this.rbGump.TabIndex = 10;
            this.rbGump.Text = "Gump";
            this.rbGump.UseVisualStyleBackColor = true;
            // 
            // rbArtLand
            // 
            this.rbArtLand.AutoSize = true;
            this.rbArtLand.Location = new System.Drawing.Point(47, 3);
            this.rbArtLand.Name = "rbArtLand";
            this.rbArtLand.Size = new System.Drawing.Size(62, 17);
            this.rbArtLand.TabIndex = 9;
            this.rbArtLand.Text = "ArtLand";
            this.rbArtLand.UseVisualStyleBackColor = true;
            // 
            // rbArt
            // 
            this.rbArt.AutoSize = true;
            this.rbArt.Checked = true;
            this.rbArt.Location = new System.Drawing.Point(3, 3);
            this.rbArt.Name = "rbArt";
            this.rbArt.Size = new System.Drawing.Size(38, 17);
            this.rbArt.TabIndex = 8;
            this.rbArt.TabStop = true;
            this.rbArt.Text = "Art";
            this.rbArt.UseVisualStyleBackColor = true;
            // 
            // flowPanel
            // 
            this.flowPanel.Controls.Add(this.pnlSingle);
            this.flowPanel.Controls.Add(this.pnlMultiple);
            this.flowPanel.Controls.Add(this.pnlRange);
            this.flowPanel.Location = new System.Drawing.Point(127, 48);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(188, 115);
            this.flowPanel.TabIndex = 6;
            // 
            // pnlSingle
            // 
            this.pnlSingle.Controls.Add(this.tbSignle);
            this.pnlSingle.Location = new System.Drawing.Point(3, 3);
            this.pnlSingle.Name = "pnlSingle";
            this.pnlSingle.Size = new System.Drawing.Size(181, 27);
            this.pnlSingle.TabIndex = 0;
            // 
            // tbSignle
            // 
            this.tbSignle.Location = new System.Drawing.Point(3, 3);
            this.tbSignle.Name = "tbSignle";
            this.tbSignle.Size = new System.Drawing.Size(175, 20);
            this.tbSignle.TabIndex = 0;
            this.tbSignle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlMultiple
            // 
            this.pnlMultiple.AutoScroll = true;
            this.pnlMultiple.Controls.Add(this.tbMultiple);
            this.pnlMultiple.Location = new System.Drawing.Point(3, 36);
            this.pnlMultiple.Name = "pnlMultiple";
            this.pnlMultiple.Size = new System.Drawing.Size(181, 89);
            this.pnlMultiple.TabIndex = 1;
            // 
            // tbMultiple
            // 
            this.tbMultiple.Location = new System.Drawing.Point(3, 3);
            this.tbMultiple.Multiline = true;
            this.tbMultiple.Name = "tbMultiple";
            this.tbMultiple.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMultiple.Size = new System.Drawing.Size(175, 84);
            this.tbMultiple.TabIndex = 1;
            this.tbMultiple.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMultiple.WordWrap = false;
            // 
            // pnlRange
            // 
            this.pnlRange.Controls.Add(this.tbRange_2);
            this.pnlRange.Controls.Add(this.tbRange_1);
            this.pnlRange.Location = new System.Drawing.Point(3, 131);
            this.pnlRange.Name = "pnlRange";
            this.pnlRange.Size = new System.Drawing.Size(181, 55);
            this.pnlRange.TabIndex = 2;
            // 
            // tbRange_2
            // 
            this.tbRange_2.Location = new System.Drawing.Point(3, 29);
            this.tbRange_2.Name = "tbRange_2";
            this.tbRange_2.Size = new System.Drawing.Size(175, 20);
            this.tbRange_2.TabIndex = 2;
            this.tbRange_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRange_1
            // 
            this.tbRange_1.Location = new System.Drawing.Point(3, 3);
            this.tbRange_1.Name = "tbRange_1";
            this.tbRange_1.Size = new System.Drawing.Size(175, 20);
            this.tbRange_1.TabIndex = 1;
            this.tbRange_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbRange
            // 
            this.rbRange.AutoSize = true;
            this.rbRange.Location = new System.Drawing.Point(254, 22);
            this.rbRange.Name = "rbRange";
            this.rbRange.Size = new System.Drawing.Size(57, 17);
            this.rbRange.TabIndex = 5;
            this.rbRange.Text = "Range";
            this.rbRange.UseVisualStyleBackColor = true;
            this.rbRange.CheckedChanged += new System.EventHandler(this.rbRange_CheckedChanged);
            // 
            // rbMultiple
            // 
            this.rbMultiple.AutoSize = true;
            this.rbMultiple.Location = new System.Drawing.Point(187, 22);
            this.rbMultiple.Name = "rbMultiple";
            this.rbMultiple.Size = new System.Drawing.Size(61, 17);
            this.rbMultiple.TabIndex = 4;
            this.rbMultiple.Text = "Multiple";
            this.rbMultiple.UseVisualStyleBackColor = true;
            this.rbMultiple.CheckedChanged += new System.EventHandler(this.rbMultiple_CheckedChanged);
            // 
            // rbSingle
            // 
            this.rbSingle.AutoSize = true;
            this.rbSingle.Checked = true;
            this.rbSingle.Location = new System.Drawing.Point(127, 22);
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.Size = new System.Drawing.Size(54, 17);
            this.rbSingle.TabIndex = 3;
            this.rbSingle.TabStop = true;
            this.rbSingle.Text = "Single";
            this.rbSingle.UseVisualStyleBackColor = true;
            this.rbSingle.CheckedChanged += new System.EventHandler(this.rbSingle_CheckedChanged);
            // 
            // pbImage
            // 
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(6, 48);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(115, 115);
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            // 
            // btnSelectBitmap
            // 
            this.btnSelectBitmap.Location = new System.Drawing.Point(6, 19);
            this.btnSelectBitmap.Name = "btnSelectBitmap";
            this.btnSelectBitmap.Size = new System.Drawing.Size(115, 23);
            this.btnSelectBitmap.TabIndex = 0;
            this.btnSelectBitmap.Text = "Select image";
            this.btnSelectBitmap.UseVisualStyleBackColor = true;
            this.btnSelectBitmap.Click += new System.EventHandler(this.btnSelectBitmap_Click);
            // 
            // lboxAddedConfigItems
            // 
            this.lboxAddedConfigItems.FormattingEnabled = true;
            this.lboxAddedConfigItems.Location = new System.Drawing.Point(342, 19);
            this.lboxAddedConfigItems.Name = "lboxAddedConfigItems";
            this.lboxAddedConfigItems.Size = new System.Drawing.Size(174, 160);
            this.lboxAddedConfigItems.TabIndex = 2;
            // 
            // btnMakePatch
            // 
            this.btnMakePatch.Enabled = false;
            this.btnMakePatch.Location = new System.Drawing.Point(342, 185);
            this.btnMakePatch.Name = "btnMakePatch";
            this.btnMakePatch.Size = new System.Drawing.Size(174, 23);
            this.btnMakePatch.TabIndex = 8;
            this.btnMakePatch.Text = "Make patch";
            this.btnMakePatch.UseVisualStyleBackColor = true;
            this.btnMakePatch.Click += new System.EventHandler(this.btnMakePatch_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 217);
            this.Controls.Add(this.btnMakePatch);
            this.Controls.Add(this.lboxAddedConfigItems);
            this.Controls.Add(this.grpboxNew);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VMulPatcher - PatchCreator";
            this.grpboxNew.ResumeLayout(false);
            this.grpboxNew.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowPanel.ResumeLayout(false);
            this.pnlSingle.ResumeLayout(false);
            this.pnlSingle.PerformLayout();
            this.pnlMultiple.ResumeLayout(false);
            this.pnlMultiple.PerformLayout();
            this.pnlRange.ResumeLayout(false);
            this.pnlRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddConfigItem;
        private System.Windows.Forms.GroupBox grpboxNew;
        private System.Windows.Forms.RadioButton rbRange;
        private System.Windows.Forms.RadioButton rbMultiple;
        private System.Windows.Forms.RadioButton rbSingle;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnSelectBitmap;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.Panel pnlSingle;
        private System.Windows.Forms.TextBox tbSignle;
        private System.Windows.Forms.Panel pnlMultiple;
        private System.Windows.Forms.Panel pnlRange;
        private System.Windows.Forms.TextBox tbRange_2;
        private System.Windows.Forms.TextBox tbRange_1;
        private System.Windows.Forms.TextBox tbMultiple;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.RadioButton rbGump;
        private System.Windows.Forms.RadioButton rbArtLand;
        private System.Windows.Forms.RadioButton rbArt;
        private System.Windows.Forms.ListBox lboxAddedConfigItems;
        private System.Windows.Forms.Button btnMakePatch;
    }
}

