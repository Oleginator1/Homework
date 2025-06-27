using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class Order
    {
        public int Id { get; set; }
        public double Amount { get; set; }    
    }

    public interface IPayment
    {
        public void ProcessPayment(Order order);
    }

    public class CreditCardPayment : IPayment
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Processing credit card payment...");
        }
    }

    public class PayPalPayment : IPayment
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Processing PayPal payment...");
        }
    }
    
    public class BankTrasferPayment : IPayment
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Processing bank transfer payment...");
        }
    }

    public class OrderRepository()
    {
        public void SaveToDatabase(Order order)
        {
            Console.WriteLine("Saving order to database...");
        }


        public void LoadFromDatabase(int orderId)
        {
            Console.WriteLine("Loading order from database...");
        }
    }

}
