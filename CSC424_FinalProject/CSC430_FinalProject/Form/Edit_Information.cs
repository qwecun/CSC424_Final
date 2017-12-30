using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using stringValidation;

namespace CSC430_FinalProject
{
    public partial class Edit_Information : Form
    {
        private string custID="";
        string connection = "Server = localhost;Port=3306;Database=fooddelivery; Uid = root; pwd=0850;";
        private string username, password, address, city, state, zipcode, phoneNumber, email, lastName, firstName;

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text.Length != 10)
                label13.Show();
            else
                label13.Hide();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text.Length != 5)
                label12.Show();
            else
                label12.Hide();
        }

        public Edit_Information( string ID)
        {
            InitializeComponent();
            custID = ID;
        }

        private void Edit_Information_Load(object sender, EventArgs e)
        {
            getCustInf();

        }

        private void getCustInf()
        {
            string query = "select * from customer where User_ID= '" + custID+"';";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
           // comboBox1.Text = "";
            while (reader.Read())
            {

                textBox3.Text = reader.GetString("First_Name");
                textBox4.Text = reader.GetString("Last_Name");
                textBox5.Text = reader.GetString("Cust_Email");
                textBox6.Text = reader.GetString("Address");
                textBox7.Text = reader.GetString("City");
                comboBox1.Text = reader.GetString("State");
                textBox9.Text = reader.GetString("Zip");
                textBox10.Text = reader.GetString("Phone_Num");
            }
            con.Close();

            query = "select * from login where User_ID= '" + custID + "';";
            con.Open();
            cmd = new MySqlCommand(query, con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                textBox1.Text = reader.GetString("User_Name");
                textBox2.Text = reader.GetString("User_Password");

            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getCustInf();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //private string username, password, address, city, state, zipcode, phoneNumber, email, lastName, firstName;
            username = textBox1.Text;
            password = textBox2.Text;
            //customer table text
            firstName = textBox3.Text;
            lastName = textBox4.Text;
            email = textBox5.Text;
            address = textBox6.Text;
            city = textBox7.Text;
            state = comboBox1.Text;
            zipcode = textBox9.Text;
            phoneNumber = textBox10.Text;

            if (validate.isPhoneNumLengthValid(phoneNumber) && validate.isUsernameLengthValid(username) && validate.isNameLengthValid(firstName) && validate.isNameLengthValid(lastName) && validate.isZipValid(zipcode))
            {
                string query = "update customer set first_name = '" + firstName + "', last_name ='" + lastName + "', cust_email= '" + email
                + "', address='" + address + "', city='" + city + "', state='" + state + "', zip='" + zipcode
                + "', Phone_Num='" + phoneNumber + "'  where User_ID= '" + custID + "';";
                MySqlConnection con = new MySqlConnection(connection);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                query = "update login set user_password = '" + password + "' where User_ID= '" + custID + "';";
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update Success");

                this.Close();
            }
            else
                MessageBox.Show("Please Re-Enter Your Information!");
        }
    }
}
