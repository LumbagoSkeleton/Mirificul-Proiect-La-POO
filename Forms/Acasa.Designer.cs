namespace WindowsFormsApp1.Forms
{
    partial class Acasa
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
            this.profil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rezervareRuta = new System.Windows.Forms.Button();
            this.gestionare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // profil
            // 
            this.profil.Location = new System.Drawing.Point(681, 27);
            this.profil.Name = "profil";
            this.profil.Size = new System.Drawing.Size(96, 55);
            this.profil.TabIndex = 0;
            this.profil.Text = "Profil";
            this.profil.UseVisualStyleBackColor = true;
            this.profil.Click += new System.EventHandler(this.profil_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(37, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pagina principala";
            // 
            // rezervareRuta
            // 
            this.rezervareRuta.Location = new System.Drawing.Point(579, 28);
            this.rezervareRuta.Name = "rezervareRuta";
            this.rezervareRuta.Size = new System.Drawing.Size(96, 55);
            this.rezervareRuta.TabIndex = 2;
            this.rezervareRuta.Text = "Rute";
            this.rezervareRuta.UseVisualStyleBackColor = true;
            this.rezervareRuta.Click += new System.EventHandler(this.rezervareRuta_Click);
            // 
            // gestionare
            // 
            this.gestionare.Location = new System.Drawing.Point(452, 28);
            this.gestionare.Name = "gestionare";
            this.gestionare.Size = new System.Drawing.Size(121, 55);
            this.gestionare.TabIndex = 3;
            this.gestionare.Text = "Optiuni administrator";
            this.gestionare.UseVisualStyleBackColor = true;
            this.gestionare.Click += new System.EventHandler(this.gestionare_Click);
            // 
            // Acasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gestionare);
            this.Controls.Add(this.rezervareRuta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.profil);
            this.Name = "Acasa";
            this.Text = "Acasa";
            this.Load += new System.EventHandler(this.Acasa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button profil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button rezervareRuta;
        private System.Windows.Forms.Button gestionare;
    }
}