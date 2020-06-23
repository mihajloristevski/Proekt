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
    public partial class Vnesi_Kafic : Form
    {
        public Vnesi_Kafic()
        {
            InitializeComponent();
        }
        ComboBox cb_tip = new ComboBox();
        TextBox tbkolicina = new TextBox();
        Button btvnesi = new Button();
        Button btizlez = new Button();
        TextBox tbcena = new TextBox();
        TextBox tb_tezina = new TextBox();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6RP8HS4;Initial Catalog=Benziska;Integrated Security=True");
        private void Vnesi_Kafic_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 400;
            this.Text = "Внеси кафич";
            this.BackColor = Color.FromArgb(255, 66, 66);
            this.ControlBox = false;

            Label lbvnesi_kafe = new Label();
            LabelZ lb_vnesikafe = new LabelZ(150, 20, 190, 14, "Внесете во кафич", lbvnesi_kafe);
            lbvnesi_kafe.Font = new Font("Roboto",14,FontStyle.Underline);
            Controls.Add(lbvnesi_kafe);

            Label lbtip_kafe = new Label();
            LabelZ lb_tikafe = new LabelZ(150, 50, 250, 12,"Изберете вид", lbtip_kafe);
            Controls.Add(lbtip_kafe);

            ComboBoxZ cbtip = new ComboBoxZ(180, 80, 100, 30, cb_tip);
            Controls.Add(cb_tip);

            Label lbkolicina = new Label();
            LabelZ lb_kolicina = new LabelZ(130, 110, 300, 12, "Внесете количина", lbkolicina);
            Controls.Add(lbkolicina);

            TextBoxZ tb_kolicina = new TextBoxZ(130, 140, tbkolicina);
            Controls.Add(tbkolicina);

            Label lb_cenakafe = new Label();
            LabelZ lb_cena_kafe = new LabelZ(120, 170, 300, 12, "Внесете Цена на кафе", lb_cenakafe);
            Controls.Add(lb_cenakafe);

            TextBoxZ tb_cena = new TextBoxZ(130, 200, tbcena);
            Controls.Add(tbcena);

            Label lbtezina = new Label();
            LabelZ lb_tezina = new LabelZ(140, 230, 300, 12, "Внесете Грамажа", lbtezina);
            Controls.Add(lbtezina);

            TextBoxZ tbtezina = new TextBoxZ(130, 270, tb_tezina);
            Controls.Add(tb_tezina);


            ButtonZ bt_vnesi = new ButtonZ(130, 300, "Внеси", btvnesi);
            btvnesi.Click += new EventHandler(this.fvnesi);
            Controls.Add(btvnesi);

            ButtonZ bt_izlez = new ButtonZ(230, 300,"Излез", btizlez);
            btizlez.Click += new EventHandler(this.fizlez);
            Controls.Add(btizlez);

            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT Ime FROM Podklasa WHERE (id_klasa = 2)";
            command.ExecuteNonQuery();
            DataTable tb = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(tb);
            foreach (DataRow dr in tb.Rows)
            {
                cb_tip.Items.Add(dr["Ime"].ToString());
            }
            conn.Close();
        }
        public void fizlez(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fvnesi(object sender, EventArgs e)
        {

            if (tb_tezina.Text == "" || tbcena.Text == "" || tbkolicina.Text == "")
            {
                MessageBox.Show("Немате внесено податоци");
            }
            else
            {
                conn.Open();


                string query = "select id_podklasa from Podklasa where Ime=@tb";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tb", cb_tip.SelectedItem);
                int res;
                res = (int)cmd.ExecuteScalar();
                query = "insert into Artikal(id_podklasa,Ime,Tezina,Cena,Kolicina) values(" + res.ToString() + ",@ime,0,@cena,@kolicina)";
                SqlCommand cmd1 = new SqlCommand(query, conn);
                cmd1.Parameters.AddWithValue("@ime", cb_tip.SelectedItem.ToString());
                cmd1.Parameters.AddWithValue("@cena", tbcena.Text);
                cmd1.Parameters.AddWithValue("@kolicina", tbkolicina.Text);
                cmd1.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Податоците се внесени");
            }
        }
    }
}
