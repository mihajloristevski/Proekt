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
    public partial class Vnesi_gorivo : Form
    {
        public Vnesi_gorivo()
        {
            InitializeComponent();
        }
        ComboBox cb_tipgorivo = new ComboBox();
        TextBox tbkolicina_gorivo = new TextBox();
        Button btvnesi = new Button();
        Button btizlez = new Button();
        TextBox tb_cenagorivo = new TextBox();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6RP8HS4;Initial Catalog=Benziska;Integrated Security=True");
        private void Vnesi_gorivo_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 350;
            this.Text = "Внеси Гориво";
            this.BackColor = Color.FromArgb(255, 66, 66);
            this.ControlBox = false;

            Label lbvnesi_gorivo = new Label();
            LabelZ lb_vnesigorivo = new LabelZ(150, 20, 200, 14, "Внесете Гориво", lbvnesi_gorivo);
            lbvnesi_gorivo.Font = new Font("Roboto",14,FontStyle.Underline);
            Controls.Add(lbvnesi_gorivo);

            Label lbtip_gorivo = new Label();
            LabelZ lb_tipgorivo = new LabelZ(130, 50, 250, 12,"Внесете тип на гориво", lbtip_gorivo);
            Controls.Add(lbtip_gorivo);

            ComboBoxZ cbtip_gorivo = new ComboBoxZ(180, 80, 100, 30, cb_tipgorivo);
            Controls.Add(cb_tipgorivo);

            Label lbkolicina_gorivo = new Label();
            LabelZ lb_kolicinagorivo = new LabelZ(100, 110, 300, 12, "Внесете количина на гориво", lbkolicina_gorivo);
            Controls.Add(lbkolicina_gorivo);

            TextBoxZ tb_kolicinagorivo = new TextBoxZ(130, 140, tbkolicina_gorivo);
            Controls.Add(tbkolicina_gorivo);

            Label lb_cenagorivo = new Label();
            LabelZ lb_cena_gorivo = new LabelZ(100, 170, 300, 12, "Внесете Цена на гориво", lb_cenagorivo);
            Controls.Add(lb_cenagorivo);

            TextBoxZ tb_cena_gorivo = new TextBoxZ(130, 200, tb_cenagorivo);
            Controls.Add(tb_cenagorivo);

            ButtonZ bt_vnesi = new ButtonZ(130, 240,"Внеси", btvnesi);
            btvnesi.Click += new EventHandler(this.fvnesi);
            Controls.Add(btvnesi);

            ButtonZ bt_izlez = new ButtonZ(230, 240,"Излез", btizlez);
            btizlez.Click += new EventHandler(this.fizlez);
            Controls.Add(btizlez);

            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT Ime FROM Podklasa WHERE (id_klasa = 3)";
            command.ExecuteNonQuery();
            DataTable tb = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(tb);
            foreach (DataRow dr in tb.Rows)
            {
                cb_tipgorivo.Items.Add(dr["Ime"].ToString());
            }
            conn.Close();
        }
        public void fizlez(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fvnesi(object sender, EventArgs e)
        {

            if (tb_cenagorivo.Text == "" || tbkolicina_gorivo.Text == "")
            {
                MessageBox.Show("Имате празни полиња");
            }
            else
            {
                conn.Open();
                string query = "select id_podklasa from Podklasa where Ime=@tb";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tb", cb_tipgorivo.SelectedItem);
                int res;
                res = (int)cmd.ExecuteScalar();
                query = "insert into Artikal(id_podklasa,Ime,Tezina,Cena,Kolicina) values(" + res.ToString() + ",@ime,0,@cena,@kolicina)";
                SqlCommand cmd1 = new SqlCommand(query, conn);
                cmd1.Parameters.AddWithValue("@ime", cb_tipgorivo.SelectedItem.ToString());
                cmd1.Parameters.AddWithValue("@cena", tb_cenagorivo.Text);
                cmd1.Parameters.AddWithValue("@kolicina", tbkolicina_gorivo.Text);
                cmd1.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Податоците се внесени");
            }
        }

       
    }
}
