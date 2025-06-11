using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIBLIOTEKA_TESTOWANIE
{
    public partial class FormUstawNoweHaslo : Form
    {
        private int idUzytkownika;
        public FormUstawNoweHaslo()
        {
            InitializeComponent();
            this.idUzytkownika = Session.LoggedInUserId;

        }

        private void FormUstawNoweHaslo_Load(object sender, EventArgs e)
        {

        }

        private void buttonZatwierdz_Click(object sender, EventArgs e)
        {
            string haslo1 = textBoxNoweHaslo1.Text.Trim();
            string haslo2 = textBoxNoweHaslo2.Text.Trim();

            if (haslo1 != haslo2)
            {
                MessageBox.Show("Hasła nie są takie same.");
                return;
            }

            if (!Validator.IsValidPassword(haslo1, idUzytkownika, out string komunikat))
            {
                MessageBox.Show(komunikat);
                return;
            }

            if (ZmienHasloNaNowe(haslo1))
            {
                MessageBox.Show("Twoje hasło zostało pomyślnie zmienione.");
                AdminFormPanelGlowny panel = new AdminFormPanelGlowny();
                panel.Show();
                this.Hide(); 
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas zmiany hasła.");
            }
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Czy na pewno chcesz anulować czynność?", "Potwierdzenie", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                new FormLogin().Show(); // wróć do ekranu logowania
            }
        }
        private bool ZmienHasloNaNowe(string noweHaslo)
        {
            string connectionString = "Server=LAPTOPIK-K4514\\SQLDEVELOPER;Database=TEST2;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string updateQuery = @"
                UPDATE Uzytkownik
                SET Haslo = @Haslo,
                    Tymczasowe_haslo = NULL,
                    Czy_tymczasowe_haslo = 0
                WHERE ID_uzytkownik = @Id";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Haslo", noweHaslo);
                        cmd.Parameters.AddWithValue("@Id", idUzytkownika); 
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
