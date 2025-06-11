namespace BIBLIOTEKA_TESTOWANIE
{
    partial class AdminFormSprawdzanieUprawnien
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
            this.buttonZmienUprawnienia = new System.Windows.Forms.Button();
            this.buttonZapis = new System.Windows.Forms.Button();
            this.buttonAnuluj = new System.Windows.Forms.Button();
            this.checkedListBoxUprawnienia = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // buttonZmienUprawnienia
            // 
            this.buttonZmienUprawnienia.BackColor = System.Drawing.Color.Peru;
            this.buttonZmienUprawnienia.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonZmienUprawnienia.Location = new System.Drawing.Point(16, 507);
            this.buttonZmienUprawnienia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonZmienUprawnienia.Name = "buttonZmienUprawnienia";
            this.buttonZmienUprawnienia.Size = new System.Drawing.Size(195, 43);
            this.buttonZmienUprawnienia.TabIndex = 5;
            this.buttonZmienUprawnienia.Text = "Zmień uprawnienia";
            this.buttonZmienUprawnienia.UseVisualStyleBackColor = false;
            this.buttonZmienUprawnienia.Click += new System.EventHandler(this.buttonZmienUprawnienia_Click_1);
            // 
            // buttonZapis
            // 
            this.buttonZapis.BackColor = System.Drawing.Color.Peru;
            this.buttonZapis.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonZapis.Location = new System.Drawing.Point(219, 507);
            this.buttonZapis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonZapis.Name = "buttonZapis";
            this.buttonZapis.Size = new System.Drawing.Size(100, 43);
            this.buttonZapis.TabIndex = 6;
            this.buttonZapis.Text = "Zapisz";
            this.buttonZapis.UseVisualStyleBackColor = false;
            this.buttonZapis.Click += new System.EventHandler(this.buttonZapis_Click_1);
            // 
            // buttonAnuluj
            // 
            this.buttonAnuluj.BackColor = System.Drawing.Color.Peru;
            this.buttonAnuluj.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAnuluj.Location = new System.Drawing.Point(111, 569);
            this.buttonAnuluj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAnuluj.Name = "buttonAnuluj";
            this.buttonAnuluj.Size = new System.Drawing.Size(100, 43);
            this.buttonAnuluj.TabIndex = 7;
            this.buttonAnuluj.Text = "Anuluj";
            this.buttonAnuluj.UseVisualStyleBackColor = false;
            this.buttonAnuluj.Click += new System.EventHandler(this.buttonAnuluj_Click);
            // 
            // checkedListBoxUprawnienia
            // 
            this.checkedListBoxUprawnienia.FormattingEnabled = true;
            this.checkedListBoxUprawnienia.Location = new System.Drawing.Point(16, 15);
            this.checkedListBoxUprawnienia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkedListBoxUprawnienia.Name = "checkedListBoxUprawnienia";
            this.checkedListBoxUprawnienia.Size = new System.Drawing.Size(301, 480);
            this.checkedListBoxUprawnienia.TabIndex = 8;
            // 
            // AdminFormSprawdzanieUprawnien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(736, 687);
            this.Controls.Add(this.checkedListBoxUprawnienia);
            this.Controls.Add(this.buttonAnuluj);
            this.Controls.Add(this.buttonZapis);
            this.Controls.Add(this.buttonZmienUprawnienia);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminFormSprawdzanieUprawnien";
            this.Text = "LibraSys | Zapominanie użytkownika";
            this.Load += new System.EventHandler(this.AdminFormSprawdzanieUprawnien_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonZmienUprawnienia;
        private System.Windows.Forms.Button buttonZapis;
        private System.Windows.Forms.Button buttonAnuluj;
        private System.Windows.Forms.CheckedListBox checkedListBoxUprawnienia;
    }
}