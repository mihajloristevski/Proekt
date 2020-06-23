using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Proekt
{
    public partial class Izmeni_Vraboten : Form
    {
        public Izmeni_Vraboten()
        {
            InitializeComponent();
        }
        TextBox tb = new TextBox();
        TextBox tb1 = new TextBox();
        TextBox tb2 = new TextBox();
        TextBox tb3 = new TextBox();
        TextBox tb4 = new TextBox();
        TextBox tb6 = new TextBox();
        RadioButton rbkor_ime = new RadioButton();
        RadioButton rbprezime = new RadioButton();
        RadioButton rblozinka = new RadioButton();
        RadioButton rbtelefon = new RadioButton();
        RadioButton rbemail = new RadioButton();
        Button bt = new Button();
        Button bt_izlez = new Button();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6RP8HS4;Initial Catalog=Benziska;Integrated Security=True");
        private DataGridView dgvVraboten = new DataGridView();
        private BindingSource bindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private void Izmeni_Vraboten_Load(object sender, EventArgs e)
        {
            this.Width = 1300;
            this.Height = 500;
            this.BackColor = Color.FromArgb(255, 66, 66);
            this.Text = "Измени вработен";
            this.ControlBox = false;


            Label lbn = new Label();
            LabelZ lbnaslove = new LabelZ(100, 20, 280, 14, "Изменување на Вработен", lbn);
            lbn.Font = new Font("Roboto", 14, FontStyle.Underline);
            Controls.Add(lbn);

            dgvVraboten.Width = 800;
            dgvVraboten.Height = 200;
            dgvVraboten.Location = new Point(450, 70);

            dgvVraboten.DataSource = bindingSource;
            conn.Open();
            dataAdapter = new SqlDataAdapter("select id_vraboten AS РеденБрој, korisnicko_ime AS КорисничкоИме, ime AS Име, prezime AS Презиме,lozinka AS Лозинка,telefon AS Телефон, EMBG AS ЕМБГ,mail AS Емаил from Vraboten", conn);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            dgvVraboten.DataSource = table;
            Controls.Add(dgvVraboten);
            conn.Close();


            Label lb = new Label();
            LabelZ lbkorisnicko_ime = new LabelZ(20, 70, 180, 12, "Измени Корисничко име", lb);
            Controls.Add(lb);

            TextBoxZ tbkorisnicko_ime = new TextBoxZ(210, 70, tb);
            tb.Enabled = false;
            Controls.Add(tb);

            RadioButtonZ rb1 = new RadioButtonZ(420, 60, 15, 15, "", 10, rbkor_ime);
            rbkor_ime.Click += new EventHandler(this.fizbor);
            Controls.Add(rbkor_ime);

            /*           Label lb1 = new Label();
                       LabelZ lbIme = new LabelZ(20, 120, 180, 12, "Измени Име", lb1);
                       Controls.Add(lb1);

                       TextBoxZ tbIme = new TextBoxZ(210, 120, tb1);
                       Controls.Add(tb1);
           */
            Label lb2 = new Label();
            LabelZ lbPrezime = new LabelZ(20, 120, 180, 12, "Измени Презиме", lb2);
            Controls.Add(lb2);

            TextBoxZ tbPrezime = new TextBoxZ(210, 120, tb2);
            tb2.Enabled = false;
            Controls.Add(tb2);

            RadioButtonZ rb2 = new RadioButtonZ(420, 110, 15, 15, "", 10, rbprezime);
            rbprezime.Click += new EventHandler(this.fizbor);
            Controls.Add(rbprezime);

            Label lb3 = new Label();
            LabelZ lbLozinka = new LabelZ(20, 170, 180, 12, "Измени Лозинка", lb3);
            Controls.Add(lb3);

            TextBoxZ tbLozinka = new TextBoxZ(210, 170, tb3);
            tb3.Enabled = false;
            Controls.Add(tb3);

            RadioButtonZ rb3 = new RadioButtonZ(420, 160, 15, 15, "", 10, rblozinka);
            rblozinka.Click += new EventHandler(this.fizbor);
            Controls.Add(rblozinka);

            Label lb4 = new Label();
            LabelZ lbTelefon = new LabelZ(20, 220, 180, 12, "Измени Телефон", lb4);
            Controls.Add(lb4);

            TextBoxZ tbTelefon = new TextBoxZ(210, 220, tb4);
            tb4.Enabled = false;
            Controls.Add(tb4);

            RadioButtonZ rb4 = new RadioButtonZ(420, 210, 15, 15, "", 10, rbtelefon);
            rbtelefon.Click += new EventHandler(this.fizbor);
            Controls.Add(rbtelefon);

            /*           Label lb5 = new Label();
                       LabelZ lbembg = new LabelZ(20, 320, 180, 12, "Измени ЕМБГ", lb5);
                       Controls.Add(lb5);

                       TextBoxZ tbembg = new TextBoxZ(210, 320, tb5);
                       Controls.Add(tb5);
                       */
            Label lb6 = new Label();
            LabelZ lbemail = new LabelZ(20, 270, 180, 12, "Измени Е-маил", lb6);
            Controls.Add(lb6);

            TextBoxZ tbe_email = new TextBoxZ(210, 270, tb6);
            tb6.Enabled = false;
            Controls.Add(tb6);

            RadioButtonZ rb5 = new RadioButtonZ(420, 260, 15, 15, "", 10, rbemail);
            rbemail.Click += new EventHandler(this.fizbor);
            Controls.Add(rbemail);

            Label lb7 = new Label();
            LabelZ lbizbor = new LabelZ(500, 320, 180, 10, "Внесете ред. број", lb7);
            Controls.Add(lb7);

            TextBoxZ tbizbor = new TextBoxZ(500, 350, tb1);
            Controls.Add(tb1);

            ButtonZ btIzmeni = new ButtonZ(100, 320, "Измени", bt);
            bt.Click += new EventHandler(this.fizmeni);
            Controls.Add(bt);

            ButtonZ btIzlez = new ButtonZ(250, 320, "Излез", bt_izlez);
            bt_izlez.Click += new EventHandler(this.fizlez);
            Controls.Add(bt_izlez);
        }
        public void fizlez(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fizbor(object sender, EventArgs e)
        {
            if (rbkor_ime.Checked == true)
                tb.Enabled = true;
            else
                tb.Enabled = false;



            if (rbprezime.Checked == true)
                tb2.Enabled = true;
            else
                tb2.Enabled = false;



            if (rblozinka.Checked == true)
                tb3.Enabled = true;
            else
                tb3.Enabled = false;


            if (rbtelefon.Checked == true)
                tb4.Enabled = true;
            else
                tb4.Enabled = false;


            if (rbemail.Checked == true)
                tb6.Enabled = true;
            else
                tb6.Enabled = false;

        }
        public void fizmeni(object sender, EventArgs e)
        {
            if (tb1.Text == "" || rbemail.Checked == false && rbkor_ime.Checked == false && rblozinka.Checked == false && rbprezime.Checked ==false && rbtelefon.Checked == false)
            {
                MessageBox.Show("Грешка");
            }
                else
                {
                if (rbkor_ime.Checked == true)
                {
                    conn.Open();
                    string query = "update Vraboten set korisnicko_ime = @korisnik where id_vraboten = @redenbroj";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@korisnik", tb.Text);
                    cmd.Parameters.AddWithValue("@redenbroj", tb1.Text);
                    cmd.ExecuteNonQuery();

                    dataAdapter = new SqlDataAdapter("select id_vraboten AS РеденБрој, korisnicko_ime AS КорисничкоИме, ime AS Име, prezime AS Презиме,lozinka AS Лозинка,telefon AS Телефон, EMBG AS ЕМБГ,mail AS Емаил from Vraboten", conn);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    dgvVraboten.DataSource = table;
                    Controls.Add(dgvVraboten);
                    conn.Close();



                    MessageBox.Show("Корисничкото име за клиентот со реден број " + tb1.Text + " e изменето во " + tb.Text);
                    tb.Text = "";
                }
                if (rbprezime.Checked == true)
                {
                    conn.Open();
                    string query = "update Vraboten set prezime = @prezime where id_vraboten = @redenbroj";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@prezime", tb2.Text);
                    cmd.Parameters.AddWithValue("@redenbroj", tb1.Text);
                    cmd.ExecuteNonQuery();

                    dataAdapter = new SqlDataAdapter("select id_vraboten AS РеденБрој, korisnicko_ime AS КорисничкоИме, ime AS Име, prezime AS Презиме,lozinka AS Лозинка,telefon AS Телефон, EMBG AS ЕМБГ,mail AS Емаил from Vraboten", conn);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    dgvVraboten.DataSource = table;
                    Controls.Add(dgvVraboten);
                    conn.Close();


                    MessageBox.Show("Презиме за клиентот со реден број " + tb1.Text + " e изменето во " + tb2.Text);
                    tb2.Text = "";
                }
                if (rblozinka.Checked == true)
                {
                    conn.Open();
                    string query = "update Vraboten set lozinka = @lozinka where id_vraboten = @redenbroj";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@lozinka", tb3.Text);
                    cmd.Parameters.AddWithValue("@redenbroj", tb1.Text);
                    cmd.ExecuteNonQuery();

                    dataAdapter = new SqlDataAdapter("select id_vraboten AS РеденБрој, korisnicko_ime AS КорисничкоИме, ime AS Име, prezime AS Презиме,lozinka AS Лозинка,telefon AS Телефон, EMBG AS ЕМБГ,mail AS Емаил from Vraboten", conn);
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    dgvVraboten.DataSource = table;
                    Controls.Add(dgvVraboten);
                    conn.Close();


                    MessageBox.Show("Лозинката за клиентот со реден број " + tb1.Text + " e изменето во " + tb3.Text);
                    tb3.Text = "";
                }
                if (rbtelefon.Checked == true)
                {  //tb4
                    conn.Open();
                    string query = "update Vraboten set telefon = @telefon where id_vraboten = @redenbroj";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@telefon", tb4.Text);
                    cmd.Parameters.AddWithValue("@redenbroj", tb1.Text);
                    cmd.ExecuteNonQuery();

                    dataAdapter = new SqlDataAdapter("select id_vraboten AS РеденБрој, korisnicko_ime AS КорисничкоИме, ime AS Име, prezime AS Презиме,lozinka AS Лозинка,telefon AS Телефон, EMBG AS ЕМБГ,mail AS Емаил from Vraboten", conn);
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    dgvVraboten.DataSource = table;
                    Controls.Add(dgvVraboten);
                    conn.Close();


                    MessageBox.Show("Телефонот за клиентот со реден број " + tb1.Text + " e изменето во " + tb4.Text);
                    tb4.Text = "";
                }
                if (rbemail.Checked == true)
                { //tb6
                    conn.Open();
                    string query = "update Vraboten set mail = @mail where id_vraboten = @redenbroj";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mail", tb6.Text);
                    cmd.Parameters.AddWithValue("@redenbroj", tb1.Text);
                    cmd.ExecuteNonQuery();

                    dataAdapter = new SqlDataAdapter("select id_vraboten AS РеденБрој, korisnicko_ime AS КорисничкоИме, ime AS Име, prezime AS Презиме,lozinka AS Лозинка,telefon AS Телефон, EMBG AS ЕМБГ,mail AS Емаил from Vraboten", conn);
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    dgvVraboten.DataSource = table;
                    Controls.Add(dgvVraboten);
                    conn.Close();



                    MessageBox.Show("Емаилот за клиентот со реден број " + tb1.Text + " e изменето во " + tb6.Text);
                    tb6.Text = "";
                    }
                }
             }
        }
    }
