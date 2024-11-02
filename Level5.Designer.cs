using System;
using System.Drawing;
using System.Windows.Forms;

namespace nguyenquocduong_2122110443
{
    partial class Level5
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
            this.components = new System.ComponentModel.Container();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.tmStopwatch = new System.Windows.Forms.Timer(this.components);
            this.lbDiem = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblDisplay.Location = new System.Drawing.Point(712, 6);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(76, 29);
            this.lblDisplay.TabIndex = 2;
            this.lblDisplay.Text = "00:00";
            // Neo vào góc trên phải và di chuyển khi form thay đổi kích thước
            this.lblDisplay.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            // 
            // tmStopwatch
            // 
            this.tmStopwatch.Interval = 1000;

            // 
            // lbDiem
            // 
            this.lbDiem.AutoSize = true;
            this.lbDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbDiem.Location = new System.Drawing.Point(12, 6);
            this.lbDiem.Name = "lbDiem";
            this.lbDiem.Size = new System.Drawing.Size(79, 25);
            this.lbDiem.TabIndex = 3;
            this.lbDiem.Text = "Điểm: 0";
            this.lbDiem.BackColor = Color.Transparent;
            // Neo vào góc trên bên trái
            this.lbDiem.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            // 
            // bai28
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbDiem);
            this.Controls.Add(this.lblDisplay);
            this.Name = "bai28";
            this.Text = "bai28";
            this.Load += new System.EventHandler(this.Level5_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Level5_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Timer tmStopwatch;
        private System.Windows.Forms.Label lbDiem;
    }
}