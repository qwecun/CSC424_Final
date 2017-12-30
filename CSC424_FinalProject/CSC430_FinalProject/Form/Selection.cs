using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC430_FinalProject
{
    public partial class Selection : Form
    {
        private string cust_ID;
        private string cust_FN;
        private string cust_LN;
        private string cust_EM;
        public Selection(string UID, string UFN, string ULN,string UEM)
        {
            InitializeComponent();
            cust_ID = UID;
            cust_FN = UFN;
            cust_LN = ULN;
            cust_EM = UEM;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderHistory rOrder = new OrderHistory(cust_ID);
            rOrder.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order menu = new Order(cust_ID, cust_FN, cust_LN, cust_EM);
            menu.Show();
        }

        private void Selection_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit_Information editInfor = new Edit_Information(cust_ID);
            editInfor.Show();
        }
    }
}
