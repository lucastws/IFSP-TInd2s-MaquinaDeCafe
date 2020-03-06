namespace TInd_MaquinaDeCafe
{
    partial class frmCarteira
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarteira));
            this.btnRetirarTroco = new System.Windows.Forms.Button();
            this.pctMoeda1real = new System.Windows.Forms.PictureBox();
            this.pctMoeda50 = new System.Windows.Forms.PictureBox();
            this.pctMoeda25 = new System.Windows.Forms.PictureBox();
            this.pctMoeda10 = new System.Windows.Forms.PictureBox();
            this.pctMoeda5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctMoeda1real)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMoeda50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMoeda25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMoeda10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMoeda5)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRetirarTroco
            // 
            this.btnRetirarTroco.Location = new System.Drawing.Point(12, 147);
            this.btnRetirarTroco.Name = "btnRetirarTroco";
            this.btnRetirarTroco.Size = new System.Drawing.Size(529, 46);
            this.btnRetirarTroco.TabIndex = 5;
            this.btnRetirarTroco.Text = "RETIRAR TROCO";
            this.btnRetirarTroco.UseVisualStyleBackColor = true;
            this.btnRetirarTroco.Click += new System.EventHandler(this.btnRetirarTroco_Click);
            // 
            // pctMoeda1real
            // 
            this.pctMoeda1real.Location = new System.Drawing.Point(440, 12);
            this.pctMoeda1real.Name = "pctMoeda1real";
            this.pctMoeda1real.Size = new System.Drawing.Size(101, 104);
            this.pctMoeda1real.TabIndex = 4;
            this.pctMoeda1real.TabStop = false;
            this.pctMoeda1real.Click += new System.EventHandler(this.pctMoeda1real_Click);
            // 
            // pctMoeda50
            // 
            this.pctMoeda50.Location = new System.Drawing.Point(333, 12);
            this.pctMoeda50.Name = "pctMoeda50";
            this.pctMoeda50.Size = new System.Drawing.Size(101, 104);
            this.pctMoeda50.TabIndex = 3;
            this.pctMoeda50.TabStop = false;
            this.pctMoeda50.Click += new System.EventHandler(this.pctMoeda50_Click);
            // 
            // pctMoeda25
            // 
            this.pctMoeda25.Location = new System.Drawing.Point(226, 12);
            this.pctMoeda25.Name = "pctMoeda25";
            this.pctMoeda25.Size = new System.Drawing.Size(101, 104);
            this.pctMoeda25.TabIndex = 2;
            this.pctMoeda25.TabStop = false;
            this.pctMoeda25.Click += new System.EventHandler(this.pctMoeda25_Click);
            // 
            // pctMoeda10
            // 
            this.pctMoeda10.Location = new System.Drawing.Point(119, 12);
            this.pctMoeda10.Name = "pctMoeda10";
            this.pctMoeda10.Size = new System.Drawing.Size(101, 104);
            this.pctMoeda10.TabIndex = 1;
            this.pctMoeda10.TabStop = false;
            this.pctMoeda10.Click += new System.EventHandler(this.pctMoeda10_Click);
            // 
            // pctMoeda5
            // 
            this.pctMoeda5.Location = new System.Drawing.Point(12, 12);
            this.pctMoeda5.Name = "pctMoeda5";
            this.pctMoeda5.Size = new System.Drawing.Size(101, 104);
            this.pctMoeda5.TabIndex = 0;
            this.pctMoeda5.TabStop = false;
            this.pctMoeda5.Click += new System.EventHandler(this.pctMoeda5_Click);
            // 
            // frmCarteira
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 205);
            this.Controls.Add(this.btnRetirarTroco);
            this.Controls.Add(this.pctMoeda1real);
            this.Controls.Add(this.pctMoeda50);
            this.Controls.Add(this.pctMoeda25);
            this.Controls.Add(this.pctMoeda10);
            this.Controls.Add(this.pctMoeda5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCarteira";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carteira";
            ((System.ComponentModel.ISupportInitialize)(this.pctMoeda1real)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMoeda50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMoeda25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMoeda10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMoeda5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctMoeda5;
        private System.Windows.Forms.PictureBox pctMoeda10;
        private System.Windows.Forms.PictureBox pctMoeda25;
        private System.Windows.Forms.PictureBox pctMoeda50;
        private System.Windows.Forms.PictureBox pctMoeda1real;
        public System.Windows.Forms.Button btnRetirarTroco;
    }
}