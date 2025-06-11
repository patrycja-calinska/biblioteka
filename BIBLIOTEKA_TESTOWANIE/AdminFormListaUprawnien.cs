using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIBLIOTEKA_TESTOWANIE
{
    public partial class AdminFormListaUprawnien : Form
    {
        public AdminFormListaUprawnien()
        {
            InitializeComponent();
            this.Text = "LibraSys | Lista uprawnień";
            WyswietlListeUprawnien();
            this.WindowState = FormWindowState.Maximized;
            int idUzytkownika = Session.LoggedInUserId;

        }

        private void AdminFormListaUprawnien_Load(object sender, EventArgs e)
        {

        }
        private void WyswietlListeUprawnien()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Rola");
            dt.Columns.Add("Uprawnienia");

            dt.Rows.Add("Administrator",
                "- Dodawanie nowych użytkowników\n" +
                "- Edycja danych użytkownika\n" +
                "- Zapomnienie użytkownika\n" +
                "- Wyświetlanie listy użytkowników\n" +
                "- Wyszukiwanie użytkowników\n" +
                "- Wyszukiwanie zapomnianych użytkowników\n" +
                "- Podgląd danych użytkownika\n" +
                "- Przegląd listy uprawnień\n" +
                "- Nadawanie uprawnień użytkownikom\n" +
                "- Przegląd użytkowników o określonym uprawnieniu\n" +
                "- Zmiana hasła użytkownikowi\n" +
                "- Automatyczne generowanie hasła\n" +
                "- Możliwość logowania do systemu\n" +
                "- Możliwość wylogowania");

            dt.Rows.Add("Bibliotekarz",
                "- Rejestrowanie nowych książek do biblioteki\n" +
                "- Przeglądanie listy książek\n" +
                "- Podgląd szczegółowych informacji o książce\n" +
                "- Rejestrowanie wypożyczenia książki\n" +
                "- Przedłużanie wypożyczenia\n" +
                "- Rejestrowanie zwrotu książki\n" +
                "- Logowanie i wylogowanie z systemu");

            dt.Rows.Add("Manager biblioteki",
                "- Przeglądanie listy rejestracji książek\n" +
                "- Przeglądanie listy dostępnych książek\n" +
                "- Przeglądanie listy wypożyczeń\n" +
                "- Logowanie i wylogowanie z systemu");

            dt.Rows.Add("Użytkownik",
                "- Logowanie do systemu\n" +
                "- Odzyskiwanie hasła\n" +
                "- Ustawienie nowego hasła po odzyskaniu");

            dataGridView_uprawnienia.DataSource = dt;

            dataGridView_uprawnienia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView_uprawnienia.Columns[0].Width = 200; // kolumna "Rola"
            dataGridView_uprawnienia.Columns[1].Width = 1000; // kolumna "Uprawnienia"

            dataGridView_uprawnienia.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView_uprawnienia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void buttonPowrot_Click_1(object sender, EventArgs e)
        {
            AdminFormPanelGlowny formStart = new AdminFormPanelGlowny();
            formStart.Show();
            this.Close();
        }

        private void dataGridView_uprawnienia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
