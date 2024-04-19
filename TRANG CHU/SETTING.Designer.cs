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
            this.rdb_t = new System.Windows.Forms.RadioButton();
            this.rdb_b = new System.Windows.Forms.RadioButton();
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
            // rdb_t
            // 
            this.rdb_t.AutoSize = true;
            this.rdb_t.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_t.Location = new System.Drawing.Point(64, 81);
            this.rdb_t.Name = "rdb_t";
            this.rdb_t.Size = new System.Drawing.Size(76, 36);
            this.rdb_t.TabIndex = 1;
            this.rdb_t.TabStop = true;
            this.rdb_t.Text = "Tắt";
            this.rdb_t.UseVisualStyleBackColor = true;
            this.rdb_t.CheckedChanged += new System.EventHandler(this.rdb_t_CheckedChanged);
            // 
            // rdb_b
            // 
            this.rdb_b.AutoSize = true;
            this.rdb_b.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_b.Location = new System.Drawing.Point(208, 81);
            this.rdb_b.Name = "rdb_b";
            this.rdb_b.Size = new System.Drawing.Size(78, 36);
            this.rdb_b.TabIndex = 2;
            this.rdb_b.TabStop = true;
            this.rdb_b.Text = "Bật";
            this.rdb_b.UseVisualStyleBackColor = true;
            this.rdb_b.CheckedChanged += new System.EventHandler(this.rdb_b_CheckedChanged);
            // 
            // SETTING
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(371, 200);
            this.Controls.Add(this.rdb_b);
            this.Controls.Add(this.rdb_t);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(439, 282);
            this.Name = "SETTING";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SETTING";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SETTING_FormClosed);
            this.Load += new System.EventHandler(this.SETTING_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdb_t;
        private System.Windows.Forms.RadioButton rdb_b;
    }
}
