namespace BIBLIOTEKA_TESTOWANIE
{
    partial class AdminFormZapomnieniUzytkownicy
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminFormZapomnieniUzytkownicy));
            this.dataGridView_zapomniani = new System.Windows.Forms.DataGridView();
            this.buttonPowrot = new System.Windows.Forms.Button();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_zapomniani)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_zapomniani
            // 
            this.dataGridView_zapomniani.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_zapomniani.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_zapomniani.Location = new System.Drawing.Point(100, 114);
            this.dataGridView_zapomniani.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_zapomniani.Name = "dataGridView_zapomniani";
            this.dataGridView_zapomniani.RowHeadersWidth = 51;
            this.dataGridView_zapomniani.RowTemplate.Height = 24;
            this.dataGridView_zapomniani.Size = new System.Drawing.Size(574, 325);
            this.dataGridView_zapomniani.TabIndex = 40;
            // 
            // buttonPowrot
            // 
            this.buttonPowrot.BackColor = System.Drawing.Color.Peru;
            this.buttonPowrot.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPowrot.Location = new System.Drawing.Point(318, 39);
            this.buttonPowrot.Name = "buttonPowrot";
            this.buttonPowrot.Size = new System.Drawing.Size(104, 42);
            this.buttonPowrot.TabIndex = 71;
            this.buttonPowrot.Text = "Powrót";
            this.buttonPowrot.UseVisualStyleBackColor = false;
            this.buttonPowrot.Click += new System.EventHandler(this.buttonPowrot_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // AdminFormZapomnieniUzytkownicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1243, 450);
            this.Controls.Add(this.buttonPowrot);
            this.Controls.Add(this.dataGridView_zapomniani);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminFormZapomnieniUzytkownicy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LibraSys | Zapomnieni użytkownicy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminFormZapomnieniUzytkownicy_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_zapomniani)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_zapomniani;
        private System.Windows.Forms.Button buttonPowrot;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}