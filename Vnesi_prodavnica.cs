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
    public partial class Vnesi_prodavnica : Form
    {
        public Vnesi_prodavnica()
        {
            InitializeComponent();
        }
        RadioButton rbklasa = new RadioButton();
        RadioButton rbpodklasa = new RadioButton();
        RadioButton rbartikal = new RadioButton();
        Button btvnesi = new Button();
        GroupBox gbklasa = new GroupBox();
        GroupBox gbpodklasa = new GroupBox();
        GroupBox gbartikal = new GroupBox();
        TextBox tbvnesi_klasa = new TextBox();
        TextBox tbime_podklasa = new TextBox();
        Button btvnesi_klasa = new Button();
        ComboBox cbizbor_klasa = new ComboBox();
        Button btvnesi_podklasa = new Button();
        ComboBox cbizbor_podklasa = new ComboBox();
        TextBox tbime_artikal = new TextBox();
        TextBox tbcena_artikal = new TextBox();
        TextBox tbgramaza_artikal = new TextBox();
        TextBox tbkolicina_artikal = new TextBox();
        Button bt_vnesiartikal = new Button();
        Button bt_izlez = new Button();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6RP8HS4;Initial Catalog=Benziska;Integrated Security=True");
        private void Vnesi_Hrana_Load(object sender, EventArgs e)
        {
            this.Width = 1000;
            this.Height = 900;
            this.Text = "Внеси продавница";
            this.BackColor = Color.FromArgb(255, 66, 66);
            this.ControlBox = false;

            Label lbnaslov = new Label();
            LabelZ lbnaslov1 = new LabelZ(300, 20, 300, 18, "Внеси во продавница", lbnaslov);
            lbnaslov.Font = new Font("Roboto", 18, FontStyle.Underline);
            Controls.Add(lbnaslov);

            RadioButtonZ rb = new RadioButtonZ(30, 70, 150, 40, "Класа", 12, rbklasa);
            rbklasa.Click += new EventHandler(this.faktiviraj);
            Controls.Add(rbklasa);

            RadioButtonZ rb1 = new RadioButtonZ(30, 120, 150, 40, "Подкласа", 12, rbpodklasa);
            rbpodklasa.Click += new EventHandler(this.faktiviraj);
            Controls.Add(rbpodklasa);

            RadioButtonZ rb2 = new RadioButtonZ(30, 170, 150, 40, "Нов Артикал", 12, rbartikal);
            rbartikal.Click += new EventHandler(this.faktiviraj);
            Controls.Add(rbartikal);

            //ButtonZ bt = new ButtonZ(80, 220, "OK", btvnesi);
            //btvnesi.Click += new EventHandler(this.faktiviraj);
            //Controls.Add(btvnesi);

            gbklasa.Width = 300;
            gbklasa.Height = 300;
            gbklasa.ForeColor = Color.White;
            gbklasa.BackColor = Color.FromArgb(255, 66, 66);
            gbklasa.Text = "Класа";
            gbklasa.Location = new Point(350, 70);
            gbklasa.Enabled = false;
            Controls.Add(gbklasa);

            Label lbklasa_ime = new Label();
            LabelZ lbklasa = new LabelZ(70, 30, 180, 14, "Име на класата", lbklasa_ime);
            gbklasa.Controls.Add(lbklasa_ime);

            TextBoxZ vnesi_klasa = new TextBoxZ(50, 70, tbvnesi_klasa);
            gbklasa.Controls.Add(tbvnesi_klasa);

            ButtonZ btvnesiklasa = new ButtonZ(100, 100, "OK", btvnesi_klasa);
            btvnesi_klasa.Click += new EventHandler(this.fvnesi);
            gbklasa.Controls.Add(btvnesi_klasa);


            gbpodklasa.Width = 300;
            gbpodklasa.Height = 300;
            gbpodklasa.ForeColor = Color.White;
            gbpodklasa.BackColor = Color.FromArgb(255, 66, 66);
            gbpodklasa.Text = "Подкласа";
            gbpodklasa.Location = new Point(660, 70);
            gbpodklasa.Enabled = false;
            Controls.Add(gbpodklasa);

           // Label lbizbor = new Label();
           // LabelZ lbizbor_klasa = new LabelZ(20, 20, 180, 14, "Изберете класа", lbizbor);
            //gbpodklasa.Controls.Add(lbizbor);

           // ComboBoxZ cbizbor = new ComboBoxZ(20, 60, 100, 40, cbizbor_klasa);
            //gbpodklasa.Controls.Add(cbizbor_klasa);

            Label lbime_podklasa = new Label();
            LabelZ lbime_klasa = new LabelZ(70, 30, 180, 14, "Име на подкласа", lbime_podklasa);
            gbpodklasa.Controls.Add(lbime_podklasa);


            TextBoxZ ime_podklasa = new TextBoxZ(50, 70, tbime_podklasa);
            gbpodklasa.Controls.Add(tbime_podklasa);

            ButtonZ vnesi_podklasa = new ButtonZ(100, 100, "OK", btvnesi_podklasa);
            btvnesi_podklasa.Click += new EventHandler(this.fvnesi);
            gbpodklasa.Controls.Add(btvnesi_podklasa);

            gbartikal.Width = 300;
            gbartikal.Height = 400;
            gbartikal.ForeColor = Color.White;
            gbartikal.BackColor = Color.FromArgb(255, 66, 66);
            gbartikal.Text = "Нов Артикал";
            gbartikal.Location = new Point(500, 380);
            gbartikal.Enabled = false;
            Controls.Add(gbartikal);

            Label lbpodklasa = new Label();
            LabelZ lbpod_klasa = new LabelZ(30, 30, 180, 10, "Изберете подкласа", lbpodklasa);
            gbartikal.Controls.Add(lbpodklasa);

            ComboBoxZ cbizborpodklasa = new ComboBoxZ(30, 60, 150, 40, cbizbor_podklasa);
            gbartikal.Controls.Add(cbizbor_podklasa);

            Label lbime_artikal = new Label();
            LabelZ lb_ime_artikal = new LabelZ(30, 90, 110, 10, "Внесете име", lbime_artikal);
            gbartikal.Controls.Add(lbime_artikal);

            TextBoxZ tb_ime_artikal = new TextBoxZ(30, 120, tbime_artikal);
            gbartikal.Controls.Add(tbime_artikal);

            Label lb_cena_artikal = new Label();
            LabelZ lbcena_artikal = new LabelZ(30, 150, 150, 10, "Внесете Цена", lb_cena_artikal);
            gbartikal.Controls.Add(lb_cena_artikal);

            TextBoxZ tb_cena_artikal = new TextBoxZ(30, 180, tbcena_artikal);
            gbartikal.Controls.Add(tbcena_artikal);

            Label lb_gramaza_artikal = new Label();
            LabelZ lbgramaza_artikal = new LabelZ(30, 210, 180, 10, "Внесете грамажа", lb_gramaza_artikal);
            gbartikal.Controls.Add(lb_gramaza_artikal);

            TextBoxZ tb_gramaza_artikal = new TextBoxZ(30, 240, tbgramaza_artikal);
            gbartikal.Controls.Add(tbgramaza_artikal);

            Label lb_kolicina_artikal = new Label();
            LabelZ lbkolicina_artikal = new LabelZ(30, 280, 180, 10, "Внесете количина", lb_kolicina_artikal);
            gbartikal.Controls.Add(lb_kolicina_artikal);

            TextBoxZ tb_kolicina_artikal = new TextBoxZ(30, 310, tbkolicina_artikal);
            gbartikal.Controls.Add(tbkolicina_artikal);


            ButtonZ btartikalvnesi = new ButtonZ(80, 350, "OK", bt_vnesiartikal);
            bt_vnesiartikal.Click += new EventHandler(this.fvnesi);
            gbartikal.Controls.Add(bt_vnesiartikal);

            ButtonZ btizlez = new ButtonZ(80, 260, "Излез", bt_izlez);
            bt_izlez.Click += new EventHandler(this.fizlez);
            Controls.Add(bt_izlez);

/*            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select Ime from Klasa";
            command.ExecuteNonQuery();
            DataTable table = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                cbizbor_klasa.Items.Add(dr["Ime"].ToString());
            }
            conn.Close();
            */
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            SqlCommand cmd = conn.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select id_podklasa,Ime from Podklasa where id_klasa = '1' ";
            command.ExecuteNonQuery();
            DataTable tb = new DataTable();
            SqlDataAdapter dataAda = new SqlDataAdapter(cmd);
            dataAdapter.Fill(tb);
            foreach (DataRow dr in tb.Rows)
            {
                cbizbor_podklasa.Items.Add(dr["Ime"].ToString());
            }
            conn.Close();



        }

        public void faktiviraj(object sender, EventArgs e)
        {
            if (rbklasa.Checked == true)

                gbklasa.Enabled = true;


            if (rbklasa.Checked == false)

                gbklasa.Enabled = false;

            if (rbpodklasa.Checked == true)

                gbpodklasa.Enabled = true;

            else

                gbpodklasa.Enabled = false;

            if (rbartikal.Checked == true)

                gbartikal.Enabled = true;

            else

                gbartikal.Enabled = false;
        }
        public void fizlez(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fvnesi(object sender, EventArgs e)
        {
            if (gbklasa.Enabled == true)
            {
                if (tbvnesi_klasa.Text == "")
                {

                    MessageBox.Show("Грешка");
                }
                else
                {
                    conn.Open();
                    string query = "insert into Klasa(Ime) values(@tbvnesi_klasa)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tbvnesi_klasa", tbvnesi_klasa.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();


                    MessageBox.Show("Податоците за класа се внесени");
                    tbvnesi_klasa.Text = "";
                }
            }
            if (gbpodklasa.Enabled == true)
            {
                if (tbime_podklasa.Text.Equals(""))
                {
                    MessageBox.Show("Грешка");
                }
                else
                {
                    conn.Open();
                    string query = "insert into Podklasa(Ime,id_klasa) values(@tbime_podklasa,'1')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tbime_podklasa", tbime_podklasa.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    tbime_podklasa.Text = "";
                    MessageBox.Show("Податоците за подкласа се внесени");
                }
                
            }
            if (gbartikal.Enabled == true) 
            {
                if (tbime_artikal.Text == "" || tbgramaza_artikal.Text == "" || tbcena_artikal.Text == "" || tbkolicina_artikal.Text == "")
                {
                    MessageBox.Show("Грешка");
                }
                else
                {
                    conn.Open();
                    string query = "insert into Artikal(id_podklasa,Ime,Tezina,Cena,Kolicina) values(@podklasa,@ime,@tezina,@cena,@kolicina)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@podklasa", cbizbor_podklasa.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@ime", tbime_artikal.Text);
                    cmd.Parameters.AddWithValue("@tezina", tbgramaza_artikal.Text);
                    cmd.Parameters.AddWithValue("@cena", tbcena_artikal.Text);
                    cmd.Parameters.AddWithValue("@kolicina", tbkolicina_artikal.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    tbime_artikal.Text = "";
                    tbgramaza_artikal.Text = "";
                    tbcena_artikal.Text = "";
                    tbkolicina_artikal.Text = "";
                    MessageBox.Show("Податоците за нов Артикал се внесени");
                }
            }
        }
    }
}
