using System;

namespace BIBLIOTEKA_TESTOWANIE
{
    partial class AdminFormDodajUzytkownika
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminFormDodajUzytkownika));
            this.rola = new System.Windows.Forms.Label();
            this.comboBoxRola = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imie = new System.Windows.Forms.Label();
            this.dane = new System.Windows.Forms.Label();
            this.textBoxNazwisko = new System.Windows.Forms.TextBox();
            this.textBoxImie = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.comboBoxPlec = new System.Windows.Forms.ComboBox();
            this.dateTimePickerDataUrodzenia = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTelefon = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPesel = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxNrLokalu = new System.Windows.Forms.TextBox();
            this.textBoxNrPosesji = new System.Windows.Forms.TextBox();
            this.textBoxUlica = new System.Windows.Forms.TextBox();
            this.textBoxKodPocztowy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMiejscowosc = new System.Windows.Forms.TextBox();
            this.buttonDodaj = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.buttonPowrot = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // rola
            // 
            this.rola.AutoSize = true;
            this.rola.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rola.Location = new System.Drawing.Point(197, 235);
            this.rola.Name = "rola";
            this.rola.Size = new System.Drawing.Size(65, 20);
            this.rola.TabIndex = 43;
            this.rola.Text = "*Rola:";
            // 
            // comboBoxRola
            // 
            this.comboBoxRola.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxRola.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxRola.FormattingEnabled = true;
            this.comboBoxRola.Location = new System.Drawing.Point(269, 234);
            this.comboBoxRola.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxRola.Name = "comboBoxRola";
            this.comboBoxRola.Size = new System.Drawing.Size(163, 25);
            this.comboBoxRola.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(159, 188);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "*Nazwisko:";
            // 
            // imie
            // 
            this.imie.AutoSize = true;
            this.imie.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.imie.Location = new System.Drawing.Point(197, 143);
            this.imie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.imie.Name = "imie";
            this.imie.Size = new System.Drawing.Size(68, 20);
            this.imie.TabIndex = 40;
            this.imie.Text = "*Imię:";
            this.imie.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dane
            // 
            this.dane.AutoSize = true;
            this.dane.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dane.Location = new System.Drawing.Point(193, 98);
            this.dane.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dane.Name = "dane";
            this.dane.Size = new System.Drawing.Size(74, 20);
            this.dane.TabIndex = 39;
            this.dane.Text = "*Login:";
            this.dane.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxNazwisko
            // 
            this.textBoxNazwisko.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxNazwisko.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNazwisko.Location = new System.Drawing.Point(269, 187);
            this.textBoxNazwisko.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNazwisko.Name = "textBoxNazwisko";
            this.textBoxNazwisko.Size = new System.Drawing.Size(163, 24);
            this.textBoxNazwisko.TabIndex = 38;
            // 
            // textBoxImie
            // 
            this.textBoxImie.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxImie.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxImie.Location = new System.Drawing.Point(269, 142);
            this.textBoxImie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxImie.Name = "textBoxImie";
            this.textBoxImie.Size = new System.Drawing.Size(163, 24);
            this.textBoxImie.TabIndex = 37;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxLogin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxLogin.Location = new System.Drawing.Point(269, 97);
            this.textBoxLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(163, 24);
            this.textBoxLogin.TabIndex = 36;
            this.textBoxLogin.TextChanged += new System.EventHandler(this.textBoxLogin_TextChanged);
            // 
            // comboBoxPlec
            // 
            this.comboBoxPlec.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxPlec.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxPlec.FormattingEnabled = true;
            this.comboBoxPlec.Location = new System.Drawing.Point(264, 401);
            this.comboBoxPlec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxPlec.Name = "comboBoxPlec";
            this.comboBoxPlec.Size = new System.Drawing.Size(132, 25);
            this.comboBoxPlec.TabIndex = 53;
            // 
            // dateTimePickerDataUrodzenia
            // 
            this.dateTimePickerDataUrodzenia.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dateTimePickerDataUrodzenia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePickerDataUrodzenia.Location = new System.Drawing.Point(163, 351);
            this.dateTimePickerDataUrodzenia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerDataUrodzenia.Name = "dateTimePickerDataUrodzenia";
            this.dateTimePickerDataUrodzenia.Size = new System.Drawing.Size(323, 24);
            this.dateTimePickerDataUrodzenia.TabIndex = 52;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(192, 507);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 20);
            this.label8.TabIndex = 51;
            this.label8.Text = "*Numer telefonu:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(193, 441);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 20);
            this.label7.TabIndex = 50;
            this.label7.Text = "*Adres e-mail:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(193, 401);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 49;
            this.label6.Text = "*Płeć:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(193, 327);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 20);
            this.label5.TabIndex = 48;
            this.label5.Text = "*Data urodzenia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(193, 279);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 47;
            this.label4.Text = "*Pesel:";
            // 
            // textBoxTelefon
            // 
            this.textBoxTelefon.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxTelefon.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxTelefon.Location = new System.Drawing.Point(197, 530);
            this.textBoxTelefon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTelefon.Name = "textBoxTelefon";
            this.textBoxTelefon.Size = new System.Drawing.Size(199, 24);
            this.textBoxTelefon.TabIndex = 46;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxEmail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxEmail.Location = new System.Drawing.Point(197, 464);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(199, 24);
            this.textBoxEmail.TabIndex = 45;
            // 
            // textBoxPesel
            // 
            this.textBoxPesel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxPesel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPesel.Location = new System.Drawing.Point(269, 278);
            this.textBoxPesel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPesel.Name = "textBoxPesel";
            this.textBoxPesel.Size = new System.Drawing.Size(163, 24);
            this.textBoxPesel.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(536, 262);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 20);
            this.label13.TabIndex = 64;
            this.label13.Text = "Numer lokalu:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(536, 219);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(152, 20);
            this.label12.TabIndex = 63;
            this.label12.Text = "*Numer posesji:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(579, 180);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 20);
            this.label11.TabIndex = 62;
            this.label11.Text = "Ulica:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(536, 139);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 20);
            this.label10.TabIndex = 61;
            this.label10.Text = "*Kod pocztowy:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(551, 95);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 20);
            this.label9.TabIndex = 60;
            this.label9.Text = "*Miejscowość:";
            // 
            // textBoxNrLokalu
            // 
            this.textBoxNrLokalu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxNrLokalu.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNrLokalu.Location = new System.Drawing.Point(699, 261);
            this.textBoxNrLokalu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNrLokalu.Name = "textBoxNrLokalu";
            this.textBoxNrLokalu.Size = new System.Drawing.Size(163, 24);
            this.textBoxNrLokalu.TabIndex = 59;
            // 
            // textBoxNrPosesji
            // 
            this.textBoxNrPosesji.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxNrPosesji.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNrPosesji.Location = new System.Drawing.Point(699, 219);
            this.textBoxNrPosesji.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNrPosesji.Name = "textBoxNrPosesji";
            this.textBoxNrPosesji.Size = new System.Drawing.Size(163, 24);
            this.textBoxNrPosesji.TabIndex = 58;
            // 
            // textBoxUlica
            // 
            this.textBoxUlica.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxUlica.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxUlica.Location = new System.Drawing.Point(699, 178);
            this.textBoxUlica.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUlica.Name = "textBoxUlica";
            this.textBoxUlica.Size = new System.Drawing.Size(163, 24);
            this.textBoxUlica.TabIndex = 57;
            // 
            // textBoxKodPocztowy
            // 
            this.textBoxKodPocztowy.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxKodPocztowy.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxKodPocztowy.Location = new System.Drawing.Point(699, 138);
            this.textBoxKodPocztowy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxKodPocztowy.Name = "textBoxKodPocztowy";
            this.textBoxKodPocztowy.Size = new System.Drawing.Size(163, 24);
            this.textBoxKodPocztowy.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(581, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 25);
            this.label1.TabIndex = 55;
            this.label1.Text = "Adres zamieszkania:";
            // 
            // textBoxMiejscowosc
            // 
            this.textBoxMiejscowosc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxMiejscowosc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxMiejscowosc.Location = new System.Drawing.Point(699, 94);
            this.textBoxMiejscowosc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMiejscowosc.Name = "textBoxMiejscowosc";
            this.textBoxMiejscowosc.Size = new System.Drawing.Size(163, 24);
            this.textBoxMiejscowosc.TabIndex = 54;
            // 
            // buttonDodaj
            // 
            this.buttonDodaj.BackColor = System.Drawing.Color.Peru;
            this.buttonDodaj.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDodaj.Location = new System.Drawing.Point(699, 311);
            this.buttonDodaj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDodaj.Name = "buttonDodaj";
            this.buttonDodaj.Size = new System.Drawing.Size(164, 62);
            this.buttonDodaj.TabIndex = 65;
            this.buttonDodaj.Text = "Dodaj";
            this.buttonDodaj.UseVisualStyleBackColor = false;
            this.buttonDodaj.Click += new System.EventHandler(this.buttonDodaj_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // buttonPowrot
            // 
            this.buttonPowrot.BackColor = System.Drawing.Color.Peru;
            this.buttonPowrot.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPowrot.Location = new System.Drawing.Point(269, 32);
            this.buttonPowrot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPowrot.Name = "buttonPowrot";
            this.buttonPowrot.Size = new System.Drawing.Size(164, 39);
            this.buttonPowrot.TabIndex = 69;
            this.buttonPowrot.Text = "Anuluj";
            this.buttonPowrot.UseVisualStyleBackColor = false;
            this.buttonPowrot.Click += new System.EventHandler(this.buttonPowrot_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(551, 407);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 70;
            this.label2.Text = "* - Pola wymagalne";
            // 
            // AdminFormDodajUzytkownika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1617, 580);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonPowrot);
            this.Controls.Add(this.buttonDodaj);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxNrLokalu);
            this.Controls.Add(this.textBoxNrPosesji);
            this.Controls.Add(this.textBoxUlica);
            this.Controls.Add(this.textBoxKodPocztowy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMiejscowosc);
            this.Controls.Add(this.comboBoxPlec);
            this.Controls.Add(this.dateTimePickerDataUrodzenia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTelefon);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxPesel);
            this.Controls.Add(this.rola);
            this.Controls.Add(this.comboBoxRola);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imie);
            this.Controls.Add(this.dane);
            this.Controls.Add(this.textBoxNazwisko);
            this.Controls.Add(this.textBoxImie);
            this.Controls.Add(this.textBoxLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminFormDodajUzytkownika";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LibraSys | Dodaj użytkownika";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminFormDodajUzytkownika_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label rola;
        private System.Windows.Forms.ComboBox comboBoxRola;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label imie;
        private System.Windows.Forms.Label dane;
        private System.Windows.Forms.TextBox textBoxNazwisko;
        private System.Windows.Forms.TextBox textBoxImie;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.ComboBox comboBoxPlec;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataUrodzenia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTelefon;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPesel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxNrLokalu;
        private System.Windows.Forms.TextBox textBoxNrPosesji;
        private System.Windows.Forms.TextBox textBoxUlica;
        private System.Windows.Forms.TextBox textBoxKodPocztowy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMiejscowosc;
        private System.Windows.Forms.Button buttonDodaj;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button buttonPowrot;
        private System.Windows.Forms.Label label2;
    }
}