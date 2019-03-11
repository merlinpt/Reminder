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
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        public Form2()
        {
            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       


                con = new SqlConnection("Data Source=(local);Initial Catalog=reminder_database;Integrated Security=True");

                try
                {

                    con.Open();
                    string query = "INSERT INTO reminder_dtls(R_Name,R_description,R_date)";
                    query += "VALUES(@EventTitle, @EventDescr,@EventDate)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@EventTitle", this.maskedTextBox1.Text);
                    cmd.Parameters.AddWithValue("@EventDescr", this.maskedTextBox2.Text);
                    cmd.Parameters.AddWithValue("@EventDate", this.dateTimePicker1.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("inserted");
                }
                finally
                {
                    con.Close();
                }



            }

        private void Form2_Load(object sender, EventArgs e)
        {
            TimeSpan TodayTime = DateTime.Now.TimeOfDay; 
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM dd yyyy hh:mm";
        }
    }
    }

