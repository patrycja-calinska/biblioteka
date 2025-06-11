namespace BIBLIOTEKA_TESTOWANIE
{
    partial class FormZmienHaslo
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
            this.dataGridViewUzytkownicy = new System.Windows.Forms.DataGridView();
            this.button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUzytkownicy)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUzytkownicy
            // 
            this.dataGridViewUzytkownicy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUzytkownicy.Location = new System.Drawing.Point(-5, 15);
            this.dataGridViewUzytkownicy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewUzytkownicy.Name = "dataGridViewUzytkownicy";
            this.dataGridViewUzytkownicy.RowHeadersWidth = 51;
            this.dataGridViewUzytkownicy.Size = new System.Drawing.Size(533, 290);
            this.dataGridViewUzytkownicy.TabIndex = 0;
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(68, 363);
            this.button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(100, 28);
            this.button.TabIndex = 1;
            this.button.Text = "button1";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // FormZmienHaslo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button);
            this.Controls.Add(this.dataGridViewUzytkownicy);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormZmienHaslo";
            this.Text = "FormZmienHaslo";
            this.Load += new System.EventHandler(this.FormZmienHaslo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUzytkownicy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUzytkownicy;
        private System.Windows.Forms.Button button;
    }
}