using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIBLIOTEKA_TESTOWANIE
{
    public partial class FormLogin : Form
    {
        //private string connectionString = "Server=LAPTOPIK-K4514\\SQLDEVELOPER;Database=TEST2;Integrated Security=True;TrustServerCertificate=True";
        private string connectionString = "Server=desktop-7l2t535;Database=BibliotekaBaza;Integrated Security=True;TrustServerCertificate=True";

        public static int ZalogowanyUzytkownikId { get; private set; } // dostępny globalnie

        public FormLogin()
        {
            InitializeComponent();
            var uprawnienia = Session.UprawnieniaUzytkownika;
            textBoxLogin.Text = "Admin1";
            textBoxHaslo.Text = "Admin!25";

        }
        private void ZarejestrujProbe(int userId, bool czyPoprawna)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string insertQuery = "INSERT INTO ProbyLogowania (FK_ID_uzytkownik, Data_proby, Czy_poprawna) VALUES (@userId, GETDATE(), @czyPoprawna)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@czyPoprawna", czyPoprawna);
                cmd.ExecuteNonQuery();
            }
        }
        private bool CzyZablokowany(int userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT COUNT(*) 
            FROM ProbyLogowania 
            WHERE FK_ID_uzytkownik = @userId 
              AND Czy_poprawna = 0 
              AND Data_proby >= DATEADD(MINUTE, -15, GETDATE())";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                int liczbaNieudanych = (int)cmd.ExecuteScalar();
                return liczbaNieudanych >= 3;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string haslo = textBoxHaslo.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(haslo))
            {
                MessageBox.Show("Podaj login i hasło.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT ID_uzytkownik, Haslo, Czy_tymczasowe_haslo, Tymczasowe_haslo FROM Uzytkownik WHERE Login_uzytkownika = @login", conn);
                cmd.Parameters.AddWithValue("@login", login);

                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Niepoprawne dane logowania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int userId = Convert.ToInt32(reader["ID_uzytkownik"]);
                string hasloZBazy = reader["Haslo"].ToString();
                string hasloTymczasowe = reader["Tymczasowe_haslo"] == DBNull.Value ? null : reader["Tymczasowe_haslo"].ToString();
                bool czyTymczasowe = Convert.ToBoolean(reader["Czy_tymczasowe_haslo"]);

                reader.Close();

                // Sprawdzenie blokady
                if (CzyZablokowany(userId))
                {
                    MessageBox.Show("Konto zostało tymczasowo zablokowane na 15 minut z powodu zbyt wielu nieudanych prób logowania.", "Zablokowane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (czyTymczasowe)
                {
                    if (haslo != hasloTymczasowe)
                    {
                        ZarejestrujProbe(userId, false);
                        MessageBox.Show("Niepoprawne dane logowania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ZarejestrujProbe(userId, true);
                    Session.LoggedInUserId = userId;
                    Session.UprawnieniaUzytkownika = PobierzUprawnieniaUzytkownika(userId);

                    FormUstawNoweHaslo ustawForm = new FormUstawNoweHaslo();
                    ustawForm.Show();
                    this.Hide();
                }
                else
                {
                    if (haslo != hasloZBazy)
                    {
                        ZarejestrujProbe(userId, false);
                        MessageBox.Show("Niepoprawne dane logowania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ZarejestrujProbe(userId, true);
                    Session.LoggedInUserId = userId;
                    Session.UprawnieniaUzytkownika = PobierzUprawnieniaUzytkownika(userId);

                    AdminFormPanelGlowny panel = new AdminFormPanelGlowny();
                    panel.Show();
                    this.Hide();
                }
            }
        }


        private void buttonOdzyskajHasło_Click(object sender, EventArgs e)
        {
            FormOdzyskajHaslo formOdzyskaj = new FormOdzyskajHaslo();
            formOdzyskaj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private List<string> PobierzUprawnieniaUzytkownika(int userId)
        {
            List<string> uprawnienia = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
    SELECT u.Nazwa 
    FROM Uprawnienia u
    JOIN Uzy_upra uu ON uu.FK_ID_uprawnienie = u.ID_uprawnienia
    WHERE uu.FK_ID_uzytkownik = @userId AND uu.Czy_dostepne = 1", conn);

                cmd.Parameters.AddWithValue("@userId", userId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        uprawnienia.Add(reader["Nazwa"].ToString());
                    }
                }
            }

            return uprawnienia;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
