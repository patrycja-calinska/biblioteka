namespace BIBLIOTEKA_TESTOWANIE
{
    partial class AdminFormListaUprawnien
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
            this.dataGridView_uprawnienia = new System.Windows.Forms.DataGridView();
            this.buttonPowrot = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_uprawnienia)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_uprawnienia
            // 
            this.dataGridView_uprawnienia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_uprawnienia.Location = new System.Drawing.Point(32, 80);
            this.dataGridView_uprawnienia.Name = "dataGridView_uprawnienia";
            this.dataGridView_uprawnienia.Size = new System.Drawing.Size(1227, 440);
            this.dataGridView_uprawnienia.TabIndex = 0;
            this.dataGridView_uprawnienia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_uprawnienia_CellContentClick);
            // 
            // buttonPowrot
            // 
            this.buttonPowrot.BackColor = System.Drawing.Color.Peru;
            this.buttonPowrot.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPowrot.Location = new System.Drawing.Point(611, 12);
            this.buttonPowrot.Name = "buttonPowrot";
            this.buttonPowrot.Size = new System.Drawing.Size(167, 45);
            this.buttonPowrot.TabIndex = 1;
            this.buttonPowrot.Text = "Powrót";
            this.buttonPowrot.UseVisualStyleBackColor = false;
            this.buttonPowrot.Click += new System.EventHandler(this.buttonPowrot_Click_1);
            // 
            // AdminFormListaUprawnien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1261, 658);
            this.Controls.Add(this.buttonPowrot);
            this.Controls.Add(this.dataGridView_uprawnienia);
            this.Name = "AdminFormListaUprawnien";
            this.Text = "LibraSys | Lista uprawnień";
            this.Load += new System.EventHandler(this.AdminFormListaUprawnien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_uprawnienia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_uprawnienia;
        private System.Windows.Forms.Button buttonPowrot;
    }
}