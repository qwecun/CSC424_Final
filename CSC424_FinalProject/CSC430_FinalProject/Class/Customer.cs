using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC430_FinalProject
{
    class Customer
    {
        public string fName;
        public string lName;
        public string email;
        public string address;
        public string city;
        public string state;
        public string zip;
        public string phone;
        public string userName;
        public string password;

        //Constructor
        public Customer()
        {
        }
        public Customer(string inFName,string inLName, string inEmail,string inAddress,string inCity,
            string inState, string inZip, string inPhone, string inUserName,string inPassword)
        {
            FName = inFName;
            LName = inLName;
            Email = inEmail;
            Address = inAddress;
            City = inCity;
            State = inState;
            Zip = inZip;
            Phone = inPhone;
            UserName = inUserName;
            Password = inPassword;
        }
        //First Name
        public string FName
        {
            get
            {
                return fName;
            }
            set
            {
                fName = value;
            }
        }
        //Last name
        public string LName
        {
            get
            {
                return lName;
            }
            set
            {
                lName = value;
            }
        }
        //email
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        //address
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        //city
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }
        //state
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        //zip
        public string Zip
        {
            get
            {
                return zip;
            }
            set
            {
                zip = value;
            }
        }
        //phone
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
        //userName
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        //password
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
