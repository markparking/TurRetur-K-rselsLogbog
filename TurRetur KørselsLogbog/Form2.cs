using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurRetur_KørselsLogbog
{
    public partial class Form2 : Form
    {
        List<Bruger> brugere = new List<Bruger>();
        public Form2()
        {
            InitializeComponent();
            BrugereFundet.DataSource = brugere;
            BrugereFundet.DisplayMember = "AlInfo";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 x = new Form1();
            x.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
        }
    }
}
