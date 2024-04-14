namespace Vòng_2
{
    partial class GuessThePrice
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
            this.btn_LH = new System.Windows.Forms.Button();
            this.btn_NH = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.pnl_Start = new System.Windows.Forms.Panel();
            this.lbl_Result = new System.Windows.Forms.Label();
            this.pnl_Result = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_Game.SuspendLayout();
            this.pnl_Start.SuspendLayout();
            this.pnl_Result.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Vòng_2.Properties.Resources.logo_1;
            this.pictureBox1.Location = new System.Drawing.Point(27, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnl_Game
            // 
            this.pnl_Game.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Game.BackColor = System.Drawing.Color.Transparent;
            this.pnl_Game.Controls.Add(this.pnl_Result);
            this.pnl_Game.Controls.Add(this.btn_LH);
            this.pnl_Game.Controls.Add(this.btn_NH);
            this.pnl_Game.Controls.Add(this.label1);
            this.pnl_Game.Location = new System.Drawing.Point(211, 163);
            this.pnl_Game.Name = "pnl_Game";
            this.pnl_Game.Size = new System.Drawing.Size(559, 304);
            this.pnl_Game.TabIndex = 1;
            this.pnl_Game.Visible = false;
            // 
            // btn_LH
            // 
            this.btn_LH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_LH.Location = new System.Drawing.Point(346, 233);
            this.btn_LH.Name = "btn_LH";
            this.btn_LH.Size = new System.Drawing.Size(96, 40);
            this.btn_LH.TabIndex = 2;
            this.btn_LH.Text = "Lon hon";
            this.btn_LH.UseVisualStyleBackColor = true;
            this.btn_LH.Click += new System.EventHandler(this.btn_LH_Click_1);
            // 
            // btn_NH
            // 
            this.btn_NH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_NH.Location = new System.Drawing.Point(111, 233);
            this.btn_NH.Name = "btn_NH";
            this.btn_NH.Size = new System.Drawing.Size(96, 40);
            this.btn_NH.TabIndex = 1;
            this.btn_NH.Text = "Nho hon";
            this.btn_NH.UseVisualStyleBackColor = true;
            this.btn_NH.Click += new System.EventHandler(this.btn_NH_Click_1);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(111, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 212);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(55, 174);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(96, 40);
            this.btn_Start.TabIndex = 4;
            this.btn_Start.Text = "Bat dau";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // pnl_Start
            // 
            this.pnl_Start.BackColor = System.Drawing.Color.Transparent;
            this.pnl_Start.Controls.Add(this.btn_Start);
            this.pnl_Start.Controls.Add(this.pictureBox1);
            this.pnl_Start.Location = new System.Drawing.Point(393, 163);
            this.pnl_Start.Name = "pnl_Start";
            this.pnl_Start.Size = new System.Drawing.Size(190, 240);
            this.pnl_Start.TabIndex = 5;
            // 
            // lbl_Result
            // 
            this.lbl_Result.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Result.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_Result.Location = new System.Drawing.Point(69, 41);
            this.lbl_Result.Name = "lbl_Result";
            this.lbl_Result.Size = new System.Drawing.Size(416, 130);
            this.lbl_Result.TabIndex = 6;
            this.lbl_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_Result
            // 
            this.pnl_Result.BackColor = System.Drawing.Color.Transparent;
            this.pnl_Result.Controls.Add(this.button1);
            this.pnl_Result.Controls.Add(this.lbl_Result);
            this.pnl_Result.Location = new System.Drawing.Point(0, 0);
            this.pnl_Result.Name = "pnl_Result";
            this.pnl_Result.Size = new System.Drawing.Size(559, 304);
            this.pnl_Result.TabIndex = 7;
            this.pnl_Result.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(227, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GuessThePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Vòng_2.Properties.Resources.snapedit_1712216454656;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(978, 544);
            this.Controls.Add(this.pnl_Game);
            this.Controls.Add(this.pnl_Start);
            this.DoubleBuffered = true;
            this.Name = "GuessThePrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vong_2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_Game.ResumeLayout(false);
            this.pnl_Start.ResumeLayout(false);
            this.pnl_Result.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnl_Game;
        private System.Windows.Forms.Button btn_LH;
        private System.Windows.Forms.Button btn_NH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Panel pnl_Start;
        private System.Windows.Forms.Label lbl_Result;
        private System.Windows.Forms.Panel pnl_Result;
        private System.Windows.Forms.Button button1;
    }
}

