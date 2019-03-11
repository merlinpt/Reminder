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
    public partial class Form4 : Form
    {
        public Form4()
        {
           
            InitializeComponent();
            FillCombobox();
        }
        protected void FillCombobox()
        {
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=reminder_database;Integrated Security=True");

            DataSet ds = new DataSet();

            string Sql = "select * from reminder_dtls";
            try{
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    comboBox1.Items.Add(DR[1]);

                }
            }
            finally
            {
                conn.Close();
            }
        
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=reminder_database;Integrated Security=True");

            string selectSql = "select * from reminder_dtls where R_Name='" + comboBox1.Text + "'";
            SqlCommand com = new SqlCommand(selectSql, conn);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(selectSql, conn);
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        comboBox1.Text = (read["R_Name"].ToString());
                        maskedTextBox2.Text = (read["R_description"].ToString());
                        dateTimePicker1.Text = (read["R_date"].ToString());
                    }
                }
            }
            finally
            {
                conn.Close();
            }


        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=(local);Initial Catalog=reminder_database;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string sql = "UPDATE reminder_dtls SET R_Name = @EventTitle , R_description = @EventDescr, R_date = @EventDate Where R_Name  = '" + comboBox1.Text + "'";


                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@EventTitle", this.comboBox1.Text));

                    cmd.Parameters.Add(new SqlParameter("@EventDescr", this.maskedTextBox2.Text));
                    cmd.Parameters.Add(new SqlParameter("@EventDate", SqlDbType.DateTime));
                    cmd.Parameters["@EventDate"].Value = dateTimePicker1.Value;

                    int rowsInserted = cmd.ExecuteNonQuery();
                    MessageBox.Show("Done!");

                }
                conn.Close();
                this.Close();
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
