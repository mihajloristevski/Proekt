using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Proekt
{
    public partial class Izmeni_Klient : Form
    {
        public Izmeni_Klient()
        {
            InitializeComponent();
        }
        TextBox tb = new TextBox();
        TextBox tb1 = new TextBox();
        TextBox tb2 = new TextBox();
        TextBox tb3 = new TextBox();
        TextBox tb4 = new TextBox();
        TextBox tb5 = new TextBox();
        RadioButton rbPrezime = new RadioButton();
        RadioButton rbTelefon = new RadioButton();
        RadioButton rbmail = new RadioButton();
        Button bt = new Button();
        Button bt1 = new Button();
        Label lb6 = new Label();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6RP8HS4;Initial Catalog=Benziska;Integrated Security=True");
        private DataGridView dgvKlient = new DataGridView();
        private BindingSource bindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private void Izmeni_Klient_Load(object sender, EventArgs e)
        {
            this.Width =1200;
            this.Height = 500;
            this.BackColor = Color.FromArgb(255, 66, 66);
            this.Text = "Измени клиент";
            this.ControlBox=false;

            Label lbn = new Label();
            LabelZ lbnaslove = new LabelZ(100,20,280,14,"Измени Клиент",lbn);
            lbn.Font = new Font("Roboto",14,FontStyle.Underline);
            Controls.Add(lbn);

            dgvKlient.Width = 650;
            dgvKlient.Height = 200;
            dgvKlient.Location = new Point(450, 70);
            dgvKlient.BackgroundColor = Color.FromArgb(255, 66, 66); 

            dgvKlient.DataSource = bindingSource;
            conn.Open();
            dataAdapter = new SqlDataAdapter("select id_klient AS РеденБрој, Ime AS Име, Prezime AS Презиме,Telefon AS Телефон, EMBG AS ЕМБГ,Mail AS Емаил from Klient", conn);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            dgvKlient.DataSource = table;
            Controls.Add(dgvKlient);
            conn.Close();

           /* Label lb1 = new Label();
            LabelZ lbIme = new LabelZ(20,70,180,12,"Изменете Име",lb1);
            Controls.Add(lb1);

            TextBoxZ tbIme = new TextBoxZ(210,70,tb1);
            Controls.Add(tb1);
            */
            Label lb2 = new Label();
            LabelZ lbPrezime = new LabelZ(20,120,180,12,"Изменете Презиме",lb2);
            Controls.Add(lb2);

            TextBoxZ tbPrezime = new TextBoxZ(210,120,tb2);
            tb2.Enabled = false;
            Controls.Add(tb2);

            RadioButtonZ rb1 = new RadioButtonZ(420, 110, 15, 15, "", 10, rbPrezime);
            rbPrezime.Click += new EventHandler(this.fizmeni);
            Controls.Add(rbPrezime);

            Label lb3 = new Label();
            LabelZ lbTelefon = new LabelZ(20,170,180,12,"Изменете Телефон",lb3);
            Controls.Add(lb3);

            TextBoxZ tbTelefon = new TextBoxZ(210,170,tb3);
            tb3.Enabled = false;
            Controls.Add(tb3);

            RadioButtonZ rb2 = new RadioButtonZ(420, 160, 15, 15, "", 10, rbTelefon);
            rbTelefon.Click += new EventHandler(this.fizmeni);
            Controls.Add(rbTelefon);

         /* Label lb4 = new Label();
            LabelZ lbembg = new LabelZ(20,220,180,12,"Изменете ЕМБГ",lb4);
            Controls.Add(lb4);

            TextBoxZ tbembg = new TextBoxZ(210,220,tb4);
            Controls.Add(tb4);
            */
            Label lb5 = new Label();
            LabelZ lbemail = new LabelZ(20, 220,180,12,"Изменете Е-маил",lb5);
            Controls.Add(lb5);

            TextBoxZ tbe_email = new TextBoxZ(210, 220,tb5);
            tb5.Enabled = false;
            Controls.Add(tb5);

            RadioButtonZ rb3 = new RadioButtonZ(420, 210, 15, 15, "", 10, rbmail);
            rbmail.Click += new EventHandler(this.fizmeni);
            Controls.Add(rbmail);

            ButtonZ btIzmeni = new ButtonZ(170,320,"Измени",bt);
            bt.Font = new Font("Roboto", 10, FontStyle.Regular);
            bt.Click += new EventHandler(this.fizmeniBAza);
            Controls.Add(bt);

            ButtonZ btizlez = new ButtonZ(280, 320, "Излез", bt1);
            bt1.Font = new Font("Roboto", 10, FontStyle.Regular);
            bt1.Click += new EventHandler(this.fizlez);
            Controls.Add(bt1);

            

            Label lb1 = new Label();
            LabelZ lb_broj = new LabelZ(420, 320, 250,10,"Внесете реден број:",lb1);
            Controls.Add(lb1);
            
            TextBoxZ tb_broj = new TextBoxZ(420,360,tb1);
            Controls.Add(tb1);

            
        }
        public void fizmeni(object sender, EventArgs e)
        {
            
            if (rbPrezime.Checked == true)
                tb2.Enabled = true;
            else
                tb2.Enabled = false;


            if (rbTelefon.Checked == true)
                tb3.Enabled = true;
            else
                tb3.Enabled = false;


            if (rbmail.Checked == true)
                tb5.Enabled = true;
            else
                tb5.Enabled = false;
        }
        public void fizlez(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fizmeniBAza(object sender, EventArgs e)
        {
            if (tb1.Text == "" || rbmail.Checked == false && rbPrezime.Checked ==false && rbTelefon.Checked == false)
            {
                MessageBox.Show("Грешка");
            }
            else
            {
                if (rbPrezime.Checked == true)
                {
                    conn.Open();
                    string query = "update Klient set prezime=@prezime where id_klient=@RedenBroj";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@prezime", tb2.Text);
                    cmd.Parameters.AddWithValue("@RedenBroj", tb1.Text);
                    cmd.ExecuteNonQuery();

                    dataAdapter = new SqlDataAdapter("select id_klient AS РеденБрој, Ime AS Име, Prezime AS Презиме,Telefon AS Телефон, EMBG AS ЕМБГ,Mail AS Емаил from Klient", conn);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    dgvKlient.DataSource = table;
                    Controls.Add(dgvKlient);
                    conn.Close();


                    MessageBox.Show("Презимето за клиентот со реден број " + tb1.Text + " e изменето во " + tb2.Text);
                    tb2.Text = "";
                }
                if (rbTelefon.Checked == true)
                {
                    conn.Open();
                    string query = "update Klient set Telefon=@telefon where id_klient=@RedenBroj";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Telefon", tb3.Text);
                    cmd.Parameters.AddWithValue("@RedenBroj", tb1.Text);
                    cmd.ExecuteNonQuery();

                    dataAdapter = new SqlDataAdapter("select id_klient AS РеденБрој, Ime AS Име, Prezime AS Презиме,Telefon AS Телефон, EMBG AS ЕМБГ,Mail AS Емаил from Klient", conn);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    dgvKlient.DataSource = table;
                    Controls.Add(dgvKlient);
                    conn.Close();


                    MessageBox.Show("Tелефонот за клиентот со реден број " + tb1.Text + " e изменето во " + tb3.Text);
                    tb3.Text = "";
                }
                if (rbmail.Checked == true)
                {
                    conn.Open();
                    string query = "update Klient set Mail=@Mail where id_klient=@RedenBroj";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Mail", tb5.Text);
                    cmd.Parameters.AddWithValue("@RedenBroj", tb1.Text);
                    cmd.ExecuteNonQuery();

                    dataAdapter = new SqlDataAdapter("select id_klient AS РеденБрој, Ime AS Име, Prezime AS Презиме,Telefon AS Телефон, EMBG AS ЕМБГ,Mail AS Емаил from Klient", conn);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    dgvKlient.DataSource = table;
                    Controls.Add(dgvKlient);
                    conn.Close();


                    MessageBox.Show("Е-маилот за клиентот со реден број " + tb1.Text + " e изменето во " + tb5.Text);
                    tb5.Text = "";
                }
            }
        }
    }
}

