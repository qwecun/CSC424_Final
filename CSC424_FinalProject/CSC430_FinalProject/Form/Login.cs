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

namespace CSC430_FinalProject
{
    public partial class Login : Form
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
        private string username, password;
        private string loginUserID, userFName, userLName, userEM;
        private int count = 1;

        public Login()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            getInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getInfo();
            username = textBox1.Text;
            password = textBox2.Text;
            for (int i = 0; i < count-1; i++)
            {
                if (usernameList[i] == username)
                {
                    loginUserID = userIDList[i];
                    userFName = firstNameList[i];
                    userLName = lastNameList[i];
                    userEM = emailList[i];
                }
            }
            if (usernameList.Exists(x => x == username) && passwordList.Exists(y => y == password))
            {
                textBox1.Clear();
                textBox2.Clear();
                Selection select = new Selection(loginUserID,userFName,userLName,userEM);
                select.Show();
                //Order menu = new Order(loginUserID);
               // menu.Show();
            }
            else
                MessageBox.Show("Please Check Your Login Information Again!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register regis = new Register();
            regis.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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

            query = "SELECT User_ID FROM login";
            using (MySqlCommand command = new MySqlCommand(query, con))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userIDList.Add(reader.GetString(0));
                    }
                }
            }

            query = "SELECT First_Name FROM customer";
            using (MySqlCommand command = new MySqlCommand(query, con))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        firstNameList.Add(reader.GetString(0));
                    }
                }
            }

            query = "SELECT Last_Name FROM customer";
            using (MySqlCommand command = new MySqlCommand(query, con))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lastNameList.Add(reader.GetString(0));
                    }
                }
            }

            query = "SELECT Cust_Email FROM customer";
            using (MySqlCommand command = new MySqlCommand(query, con))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        emailList.Add(reader.GetString(0));
                    }
                }
            }
            con.Close();
        }

    }
}
