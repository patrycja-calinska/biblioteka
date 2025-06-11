using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BIBLIOTEKA_TESTOWANIE
{
    public partial class AdminFormSprawdzanieUprawnien : Form
    {
        private readonly string connectionString = "Server=desktop-7l2t535;Database=BibliotekaBaza;Integrated Security=True;TrustServerCertificate=True";
        private readonly int userId;

        public AdminFormSprawdzanieUprawnien(int id)
        {
            InitializeComponent();
            userId = id;
            WczytajUprawnienia();
            UstawTrybPrzegladania();
            int idUzytkownika = Session.LoggedInUserId;

        }

        private void WczytajUprawnienia()
        {
            string query = "SELECT Nazwa FROM Uprawnienia";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                checkedListBoxUprawnienia.Items.Clear();

                while (reader.Read())
                {
                    checkedListBoxUprawnienia.Items.Add(reader["Nazwa"].ToString());
                }
            }

            // Teraz sprawdź, które uprawnienia są przypisane do użytkownika
            string userUprawnieniaQuery = @"
            SELECT r.Nazwa
            FROM dbo.Uprawnienia r
            JOIN dbo.Uzy_upra u ON r.ID_uprawnienia = u.FK_ID_uprawnienie
            WHERE u.FK_ID_uzytkownik = @userId AND u.Czy_dostepne = 1";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(userUprawnieniaQuery, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Zaznaczenie uprawnień, które użytkownik posiada
                while (reader.Read())
                {
                    string uprawnienie = reader["Nazwa"].ToString();
                    for (int i = 0; i < checkedListBoxUprawnienia.Items.Count; i++)
                    {
                        if (checkedListBoxUprawnienia.Items[i].ToString() == uprawnienie)
                        {
                            checkedListBoxUprawnienia.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        private void UstawTrybPrzegladania()
        {
            // Ustawienie checkboxów jako nieedytowalnych na początku
            checkedListBoxUprawnienia.Enabled = false;
            buttonZapis.Visible = false;
        }
        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Czy na pewno chcesz porzucić czynność?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AdminFormPrzeglądUżytkownikówODanymUprawnieniu form = new AdminFormPrzeglądUżytkownikówODanymUprawnieniu();
                this.Close();
            }
        }

        private void buttonZapis_Click_1(object sender, EventArgs e)
        {
            if (checkedListBoxUprawnienia.CheckedItems.Count == 0)
            {
                MessageBox.Show("Musisz zaznaczyć przynajmniej jedno uprawnienie, aby zapisać zmiany.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isAnyChange = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Sprawdzamy, czy zostały wprowadzone jakiekolwiek zmiany
                foreach (var item in checkedListBoxUprawnienia.Items)
                {
                    bool isChecked = checkedListBoxUprawnienia.CheckedItems.Contains(item);

                    // Pobieramy uprawnienie
                    string uprawnienie = item.ToString();

                    // Sprawdzamy aktualny stan uprawnienia w bazie
                    string query = @"
                SELECT Czy_dostepne
                FROM dbo.Uzy_upra
                WHERE FK_ID_uzytkownik = @userId
                AND FK_ID_uprawnienie = (SELECT ID_uprawnienia FROM dbo.Uprawnienia WHERE Nazwa = @uprawnienie)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@uprawnienie", uprawnienie);

                    var result = cmd.ExecuteScalar();
                    bool currentState = result != null && Convert.ToBoolean(result);

                    // Jeśli stan uprawnienia w bazie różni się od zaznaczonego w checkboxie, oznacza to zmianę
                    if (currentState != isChecked)
                    {
                        isAnyChange = true;
                    }

                    // Zaktualizuj uprawnienia, jeśli zostały zmienione
                    if (isChecked)
                    {
                        string updateQuery = @"
                    UPDATE dbo.Uzy_upra
                    SET Czy_dostepne = 1
                    WHERE FK_ID_uzytkownik = @userId
                    AND FK_ID_uprawnienie = (SELECT ID_uprawnienia FROM dbo.Uprawnienia WHERE Nazwa = @uprawnienie)";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@userId", userId);
                        updateCmd.Parameters.AddWithValue("@uprawnienie", uprawnienie);
                        updateCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string updateQuery = @"
                    UPDATE dbo.Uzy_upra
                    SET Czy_dostepne = 0
                    WHERE FK_ID_uzytkownik = @userId
                    AND FK_ID_uprawnienie = (SELECT ID_uprawnienia FROM dbo.Uprawnienia WHERE Nazwa = @uprawnienie)";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@userId", userId);
                        updateCmd.Parameters.AddWithValue("@uprawnienie", uprawnienie);
                        updateCmd.ExecuteNonQuery();
                    }
                }
            }

            if (isAnyChange)
            {
                MessageBox.Show("Uprawnienia zostały pomyślnie zapisane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nie dokonano żadnych zmian w uprawnieniach.", "Brak zmian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            UstawTrybPrzegladania();
        }

        private void buttonZmienUprawnienia_Click_1(object sender, EventArgs e)
        {
            // Umożliwienie edytowania uprawnień
            checkedListBoxUprawnienia.Enabled = true;
            buttonZapis.Visible = true;
        }

        private void AdminFormSprawdzanieUprawnien_Load(object sender, EventArgs e)
        {

        }
    }

}
