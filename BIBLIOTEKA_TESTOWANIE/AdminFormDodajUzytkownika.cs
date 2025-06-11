using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BIBLIOTEKA_TESTOWANIE
{
    public partial class AdminFormDodajUzytkownika : Form
    {
        private string connectionString = "Server=desktop-7l2t535;Database=BibliotekaBaza;Integrated Security=True;TrustServerCertificate=True";

        public AdminFormDodajUzytkownika()
        {
            InitializeComponent();
            LoadComboBoxes();
            WypelnijLosowymiDanymi(); // <- Dodaj to, żeby od razu wypełniało
            this.Text = "Dodawanie użytkowników";
            int idUzytkownika = Session.LoggedInUserId;


        }

        private void LoadComboBoxes()
        {
            comboBoxPlec.Items.Clear();
            comboBoxPlec.Items.Add(new KeyValuePair<int, string>(1, "M"));
            comboBoxPlec.Items.Add(new KeyValuePair<int, string>(2, "K"));
            comboBoxPlec.DisplayMember = "Value";
            comboBoxPlec.ValueMember = "Key";
            comboBoxPlec.SelectedIndex = 0;

            comboBoxRola.Items.Clear();
            comboBoxRola.Items.Add(new KeyValuePair<int, string>(1, "Admin"));
            comboBoxRola.Items.Add(new KeyValuePair<int, string>(2, "Użytkownik"));
            comboBoxRola.Items.Add(new KeyValuePair<int, string>(3, "Gość"));
            comboBoxRola.Items.Add(new KeyValuePair<int, string>(4, "Bibliotekarz"));
            comboBoxRola.Items.Add(new KeyValuePair<int, string>(5, "Manager Biblioteki"));
            comboBoxRola.DisplayMember = "Value";
            comboBoxRola.ValueMember = "Key";
            comboBoxRola.SelectedIndex = 0;
        }

        private void WypelnijLosowymiDanymi()
        {
            Random rnd = new Random();
            string[] imiona = { "Jan", "Anna", "Marek", "Katarzyna", "Tomasz" };
            string[] nazwiska = { "Kowalski", "Nowak", "Wiśniewski", "Wójcik", "Kamińska" };
            string[] miasta = { "Warszawa", "Kraków", "Gdańsk", "Poznań", "Wrocław" };
            string[] ulice = { "Słoneczna", "Polna", "Leśna", "Kwiatowa", "Długa" };
            string[] prefixyTelefonu = { "5", "6", "7", "8" };

            string imie = imiona[rnd.Next(imiona.Length)];
            string nazwisko = nazwiska[rnd.Next(nazwiska.Length)];
            string login = imie.ToLower() + "." + nazwisko.ToLower() + rnd.Next(100, 999);
            string pesel = GenerujPoprawnyPesel(rnd);
            string email = login + "@test.pl";
            string telefon = prefixyTelefonu[rnd.Next(prefixyTelefonu.Length)] + rnd.Next(10000000, 99999999).ToString();
            string miasto = miasta[rnd.Next(miasta.Length)];
            string kod = rnd.Next(10, 99) + "-" + rnd.Next(100, 999);
            string ulica = ulice[rnd.Next(ulice.Length)];
            string nrDomu = rnd.Next(1, 100).ToString();
            string nrLokalu = rnd.Next(1, 20).ToString();

            textBoxLogin.Text = login;
            textBoxImie.Text = imie;
            textBoxNazwisko.Text = nazwisko;
            textBoxPesel.Text = pesel;
            textBoxEmail.Text = email;
            textBoxTelefon.Text = telefon;
            textBoxMiejscowosc.Text = miasto;
            textBoxKodPocztowy.Text = kod;
            textBoxUlica.Text = ulica;
            textBoxNrPosesji.Text = nrDomu;
            textBoxNrLokalu.Text = nrLokalu;
            dateTimePickerDataUrodzenia.Value = new DateTime(rnd.Next(1960, 2005), rnd.Next(1, 13), rnd.Next(1, 28));
            comboBoxPlec.SelectedIndex = rnd.Next(0, comboBoxPlec.Items.Count);
            comboBoxRola.SelectedIndex = rnd.Next(0, comboBoxRola.Items.Count);
        }

        // Funkcja do generowania poprawnego PESEL
        private string GenerujPoprawnyPesel(Random rnd)
        {
            DateTime data = new DateTime(rnd.Next(1960, 2005), rnd.Next(1, 13), rnd.Next(1, 28));
            int rok = data.Year;
            int miesiac = data.Month;
            int dzien = data.Day;

            if (rok >= 2000)
                miesiac += 20;

            string pesel = $"{rok % 100:D2}{miesiac:D2}{dzien:D2}{rnd.Next(1000, 9999)}";

            // Oblicz cyfrę kontrolną
            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int suma = 0;
            for (int i = 0; i < 10; i++)
                suma += (pesel[i] - '0') * wagi[i];

            int cyfraKontrolna = (10 - (suma % 10)) % 10;

            return pesel + cyfraKontrolna.ToString();
        }
        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Czy na pewno chcesz dodać użytkownika?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            string login = textBoxLogin.Text.Trim();
            string imie = textBoxImie.Text.Trim();
            string nazwisko = textBoxNazwisko.Text.Trim();
            string pesel = textBoxPesel.Text.Trim();
            string plec = comboBoxPlec.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string telefon = textBoxTelefon.Text.Trim();
            string miejscowosc = textBoxMiejscowosc.Text.Trim();
            string kodPocztowy = textBoxKodPocztowy.Text.Trim();
            string ulica = textBoxUlica.Text.Trim();
            string nrPosesji = textBoxNrPosesji.Text.Trim();
            string nrLokalu = textBoxNrLokalu.Text.Trim();
            DateTime dataUrodzenia = dateTimePickerDataUrodzenia.Value;

            int idPlec = ((KeyValuePair<int, string>)comboBoxPlec.SelectedItem).Key;
            int idRola = ((KeyValuePair<int, string>)comboBoxRola.SelectedItem).Key;

            if (!Validator.ValidateUserDataDetailed(login, imie, nazwisko, pesel, plec, email, telefon, miejscowosc, kodPocztowy, ulica, nrPosesji, out string errorMsg))
            {
                MessageBox.Show(errorMsg, "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var konflikty = DatabaseHelper.GetExistingUserConflicts(connectionString, login, pesel, email);
            if (konflikty.Count > 0)
            {
                string msg = string.Join("\n", konflikty);
                MessageBox.Show(msg, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool sukces = DatabaseHelper.AddUser(
                connectionString, login, imie, nazwisko, pesel, email, telefon,
                miejscowosc, kodPocztowy, ulica, nrPosesji, nrLokalu,
                dataUrodzenia, idPlec);

            if (sukces)
            {
                MessageBox.Show("Użytkownik został dodany do systemu", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Pobierz ID nowo dodanego użytkownika
                int userId = DatabaseHelper.GetUserIdByLogin(connectionString, login);
                if (userId == -1)
                {
                    MessageBox.Show("Nie udało się pobrać ID nowego użytkownika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Pobierz nazwę wybranej roli
                string rola = ((KeyValuePair<int, string>)comboBoxRola.SelectedItem).Value;

                // Przypisz uprawnienia na podstawie roli
                List<int> uprawnienia = UprawnieniaNaPodstawieRoli(rola);
                foreach (int idUprawnienia in uprawnienia)
                {
                    DatabaseHelper.PrzypiszUprawnienieUzytkownikowi(connectionString, userId, idUprawnienia);
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania użytkownika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPowrot_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Czy na pewno chcesz porzucić ten formularz?",
               "Potwierdzenie",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                AdminFormPanelGlowny adminFormPanelGlowny = new AdminFormPanelGlowny();
                adminFormPanelGlowny.Show();
                this.Close();
            }

        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            // Coś do zrobienia, albo pusta metoda
        }
        private List<int> UprawnieniaNaPodstawieRoli(string rola)
        {
            switch (rola)
            {
                case "Administrator":
                    return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
                case "Bibliotekarz":
                    return new List<int> { 15, 16, 17, 18, 19, 20, 13, 14 };
                case "Manager biblioteki":
                    return new List<int> { 21, 22, 23, 13, 14 };
                case "Użytkownik":
                    return new List<int> { 13, 24, 25 };
                default:
                    return new List<int>();
            }
        }

        private void AdminFormDodajUzytkownika_Load(object sender, EventArgs e)
        {

        }
    }
}
