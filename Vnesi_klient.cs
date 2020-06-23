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
    public partial class Vnesi_klient : Form
    {
        public Vnesi_klient()
        {
            InitializeComponent();
        }
        TextBox tb = new TextBox();
        TextBox tb1 = new TextBox();
        TextBox tb2 = new TextBox();
        TextBox tb3 = new TextBox();
        TextBox tb4 = new TextBox();
        TextBox tb5 = new TextBox();
        Button bt = new Button();
        Button bt1 = new Button();
        Label lb6 = new Label();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6RP8HS4;Initial Catalog=Benziska;Integrated Security=True");
        private void Vnesi_klient_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 500;
            this.BackColor = Color.FromArgb(255, 66, 66);
            this.Text = "Внесување нов клиент";
            this.ControlBox=false;

            Label lbn = new Label();
            LabelZ lbnaslove = new LabelZ(100,20,280,14,"Внесување на нов Клиент",lbn);
            lbn.Font = new Font("Roboto",14,FontStyle.Underline);
            Controls.Add(lbn);

            Label lb1 = new Label();
            LabelZ lbIme = new LabelZ(20,70,180,12,"Внесете Име",lb1);
            Controls.Add(lb1);

            TextBoxZ tbIme = new TextBoxZ(210,70,tb1);
            Controls.Add(tb1);

            Label lb2 = new Label();
            LabelZ lbPrezime = new LabelZ(20,120,180,12,"Внесете Презиме",lb2);
            Controls.Add(lb2);

            TextBoxZ tbPrezime = new TextBoxZ(210,120,tb2);
            Controls.Add(tb2);

            

            Label lb3 = new Label();
            LabelZ lbTelefon = new LabelZ(20,170,180,12,"Внесете Телефон",lb3);
            Controls.Add(lb3);

            TextBoxZ tbTelefon = new TextBoxZ(210,170,tb3);
            Controls.Add(tb3);

            Label lb4 = new Label();
            LabelZ lbembg = new LabelZ(20,220,180,12,"ЕМБГ",lb4);
            Controls.Add(lb4);

            TextBoxZ tbembg = new TextBoxZ(210,220,tb4);
            Controls.Add(tb4);

            Label lb5 = new Label();
            LabelZ lbemail = new LabelZ(20, 270,180,12,"Внесете Е-маил",lb5);
            Controls.Add(lb5);

            TextBoxZ tbe_email = new TextBoxZ(210, 270,tb5);
            Controls.Add(tb5);

            ButtonZ btVnesi = new ButtonZ(170,320,"Внеси",bt);
            bt.Font = new Font("Roboto", 10, FontStyle.Regular);
            bt.Click += new EventHandler(this.fvnesi);
            Controls.Add(bt);

            ButtonZ btizlez = new ButtonZ(280, 320, "Излез", bt1);
            bt1.Font = new Font("Roboto", 10, FontStyle.Regular);
            bt1.Click += new EventHandler(this.fizlez);
            Controls.Add(bt1);

            
            LabelZ lbprikazi = new LabelZ(20,370,350,12,"Податоците за клиентот се внесени",lb6);
            lb6.ForeColor = Color.Black;
            lb6.Hide();
            Controls.Add(lb6);

        }
        public void fvnesi(object sender, EventArgs e)
        {
            if (tb1.Text == "" || tb.Text == "" || tb2.Text == "" || tb3.Text == "" || tb4.Text == "" || tb5.Text == "")
            {
                MessageBox.Show("Имате празни Полиња");
            }
            else
            {
                conn.Open();
                string query = "insert into Klient(Ime,Prezime,Telefon,EMBG,Mail) values (@tb1,@tb2,@tb3,@tb4,@tb5)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tb1", tb1.Text);
                cmd.Parameters.AddWithValue("@tb2", tb2.Text);
                cmd.Parameters.AddWithValue("@tb3", tb3.Text);
                cmd.Parameters.AddWithValue("@tb4", tb4.Text);
                cmd.Parameters.AddWithValue("@tb5", tb5.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Податоците се внесени");
                lb6.Show();
                tb1.Text = "";
                tb2.Text = "";
                tb3.Text = "";
                tb4.Text = "";
                tb5.Text = "";
            }
            //if(tb1.Text != "" || tb2.Text != "" )
         
            
        }
        public void fizlez(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
