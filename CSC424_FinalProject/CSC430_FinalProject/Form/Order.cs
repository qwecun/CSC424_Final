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
using System.Net.Mail;
using System.Net;

namespace CSC430_FinalProject
{
    public partial class Order : Form
    {
        string connection = "Server = localhost;Port=3306;Database=fooddelivery; Uid = root; pwd=0850;";
        private List<string> orderList = new List<string>();
        private string cust_ID;
        private string cust_FN;
        private string cust_LN;
        private string cust_EM;
        private string orderID;
        private string foodName;
        private string quantity;
        private int foodCount=1;
        private decimal totalP = 0;

        public Order(string UID, string UFN, string ULN, string UEM)
        {
            InitializeComponent();
            cust_ID = UID;
            cust_FN = UFN;
            cust_LN = ULN;
            cust_EM = UEM;
        }
       

        private void Order_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            getInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0 )
            {
                orderID = "O" + foodCount.ToString();
                foodName = "Burger";
                quantity = numericUpDown1.Value.ToString();
                //burgerC = numericUpDown1.Value;

                MySqlConnection con = new MySqlConnection(connection);
                con.Open();
                string query = "INSERT INTO fooddelivery.food_order(Order_ID, Food_Name, Quantity, User_ID) VALUES (@oid,@food,@quan,@uid)";
                MySqlCommand comm = new MySqlCommand(query, con);
                comm.Parameters.AddWithValue("@oid", orderID);
                comm.Parameters.AddWithValue("@food", foodName);
                comm.Parameters.AddWithValue("@quan", quantity);
                comm.Parameters.AddWithValue("@uid", cust_ID);
                comm.ExecuteNonQuery();
                con.Close();
                foodCount++;
            }
            if (numericUpDown2.Value > 0)
            {
                orderID = "O" + foodCount.ToString();
                foodName = "Chicken Burger";
                quantity = numericUpDown2.Value.ToString();
                //chickenC = numericUpDown1.Value;

                MySqlConnection con = new MySqlConnection(connection);
                con.Open();
                string query = "INSERT INTO fooddelivery.food_order(Order_ID, Food_Name, Quantity, User_ID) VALUES (@oid,@food,@quan,@uid)";
                MySqlCommand comm = new MySqlCommand(query, con);
                comm.Parameters.AddWithValue("@oid", orderID);
                comm.Parameters.AddWithValue("@food", foodName);
                comm.Parameters.AddWithValue("@quan", quantity);
                comm.Parameters.AddWithValue("@uid", cust_ID);
                comm.ExecuteNonQuery();
                con.Close();
                foodCount++;
            }
            if (numericUpDown3.Value > 0)
            {
                getInfo();
                orderID = "O" + foodCount.ToString();
                foodName = "Chicken Nuggets";
                quantity = numericUpDown3.Value.ToString();
                //nuggetC = numericUpDown1.Value;

                MySqlConnection con = new MySqlConnection(connection);
                con.Open();
                string query = "INSERT INTO fooddelivery.food_order(Order_ID, Food_Name, Quantity, User_ID) VALUES (@oid,@food,@quan,@uid)";
                MySqlCommand comm = new MySqlCommand(query, con);
                comm.Parameters.AddWithValue("@oid", orderID);
                comm.Parameters.AddWithValue("@food", foodName);
                comm.Parameters.AddWithValue("@quan", quantity);
                comm.Parameters.AddWithValue("@uid", cust_ID);
                comm.ExecuteNonQuery();
                con.Close();
                foodCount++;
            }
            if (numericUpDown4.Value > 0)
            {
                orderID = "O" + foodCount.ToString();
                foodName = "Milkshake";
                quantity = numericUpDown4.Value.ToString();
                //shakeC = numericUpDown1.Value;

                MySqlConnection con = new MySqlConnection(connection);
                con.Open();
                string query = "INSERT INTO fooddelivery.food_order(Order_ID, Food_Name, Quantity, User_ID) VALUES (@oid,@food,@quan,@uid)";
                MySqlCommand comm = new MySqlCommand(query, con);
                comm.Parameters.AddWithValue("@oid", orderID);
                comm.Parameters.AddWithValue("@food", foodName);
                comm.Parameters.AddWithValue("@quan", quantity);
                comm.Parameters.AddWithValue("@uid", cust_ID);
                comm.ExecuteNonQuery();
                con.Close();
                foodCount++;
            }
            if (numericUpDown5.Value > 0)
            {
                orderID = "O" + foodCount.ToString();
                foodName = "Soda";
                quantity = numericUpDown5.Value.ToString();
                //sodaC = numericUpDown1.Value;

                MySqlConnection con = new MySqlConnection(connection);
                con.Open();
                string query = "INSERT INTO fooddelivery.food_order(Order_ID, Food_Name, Quantity, User_ID) VALUES (@oid,@food,@quan,@uid)";
                MySqlCommand comm = new MySqlCommand(query, con);
                comm.Parameters.AddWithValue("@oid", orderID);
                comm.Parameters.AddWithValue("@food", foodName);
                comm.Parameters.AddWithValue("@quan", quantity);
                comm.Parameters.AddWithValue("@uid", cust_ID);
                comm.ExecuteNonQuery();
                con.Close();
                foodCount++;
            }
            if (numericUpDown6.Value > 0)
            {
                orderID = "O" + foodCount.ToString();
                foodName = "Orange Juice";
                quantity = numericUpDown6.Value.ToString();
                //juiceC = numericUpDown1.Value;

                MySqlConnection con = new MySqlConnection(connection);
                con.Open();
                string query = "INSERT INTO fooddelivery.food_order(Order_ID, Food_Name, Quantity, User_ID) VALUES (@oid,@food,@quan,@uid)";
                MySqlCommand comm = new MySqlCommand(query, con);
                comm.Parameters.AddWithValue("@oid", orderID);
                comm.Parameters.AddWithValue("@food", foodName);
                comm.Parameters.AddWithValue("@quan", quantity);
                comm.Parameters.AddWithValue("@uid", cust_ID);
                comm.ExecuteNonQuery();
                con.Close();
                foodCount++;
            }
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "trdeliveryservice@gmail.com";
            string password = "trdelivery123";
            string emailTo = cust_EM;
            string subject = "Hero Food Delivery Service";
            string body = ("Hello " + cust_FN +" " + cust_LN + ",<br /> Thank you for ordering at TR Food Delivery Service. Your order will be arriving within 30 minutes!");
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                // Can set to false, if you are sending pure text.
                //mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
                //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
            this.Close();
            MessageBox.Show("Order Recieved!");
        }

        private void getInfo()
        {
            foodCount = 1;
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            string query = "SELECT Order_ID FROM food_order";
            using (MySqlCommand command = new MySqlCommand(query, con))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orderList.Add(reader.GetString(0));
                        foodCount++;
                    }
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            getUpdate();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            getUpdate();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            getUpdate();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            getUpdate();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            getUpdate();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            getUpdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getUpdate()
        {
            totalP = ((numericUpDown1.Value * Convert.ToDecimal(1.50)) + (numericUpDown2.Value * Convert.ToDecimal(2.00)) +
                (numericUpDown3.Value * Convert.ToDecimal(1.25)) + (numericUpDown4.Value * Convert.ToDecimal(2.25)) +
                (numericUpDown5.Value * Convert.ToDecimal(1.25)) + (numericUpDown6.Value * Convert.ToDecimal(1.50)));
            label4.Text = ("$" + totalP.ToString());
        }
    }
}
