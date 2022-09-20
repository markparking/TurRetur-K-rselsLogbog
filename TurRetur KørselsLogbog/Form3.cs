using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TurRetur_KørselsLogbog
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 x = new Form1();
            x.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cs = Helper.CnnVal("KørselLogDB");
            SqlConnection cnn = new SqlConnection(cs);
            cnn.Open();
            DataAccess da = new DataAccess();
            var select = "SELECT * FROM KørselsLog";
            var c = new SqlConnection(Helper.CnnVal("KørselLogDB")); 
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            cnn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cn = Helper.CnnVal("KørselLogDB");
            string query = "INSERT INTO KørselsLog (mID, Km, Dato, Note) VALUES('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.dateTimePicker1.Value.ToString("d-MMM-yyyy hh:mm:ss") + "','" + this.textBox4.Text + "');";
            SqlConnection cnd = new SqlConnection(cn);
            SqlCommand cmd = new SqlCommand(query, cnd);
            SqlDataReader reader;
            try
            {
                cnd.Open();
                reader = cmd.ExecuteReader();
                MessageBox.Show("Ny kørsel oprettet.");
                while (reader.Read()) ;
                cnd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cn = Helper.CnnVal("KørselLogDB");
            string query = "DELETE FROM KørselsLog WHERE kID='" + this.textBox3.Text + "';";
            SqlConnection cnd = new SqlConnection(cn);
            SqlCommand cmd = new SqlCommand(query, cnd);
            SqlDataReader reader;
            try
            {
                cnd.Open();
                reader = cmd.ExecuteReader();
                MessageBox.Show("Kørsel slettet.");
                while (reader.Read()) ;
                cnd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox3.Text = row.Cells["kID"].Value.ToString();
            }
        }
    }
}
