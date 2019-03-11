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

namespace Reminder
{
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 settingsForm = new Form4();
            settingsForm.Show();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
                
                dataGridView1.Refresh();
                dataGridView1.DataSource = GetReminderDetails();
           
            
        }
        private DataTable GetReminderDetails()
        {
            con = new SqlConnection("Data Source=(local);Initial Catalog=reminder_database;Integrated Security=True");
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM reminder_dtls ", con);



            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
