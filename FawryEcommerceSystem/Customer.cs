using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryEcommerceSystem
{
    public class Customer
    {
        public string Name { get; }
        public double Balance { get; private set; }


        // Constructor to initialize customer with name and balance
        public Customer(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }

        // Method to add balance to the customer's account
        public bool DeductBalance(double amount)
        {
            if (amount > Balance)
                return false;

            Balance -= amount;
            return true;
        }


    }
}
