using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Araba_Oyunu
{
    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
        }
        int seritsayisi = 1, mesafe = 0, hizlanma = 70;
        Random R = new Random();
        bool seritharaket = false;
        class randomCar
        {
            public bool fakehavecar = false;
            public PictureBox fakecar;
            public bool vakit = false;
        }
        randomCar[] rndcar = new randomCar[2];

        //araba çağırma
        void bringerandomcar(PictureBox pb)
        {
            int rnd = R.Next(0, 4);
            switch (rnd)
            {
                case 0:
                    pb.Image = Properties.Resources.car1;
                    break;

                case 1:
                    pb.Image = Properties.Resources.car2;
                    break;

                case 2:
                    pb.Image = Properties.Resources.car3;
                    break;

                case 3:
                    pb.Image = Properties.Resources.car4;
                    break;
            }
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        //araç konum
        private void aracyerine()
        {
            if (seritsayisi == 1)
            {
                redcar.Location = new Point(210, 338);
            }
            else if (seritsayisi == 0)
            {
                redcar.Location = new Point(40, 338);
            }
            else if (seritsayisi == 2)
            {
                redcar.Location = new Point(370, 338);
            }
        }
        //yüksek skor ve arabalar
        private void Form1_Load(object sender, EventArgs e)
        {
            for (var i = 0; i < rndcar.Length; i++)
            {
                rndcar[i] = new randomCar();
            }
            rndcar[0].vakit = true;
            aracyerine();
            skorm.Text = Settings1.Default.highskor.ToString() + " M";
        }
        //araba haraketleri ve düzenleri
        private void timerrandomcar_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < rndcar.Length; i++)
            {
                if (!rndcar[i].fakehavecar && rndcar[i].vakit)
                {
                    rndcar[i].fakecar = new PictureBox();
                    bringerandomcar(rndcar[i].fakecar);
                    rndcar[i].fakecar.Size = new Size(70, 100);
                    rndcar[i].fakecar.Top = -rndcar[i].fakecar.Height;
                    int seriteyerlestir = R.Next(0, 3);
                    if (seriteyerlestir == 0)
                    {
                        rndcar[i].fakecar.Left = 40;
                    }
                    else if (seriteyerlestir == 1)
                    {
                        rndcar[i].fakecar.Left = 210;
                    }
                    else if (seriteyerlestir == 2)
                    {
                        rndcar[i].fakecar.Left = 370;
                    }
                    this.Controls.Add(rndcar[i].fakecar);
                    rndcar[i].fakehavecar = true;
                }
                else
                {
                    if (rndcar[i].vakit)
                    {
                        rndcar[i].fakecar.Top += 20;
                        if (rndcar[i].fakecar.Top >= 154)
                        {
                            for (int j = 0; j < rndcar.Length; j++)
                            {
                                if (!rndcar[j].vakit)
                                {
                                    rndcar[j].vakit = true;
                                    break;
                                }
                            }
                        }
                        if (rndcar[i].fakecar.Top >= this.Height - 20)
                        {
                            rndcar[i].fakecar.Dispose();
                            rndcar[i].fakehavecar = false;
                            rndcar[i].vakit = false;
                        }
                    }

                }
                //kaza
                if (rndcar[i].vakit)
                {
                    float mutlakX = Math.Abs((redcar.Left + (redcar.Width / 2)) - (rndcar[i].fakecar.Left + (rndcar[i].fakecar.Width / 2)));
                    float mutlakY = Math.Abs((redcar.Top + (redcar.Height / 2)) - (rndcar[i].fakecar.Top + (rndcar[i].fakecar.Height / 2)));
                    float farkgenislik = (redcar.Width / 2) + (rndcar[i].fakecar.Width / 2);
                    float farkyuykseklik = (redcar.Height / 2) + (rndcar[i].fakecar.Height / 2);
                    if ((farkgenislik > mutlakX) && (farkyuykseklik > mutlakY))
                    {
                        timerrandomcar.Enabled = false;
                        timerserit.Enabled = false;
                        if (mesafe > Settings1.Default.highskor)
                        {
                            MessageBox.Show("Yeni Yüksek Skor ==> " + mesafe.ToString() + " M", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Settings1.Default.highskor = mesafe;
                            Settings1.Default.Save();
                        }
                        DialogResult dr = MessageBox.Show("Kaza Yaptınız!! Tekrar Oynamak İstermisiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            aracyerine();
                            for (int j = 0; j < rndcar.Length; j++)
                            {
                                rndcar[j].fakecar.Dispose();
                                rndcar[j].fakehavecar = false;
                                rndcar[j].vakit = false;
                            }
                            mesafe = 0;
                            hizlanma = 70;
                            rndcar[0].vakit = true;
                            timerrandomcar.Enabled = true;
                            timerrandomcar.Interval = 200;
                            timerserit.Enabled = true;
                            timerrandomcar.Interval = 200;
                            skorm.Text = Settings1.Default.highskor.ToString() + " M";
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
            }
        }
        //kontroller
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (seritsayisi < 2)
                    seritsayisi++;
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (seritsayisi > 0)
                    seritsayisi--;
            }
            aracyerine();
        }
        //oyun kapatma
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerserit.Enabled = false;
            timerrandomcar.Enabled = false;
            DialogResult dr = MessageBox.Show("Oyundan Çıkmak Üzeresin!", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
                timerserit.Enabled = true;
                timerrandomcar.Enabled = true;
            }
        }
        //oyun durdurma
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timerserit.Enabled = false;
            timerrandomcar.Enabled = false;
            form2 = new Form2();
            form2.Show();
        }
        //hızlanma ayarlama
        void hizlevel()
        {
            //2.seviye
            if (mesafe > 150 && mesafe < 300)
            {
                hizlanma = 100;
                timerserit.Interval = 125;
                timerrandomcar.Interval = 100;
            }
            //3.seviye
            else if (mesafe > 300 && mesafe < 550)
            {
                hizlanma = 130;
                timerserit.Interval = 100;
                timerrandomcar.Interval = 80;
            }
            //4.seviye
            else if (mesafe > 550)
            {
                hizlanma = 170;
                timerserit.Interval = 80;
                timerrandomcar.Interval = 20;
            }
        }
        //serit haraketleri
        private void timerserit_Tick(object sender, EventArgs e)
        {
            mesafe++;
            hizlevel();
            if (seritharaket == false)
            {
                for (int i = 1; i <= 6; i++)
                {
                    this.Controls.Find("seritsol" + i.ToString(), true)[0].Top -= 25;
                    this.Controls.Find("seritsag" + i.ToString(), true)[0].Top -= 25;
                    seritharaket = true;
                }
            }
            else
            {
                for (int i = 1; i <= 6; i++)
                {
                    this.Controls.Find("seritsol" + i.ToString(), true)[0].Top += 25;
                    this.Controls.Find("seritsag" + i.ToString(), true)[0].Top += 25;
                    seritharaket = false;
                }
            }
            m.Text = mesafe.ToString() + "M";
            km.Text = hizlanma.ToString() + "Km/s";
        }
    }
}