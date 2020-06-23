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
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace Proekt
{
    public partial class Izveshtaj : Form
    {
        public Izveshtaj()
        {
            InitializeComponent();
        }
        RadioButton rbVraboten = new RadioButton();
        RadioButton rbKlient = new RadioButton();
        RadioButton rbArtikal = new RadioButton();
        Button bt = new Button();
        /*ComboBox cbprikazi = new ComboBox();
        private DataGridView dgvArtikal = new DataGridView();
        private DataGridView dgvKlient = new DataGridView();
        private DataGridView dgvVraboten = new DataGridView();
        private BindingSource bindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();*/
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6RP8HS4;Initial Catalog=Benziska;Integrated Security=True");
        private void Izveshtaj_Load(object sender, EventArgs e)
        {
            this.Width = 640;
            this.Height =350;
            this.Text = "Извештај";
            this.BackColor = Color.FromArgb(244, 66, 66);
            this.ControlBox = false;

            RadioButtonZ rbvraboten = new RadioButtonZ(20, 50, 150, 40, "Вработен", 10, rbVraboten);
            rbVraboten.Click += new EventHandler(this.fprikazi);
            Controls.Add(rbVraboten);

            RadioButtonZ rbklient = new RadioButtonZ(20, 100, 150, 40, "Клиент", 10, rbKlient);
            rbKlient.Click += new EventHandler(this.fprikazi);
            Controls.Add(rbKlient);

            RadioButtonZ rbartikal = new RadioButtonZ(20, 150, 150, 40, "Артикал", 10, rbArtikal);
            rbArtikal.Click += new EventHandler(this.fprikazi);
            Controls.Add(rbArtikal);


            PictureBox logo = new PictureBox();
            logo.Width = 300;
            logo.Height = 150;
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.Location = new Point(300, 50);
            logo.ImageLocation = "C:\\Users\\Mihajlo\\Desktop\\Proekt\\logo.png";
            Controls.Add(logo);

            ButtonZ btizlez = new ButtonZ(20, 200, "Излез", bt);
            bt.Click += new EventHandler(this.fizlez);
            Controls.Add(bt);

            /*ComboBoxZ cb_prikazi = new ComboBoxZ(20, 50, 150, 40, cbprikazi);
            cbprikazi.Items.Add("Vraboten");
            cbprikazi.Items.Add("Klient");
            cbprikazi.Items.Add("Artikal");
            cbprikazi.Click += new EventHandler(this.fprikazi);
            Controls.Add(cbprikazi);

            dgvVraboten.Visible = false;
        }
        public void fprikazi(object sender, EventArgs e)
        {
            if (cbprikazi.SelectedIndex == 1)
            {
                dgvVraboten.Visible = true;

                dgvVraboten.Width = 555;
                dgvVraboten.Height = 140;
                dgvVraboten.Location = new Point(200, 20);
                dgvVraboten.ReadOnly = true;
                dgvVraboten.DataSource = bindingSource;

                conn.Open();
                dataAdapter = new SqlDataAdapter("select id_vraboten AS РеденБрој, ime AS Име, prezime AS Презиме,telefon AS Телефон, EMBG AS ЕМБГ,mail AS Емаил from Vraboten", conn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(dataAdapter);
                DataTable table1 = new DataTable();
                table1.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table1);
                dgvVraboten.DataSource = table1;
                Controls.Add(dgvVraboten);
                conn.Close();
            }
        }*/
        }
        public void fizlez(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fprikazi(object sender, EventArgs e)
        {
            Izveshtaj_Vraboten iv = new Izveshtaj_Vraboten();
            Izveshtaj_Klient ik = new Izveshtaj_Klient();
            Izveshtaj_artikal ia = new Izveshtaj_artikal();
            if (rbVraboten.Checked == true)
            
                iv.Show();
            if (rbArtikal.Checked == true)

                ia.Show();
            
            if (rbKlient.Checked == true)
                
                ik.Show();
        }
    }
}