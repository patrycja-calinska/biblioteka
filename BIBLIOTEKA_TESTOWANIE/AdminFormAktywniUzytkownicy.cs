using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BIBLIOTEKA_TESTOWANIE
{
    public partial class AdminFormAktywniUzytkownicy : Form
    {
        private string connectionString = "Server=desktop-7l2t535;Database=BibliotekaBaza;Integrated Security=True;TrustServerCertificate=True";

        public AdminFormAktywniUzytkownicy()
        {
            InitializeComponent();
            WyswietlUzytkownikow();
            this.Text = "LibraSys | Aktywni użytkownicy";
            int idUzytkownika = Session.LoggedInUserId;

            textBoxImie.TextChanged += FiltrujUzytkownikow;
            textBoxNazwisko.TextChanged += FiltrujUzytkownikow;
            textBoxLogin.TextChanged += FiltrujUzytkownikow;
            var uprawnienia = Session.UprawnieniaUzytkownika;
            buttonZapomnij.Visible = uprawnienia.Contains("Zapominanie użytkownika");
            buttonSzczegoly.Visible = uprawnienia.Contains("Podgląd danych użytkownika");
        }

        private void WyswietlUzytkownikow()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                SELECT 
                ID_uzytkownik,
                Login_uzytkownika AS Login,
                Imie AS Imię,
                Nazwisko,
                Email AS [E-mail],
                PESEL
                FROM dbo.Uzytkownik
                WHERE Czy_zapomniany = 1";


                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewUzytkownicy.DataSource = dt;
                if (dt.Columns.Contains("ID_uzytkownik"))
                    dataGridViewUzytkownicy.Columns["ID_uzytkownik"].Visible = false;
            }
        }


        private void FiltrujUzytkownikow(object sender, EventArgs e)
        {
            string imie = textBoxImie.Text.Trim();
            string nazwisko = textBoxNazwisko.Text.Trim();
            string login = textBoxLogin.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                SELECT 
                ID_uzytkownik,
                Login_uzytkownika AS Login,
                Imie AS Imię,
                Nazwisko,
                Email AS [E-mail],
                PESEL
                FROM dbo.Uzytkownik
                WHERE Czy_zapomniany = 1"; // dodane ograniczenie

                if (!string.IsNullOrEmpty(imie))
                    query += " AND Imie LIKE @imie";
                if (!string.IsNullOrEmpty(nazwisko))
                    query += " AND Nazwisko LIKE @nazwisko";
                if (!string.IsNullOrEmpty(login))
                    query += " AND Login_uzytkownika LIKE @login";

                SqlCommand cmd = new SqlCommand(query, conn);

                if (!string.IsNullOrEmpty(imie))
                    cmd.Parameters.AddWithValue("@imie", "%" + imie + "%");
                if (!string.IsNullOrEmpty(nazwisko))
                    cmd.Parameters.AddWithValue("@nazwisko", "%" + nazwisko + "%");
                if (!string.IsNullOrEmpty(login))
                    cmd.Parameters.AddWithValue("@login", "%" + login + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewUzytkownicy.DataSource = dt;
                if (dt.Columns.Contains("ID_uzytkownik"))
                    dataGridViewUzytkownicy.Columns["ID_uzytkownik"].Visible = false;
            }
        }


        private void buttonSzczegoly_Click(object sender, EventArgs e)
        {
            if (dataGridViewUzytkownicy.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz użytkownika z listy.");
                return;
            }

            int id = Convert.ToInt32(dataGridViewUzytkownicy.SelectedRows[0].Cells["ID_uzytkownik"].Value);

            AdminFormPodgladDanych szczegoly = new AdminFormPodgladDanych(id, connectionString);
            szczegoly.FormClosed += (s, args) => WyswietlUzytkownikow();
            szczegoly.ShowDialog();
            this.Hide();
        }

        private void buttonZapomnij_Click(object sender, EventArgs e)
        {
            if (dataGridViewUzytkownicy.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz użytkownika z listy.");
                return;
            }

            int userId = Convert.ToInt32(dataGridViewUzytkownicy.SelectedRows[0].Cells["ID_uzytkownik"].Value);

            DialogResult result = MessageBox.Show(
                "Czy na pewno chcesz zapomnieć użytkownika?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            string losoweImie = GenerujLosowyString(10);
            string losoweNazwisko = GenerujLosowyString(12);

            DateTime dataUrodzenia;
            int plecId;
            string losowyPesel = GenerujLosowyPesel(out dataUrodzenia, out plecId);
            string losowaData = GenerujLosowaDate(dataUrodzenia);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                int idAdmina = -1;
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 ID_uzytkownik FROM dbo.Uzytkownik WHERE FK_ID_rola = 2", conn))
                {
                    var resultAdmin = cmd.ExecuteScalar();
                    if (resultAdmin != null)
                        idAdmina = Convert.ToInt32(resultAdmin);
                }

                if (idAdmina == -1)
                {
                    MessageBox.Show("Brak administratora w bazie!");
                    return;
                }

                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE dbo.Uzytkownik " +
                    "SET Imie = @imie, Nazwisko = @nazwisko, PESEL = @pesel, Data_urodzenia = @data, Plec = @plec, Czy_zapomniany = 1 " +
                    "WHERE ID_uzytkownik = @id; " +
                    "INSERT INTO dbo.Zapominany (FK_ID_uzytkownik, Data_zapomnienia, Zglaszacz) VALUES (@id, GETDATE(), @zglaszacz);",
                    conn))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.Parameters.AddWithValue("@imie", losoweImie);
                    cmd.Parameters.AddWithValue("@nazwisko", losoweNazwisko);
                    cmd.Parameters.AddWithValue("@pesel", losowyPesel);
                    cmd.Parameters.AddWithValue("@data", losowaData);
                    cmd.Parameters.AddWithValue("@plec", plecId);
                    cmd.Parameters.AddWithValue("@zglaszacz", idAdmina);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Użytkownik został zapomniany.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            WyswietlUzytkownikow();
        }

        private void buttonPowrot_Click(object sender, EventArgs e)
        {
            AdminFormPanelGlowny formStart = new AdminFormPanelGlowny();
            formStart.Show();
            this.Close();
        }

        private string GenerujLosowyString(int length)
        {
            const string znaki = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            return new string(Enumerable.Repeat(znaki, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string GenerujLosowyPesel(out DateTime dataUrodzenia, out int plecId)
        {
            Random rand = new Random();

            DateTime start = new DateTime(1950, 1, 1);
            DateTime end = new DateTime(2005, 12, 31);
            int range = (end - start).Days;
            dataUrodzenia = start.AddDays(rand.Next(range));

            int year = dataUrodzenia.Year;
            int month = dataUrodzenia.Month;
            int day = dataUrodzenia.Day;

            int encodedMonth = month;
            if (year >= 2000 && year < 2100)
                encodedMonth += 20;

            string dataCzesc = $"{(year % 100):D2}{encodedMonth:D2}{day:D2}";

            int seria = rand.Next(100, 999); // tylko 3 cyfry!
            int plecCyfra = rand.Next(0, 5) * 2;

            if (rand.Next(2) == 1)
                plecCyfra += 1;

            plecId = (plecCyfra % 2 == 0) ? 2 : 1; // 1 = M, 2 = K

            string pesel = dataCzesc + seria.ToString("D3") + plecCyfra.ToString(); // razem 11 znaków
            return pesel;
        }

        private string GenerujLosowaDate(DateTime data)
        {
            return data.ToString("yyyy-MM-dd");
        }

        private void dataGridViewUzytkownicy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obsługa kliknięcia — np. wyświetl dane z klikniętej komórki
        }

        private void textBoxImie_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdminFormAktywniUzytkownicy_Load(object sender, EventArgs e)
        {

        }
    }
}
