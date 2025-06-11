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
    public partial class FormZmienHaslo : Form
    {
        private string connectionString = "Server=LAPTOPIK-K4514\\SQLDEVELOPER;Database=BibliotekaBaza;Integrated Security=True;TrustServerCertificate=True";

        public FormZmienHaslo()
        {
            InitializeComponent();
            int idUzytkownika = Session.LoggedInUserId;
            WyswietlWszystkichUzytkownikow();

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

        private void button_Click(object sender, EventArgs e)
        {

        }

        private void FormZmienHaslo_Load(object sender, EventArgs e)
        {

        }
    }
}
