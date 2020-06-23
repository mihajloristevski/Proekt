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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button bt = new Button();
        TextBox tb = new TextBox();
        TextBox tb1 = new TextBox();
        SqlConnection conn = new SqlConnection(" Data Source=DESKTOP-6RP8HS4;Initial Catalog=Benziska;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 640;
            this.Height = 600;
            this.BackColor = Color.FromArgb(244, 66, 66);
            this.Text = "Логин Форма";
            
             TextBoxZ tbusername = new TextBoxZ(200,200, tb);
             tb.KeyDown += new KeyEventHandler(this.enter);
            Controls.Add(tb);

            TextBoxX tbpassword = new TextBoxX(200, 260,tb1);
            tb1.KeyDown += new KeyEventHandler(this.enter);
            Controls.Add(tb1);

            ButtonZ btlogin = new ButtonZ(250,290,"Логирајсе",bt);
            bt.Click += new EventHandler(this.click);
            Controls.Add(bt);

            Label lb = new Label();
            LabelZ lbkorisnik = new LabelZ(250, 180,150,10 ,"Корисничко име", lb);
            lb.Font = new Font("Roboto", 10, FontStyle.Regular);
            Controls.Add(lb);

            Label lb1 = new Label();
            LabelZ lblozinka = new LabelZ(270, 240,150,10 ,"Лозинка", lb1);
            lb1.Font = new Font("Roboto", 10, FontStyle.Regular);
            Controls.Add(lb1);

            PictureBox logo = new PictureBox();
            logo.Width = 300;
            logo.Height = 100;
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.Location = new Point(150, 40);
            logo.ImageLocation = "C:\\Users\\Mihajlo\\Desktop\\Proekt\\logo.png";
            Controls.Add(logo);
            
            
        }
        public void enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select COUNT(*) from Vraboten where Korisnicko_ime=@tb and Lozinka=@tb1", conn);
                cmd.Parameters.AddWithValue("@tb", tb.Text);
                cmd.Parameters.AddWithValue("@tb1", tb1.Text);
                int res;
                res = (int)cmd.ExecuteScalar();
                conn.Close();

                if (res == 1)
                {
                    Pocetnaforma pf = new Pocetnaforma();
                    pf.Show();
                    this.Hide();
                }
                else
                {
                    tb.Text = "";
                    tb1.Text = "";
                    MessageBox.Show("Грешка при логирање");
                }
            }
        }
        public void click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from Vraboten where Korisnicko_ime=@tb and Lozinka=@tb1", conn);
            cmd.Parameters.AddWithValue("@tb", tb.Text);
            cmd.Parameters.AddWithValue("@tb1", tb1.Text);
            int res;
            res = (int)cmd.ExecuteScalar();
            conn.Close();

            if (res == 1)
            {
                Pocetnaforma pf = new Pocetnaforma();
                pf.Show();
                this.Hide();
            }
            else
            {
                tb.Text = "";
                tb1.Text = "";
                MessageBox.Show("Грешка при логирање");
            }
        }
    }
}
