using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proekt
{
    public partial class Pocetnaforma : Form
    {
        public Pocetnaforma()
        {
            InitializeComponent();
        }
        ListBox lb = new ListBox();
        private void Pocetnaforma_Load(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 600;
            this.BackColor = Color.FromArgb(255, 66, 66);
            this.Text ="Почетна форма";
            this.ControlBox = false;


           // MenuStrip menu = new MenuStrip();
           


            MainMenu adminlogin = new MainMenu(); 
           
            MenuItem vnesi = new MenuItem();
            vnesi.Text = "Внеси";
            adminlogin.MenuItems.Add(vnesi);
           

            MenuItem prodavnica = new MenuItem();
            prodavnica.Text = "Продавница";
            prodavnica.Click += new EventHandler(this.fvprodavnica);
            vnesi.MenuItems.Add(prodavnica);


            MenuItem gorivo = new MenuItem();
            gorivo.Text = "Гориво";
            gorivo.Click += new EventHandler(this.fvgorivo);
            vnesi.MenuItems.Add(gorivo);
            

            MenuItem kafic = new MenuItem();
            kafic.Text = "Кафич";
            kafic.Click += new EventHandler(this.fvkafic);
            vnesi.MenuItems.Add(kafic);

            

            MenuItem klient = new MenuItem();
            klient.Text = "Клиент";
            klient.Click += new EventHandler(this.fvklient);
            vnesi.MenuItems.Add(klient);

            MenuItem vraboten = new MenuItem();
            vraboten.Text = "Вработен";
            vraboten.Click += new EventHandler(this.fvvraboten);
            vnesi.MenuItems.Add(vraboten);

            MenuItem izmeni = new MenuItem();
            izmeni.Text = "Измени";
            adminlogin.MenuItems.Add(izmeni);

            MenuItem iVraboten = new MenuItem();
            iVraboten.Text = "Вработен";
            iVraboten.Click += new EventHandler(this.fiVraboten);
            izmeni.MenuItems.Add(iVraboten);

            MenuItem iKlient = new MenuItem();
            iKlient.Text = "Клиент";
            iKlient.Click += new EventHandler(this.fiKlient);
            izmeni.MenuItems.Add(iKlient);

            //MenuItem iIzmeni = new MenuItem();
            //iIzmeni.Text = "Измени";
            //iIzmeni.Click += new EventHandler(this.fizmeni);
            //izmeni.MenuItems.Add(iIzmeni);
            // Da se trgnat site podmeni i vo edna forma da se naprat site izmeni so radiobutton
            /*MenuItem iKlasa = new MenuItem();
            iKlasa.Text = "Класа";
            izmeni.MenuItems.Add(iKlasa);

            MenuItem iPodklasa = new MenuItem();
            iPodklasa.Text = "Подкласа";
            izmeni.MenuItems.Add(iPodklasa);

            MenuItem iArtikal = new MenuItem();
            iArtikal.Text = "Артикал";
            izmeni.MenuItems.Add(iArtikal);

            MenuItem iVraboten = new MenuItem();
            iVraboten.Text = "Вработен";
            izmeni.MenuItems.Add(iVraboten);

            MenuItem iKlient = new MenuItem();
            iKlient.Text = "Клиент";
            izmeni.MenuItems.Add(iKlient);
            */
            MenuItem izbrisi = new MenuItem();
            izbrisi.Text = "Избриши";
            adminlogin.MenuItems.Add(izbrisi);

            MenuItem izProdavnica = new MenuItem();
            izProdavnica.Text = "Продавница";
            izProdavnica.Click += new EventHandler(this.fiprodavnica);
            izbrisi.MenuItems.Add(izProdavnica);

            MenuItem izGorivo = new MenuItem();
            izGorivo.Text = "Гориво";
            izGorivo.Click += new EventHandler(this.figorivo);
            izbrisi.MenuItems.Add(izGorivo);

            MenuItem izKafic = new MenuItem();
            izKafic.Text = "Кафич";
            izKafic.Click += new EventHandler(this.fikafic);
            izbrisi.MenuItems.Add(izKafic);

            MenuItem izvestaj = new MenuItem();
            izvestaj.Text = "Извештај";
            izvestaj.Click += new EventHandler(this.fizvestaj);
            adminlogin.MenuItems.Add(izvestaj);

            MenuItem prodazba = new MenuItem();
            prodazba.Text = "Продажба";
            prodazba.Click += new EventHandler(this.fprodazba);
            adminlogin.MenuItems.Add(prodazba);
            

            MenuItem izlez = new MenuItem();
            izlez.Text = "Излез";
            izlez.Click += new EventHandler(this.fizlez);
            adminlogin.MenuItems.Add(izlez);
            Menu = adminlogin;

            PictureBox gifreklama = new PictureBox();
            gifreklama.Width = 800;
            gifreklama.Height = 600;
            gifreklama.Location = new Point(0, 0);
            gifreklama.SizeMode = PictureBoxSizeMode.StretchImage;
            gifreklama.ImageLocation = "C:\\Users\\Mihajlo\\Desktop\\Proekt\\gifreklama.gif";
            Controls.Add(gifreklama);
             

           /* ListBoxZ lb1 = new ListBoxZ(30, 30, 300, 300, lb);
            lb.Items.Add("Viktor");
            Controls.Add(lb);
            
            RadioButton rb = new RadioButton();
            RadioButtonZ rbopcija1 = new RadioButtonZ(400, 30, 100, 30, "Opcija 1 ", rb);
            Controls.Add(rb);

            CheckBox cb = new CheckBox();
            CheckBoxZ cbopcija1 = new CheckBoxZ(400, 60 , 100, 30, "Opcija 1 " , cb);
            Controls.Add(cb);

            ComboBox combobox = new ComboBox();
            ComboBoxZ box = new ComboBoxZ(30,400,400,100,combobox);
            combobox.Items.Add("Pukanki");
            Controls.Add(combobox);
            */
        }
        public void fizlez(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void fvklient(object sender, EventArgs e)
        {
            Vnesi_klient vk = new Vnesi_klient();
            vk.Show();
        }
        public void fvvraboten(object sender, EventArgs e)
        {
            Vnesi_Vraboten vv = new Vnesi_Vraboten();
            vv.Show();
        }
        public void fvprodavnica(object sender, EventArgs e)
        {
            Vnesi_prodavnica vh = new Vnesi_prodavnica();
            vh.Show();
        }
        public void fvgorivo(object sender, EventArgs e)
        {
            Vnesi_gorivo vg = new Vnesi_gorivo();
            vg.Show();
        }
        public void fvkafic(object sender, EventArgs e)
        {
            Vnesi_Kafic vk = new Vnesi_Kafic();
            vk.Show();
        }
        /*public void fizmeni(object sender, EventArgs e)
        {
            Forma_Izmeni izmeni = new Forma_Izmeni();
            izmeni.Show();
        }
        */
        public void fiprodavnica(object sender, EventArgs e)
        {
            Izbrishi_Prodavnica prodavnica = new Izbrishi_Prodavnica();
            prodavnica.Show();
        }
        public void figorivo(object sender, EventArgs e)
        {
            Izbrishi_Gorivo igorivo = new Izbrishi_Gorivo();
            igorivo.Show();
         }
        public void fikafic(object sender, EventArgs e)
        {
            Izbrishi_Kafic ikafic = new Izbrishi_Kafic();
            ikafic.Show();
        }
        public void fiKlient(object sender, EventArgs e)
        {
            Izmeni_Klient iklient = new Izmeni_Klient();
            iklient.Show();
        }
        public void fiVraboten(object sender, EventArgs e)
        {
            Izmeni_Vraboten ivraboten = new Izmeni_Vraboten();
            ivraboten.Show();
        }
        public void fprodazba(object sender, EventArgs e)
        {
            Prodazba prodazba = new Prodazba();
            prodazba.Show();
        }
        public void fizvestaj(object sender, EventArgs e)
        {
            Izveshtaj iz = new Izveshtaj();
            iz.Show();
        }

    }
}