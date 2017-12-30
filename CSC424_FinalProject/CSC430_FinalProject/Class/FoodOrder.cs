using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSC430_FinalProject
{
    class FoodOrder
    {
        private string orderID;
        private string foodName;
        private int quantity;

        //constractor
        public FoodOrder()
        {

        }
        public FoodOrder(string inID, string inName, int inQty)
        {
            OrderID = inID;
            FoodName = inName;
            Quantity = inQty;
        }

        //OrderID
        public string OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        //FoodName
        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; }
        }
        //Qty
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}
