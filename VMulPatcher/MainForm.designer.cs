namespace VMulPatcher
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
            this.lbSlots = new System.Windows.Forms.ListBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBuildMUL = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbSlots
            // 
            this.lbSlots.FormattingEnabled = true;
            this.lbSlots.Location = new System.Drawing.Point(12, 12);
            this.lbSlots.Name = "lbSlots";
            this.lbSlots.Size = new System.Drawing.Size(97, 303);
            this.lbSlots.TabIndex = 0;
            this.lbSlots.SelectedIndexChanged += new System.EventHandler(this.lbSlots_SelectedIndexChanged);
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(115, 41);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(328, 274);
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(115, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(196, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save as bitmap";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBuildMUL
            // 
            this.btnBuildMUL.Location = new System.Drawing.Point(356, 12);
            this.btnBuildMUL.Name = "btnBuildMUL";
            this.btnBuildMUL.Size = new System.Drawing.Size(87, 23);
            this.btnBuildMUL.TabIndex = 4;
            this.btnBuildMUL.Text = "Build MUL";
            this.btnBuildMUL.UseVisualStyleBackColor = true;
            this.btnBuildMUL.Click += new System.EventHandler(this.btnBuildMUL_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(303, 15);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(47, 16);
            this.progressBar1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 324);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnBuildMUL);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lbSlots);
            this.Name = "MainForm";
            this.Text = "Venushja Mulpatcher v0.1 aplha GUI";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbSlots;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBuildMUL;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}