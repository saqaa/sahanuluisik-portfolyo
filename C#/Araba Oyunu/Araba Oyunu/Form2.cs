using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Araba_Oyunu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void oyundevam_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void bastanbasla_Click(object sender, EventArgs e)
        {
            
        }

        private void oyundancik_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
