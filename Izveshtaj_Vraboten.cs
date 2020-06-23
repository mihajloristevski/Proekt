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
    public partial class Izveshtaj_Vraboten : Form
    {
        public Izveshtaj_Vraboten()
        {
            InitializeComponent();
        }
        ComboBox cb = new ComboBox();
        TextBox tb = new TextBox();
        Button bt = new Button();
        Button bt1 = new Button();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6RP8HS4;Initial Catalog=Benziska;Integrated Security=True");
        private DataGridView dgvVraboten = new DataGridView();
        private BindingSource bindingSource = new BindingSource();
        private void Izveshtaj_Vraboten_Load(object sender, EventArgs e)
        {
            this.Width = 640;
            this.Height = 250;
            this.Text = "Извештај Вработен";
            this.BackColor = Color.FromArgb(244, 66, 66);
            this.ControlBox = false;

            ComboBoxZ cbizbor = new ComboBoxZ(50, 20, 100, 40, cb);
            cb.Items.Add("Име");
            cb.Items.Add("Презиме");
            cb.Items.Add("Tелефон");
            cb.Items.Add("EМБГ");
            cb.Items.Add("E-Маил");
            Controls.Add(cb);

            TextBoxZ tbizbor = new TextBoxZ(170, 20, tb);
            Controls.Add(tb);

            ButtonZ btok = new ButtonZ(70, 70, "OK", bt);
            bt.Click += new EventHandler(this.fprikazi);
            Controls.Add(bt);
            
            ButtonZ btizlez = new ButtonZ(170, 70, "Излез", bt1);
            bt1.Click += new EventHandler(this.fizlez);
            Controls.Add(bt1);
        }
        public void fizlez(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fprikazi(object sender, EventArgs e)
        {
            if (cb.SelectedValue == "" || tb.Text == "")
            {
                MessageBox.Show("Внесете податоци");          
            }
            else
            {
            if (cb.SelectedIndex == 0)
            {
                this.Height = 500;
                dgvVraboten.Width = 555;
                dgvVraboten.Height = 140;
                dgvVraboten.Location = new Point(20, 150);
                dgvVraboten.ReadOnly = true;


                dgvVraboten.DataSource = bindingSource;

                conn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select ime,prezime,telefon,EMBG,mail from Vraboten where ime = '" + tb.Text + "'", conn);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dgvVraboten.DataSource = table;
                Controls.Add(dgvVraboten);
                conn.Close();

            }
            if (cb.SelectedIndex == 1)
            {
                this.Height = 500;
                dgvVraboten.Width = 555;
                dgvVraboten.Height = 140;
                dgvVraboten.Location = new Point(20, 150);
                dgvVraboten.ReadOnly = true;


                dgvVraboten.DataSource = bindingSource;

                conn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select ime,prezime,telefon,EMBG,mail from Vraboten where prezime = '" + tb.Text + "'", conn);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dgvVraboten.DataSource = table;
                Controls.Add(dgvVraboten);
                conn.Close();

            }
            if (cb.SelectedIndex == 2)
            {
                this.Height = 500;
                dgvVraboten.Width = 555;
                dgvVraboten.Height = 140;
                dgvVraboten.Location = new Point(20, 150);
                dgvVraboten.ReadOnly = true;


                dgvVraboten.DataSource = bindingSource;

                conn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select ime,prezime,telefon,EMBG,mail from Vraboten where telefon = '" + tb.Text + "'", conn);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dgvVraboten.DataSource = table;
                Controls.Add(dgvVraboten);
                conn.Close();

            }
            if (cb.SelectedIndex == 3)
            {
                this.Height = 500;
                dgvVraboten.Width = 555;
                dgvVraboten.Height = 140;
                dgvVraboten.Location = new Point(20, 150);
                dgvVraboten.ReadOnly = true;


                dgvVraboten.DataSource = bindingSource;

                conn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select ime,prezime,telefon,EMBG,mail from Vraboten where EMBG = '" + tb.Text + "'", conn);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dgvVraboten.DataSource = table;
                Controls.Add(dgvVraboten);
                conn.Close();

            }
            if (cb.SelectedIndex == 4)
            {
                this.Height = 500;
                dgvVraboten.Width = 555;
                dgvVraboten.Height = 140;
                dgvVraboten.Location = new Point(20, 150);
                dgvVraboten.ReadOnly = true;


                dgvVraboten.DataSource = bindingSource;

                conn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select ime,prezime,telefon,EMBG,mail from Vraboten where mail = '" + tb.Text + "'", conn);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dgvVraboten.DataSource = table;
                Controls.Add(dgvVraboten);
                conn.Close();
            }
          }
       }
    }
}
