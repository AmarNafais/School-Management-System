using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project__CSE_22._2___034_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cls_connection.Open_connection();
            MySqlCommand cmd = new MySqlCommand("Insert into student Values (@reg_no,@first_name,@last_name,@date_of_birth,@gender,@address,@email,@mobile_phone,@home_phone,@parent_name,@nic,@contact_number)", cls_connection.con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reg_no", txt_reg_no.Text);
            cmd.Parameters.AddWithValue("@first_name", txt_first_name.Text);
            cmd.Parameters.AddWithValue("@last_name", txt_last_name.Text);
            cmd.Parameters.AddWithValue("@date_of_birth", txt_date_of_birth.Text);
            cmd.Parameters.AddWithValue("@gender", txt_gender.Text);
            cmd.Parameters.AddWithValue("@address", txt_address.Text);
            cmd.Parameters.AddWithValue("@email", txt_email.Text);
            cmd.Parameters.AddWithValue("@mobile_phone", txt_mobile_phone.Text);
            cmd.Parameters.AddWithValue("@home_phone", txt_home_phone.Text);
            cmd.Parameters.AddWithValue("@parent_name", txt_parent_name.Text);
            cmd.Parameters.AddWithValue("@nic", txt_nic.Text);
            cmd.Parameters.AddWithValue("@phone", txt_phone.Text);
            cmd.ExecuteNonQuery();
            cls_connection.Close_connection();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cls_connection.Open_connection();
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from student",cls_connection.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "student");
            dataGridView1.DataSource = ds.Tables["student"].DefaultView;
            cls_connection.Close_connection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 frm3 = new Form3();
            frm3.Show();
        }
    }
}
