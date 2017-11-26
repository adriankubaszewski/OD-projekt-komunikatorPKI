namespace Komunikator_z_PKI
{
    partial class Rejestracja
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
            this.label2 = new System.Windows.Forms.Label();
            this.tb_imie = new System.Windows.Forms.TextBox();
            this.tb_nazwisko = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_haslo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_klucz = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_haslo2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rejestracja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Imię:";
            // 
            // tb_imie
            // 
            this.tb_imie.Location = new System.Drawing.Point(76, 81);
            this.tb_imie.Name = "tb_imie";
            this.tb_imie.Size = new System.Drawing.Size(143, 20);
            this.tb_imie.TabIndex = 2;
            // 
            // tb_nazwisko
            // 
            this.tb_nazwisko.Location = new System.Drawing.Point(76, 130);
            this.tb_nazwisko.Name = "tb_nazwisko";
            this.tb_nazwisko.Size = new System.Drawing.Size(143, 20);
            this.tb_nazwisko.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nazwisko:";
            // 
            // tb_login
            // 
            this.tb_login.Location = new System.Drawing.Point(76, 180);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(143, 20);
            this.tb_login.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Login";
            // 
            // tb_haslo
            // 
            this.tb_haslo.Location = new System.Drawing.Point(76, 228);
            this.tb_haslo.Name = "tb_haslo";
            this.tb_haslo.Size = new System.Drawing.Size(143, 20);
            this.tb_haslo.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(132, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Hasło";
            // 
            // tb_klucz
            // 
            this.tb_klucz.Location = new System.Drawing.Point(76, 367);
            this.tb_klucz.Name = "tb_klucz";
            this.tb_klucz.Size = new System.Drawing.Size(143, 20);
            this.tb_klucz.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "klucz publiczny";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Utwórz konto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(104, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Powtórz hasło";
            // 
            // tb_haslo2
            // 
            this.tb_haslo2.Location = new System.Drawing.Point(76, 279);
            this.tb_haslo2.Name = "tb_haslo2";
            this.tb_haslo2.Size = new System.Drawing.Size(143, 20);
            this.tb_haslo2.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(176, 393);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Zamknij";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 466);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tb_haslo2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_klucz);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_haslo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_login);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_nazwisko);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_imie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_imie;
        private System.Windows.Forms.TextBox tb_nazwisko;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_haslo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_klucz;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_haslo2;
        private System.Windows.Forms.Button button2;
    }
}