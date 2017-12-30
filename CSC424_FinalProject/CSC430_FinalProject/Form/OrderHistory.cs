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
    public partial class OrderHistory : Form
    {
        string connection = "Server = localhost;Port=3306;Database=fooddelivery; Uid = root; pwd=0850;";
        private string cust_ID;
        //private string theOrderID;
        public OrderHistory(string UID)
        {
            InitializeComponent();
            cust_ID = UID;
        }

        private void RemoveOrder_Load(object sender, EventArgs e)
        {
            //this.ControlBox = false;
            refreshGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    theOrderID = textBox1.Text;
        //    string query = "DELETE FROM fooddelivery.food_order where Order_ID = '" + theOrderID + "'";
        //    MySqlConnection con = new MySqlConnection(connection);
        //    con.Open();
        //    MySqlCommand comm = new MySqlCommand(query, con);
        //    comm.ExecuteNonQuery();
        //    refreshGrid();
        //    con.Close();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        private void refreshGrid()
        {
            string query = "SELECT * FROM fooddelivery.food_order where User_ID = '" + cust_ID + "'";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            //dataGridView1.DataSource = ds;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }
    }
}
