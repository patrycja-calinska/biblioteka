using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BIBLIOTEKA_TESTOWANIE
{
    public partial class AdminFormPrzeglądUżytkownikówODanymUprawnieniu : Form
    {
        private string connectionString = "Server=desktop-7l2t535;Database=BibliotekaBaza;Integrated Security=True;TrustServerCertificate=True";

        public AdminFormPrzeglądUżytkownikówODanymUprawnieniu()
        {
            InitializeComponent();
            this.Text = "LibraSys | Przegląd użytkowników o danym uprawnieniu";
            this.WindowState = FormWindowState.Maximized;
            WyswietlWszystkichUzytkownikow();
            checkedListBoxUprawnienia.Visible = false;
            buttonSzukaj.Visible = false;
            buttonWyczysc.Visible = false;
            int idUzytkownika = Session.LoggedInUserId;
            var uprawnienia = Session.UprawnieniaUzytkownika;
            buttonFiltruj.Visible = uprawnienia.Contains("Przegląd użytkowników o danym uprawnieniu");

        }

        private void WypelnijCheckedListBoxUprawnieniami()
        {
            string query = "SELECT Nazwa FROM dbo.Uprawnienia";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Czyszczenie poprzednich elementów w CheckedListBox
                checkedListBoxUprawnienia.Items.Clear();

                // Dodawanie uprawnień do CheckedListBox
                while (reader.Read())
                {
                    checkedListBoxUprawnienia.Items.Add(reader["Nazwa"].ToString());
                }
            }
        }

        private void buttonSzukaj_Click(object sender, EventArgs e)
        {
            // Wybór uprawnień zaznaczonych w CheckedListBox
            var selectedUprawnienia = checkedListBoxUprawnienia.CheckedItems;

            if (selectedUprawnienia.Count == 0)
            {
                MessageBox.Show("Wybierz przynajmniej jedno uprawnienie.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Budowanie zapytania SQL na podstawie zaznaczonych uprawnień
            string query = @"
                SELECT DISTINCT u.ID_uzytkownik, u.Imie, u.Nazwisko, u.Login_uzytkownika
                FROM dbo.Uzytkownik u
                JOIN dbo.Uzy_upra uu ON u.ID_uzytkownik = uu.FK_ID_uzytkownik
                WHERE uu.FK_ID_uprawnienie IN (";

            // Dodanie wszystkich zaznaczonych uprawnień do zapytania SQL
            for (int i = 0; i < selectedUprawnienia.Count; i++)
            {
                query += $"@idUprawnienie{i}";
                if (i < selectedUprawnienia.Count - 1)
                    query += ", ";
            }
            query += ") AND uu.Czy_dostepne = 1 AND u.Czy_zapomniany = 1";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                for (int i = 0; i < selectedUprawnienia.Count; i++)
                {
                    cmd.Parameters.AddWithValue($"@idUprawnienie{i}", GetUprawnienieId(selectedUprawnienia[i].ToString()));
                }

                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewUzytkownicy.DataSource = dt;

                if (dt.Columns.Contains("ID_uzytkownik") && dataGridViewUzytkownicy.Columns["ID_uzytkownik"] != null)
                {
                    dataGridViewUzytkownicy.Columns["ID_uzytkownik"].Visible = false;
                }
            }
        }

        // Funkcja pomocnicza, która zwraca ID uprawnienia na podstawie jego nazwy
        private int GetUprawnienieId(string uprawnienieName)
        {
            string query = "SELECT ID_uprawnienia FROM dbo.Uprawnienia WHERE Nazwa = @uprawnienie";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@uprawnienie", uprawnienieName);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void buttonPowrot_Click(object sender, EventArgs e)
        {
            AdminFormPanelGlowny formStart = new AdminFormPanelGlowny();
            formStart.Show();
            this.Close();
        }
       

        private void buttonFiltruj_Click_1(object sender, EventArgs e)
        {
            WypelnijCheckedListBoxUprawnieniami();

            checkedListBoxUprawnienia.Visible = true;
            buttonSzukaj.Visible = true;
            buttonWyczysc.Visible = true;
        }

        private void buttonSprawdzUprawnienia_Click(object sender, EventArgs e)
        {
            if (dataGridViewUzytkownicy.SelectedRows.Count != 1)
            {
                MessageBox.Show("Wybierz jednego użytkownika z listy.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedId = Convert.ToInt32(dataGridViewUzytkownicy.SelectedRows[0].Cells["ID_uzytkownik"].Value);

            AdminFormSprawdzanieUprawnien form = new AdminFormSprawdzanieUprawnien(selectedId);

            form.Show();

        }
        private void WyswietlWszystkichUzytkownikow()
        {
            string query = @"
                SELECT DISTINCT u.ID_uzytkownik, u.Imie, u.Nazwisko, u.Login_uzytkownika
                FROM dbo.Uzytkownik u
                WHERE u.Czy_zapomniany = 1";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewUzytkownicy.DataSource = dt;

                if (dt.Columns.Contains("ID_uzytkownik") && dataGridViewUzytkownicy.Columns["ID_uzytkownik"] != null)
                {
                    dataGridViewUzytkownicy.Columns["ID_uzytkownik"].Visible = false;
                }
            }
        }
        private void buttonWyczysc_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxUprawnienia.Items.Count; i++)
            {
                checkedListBoxUprawnienia.SetItemChecked(i, false);
            }

            checkedListBoxUprawnienia.ClearSelected();
            WyswietlWszystkichUzytkownikow();
        }

        private void AdminFormPrzeglądUżytkownikówODanymUprawnieniu_Load(object sender, EventArgs e)
        {

        }
    }
}
