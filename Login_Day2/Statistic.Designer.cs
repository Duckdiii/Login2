namespace Login_Day2
{
    partial class Statistic
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
            this.SumQuantity_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SumMale_label = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SumFemale_label = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SumQuantity_label
            // 
            this.SumQuantity_label.AutoSize = true;
            this.SumQuantity_label.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SumQuantity_label.Location = new System.Drawing.Point(242, 38);
            this.SumQuantity_label.Name = "SumQuantity_label";
            this.SumQuantity_label.Size = new System.Drawing.Size(166, 62);
            this.SumQuantity_label.TabIndex = 0;
            this.SumQuantity_label.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SumQuantity_label);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 160);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SumMale_label);
            this.panel2.Location = new System.Drawing.Point(12, 178);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 157);
            this.panel2.TabIndex = 2;
            // 
            // SumMale_label
            // 
            this.SumMale_label.AutoSize = true;
            this.SumMale_label.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SumMale_label.Location = new System.Drawing.Point(71, 42);
            this.SumMale_label.Name = "SumMale_label";
            this.SumMale_label.Size = new System.Drawing.Size(166, 62);
            this.SumMale_label.TabIndex = 1;
            this.SumMale_label.Text = "label2";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SumFemale_label);
            this.panel3.Location = new System.Drawing.Point(340, 178);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(342, 157);
            this.panel3.TabIndex = 3;
            // 
            // SumFemale_label
            // 
            this.SumFemale_label.AutoSize = true;
            this.SumFemale_label.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SumFemale_label.Location = new System.Drawing.Point(84, 42);
            this.SumFemale_label.Name = "SumFemale_label";
            this.SumFemale_label.Size = new System.Drawing.Size(166, 62);
            this.SumFemale_label.TabIndex = 2;
            this.SumFemale_label.Text = "label3";
            // 
            // Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 347);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Statistic";
            this.Text = "Statistic_23110009_NguyenDucDuy";
            this.Load += new System.EventHandler(this.Statistic_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label SumQuantity_label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label SumMale_label;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label SumFemale_label;
    }
}