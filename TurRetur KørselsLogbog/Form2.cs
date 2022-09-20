using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace TurRetur_KørselsLogbog
{
    public partial class Form2 : Form
    {
        public int check = 1;
        public List<Bruger> brugere = new List<Bruger>();
        public Form2()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
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
            var select = "SELECT * FROM Brugere";
            var c = new SqlConnection(Helper.CnnVal("KørselLogDB")); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            cnn.Close();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kørselLogDataSet1.Brugere' table. You can move, or remove it, as needed.
            this.brugereTableAdapter.Fill(this.kørselLogDataSet1.Brugere);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox10.Text = row.Cells["MedarbejderID"].Value.ToString();
                textBox9.Text = row.Cells["Fornavn"].Value.ToString();
                textBox8.Text = row.Cells["Efternavn"].Value.ToString();
                textBox7.Text = row.Cells["NrPlade"].Value.ToString();
                textBox6.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void GemÆndring_Click(object sender, EventArgs e)
        {
            string cn = Helper.CnnVal("KørselLogDB");
            string query = "UPDATE Brugere SET MedarbejderID='" + this.textBox10.Text + "', Fornavn='" + this.textBox9.Text + "', Efternavn='" + this.textBox8.Text + "', NrPlade='" + this.textBox7.Text + "', Email='" + this.textBox6.Text + "'WHERE MedarbejderID='" + this.textBox10.Text+"'; ";
            SqlConnection cnd = new SqlConnection(cn);
            SqlCommand cmd = new SqlCommand(query, cnd);
            SqlDataReader reader;
            try
            {
                cnd.Open();
                reader = cmd.ExecuteReader();
                MessageBox.Show("Bruger opdateret.");
                while (reader.Read()) ;
                cnd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cn = Helper.CnnVal("KørselLogDB");
            string query = "INSERT INTO Brugere (MedarbejderID, Fornavn, Efternavn, NrPlade, Email) VALUES('" +this.textBox1.Text+"','" +this.textBox2.Text+"','" +this.textBox3.Text+"','" +this.textBox4.Text+"','" +this.textBox5.Text+"');";
            SqlConnection cnd = new SqlConnection(cn);
            SqlCommand cmd = new SqlCommand(query, cnd);
            SqlDataReader reader;
            try
            {
                cnd.Open();
                reader = cmd.ExecuteReader();
                MessageBox.Show("Ny bruger oprettet.");
                while (reader.Read()) ;
                cnd.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cn = Helper.CnnVal("KørselLogDB");
            string query = "DELETE FROM Brugere WHERE MedarbejderID='"+ this.textBox10.Text + "';";
            SqlConnection cnd = new SqlConnection(cn);
            SqlCommand cmd = new SqlCommand(query, cnd);
            SqlDataReader reader;
            try
            {
                cnd.Open();
                reader = cmd.ExecuteReader();
                MessageBox.Show("Bruger slettet.");
                while (reader.Read()) ;
                cnd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

