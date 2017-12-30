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

    public partial class Register : Form
    {
        string connection = "Server = localhost;Port=3306;Database=fooddelivery; Uid = root; pwd=0850;";
        private List<string> usernameList = new List<string>();
        private List<string> passwordList = new List<string>();
        private List<string> userIDList = new List<string>();
        private List<string> phoneNumberList = new List<string>();
        private List<string> addressList = new List<string>();
        private List<string> cityList = new List<string>();
        private List<string> stateList = new List<string>();
        private List<string> zipList = new List<string>();
        private List<string> emailList = new List<string>();
        private List<string> lastNameList = new List<string>();
        private List<string> firstNameList = new List<string>();
        private string username, password, address, city, state, zipcode, phoneNumber, email, lastName, firstName;

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text.Length != 10) 
                label13.Show();
            else
                label13.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {

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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text.Length != 5)
                label12.Show();
            else
                label12.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 6)
                label11.Show();
            else
                label11.Hide();
        }

        private string userID;
        private int count = 1;

        private void Register_Load(object sender, EventArgs e)
        {
            getInfo();
        }

        public Register()
        {
            InitializeComponent();
            //textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //login table text
            username = textBox1.Text;
            password = textBox2.Text;
            userID = "U" + count.ToString();

            //customer table text
            firstName = textBox3.Text;
            lastName = textBox4.Text;
            email = textBox5.Text;
            address = textBox6.Text;
            city = textBox7.Text;
            state = comboBox1.Text;
            zipcode = textBox9.Text;
            phoneNumber = textBox10.Text;
            if (validate.isPhoneNumLengthValid(phoneNumber) && validate.isUsernameLengthValid(username) && validate.isNameLengthValid(firstName) && validate.isNameLengthValid(lastName) && validate.isZipValid(zipcode)) {
                //login table insert functions
                MySqlConnection con = new MySqlConnection(connection);
                con.Open();
                string query = "INSERT INTO fooddelivery.login(User_ID, User_name, User_password) VALUES (@uid,@user,@pass)";
                MySqlCommand comm = new MySqlCommand(query, con);
                comm.Parameters.AddWithValue("@uid", userID);
                comm.Parameters.AddWithValue("@user", username);
                comm.Parameters.AddWithValue("@pass", password);
                comm.ExecuteNonQuery();
                count++;

                //customer info table insert functions
                string query2 = "INSERT INTO fooddelivery.customer(User_ID, First_Name, Last_Name, Cust_Email,Address,City,State,Zip,Phone_Num) VALUES (@uid,@fname,@lname,@mail,@uaddress,@ucity,@ustate,@uzip,@uphone)";
                MySqlCommand comm1 = new MySqlCommand(query2, con);
                comm1.Parameters.AddWithValue("@uid", userID);
                comm1.Parameters.AddWithValue("@fname", firstName);
                comm1.Parameters.AddWithValue("@lname", lastName);
                comm1.Parameters.AddWithValue("@mail", email);
                comm1.Parameters.AddWithValue("@uaddress", address);
                comm1.Parameters.AddWithValue("@ucity", city);
                comm1.Parameters.AddWithValue("@ustate", state);
                comm1.Parameters.AddWithValue("@uzip", zipcode);
                comm1.Parameters.AddWithValue("@uphone", phoneNumber);
                comm1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Account Registered!");
                this.Close();
            }
            else
                MessageBox.Show("Please Re-Enter Your Information!");
        }

        private void getInfo()
        {
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            string query = "SELECT User_name FROM login";
            using (MySqlCommand command = new MySqlCommand(query, con))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usernameList.Add(reader.GetString(0));
                        count++;
                    }
                }
            }

            query = "SELECT User_password FROM login";
            using (MySqlCommand command = new MySqlCommand(query, con))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        passwordList.Add(reader.GetString(0));
                    }
                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }
    }
}

