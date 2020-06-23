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
    public partial class Prodazba : Form
    {
        public Prodazba()
        {
            InitializeComponent();
        }
        TextBox tbvnesiredbroj = new TextBox();
        TextBox tbrbKlient = new TextBox();
        TextBox tbredbrojVraboten = new TextBox();
        TextBox tbvnesiKolicina = new TextBox();
        TextBox tbCena = new TextBox();
        TextBox tbfaktura = new TextBox();
        Button btVnesi = new Button();
        Button btIzlez = new Button();
        Button btpotvrdi = new Button();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6RP8HS4;Initial Catalog=Benziska;Integrated Security=True");
        private DataGridView dgvArtikal = new DataGridView();
        private DataGridView dgvKlient = new DataGridView();
        private DataGridView dgvVraboten = new DataGridView();
        private BindingSource bindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private void Prodazba_Load(object sender, EventArgs e)
        {
            this.Width = 1050;
            this.Height = 880;
            this.Text = "Продажба";
            this.BackColor = Color.FromArgb(244, 66, 66);
            this.ControlBox = false;





            //select Cena from Artikal where id_artikal=3
            conn.Open();
            string query1 = "select max(br_faktura)+1 from Prodazba";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@redenbroj", tbvnesiredbroj.Text);
            //
            int brf = (int)cmd1.ExecuteScalar();
            conn.Close();



            Label lbfaktura = new Label();
            LabelZ lb_faktura = new LabelZ(600, 50, 180, 10, "Број на фактура:", lbfaktura);
            Controls.Add(lbfaktura);

            TextBoxZ tb_faktura = new TextBoxZ(790, 50, tbfaktura);
            tbfaktura.Text = brf.ToString();               
            Controls.Add(tbfaktura);

            Label lbprikazartikal = new Label();
            LabelZ lbprikaz_artikal = new LabelZ(20, 20, 200, 12, "Приказ артикал: ", lbprikazartikal);
            Controls.Add(lbprikazartikal);

            dgvArtikal.Width = 555;
            dgvArtikal.Height = 140;
            dgvArtikal.Location = new Point(20, 50);
            dgvArtikal.ReadOnly = true;

            dgvArtikal.DataSource = bindingSource;
            conn.Open();
            dataAdapter = new SqlDataAdapter("select id_artikal AS РеденБрој, Ime AS Име, Tezina AS Тежина, Cena AS Цена,Kolicina AS Количина from Artikal ", conn);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            dgvArtikal.DataSource = table;
            Controls.Add(dgvArtikal);
            conn.Close();

            Label lbvnesiredbroj = new Label();
            LabelZ lbvnesi_redbroj = new LabelZ(20, 230, 200, 10, "Внесете реден број: ", lbvnesiredbroj);
            Controls.Add(lbvnesiredbroj);

            TextBoxZ tb_vnesiredbroj = new TextBoxZ(220, 230, tbvnesiredbroj);
            Controls.Add(tbvnesiredbroj);

            Label lbklient = new Label();
            LabelZ lb_klient = new LabelZ(20, 280, 200, 12, "Приказ клиент: ", lbklient);
            Controls.Add(lbklient);

            dgvKlient.Width = 555;
            dgvKlient.Height = 140;
            dgvKlient.Location = new Point(20, 310);
            dgvKlient.ReadOnly = true;

            dgvKlient.DataSource = bindingSource;
            conn.Open();
            dataAdapter = new SqlDataAdapter("select id_klient AS РеденБрој, Ime AS Име, Prezime AS Презиме,Telefon AS Телефон, EMBG AS ЕМБГ,Mail AS Емаил from Klient", conn);
            SqlCommandBuilder command = new SqlCommandBuilder(dataAdapter);
            DataTable tb = new DataTable();
            tb.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(tb);
            dgvKlient.DataSource = tb;
            Controls.Add(dgvKlient);
            conn.Close();

            Label lbrbklient = new Label();
            LabelZ lb_rbklient = new LabelZ(20, 460, 200, 10, "Внесете реден број: ", lbrbklient);
            Controls.Add(lbrbklient);

            TextBoxZ tb_rbKlient = new TextBoxZ(220, 460, tbrbKlient);
            Controls.Add(tbrbKlient);

            Label lbvraboten = new Label();
            LabelZ lb_vraboten = new LabelZ(20, 500, 200, 12, "Приказ Вработен: ", lbvraboten);
            Controls.Add(lbvraboten);

            dgvVraboten.Width = 555;
            dgvVraboten.Height = 140;
            dgvVraboten.Location = new Point(20, 540);
            dgvVraboten.ReadOnly = true;
            dgvVraboten.DataSource = bindingSource;
            
            conn.Open();
            dataAdapter = new SqlDataAdapter("select id_vraboten AS РеденБрој, ime AS Име, prezime AS Презиме,telefon AS Телефон, EMBG AS ЕМБГ,mail AS Емаил from Vraboten", conn);
            SqlCommandBuilder cmd = new  SqlCommandBuilder(dataAdapter);
            DataTable table1 = new DataTable();
            table1.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table1);
            dgvVraboten.DataSource = table1;
            Controls.Add(dgvVraboten);
            conn.Close();

            Label lbredbrVraboten = new Label();
            LabelZ lb_redbrVraboten = new LabelZ(20, 690, 200, 12, "Внесете реден број: ", lbredbrVraboten);
            Controls.Add(lbredbrVraboten);

            TextBoxZ tb_redbrojVraboten = new TextBoxZ(220, 690, tbredbrojVraboten);
            Controls.Add(tbredbrojVraboten);

            Label lbKolicina = new Label();
            LabelZ lb_Kolicina = new LabelZ(20, 730, 200, 12, "Внесете количина: ", lbKolicina);
            Controls.Add(lbKolicina);

            TextBoxZ tb_vnesiKolicina = new TextBoxZ(220, 730, tbvnesiKolicina);
            Controls.Add(tbvnesiKolicina);

            Label lbCena = new Label();
            LabelZ lb_cena = new LabelZ(280, 770, 130, 12, "Приказ Цена: ", lbCena);
            Controls.Add(lbCena);

            TextBoxZ tb_cena = new TextBoxZ(420, 770, tbCena);
            Controls.Add(tbCena);

            ButtonZ btvnesi = new ButtonZ(20, 770, "Внеси", btVnesi);
            btVnesi.Click += new EventHandler(this.fvnesi);
            Controls.Add(btVnesi);

            ButtonZ btizlez = new ButtonZ(130, 770, "Излез", btIzlez);
            btIzlez.Click += new EventHandler(this.fizlez);
            Controls.Add(btIzlez);

            ButtonZ bt_potvrdi = new ButtonZ(75, 800, "Потврди", btpotvrdi);
            btpotvrdi.Click += new EventHandler(this.fpotvrdi);
            Controls.Add(btpotvrdi);

            PictureBox logo = new PictureBox();
            logo.Width = 900;
            logo.Height = 300;
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.Location = new Point(600,300);
            logo.ImageLocation = "C:\\Users\\Mihajlo\\Desktop\\Proekt\\logo.png";
            Controls.Add(logo);

        }
        public void fizlez(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fvnesi(object sender, EventArgs e)
        {
            if (tbvnesiredbroj.Text == "" || tbvnesiKolicina.Text == "" && tbrbKlient.Text == "" || tbredbrojVraboten.Text =="")
            {
                MessageBox.Show("Внесете Артикал,Количина или вработен");
            }
            else
            {
                //select Cena from Artikal where id_artikal=3
                conn.Open();
                string query = "select Cena from Artikal where id_artikal=@redenbroj";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@redenbroj", tbvnesiredbroj.Text);
                //
                int cena = (int)cmd.ExecuteScalar();
                int vcena = cena * Convert.ToInt16(tbvnesiKolicina.Text);
                tbCena.Text = vcena.ToString();
                conn.Close();
            }
        }
        public void fpotvrdi(object sender, EventArgs e)
        {
            conn.Open();
            string query = "insert into Prodazba(id_artikal,id_klient,id_vraboten,Kolicina,Vkupna_cena,br_faktura) values(@artikal,@klient,@vraboten,@kolicina,@vcena,@faktura)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@artikal",tbvnesiredbroj.Text);
            cmd.Parameters.AddWithValue("@klient", tbrbKlient.Text);
            cmd.Parameters.AddWithValue("@vraboten", tbredbrojVraboten.Text);
            cmd.Parameters.AddWithValue("@kolicina", tbvnesiKolicina.Text);
            cmd.Parameters.AddWithValue("@vcena", tbCena.Text);
            cmd.Parameters.AddWithValue("@faktura",tbfaktura.Text);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Цената е потврдена");
        }

    }
}
