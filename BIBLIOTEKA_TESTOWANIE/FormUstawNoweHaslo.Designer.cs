namespace BIBLIOTEKA_TESTOWANIE
{
    partial class FormUstawNoweHaslo
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
            this.textBoxNoweHaslo1 = new System.Windows.Forms.TextBox();
            this.textBoxNoweHaslo2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonZatwierdz = new System.Windows.Forms.Button();
            this.buttonAnuluj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNoweHaslo1
            // 
            this.textBoxNoweHaslo1.Location = new System.Drawing.Point(370, 140);
            this.textBoxNoweHaslo1.Name = "textBoxNoweHaslo1";
            this.textBoxNoweHaslo1.Size = new System.Drawing.Size(171, 20);
            this.textBoxNoweHaslo1.TabIndex = 0;
            // 
            // textBoxNoweHaslo2
            // 
            this.textBoxNoweHaslo2.Location = new System.Drawing.Point(370, 184);
            this.textBoxNoweHaslo2.Name = "textBoxNoweHaslo2";
            this.textBoxNoweHaslo2.Size = new System.Drawing.Size(171, 20);
            this.textBoxNoweHaslo2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(273, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nowe hasło:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(216, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Powtórz nowe hasło:";
            // 
            // buttonZatwierdz
            // 
            this.buttonZatwierdz.BackColor = System.Drawing.Color.Peru;
            this.buttonZatwierdz.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonZatwierdz.Location = new System.Drawing.Point(229, 240);
            this.buttonZatwierdz.Name = "buttonZatwierdz";
            this.buttonZatwierdz.Size = new System.Drawing.Size(119, 53);
            this.buttonZatwierdz.TabIndex = 4;
            this.buttonZatwierdz.Text = "Zatwierdź";
            this.buttonZatwierdz.UseVisualStyleBackColor = false;
            this.buttonZatwierdz.Click += new System.EventHandler(this.buttonZatwierdz_Click);
            // 
            // buttonAnuluj
            // 
            this.buttonAnuluj.BackColor = System.Drawing.Color.Peru;
            this.buttonAnuluj.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAnuluj.Location = new System.Drawing.Point(507, 240);
            this.buttonAnuluj.Name = "buttonAnuluj";
            this.buttonAnuluj.Size = new System.Drawing.Size(119, 53);
            this.buttonAnuluj.TabIndex = 5;
            this.buttonAnuluj.Text = "Anuluj";
            this.buttonAnuluj.UseVisualStyleBackColor = false;
            this.buttonAnuluj.Click += new System.EventHandler(this.buttonAnuluj_Click);
            // 
            // FormUstawNoweHaslo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAnuluj);
            this.Controls.Add(this.buttonZatwierdz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNoweHaslo2);
            this.Controls.Add(this.textBoxNoweHaslo1);
            this.Name = "FormUstawNoweHaslo";
            this.Text = "FormUstawNoweHaslo";
            this.Load += new System.EventHandler(this.FormUstawNoweHaslo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNoweHaslo1;
        private System.Windows.Forms.TextBox textBoxNoweHaslo2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonZatwierdz;
        private System.Windows.Forms.Button buttonAnuluj;
    }
}