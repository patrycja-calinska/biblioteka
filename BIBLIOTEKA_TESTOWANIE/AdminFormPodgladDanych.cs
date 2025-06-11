using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BIBLIOTEKA_TESTOWANIE
{
    public partial class AdminFormPodgladDanych : Form
    {
        private int uzytkownikID;
        private Button buttonPowrot;
        private Button buttonEdytuj;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox textBoxNrLokalu;
        private TextBox textBoxNrPosesji;
        private TextBox textBoxUlica;
        private TextBox textBoxKodPocztowy;
        private Label label1;
        private TextBox textBoxMiejscowosc;
        private ComboBox comboBoxPlec;
        private DateTimePicker dateTimePickerDataUrodzenia;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox textBoxTelefon;
        private TextBox textBoxEmail;
        private TextBox textBoxPesel;
        private Label rola;
        private ComboBox comboBoxRola;
        private Label label3;
        private Label imie;
        private Label dane;
        private TextBox textBoxNazwisko;
        private TextBox textBoxImie;
        private TextBox textBoxLogin;
        private Button buttonZapis;
        private Button buttonZmienHaslo;
        private Button buttonZapiszHaslo;
        private TextBox textBoxNoweHaslo;
        private TextBox textBoxPowtorzNoweHaslo;
        private Label label2;
        private Label label14;
        private string connectionString;

        public AdminFormPodgladDanych(int id, string connStr)
        {
            uzytkownikID = id;
            connectionString = connStr;
            InitializeComponent();
            WczytajDane();
            UstawPolaEdycji(false);
            buttonZapis.Visible = false;
            textBoxNoweHaslo.Enabled = false;
            textBoxPowtorzNoweHaslo.Enabled = false;
            buttonZapiszHaslo.Visible = false;
            int idUzytkownika = Session.LoggedInUserId;
            var uprawnienia = Session.UprawnieniaUzytkownika;
            buttonEdytuj.Visible = uprawnienia.Contains("Edycja danych użytkownika");
            buttonZmienHaslo.Visible = uprawnienia.Contains("Zmiana hasła użytkownika");



        }

        private void WczytajDane()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT u.*, a.Miejscowosc, a.Kod_pocztowy, a.Ulica, a.Numer_ulicy, a.Numer_lokalu, u.Plec AS Plec
                                 FROM dbo.Uzytkownik u
                                 INNER JOIN dbo.Adres a ON u.FK_ID_adres = a.ID_adres
                                 WHERE u.ID_uzytkownik = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", uzytkownikID);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBoxLogin.Text = reader["Login_uzytkownika"].ToString();
                    textBoxImie.Text = reader["Imie"].ToString();
                    textBoxNazwisko.Text = reader["Nazwisko"].ToString();
                    textBoxPesel.Text = reader["PESEL"].ToString();
                    dateTimePickerDataUrodzenia.Value = Convert.ToDateTime(reader["Data_urodzenia"]);
                    comboBoxPlec.Text = reader["Plec"].ToString();
                    textBoxEmail.Text = reader["Email"].ToString();
                    textBoxTelefon.Text = reader["Numer_telefonu"].ToString();
                    textBoxMiejscowosc.Text = reader["Miejscowosc"].ToString();
                    textBoxKodPocztowy.Text = reader["Kod_pocztowy"].ToString();
                    textBoxUlica.Text = reader["Ulica"].ToString();
                    textBoxNrPosesji.Text = reader["Numer_ulicy"].ToString();
                    textBoxNrLokalu.Text = reader["Numer_lokalu"].ToString();

                    this.Text = $"Szczegóły: {reader["Login_uzytkownika"]}";
                }
            }

        }

        private int GetForeignKeyId(SqlConnection conn, string tabela, string kolumnaNazwy, string wartosc)
        {
            string query = $"SELECT TOP 1 ID_{tabela.ToLower()} FROM dbo.{tabela} WHERE {kolumnaNazwy} = @wartosc";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@wartosc", wartosc);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
       private void buttonEdytuj_Click_1(object sender, EventArgs e)
        {
            UstawPolaEdycji(true);
            buttonZapis.Visible = true;
        }
        private void UstawPolaEdycji(bool edytowalne)
        {
            textBoxLogin.Enabled = edytowalne;
            textBoxImie.Enabled = edytowalne;
            textBoxNazwisko.Enabled = edytowalne;
            textBoxPesel.Enabled = edytowalne;
            textBoxEmail.Enabled = edytowalne;
            textBoxTelefon.Enabled = edytowalne;
            textBoxMiejscowosc.Enabled = edytowalne;
            textBoxKodPocztowy.Enabled = edytowalne;
            textBoxUlica.Enabled = edytowalne;
            textBoxNrPosesji.Enabled = edytowalne;
            textBoxNrLokalu.Enabled = edytowalne;

            comboBoxRola.Enabled = edytowalne;
            comboBoxPlec.Enabled = edytowalne;
            dateTimePickerDataUrodzenia.Enabled = edytowalne;
        }

        private void ZapomnijUzytkownika(int userId)
        {
            string losoweImie = GenerujLosowyString(10);
            string losoweNazwisko = GenerujLosowyString(12);

            // Generuj PESEL + datę urodzenia + płeć w sposób spójny
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
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        idAdmina = Convert.ToInt32(result);
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
        private void buttonPowrot_Click(object sender, EventArgs e)
        {
            AdminFormPanelGlowny formStart = new AdminFormPanelGlowny();
            formStart.Show();
            this.Close();
        }

        private void buttonZapis_Click(object sender, EventArgs e)
        {
            string errorMsg;
            if (!Validator.ValidateUserDataDetailed(
                textBoxLogin.Text,
                textBoxImie.Text,
                textBoxNazwisko.Text,
                textBoxPesel.Text,
                comboBoxPlec.Text,
                textBoxEmail.Text,
                textBoxTelefon.Text,
                textBoxMiejscowosc.Text,
                textBoxKodPocztowy.Text,
                textBoxUlica.Text,
                textBoxNrPosesji.Text,
                out errorMsg))
            {
                MessageBox.Show(errorMsg, "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT u.*, a.Miejscowosc, a.Kod_pocztowy, a.Ulica, a.Numer_ulicy, a.Numer_lokalu,  u.Plec
                                 FROM dbo.Uzytkownik u
                                 INNER JOIN dbo.Adres a ON u.FK_ID_adres = a.ID_adres
                                 WHERE u.ID_uzytkownik = @ID";

                SqlCommand selectCmd = new SqlCommand(query, conn);
                selectCmd.Parameters.AddWithValue("@ID", uzytkownikID);

                SqlDataReader reader = selectCmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Nie znaleziono użytkownika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool zmieniono = false;
                zmieniono |= reader["Login_uzytkownika"].ToString() != textBoxLogin.Text;
                zmieniono |= reader["Imie"].ToString() != textBoxImie.Text;
                zmieniono |= reader["Nazwisko"].ToString() != textBoxNazwisko.Text;
                zmieniono |= reader["PESEL"].ToString() != textBoxPesel.Text;
                zmieniono |= Convert.ToDateTime(reader["Data_urodzenia"]) != dateTimePickerDataUrodzenia.Value;
                zmieniono |= reader["Email"].ToString() != textBoxEmail.Text;
                zmieniono |= reader["Numer_telefonu"].ToString() != textBoxTelefon.Text;
                zmieniono |= reader["Miejscowosc"].ToString() != textBoxMiejscowosc.Text;
                zmieniono |= reader["Kod_pocztowy"].ToString() != textBoxKodPocztowy.Text;
                zmieniono |= reader["Ulica"].ToString() != textBoxUlica.Text;
                zmieniono |= reader["Numer_ulicy"].ToString() != textBoxNrPosesji.Text;
                zmieniono |= reader["Numer_lokalu"].ToString() != textBoxNrLokalu.Text;
                zmieniono |= reader["Plec"].ToString() != comboBoxPlec.Text;

                reader.Close();

                if (!zmieniono)
                {
                    MessageBox.Show("Nie wprowadzono żadnych zmian.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Dane zostały zmienione pomyślnie.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

               

                string updateAdres = @"UPDATE dbo.Adres SET 
                        Miejscowosc = @Miejscowosc, Kod_pocztowy = @Kod, Ulica = @Ulica, 
                        Numer_ulicy = @NrUl, Numer_lokalu = @NrLok 
                      WHERE ID_adres = (SELECT FK_ID_adres FROM dbo.Uzytkownik WHERE ID_uzytkownik = @ID)";

                SqlCommand cmdAdres = new SqlCommand(updateAdres, conn);
                cmdAdres.Parameters.AddWithValue("@Miejscowosc", textBoxMiejscowosc.Text);
                cmdAdres.Parameters.AddWithValue("@Kod", textBoxKodPocztowy.Text);
                cmdAdres.Parameters.AddWithValue("@Ulica", textBoxUlica.Text);
                cmdAdres.Parameters.AddWithValue("@NrUl", textBoxNrPosesji.Text);
                cmdAdres.Parameters.AddWithValue("@NrLok", textBoxNrLokalu.Text);
                cmdAdres.Parameters.AddWithValue("@ID", uzytkownikID);
                cmdAdres.ExecuteNonQuery();

                string updateUzytkownik = @"UPDATE dbo.Uzytkownik SET 
                            Login_uzytkownika = @Login, Imie = @Imie, Nazwisko = @Nazwisko, PESEL = @PESEL,
                            Data_urodzenia = @DataUr, Email = @Email, Numer_telefonu = @Tel,
                            Plec = @IDPlec, FK_ID_rola = @IDRola
                          WHERE ID_uzytkownik = @ID";

                SqlCommand cmd = new SqlCommand(updateUzytkownik, conn);
                cmd.Parameters.AddWithValue("@Login", textBoxLogin.Text);
                cmd.Parameters.AddWithValue("@Imie", textBoxImie.Text);
                cmd.Parameters.AddWithValue("@Nazwisko", textBoxNazwisko.Text);
                cmd.Parameters.AddWithValue("@PESEL", textBoxPesel.Text);
                cmd.Parameters.AddWithValue("@DataUr", dateTimePickerDataUrodzenia.Value);
                cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                cmd.Parameters.AddWithValue("@Tel", textBoxTelefon.Text);
                cmd.Parameters.AddWithValue("@IDPlec", comboBoxPlec.Text);
                cmd.Parameters.AddWithValue("@ID", uzytkownikID);
                cmd.ExecuteNonQuery();
            }
        }



            private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminFormPodgladDanych));
            this.buttonPowrot = new System.Windows.Forms.Button();
            this.buttonEdytuj = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxNrLokalu = new System.Windows.Forms.TextBox();
            this.textBoxNrPosesji = new System.Windows.Forms.TextBox();
            this.textBoxUlica = new System.Windows.Forms.TextBox();
            this.textBoxKodPocztowy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMiejscowosc = new System.Windows.Forms.TextBox();
            this.comboBoxPlec = new System.Windows.Forms.ComboBox();
            this.dateTimePickerDataUrodzenia = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTelefon = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPesel = new System.Windows.Forms.TextBox();
            this.rola = new System.Windows.Forms.Label();
            this.comboBoxRola = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imie = new System.Windows.Forms.Label();
            this.dane = new System.Windows.Forms.Label();
            this.textBoxNazwisko = new System.Windows.Forms.TextBox();
            this.textBoxImie = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.buttonZapis = new System.Windows.Forms.Button();
            this.buttonZmienHaslo = new System.Windows.Forms.Button();
            this.buttonZapiszHaslo = new System.Windows.Forms.Button();
            this.textBoxNoweHaslo = new System.Windows.Forms.TextBox();
            this.textBoxPowtorzNoweHaslo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonPowrot
            // 
            this.buttonPowrot.BackColor = System.Drawing.Color.Peru;
            this.buttonPowrot.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPowrot.Location = new System.Drawing.Point(236, 12);
            this.buttonPowrot.Name = "buttonPowrot";
            this.buttonPowrot.Size = new System.Drawing.Size(121, 32);
            this.buttonPowrot.TabIndex = 102;
            this.buttonPowrot.Text = "Powrót";
            this.buttonPowrot.UseVisualStyleBackColor = false;
            this.buttonPowrot.Click += new System.EventHandler(this.buttonPowrot_Click);
            // 
            // buttonEdytuj
            // 
            this.buttonEdytuj.BackColor = System.Drawing.Color.Peru;
            this.buttonEdytuj.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonEdytuj.Location = new System.Drawing.Point(547, 225);
            this.buttonEdytuj.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEdytuj.Name = "buttonEdytuj";
            this.buttonEdytuj.Size = new System.Drawing.Size(123, 48);
            this.buttonEdytuj.TabIndex = 100;
            this.buttonEdytuj.Text = "Edytuj";
            this.buttonEdytuj.UseVisualStyleBackColor = false;
            this.buttonEdytuj.Click += new System.EventHandler(this.buttonEdytuj_Click_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(435, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 16);
            this.label13.TabIndex = 98;
            this.label13.Text = "Numer lokalu:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(435, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 16);
            this.label12.TabIndex = 97;
            this.label12.Text = "Numer posesji:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(467, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 16);
            this.label11.TabIndex = 96;
            this.label11.Text = "Ulica:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(435, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 16);
            this.label10.TabIndex = 95;
            this.label10.Text = "Kod pocztowy:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(446, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 16);
            this.label9.TabIndex = 94;
            this.label9.Text = "Miejscowość:";
            // 
            // textBoxNrLokalu
            // 
            this.textBoxNrLokalu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxNrLokalu.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNrLokalu.Location = new System.Drawing.Point(547, 190);
            this.textBoxNrLokalu.Name = "textBoxNrLokalu";
            this.textBoxNrLokalu.Size = new System.Drawing.Size(123, 21);
            this.textBoxNrLokalu.TabIndex = 93;
            // 
            // textBoxNrPosesji
            // 
            this.textBoxNrPosesji.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxNrPosesji.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNrPosesji.Location = new System.Drawing.Point(547, 155);
            this.textBoxNrPosesji.Name = "textBoxNrPosesji";
            this.textBoxNrPosesji.Size = new System.Drawing.Size(123, 21);
            this.textBoxNrPosesji.TabIndex = 92;
            // 
            // textBoxUlica
            // 
            this.textBoxUlica.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxUlica.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxUlica.Location = new System.Drawing.Point(547, 123);
            this.textBoxUlica.Name = "textBoxUlica";
            this.textBoxUlica.Size = new System.Drawing.Size(123, 21);
            this.textBoxUlica.TabIndex = 91;
            // 
            // textBoxKodPocztowy
            // 
            this.textBoxKodPocztowy.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxKodPocztowy.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxKodPocztowy.Location = new System.Drawing.Point(547, 90);
            this.textBoxKodPocztowy.Name = "textBoxKodPocztowy";
            this.textBoxKodPocztowy.Size = new System.Drawing.Size(123, 21);
            this.textBoxKodPocztowy.TabIndex = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(469, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 18);
            this.label1.TabIndex = 89;
            this.label1.Text = "Adres zamieszkania:";
            // 
            // textBoxMiejscowosc
            // 
            this.textBoxMiejscowosc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxMiejscowosc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxMiejscowosc.Location = new System.Drawing.Point(547, 54);
            this.textBoxMiejscowosc.Name = "textBoxMiejscowosc";
            this.textBoxMiejscowosc.Size = new System.Drawing.Size(123, 21);
            this.textBoxMiejscowosc.TabIndex = 88;
            // 
            // comboBoxPlec
            // 
            this.comboBoxPlec.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxPlec.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxPlec.FormattingEnabled = true;
            this.comboBoxPlec.Location = new System.Drawing.Point(236, 301);
            this.comboBoxPlec.Name = "comboBoxPlec";
            this.comboBoxPlec.Size = new System.Drawing.Size(100, 21);
            this.comboBoxPlec.TabIndex = 87;
            // 
            // dateTimePickerDataUrodzenia
            // 
            this.dateTimePickerDataUrodzenia.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dateTimePickerDataUrodzenia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePickerDataUrodzenia.Location = new System.Drawing.Point(160, 260);
            this.dateTimePickerDataUrodzenia.Name = "dateTimePickerDataUrodzenia";
            this.dateTimePickerDataUrodzenia.Size = new System.Drawing.Size(243, 21);
            this.dateTimePickerDataUrodzenia.TabIndex = 86;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(182, 387);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 16);
            this.label8.TabIndex = 85;
            this.label8.Text = "Numer telefonu:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(183, 333);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 16);
            this.label7.TabIndex = 84;
            this.label7.Text = "Adres e-mail:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(183, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 83;
            this.label6.Text = "Płeć:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(183, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 82;
            this.label5.Text = "Data urodzenia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(183, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 81;
            this.label4.Text = "Pesel:";
            // 
            // textBoxTelefon
            // 
            this.textBoxTelefon.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxTelefon.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxTelefon.Location = new System.Drawing.Point(186, 406);
            this.textBoxTelefon.Name = "textBoxTelefon";
            this.textBoxTelefon.Size = new System.Drawing.Size(150, 21);
            this.textBoxTelefon.TabIndex = 80;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxEmail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxEmail.Location = new System.Drawing.Point(186, 352);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(150, 21);
            this.textBoxEmail.TabIndex = 79;
            // 
            // textBoxPesel
            // 
            this.textBoxPesel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxPesel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPesel.Location = new System.Drawing.Point(236, 201);
            this.textBoxPesel.Name = "textBoxPesel";
            this.textBoxPesel.Size = new System.Drawing.Size(121, 21);
            this.textBoxPesel.TabIndex = 78;
            // 
            // rola
            // 
            this.rola.AutoSize = true;
            this.rola.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rola.Location = new System.Drawing.Point(186, 166);
            this.rola.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rola.Name = "rola";
            this.rola.Size = new System.Drawing.Size(40, 16);
            this.rola.TabIndex = 77;
            this.rola.Text = "Rola:";
            // 
            // comboBoxRola
            // 
            this.comboBoxRola.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxRola.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxRola.FormattingEnabled = true;
            this.comboBoxRola.Location = new System.Drawing.Point(236, 165);
            this.comboBoxRola.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxRola.Name = "comboBoxRola";
            this.comboBoxRola.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRola.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(157, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 75;
            this.label3.Text = "Nazwisko:";
            // 
            // imie
            // 
            this.imie.AutoSize = true;
            this.imie.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.imie.Location = new System.Drawing.Point(186, 91);
            this.imie.Name = "imie";
            this.imie.Size = new System.Drawing.Size(40, 16);
            this.imie.TabIndex = 74;
            this.imie.Text = "Imię:";
            this.imie.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dane
            // 
            this.dane.AutoSize = true;
            this.dane.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dane.Location = new System.Drawing.Point(183, 55);
            this.dane.Name = "dane";
            this.dane.Size = new System.Drawing.Size(47, 16);
            this.dane.TabIndex = 73;
            this.dane.Text = "Login:";
            this.dane.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxNazwisko
            // 
            this.textBoxNazwisko.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxNazwisko.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNazwisko.Location = new System.Drawing.Point(236, 127);
            this.textBoxNazwisko.Name = "textBoxNazwisko";
            this.textBoxNazwisko.Size = new System.Drawing.Size(121, 21);
            this.textBoxNazwisko.TabIndex = 72;
            // 
            // textBoxImie
            // 
            this.textBoxImie.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxImie.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxImie.Location = new System.Drawing.Point(236, 91);
            this.textBoxImie.Name = "textBoxImie";
            this.textBoxImie.Size = new System.Drawing.Size(121, 21);
            this.textBoxImie.TabIndex = 71;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxLogin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxLogin.Location = new System.Drawing.Point(236, 54);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(121, 21);
            this.textBoxLogin.TabIndex = 70;
            // 
            // buttonZapis
            // 
            this.buttonZapis.BackColor = System.Drawing.Color.Peru;
            this.buttonZapis.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonZapis.Location = new System.Drawing.Point(545, 355);
            this.buttonZapis.Name = "buttonZapis";
            this.buttonZapis.Size = new System.Drawing.Size(125, 48);
            this.buttonZapis.TabIndex = 103;
            this.buttonZapis.Text = "Zapisz";
            this.buttonZapis.UseVisualStyleBackColor = false;
            this.buttonZapis.Click += new System.EventHandler(this.buttonZapis_Click);
            // 
            // buttonZmienHaslo
            // 
            this.buttonZmienHaslo.BackColor = System.Drawing.Color.Peru;
            this.buttonZmienHaslo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonZmienHaslo.Location = new System.Drawing.Point(778, 91);
            this.buttonZmienHaslo.Name = "buttonZmienHaslo";
            this.buttonZmienHaslo.Size = new System.Drawing.Size(243, 32);
            this.buttonZmienHaslo.TabIndex = 104;
            this.buttonZmienHaslo.Text = "Zmień hasło użytkownikowi";
            this.buttonZmienHaslo.UseVisualStyleBackColor = false;
            this.buttonZmienHaslo.Click += new System.EventHandler(this.buttonZmienHaslo_Click);
            // 
            // buttonZapiszHaslo
            // 
            this.buttonZapiszHaslo.BackColor = System.Drawing.Color.Peru;
            this.buttonZapiszHaslo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonZapiszHaslo.Location = new System.Drawing.Point(778, 234);
            this.buttonZapiszHaslo.Name = "buttonZapiszHaslo";
            this.buttonZapiszHaslo.Size = new System.Drawing.Size(243, 32);
            this.buttonZapiszHaslo.TabIndex = 105;
            this.buttonZapiszHaslo.Text = "Zapisz hasło";
            this.buttonZapiszHaslo.UseVisualStyleBackColor = false;
            this.buttonZapiszHaslo.Click += new System.EventHandler(this.buttonZapiszHaslo_Click);
            // 
            // textBoxNoweHaslo
            // 
            this.textBoxNoweHaslo.Location = new System.Drawing.Point(885, 143);
            this.textBoxNoweHaslo.Name = "textBoxNoweHaslo";
            this.textBoxNoweHaslo.Size = new System.Drawing.Size(136, 20);
            this.textBoxNoweHaslo.TabIndex = 106;
            // 
            // textBoxPowtorzNoweHaslo
            // 
            this.textBoxPowtorzNoweHaslo.Location = new System.Drawing.Point(885, 182);
            this.textBoxPowtorzNoweHaslo.Name = "textBoxPowtorzNoweHaslo";
            this.textBoxPowtorzNoweHaslo.Size = new System.Drawing.Size(136, 20);
            this.textBoxPowtorzNoweHaslo.TabIndex = 107;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(775, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 108;
            this.label2.Text = "Nowe hasło:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(734, 186);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(145, 16);
            this.label14.TabIndex = 109;
            this.label14.Text = "Powtórz nowe hasło:";
            // 
            // AdminFormPodgladDanych
            // 
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1069, 435);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPowtorzNoweHaslo);
            this.Controls.Add(this.textBoxNoweHaslo);
            this.Controls.Add(this.buttonZapiszHaslo);
            this.Controls.Add(this.buttonZmienHaslo);
            this.Controls.Add(this.buttonZapis);
            this.Controls.Add(this.buttonPowrot);
            this.Controls.Add(this.buttonEdytuj);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxNrLokalu);
            this.Controls.Add(this.textBoxNrPosesji);
            this.Controls.Add(this.textBoxUlica);
            this.Controls.Add(this.textBoxKodPocztowy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMiejscowosc);
            this.Controls.Add(this.comboBoxPlec);
            this.Controls.Add(this.dateTimePickerDataUrodzenia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTelefon);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxPesel);
            this.Controls.Add(this.rola);
            this.Controls.Add(this.comboBoxRola);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imie);
            this.Controls.Add(this.dane);
            this.Controls.Add(this.textBoxNazwisko);
            this.Controls.Add(this.textBoxImie);
            this.Controls.Add(this.textBoxLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminFormPodgladDanych";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LibraSys | Podgląd danych";
            this.Load += new System.EventHandler(this.FormPodgladSzczegoly_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FormPodgladSzczegoly_Load(object sender, EventArgs e)
        {
            UstawPolaEdycji(false);
        }

        private void buttonZmienHaslo_Click(object sender, EventArgs e)
        {
            {
                textBoxNoweHaslo.Enabled = true;
                textBoxPowtorzNoweHaslo.Enabled = true;
                buttonZapiszHaslo.Visible = true;
            }
        }

        private void buttonZapiszHaslo_Click(object sender, EventArgs e)
        {
            string noweHaslo = textBoxNoweHaslo.Text;
            string powtorzHaslo = textBoxPowtorzNoweHaslo.Text;

            if (noweHaslo != powtorzHaslo)
            {
                MessageBox.Show("Hasła nie są takie same.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string komunikat;
            if (!Validator.IsValidPassword(noweHaslo,uzytkownikID, out komunikat))
            {
                MessageBox.Show(komunikat, "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Uzytkownik SET Haslo = @haslo WHERE ID_uzytkownik = @id", conn);
                cmd.Parameters.AddWithValue("@haslo", noweHaslo);
                cmd.Parameters.AddWithValue("@id", uzytkownikID);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Hasło zostało zmienione.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
        }
    }
}
