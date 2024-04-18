namespace TrangChu
{
    partial class SETTING
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
            this.label1 = new System.Windows.Forms.Label();
            this.rdb_bat = new System.Windows.Forms.RadioButton();
            this.rdb_tat = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(113, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Âm Thanh";
            // 
            // rdb_bat
            // 
            this.rdb_bat.AutoSize = true;
            this.rdb_bat.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_bat.Location = new System.Drawing.Point(64, 81);
            this.rdb_bat.Name = "rdb_bat";
            this.rdb_bat.Size = new System.Drawing.Size(78, 36);
            this.rdb_bat.TabIndex = 1;
            this.rdb_bat.TabStop = true;
            this.rdb_bat.Text = "Bật";
            this.rdb_bat.UseVisualStyleBackColor = true;
            this.rdb_bat.CheckedChanged += new System.EventHandler(this.rdb_bat_CheckedChanged);
            // 
            // rdb_tat
            // 
            this.rdb_tat.AutoSize = true;
            this.rdb_tat.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_tat.Location = new System.Drawing.Point(208, 81);
            this.rdb_tat.Name = "rdb_tat";
            this.rdb_tat.Size = new System.Drawing.Size(76, 36);
            this.rdb_tat.TabIndex = 2;
            this.rdb_tat.TabStop = true;
            this.rdb_tat.Text = "Tắt";
            this.rdb_tat.UseVisualStyleBackColor = true;
            this.rdb_tat.CheckedChanged += new System.EventHandler(this.rdb_tat_CheckedChanged);
            // 
            // SETTING
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(371, 200);
            this.Controls.Add(this.rdb_tat);
            this.Controls.Add(this.rdb_bat);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(439, 282);
            this.Name = "SETTING";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SETTING";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SETTING_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdb_bat;
        private System.Windows.Forms.RadioButton rdb_tat;
    }
}
