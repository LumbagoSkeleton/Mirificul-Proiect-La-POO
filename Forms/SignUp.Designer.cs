namespace WindowsFormsApp1
{
    partial class SignUp
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
            this.label2 = new System.Windows.Forms.Label();
            this.prenumeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numeTextBox = new System.Windows.Forms.TextBox();
            this.signupButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.varstaTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.parolaTextBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.parolaTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ListaRoluri = new System.Windows.Forms.ListBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Prenume";
            // 
            // prenumeTextBox
            // 
            this.prenumeTextBox.Location = new System.Drawing.Point(324, 119);
            this.prenumeTextBox.Name = "prenumeTextBox";
            this.prenumeTextBox.Size = new System.Drawing.Size(249, 22);
            this.prenumeTextBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nume";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // numeTextBox
            // 
            this.numeTextBox.Location = new System.Drawing.Point(324, 91);
            this.numeTextBox.Name = "numeTextBox";
            this.numeTextBox.Size = new System.Drawing.Size(249, 22);
            this.numeTextBox.TabIndex = 9;
            // 
            // signupButton
            // 
            this.signupButton.Location = new System.Drawing.Point(324, 395);
            this.signupButton.Name = "signupButton";
            this.signupButton.Size = new System.Drawing.Size(147, 39);
            this.signupButton.TabIndex = 8;
            this.signupButton.Text = "Autentificare";
            this.signupButton.UseVisualStyleBackColor = true;
            this.signupButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Adresa e-mail";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(324, 175);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(249, 22);
            this.emailTextBox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Varsta";
            // 
            // varstaTextBox
            // 
            this.varstaTextBox.Location = new System.Drawing.Point(324, 147);
            this.varstaTextBox.Name = "varstaTextBox";
            this.varstaTextBox.Size = new System.Drawing.Size(249, 22);
            this.varstaTextBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label5.Location = new System.Drawing.Point(303, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 29);
            this.label5.TabIndex = 17;
            this.label5.Text = "Creeaza un cont";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 34);
            this.label6.TabIndex = 21;
            this.label6.Text = "Confirmarea\r\nparolei";
            // 
            // parolaTextBox2
            // 
            this.parolaTextBox2.Location = new System.Drawing.Point(324, 243);
            this.parolaTextBox2.Name = "parolaTextBox2";
            this.parolaTextBox2.PasswordChar = '*';
            this.parolaTextBox2.Size = new System.Drawing.Size(249, 22);
            this.parolaTextBox2.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Parola";
            // 
            // parolaTextBox
            // 
            this.parolaTextBox.Location = new System.Drawing.Point(324, 203);
            this.parolaTextBox.Name = "parolaTextBox";
            this.parolaTextBox.PasswordChar = '*';
            this.parolaTextBox.Size = new System.Drawing.Size(249, 22);
            this.parolaTextBox.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(223, 277);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Rol";
            // 
            // ListaRoluri
            // 
            this.ListaRoluri.FormattingEnabled = true;
            this.ListaRoluri.ItemHeight = 16;
            this.ListaRoluri.Items.AddRange(new object[] {
            "Calator",
            "Administrator"});
            this.ListaRoluri.Location = new System.Drawing.Point(324, 277);
            this.ListaRoluri.Name = "ListaRoluri";
            this.ListaRoluri.Size = new System.Drawing.Size(249, 36);
            this.ListaRoluri.TabIndex = 23;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(153, 335);
            this.errorLabel.MinimumSize = new System.Drawing.Size(500, 17);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(500, 17);
            this.errorLabel.TabIndex = 24;
            this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.errorLabel.Click += new System.EventHandler(this.label9_Click);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 523);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.ListaRoluri);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.parolaTextBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.parolaTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.varstaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.prenumeTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numeTextBox);
            this.Controls.Add(this.signupButton);
            this.Name = "SignUp";
            this.Text = "SignUp";
            this.Load += new System.EventHandler(this.SignUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox prenumeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numeTextBox;
        private System.Windows.Forms.Button signupButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox varstaTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox parolaTextBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox parolaTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox ListaRoluri;
        private System.Windows.Forms.Label errorLabel;
    }
}