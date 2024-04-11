namespace Vòng_2
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_Game = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_LH = new System.Windows.Forms.Button();
            this.btn_NH = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_Game.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Vòng_2.Properties.Resources.logo_1;
            this.pictureBox1.Location = new System.Drawing.Point(417, 223);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnl_Game
            // 
            this.pnl_Game.BackColor = System.Drawing.Color.Transparent;
            this.pnl_Game.Controls.Add(this.label2);
            this.pnl_Game.Controls.Add(this.btn_LH);
            this.pnl_Game.Controls.Add(this.btn_NH);
            this.pnl_Game.Controls.Add(this.label1);
            this.pnl_Game.Location = new System.Drawing.Point(301, 163);
            this.pnl_Game.Name = "pnl_Game";
            this.pnl_Game.Size = new System.Drawing.Size(373, 287);
            this.pnl_Game.TabIndex = 1;
            this.pnl_Game.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 32);
            this.label2.TabIndex = 3;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_LH
            // 
            this.btn_LH.Location = new System.Drawing.Point(226, 207);
            this.btn_LH.Name = "btn_LH";
            this.btn_LH.Size = new System.Drawing.Size(96, 40);
            this.btn_LH.TabIndex = 2;
            this.btn_LH.Text = "Lon hon";
            this.btn_LH.UseVisualStyleBackColor = true;
            // 
            // btn_NH
            // 
            this.btn_NH.Location = new System.Drawing.Point(54, 207);
            this.btn_NH.Name = "btn_NH";
            this.btn_NH.Size = new System.Drawing.Size(96, 40);
            this.btn_NH.TabIndex = 1;
            this.btn_NH.Text = "Nho hon";
            this.btn_NH.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 32);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Vòng_2.Properties.Resources.snapedit_1712216454656;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(978, 544);
            this.Controls.Add(this.pnl_Game);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vong_2";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_Game.ResumeLayout(false);
            this.pnl_Game.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnl_Game;
        private System.Windows.Forms.Button btn_LH;
        private System.Windows.Forms.Button btn_NH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

