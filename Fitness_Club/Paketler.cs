using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_Club
{
    public partial class Paketler : Form
    {
        public Paketler()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            this.Close();
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
        }

        private void Paketler_Load(object sender, EventArgs e)
        {

        }
    }
}
