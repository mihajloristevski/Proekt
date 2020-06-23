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
    public partial class Izbrishi_Gorivo : Form
    {
        public Izbrishi_Gorivo()
        {
            InitializeComponent();
        }
        TextBox tbredbroj = new TextBox();
        Button btok = new Button();
        Button btizlez = new Button();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6RP8HS4;Initial Catalog=Benziska;Integrated Security=True");
        private DataGridView dgvArtikal = new DataGridView();
        private BindingSource bindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private void Izbrishi_Gorivo_Load(object sender, EventArgs e)
        {
            this.Width = 640;
            this.Height = 600;
            this.BackColor = Color.FromArgb(244, 66, 66);
            this.Text = "Избриши Гориво";
            this.ControlBox = false;

            Label lbprikaz = new Label();
            LabelZ lbprikazi = new LabelZ(50, 50, 350, 12, "Приказ на податоци во Гориво:", lbprikaz);
            Controls.Add(lbprikaz);

            Label lbbrishi = new Label();
            LabelZ lbizbrishi = new LabelZ(50, 400, 300, 12, "Внесете реден број за бришење:", lbbrishi);
            Controls.Add(lbbrishi);

            TextBoxZ tb_redbroj = new TextBoxZ(360, 400, tbredbroj);
            Controls.Add(tbredbroj);

            ButtonZ bt_ok = new ButtonZ(300, 460, "OK", btok);
            btok.Click += new EventHandler(this.fizbrisi);
            Controls.Add(btok);

            ButtonZ bt_izlez = new ButtonZ(400, 460, "Излез", btizlez);
            btizlez.Click += new EventHandler(this.fizlez);
            Controls.Add(btizlez);
        
            dgvArtikal.Width = 550;
            dgvArtikal.Height = 200;
            dgvArtikal.Location = new Point(50, 90);

            dgvArtikal.DataSource = bindingSource;
            conn.Open();
            dataAdapter = new SqlDataAdapter("select id_artikal AS РеденБрој, Ime AS Име, Tezina AS Тежина, Cena AS Цена,Kolicina AS Количина from Artikal where (id_podklasa between 4 and 6)", conn);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            dgvArtikal.DataSource = table;
            Controls.Add(dgvArtikal);
            conn.Close();
            
        }
        public void fizlez(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fizbrisi(object sender, EventArgs e)
        {
            conn.Open();
            string query = "delete from Artikal where id_artikal=@redbroj";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@redbroj", tbredbroj.Text);
            cmd.ExecuteNonQuery();
            conn.Close();

            dataAdapter = new SqlDataAdapter("select id_artikal AS РеденБрој, Ime AS Име, Tezina AS Тежина, Cena AS Цена,Kolicina AS Количина from Artikal where (id_podklasa between 4 and 6)", conn);
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            dgvArtikal.DataSource = table;
            Controls.Add(dgvArtikal);
            conn.Close();
            if (tbredbroj.Text == "")
            {
                MessageBox.Show("Грешка");
            }
            else
            {
                tbredbroj.Text = "";
                MessageBox.Show("Успешно се избришани податоците");
            }
        }
    }
}
