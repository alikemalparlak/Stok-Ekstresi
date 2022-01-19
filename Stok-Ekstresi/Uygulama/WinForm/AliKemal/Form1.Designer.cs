
namespace AliKemal
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
            this.btn_Getir = new System.Windows.Forms.Button();
            this.dt_Baslangic = new System.Windows.Forms.DateTimePicker();
            this.dt_Bitis = new System.Windows.Forms.DateTimePicker();
            this.grd_Liste = new System.Windows.Forms.DataGridView();
            this.txt_MalKodu = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Liste)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Getir
            // 
            this.btn_Getir.Location = new System.Drawing.Point(576, 11);
            this.btn_Getir.Name = "btn_Getir";
            this.btn_Getir.Size = new System.Drawing.Size(190, 23);
            this.btn_Getir.TabIndex = 1;
            this.btn_Getir.Text = "GETİR";
            this.btn_Getir.UseVisualStyleBackColor = true;
            this.btn_Getir.Click += new System.EventHandler(this.btn_Getir_Click);
            // 
            // dt_Baslangic
            // 
            this.dt_Baslangic.Location = new System.Drawing.Point(250, 12);
            this.dt_Baslangic.Name = "dt_Baslangic";
            this.dt_Baslangic.Size = new System.Drawing.Size(158, 20);
            this.dt_Baslangic.TabIndex = 2;
            // 
            // dt_Bitis
            // 
            this.dt_Bitis.Location = new System.Drawing.Point(414, 12);
            this.dt_Bitis.Name = "dt_Bitis";
            this.dt_Bitis.Size = new System.Drawing.Size(156, 20);
            this.dt_Bitis.TabIndex = 2;
            // 
            // grd_Liste
            // 
            this.grd_Liste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Liste.Location = new System.Drawing.Point(13, 38);
            this.grd_Liste.Name = "grd_Liste";
            this.grd_Liste.Size = new System.Drawing.Size(759, 400);
            this.grd_Liste.TabIndex = 3;
            // 
            // txt_MalKodu
            // 
            this.txt_MalKodu.Location = new System.Drawing.Point(13, 11);
            this.txt_MalKodu.Name = "txt_MalKodu";
            this.txt_MalKodu.Size = new System.Drawing.Size(231, 20);
            this.txt_MalKodu.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 450);
            this.Controls.Add(this.txt_MalKodu);
            this.Controls.Add(this.grd_Liste);
            this.Controls.Add(this.dt_Bitis);
            this.Controls.Add(this.dt_Baslangic);
            this.Controls.Add(this.btn_Getir);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_Liste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Getir;
        private System.Windows.Forms.DateTimePicker dt_Baslangic;
        private System.Windows.Forms.DateTimePicker dt_Bitis;
        private System.Windows.Forms.DataGridView grd_Liste;
        private System.Windows.Forms.TextBox txt_MalKodu;
    }
}

