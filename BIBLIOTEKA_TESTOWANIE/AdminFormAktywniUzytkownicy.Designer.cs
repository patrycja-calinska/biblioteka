namespace BIBLIOTEKA_TESTOWANIE
{
    partial class AdminFormAktywniUzytkownicy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminFormAktywniUzytkownicy));
            this.dataGridViewUzytkownicy = new System.Windows.Forms.DataGridView();
            this.buttonSzczegoly = new System.Windows.Forms.Button();
            this.buttonPowrot = new System.Windows.Forms.Button();
            this.textBoxImie = new System.Windows.Forms.TextBox();
            this.textBoxNazwisko = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonZapomnij = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUzytkownicy)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUzytkownicy
            // 
            this.dataGridViewUzytkownicy.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewUzytkownicy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUzytkownicy.Location = new System.Drawing.Point(15, 60);
            this.dataGridViewUzytkownicy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewUzytkownicy.Name = "dataGridViewUzytkownicy";
            this.dataGridViewUzytkownicy.RowHeadersWidth = 51;
            this.dataGridViewUzytkownicy.RowTemplate.Height = 24;
            this.dataGridViewUzytkownicy.Size = new System.Drawing.Size(995, 450);
            this.dataGridViewUzytkownicy.TabIndex = 69;
            this.dataGridViewUzytkownicy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUzytkownicy_CellContentClick);
            // 
            // buttonSzczegoly
            // 
            this.buttonSzczegoly.BackColor = System.Drawing.Color.Peru;
            this.buttonSzczegoly.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSzczegoly.Location = new System.Drawing.Point(41, 529);
            this.buttonSzczegoly.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSzczegoly.Name = "buttonSzczegoly";
            this.buttonSzczegoly.Size = new System.Drawing.Size(216, 76);
            this.buttonSzczegoly.TabIndex = 72;
            this.buttonSzczegoly.Text = "Szczegółowe dane";
            this.buttonSzczegoly.UseVisualStyleBackColor = false;
            this.buttonSzczegoly.Click += new System.EventHandler(this.buttonSzczegoly_Click);
            // 
            // buttonPowrot
            // 
            this.buttonPowrot.BackColor = System.Drawing.Color.Peru;
            this.buttonPowrot.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPowrot.Location = new System.Drawing.Point(880, 10);
            this.buttonPowrot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPowrot.Name = "buttonPowrot";
            this.buttonPowrot.Size = new System.Drawing.Size(100, 41);
            this.buttonPowrot.TabIndex = 73;
            this.buttonPowrot.Text = "Powrót";
            this.buttonPowrot.UseVisualStyleBackColor = false;
            this.buttonPowrot.Click += new System.EventHandler(this.buttonPowrot_Click);
            // 
            // textBoxImie
            // 
            this.textBoxImie.Location = new System.Drawing.Point(77, 22);
            this.textBoxImie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxImie.Name = "textBoxImie";
            this.textBoxImie.Size = new System.Drawing.Size(132, 22);
            this.textBoxImie.TabIndex = 74;
            this.textBoxImie.TextChanged += new System.EventHandler(this.textBoxImie_TextChanged);
            // 
            // textBoxNazwisko
            // 
            this.textBoxNazwisko.Location = new System.Drawing.Point(337, 22);
            this.textBoxNazwisko.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNazwisko.Name = "textBoxNazwisko";
            this.textBoxNazwisko.Size = new System.Drawing.Size(132, 22);
            this.textBoxNazwisko.TabIndex = 75;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(565, 22);
            this.textBoxLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(132, 22);
            this.textBoxLogin.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 77;
            this.label1.Text = "Imię:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(232, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 78;
            this.label2.Text = "Nazwisko:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(495, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 79;
            this.label3.Text = "Login:";
            // 
            // buttonZapomnij
            // 
            this.buttonZapomnij.BackColor = System.Drawing.Color.Peru;
            this.buttonZapomnij.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonZapomnij.Location = new System.Drawing.Point(764, 529);
            this.buttonZapomnij.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonZapomnij.Name = "buttonZapomnij";
            this.buttonZapomnij.Size = new System.Drawing.Size(216, 76);
            this.buttonZapomnij.TabIndex = 80;
            this.buttonZapomnij.Text = "Zapomnij użytkownika";
            this.buttonZapomnij.UseVisualStyleBackColor = false;
            this.buttonZapomnij.Click += new System.EventHandler(this.buttonZapomnij_Click);
            // 
            // AdminFormAktywniUzytkownicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1031, 649);
            this.Controls.Add(this.buttonZapomnij);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.textBoxNazwisko);
            this.Controls.Add(this.textBoxImie);
            this.Controls.Add(this.buttonPowrot);
            this.Controls.Add(this.buttonSzczegoly);
            this.Controls.Add(this.dataGridViewUzytkownicy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminFormAktywniUzytkownicy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LibraSys | Aktywni użytkownicy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminFormAktywniUzytkownicy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUzytkownicy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUzytkownicy;
        private System.Windows.Forms.Button buttonSzczegoly;
        private System.Windows.Forms.Button buttonPowrot;
        private System.Windows.Forms.TextBox textBoxImie;
        private System.Windows.Forms.TextBox textBoxNazwisko;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonZapomnij;
    }
}