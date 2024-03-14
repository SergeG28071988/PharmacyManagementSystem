namespace Pharmacy.UI
{
    partial class SplashForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Percentages = new System.Windows.Forms.Label();
            this.MyProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Percentages
            // 
            this.Percentages.AutoSize = true;
            this.Percentages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Percentages.Location = new System.Drawing.Point(101, 342);
            this.Percentages.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Percentages.Name = "Percentages";
            this.Percentages.Size = new System.Drawing.Size(23, 20);
            this.Percentages.TabIndex = 5;
            this.Percentages.Text = "%";
            // 
            // MyProgress
            // 
            this.MyProgress.Location = new System.Drawing.Point(159, 333);
            this.MyProgress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MyProgress.Name = "MyProgress";
            this.MyProgress.Size = new System.Drawing.Size(469, 34);
            this.MyProgress.TabIndex = 4;
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::Pharmacy.UI.Properties.Resources.аптека_2;
            this.ClientSize = new System.Drawing.Size(773, 431);
            this.Controls.Add(this.Percentages);
            this.Controls.Add(this.MyProgress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SplashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashForm";
            this.Load += new System.EventHandler(this.SplashForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Percentages;
        private System.Windows.Forms.ProgressBar MyProgress;
    }
}