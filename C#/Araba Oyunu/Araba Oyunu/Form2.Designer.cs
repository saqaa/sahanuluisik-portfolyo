namespace Araba_Oyunu
{
    partial class Form2
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
            this.oyundevam = new System.Windows.Forms.Button();
            this.bastanbasla = new System.Windows.Forms.Button();
            this.oyundancik = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oyun Durduruldu!!";
            // 
            // oyundevam
            // 
            this.oyundevam.Location = new System.Drawing.Point(32, 46);
            this.oyundevam.Name = "oyundevam";
            this.oyundevam.Size = new System.Drawing.Size(191, 35);
            this.oyundevam.TabIndex = 1;
            this.oyundevam.Text = "Oyuna Devam Et";
            this.oyundevam.UseVisualStyleBackColor = true;
            this.oyundevam.Click += new System.EventHandler(this.oyundevam_Click);
            // 
            // bastanbasla
            // 
            this.bastanbasla.Location = new System.Drawing.Point(32, 87);
            this.bastanbasla.Name = "bastanbasla";
            this.bastanbasla.Size = new System.Drawing.Size(191, 35);
            this.bastanbasla.TabIndex = 2;
            this.bastanbasla.Text = "Baştan Başla";
            this.bastanbasla.UseVisualStyleBackColor = true;
            this.bastanbasla.Click += new System.EventHandler(this.bastanbasla_Click);
            // 
            // oyundancik
            // 
            this.oyundancik.Location = new System.Drawing.Point(32, 128);
            this.oyundancik.Name = "oyundancik";
            this.oyundancik.Size = new System.Drawing.Size(191, 35);
            this.oyundancik.TabIndex = 3;
            this.oyundancik.Text = "Oyundan Çık";
            this.oyundancik.UseVisualStyleBackColor = true;
            this.oyundancik.Click += new System.EventHandler(this.oyundancik_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 180);
            this.ControlBox = false;
            this.Controls.Add(this.oyundancik);
            this.Controls.Add(this.bastanbasla);
            this.Controls.Add(this.oyundevam);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duraklatıldı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button oyundancik;
        public System.Windows.Forms.Button oyundevam;
        public System.Windows.Forms.Button bastanbasla;
    }
}