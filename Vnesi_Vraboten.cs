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
    public partial class Vnesi_Vraboten : Form
    {
        public Vnesi_Vraboten()
        {
            InitializeComponent();
        }
         TextBox tb = new TextBox();
        TextBox tb1 = new TextBox();
        TextBox tb2 = new TextBox();
        TextBox tb3 = new TextBox();
        TextBox tb4 = new TextBox();
        TextBox tb5 = new TextBox();
        TextBox tb6 = new TextBox();
        Button bt = new Button();
        Button bt1 = new Button();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6RP8HS4;Initial Catalog=Benziska;Integrated Security=True");
        private void Vnesi_Vraboten_Load(object sender, EventArgs e)
        {
           
       
            this.Width = 500;
            this.Height = 500;
            this.Text = "Внеси Вработен";
            this.BackColor = Color.FromArgb(255, 66, 66);
            this.Text = "Внесување нов вработен";
            this.ControlBox = false;


            Label lbn = new Label();
            LabelZ lbnaslove = new LabelZ(100,20,280,14,"Внесување на нов Вработен",lbn);
            lbn.Font = new Font("Roboto",14,FontStyle.Underline);
            Controls.Add(lbn);



            Label lb = new Label();
            LabelZ lbkorisnicko_ime = new LabelZ(20,70,180,12,"Корисничко име",lb);
            Controls.Add(lb);

            TextBoxZ tbkorisnicko_ime = new TextBoxZ(210,70,tb);
            Controls.Add(tb);

            Label lb1 = new Label();
            LabelZ lbIme = new LabelZ(20,120,180,12,"Внесете Име",lb1);
            Controls.Add(lb1);

            TextBoxZ tbIme = new TextBoxZ(210,120,tb1);
            Controls.Add(tb1);

            Label lb2 = new Label();
            LabelZ lbPrezime = new LabelZ(20,170,180,12,"Внесете Презиме",lb2);
            Controls.Add(lb2);

            TextBoxZ tbPrezime = new TextBoxZ(210,170,tb2);
            Controls.Add(tb2);

            Label lb3 = new Label();
            LabelZ lbLozinka = new LabelZ(20,220,180,12,"Внесете Лозинка",lb3);
            Controls.Add(lb3);

            TextBoxZ tbLozinka = new TextBoxZ(210,220,tb3);
            Controls.Add(tb3);

            Label lb4 = new Label();
            LabelZ lbTelefon = new LabelZ(20,270,180,12,"Внесете Телефон",lb4);
            Controls.Add(lb4);

            TextBoxZ tbTelefon = new TextBoxZ(210,270,tb4);
            Controls.Add(tb4);

            Label lb5 = new Label();
            LabelZ lbembg = new LabelZ(20,320,180,12,"ЕМБГ",lb5);
            Controls.Add(lb5);

            TextBoxZ tbembg = new TextBoxZ(210,320,tb5);
            Controls.Add(tb5);

            Label lb6 = new Label();
            LabelZ lbemail = new LabelZ(20, 370,180,12,"Внесете Е-маил",lb6);
            Controls.Add(lb6);

            TextBoxZ tbe_email = new TextBoxZ(210, 370,tb6);
            Controls.Add(tb6);

            ButtonZ btVnesi = new ButtonZ(50,420,"Внеси",bt);
            bt.Font = new Font("Roboto", 8, FontStyle.Regular);
            bt.Click += new EventHandler(this.fvnesi);
            Controls.Add(bt);

            ButtonZ btIzlez = new ButtonZ(170, 420, "Излез", bt1);
            bt1.Click += new EventHandler(this.fizlez);
            Controls.Add(bt1);

        }
        public void fvnesi(object sender, EventArgs e)
        {
            if (tb.Text == "" || tb1.Text == "" || tb2.Text == "" || tb3.Text == "" || tb4.Text == "" || tb5.Text == "" || tb6.Text == "")
            {
                MessageBox.Show("Имате празни полиња");
            }
            else
            {
                conn.Open();
                string query = "insert into Vraboten(korisnicko_ime,ime,prezime,lozinka,telefon,EMBG,mail) values (@tb,@tb1,@tb2,@tb3,@tb4,@tb5,@tb6)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tb", tb.Text);
                cmd.Parameters.AddWithValue("@tb1", tb1.Text);
                cmd.Parameters.AddWithValue("@tb2", tb2.Text);
                cmd.Parameters.AddWithValue("@tb3", tb3.Text);
                cmd.Parameters.AddWithValue("@tb4", tb4.Text);
                cmd.Parameters.AddWithValue("@tb5", tb5.Text);
                cmd.Parameters.AddWithValue("@tb6", tb6.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Податоците се внесени");

                tb.Text = "";
                tb1.Text = "";
                tb2.Text = "";
                tb3.Text = "";
                tb4.Text = "";
                tb5.Text = "";
                tb6.Text = "";
            }
        }
        public void fizlez(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

      
