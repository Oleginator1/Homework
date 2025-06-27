using Exercise;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Exemplu
{
   
    public class MyClass
    {
        static void Main(string[] args)
        {
            Order order = new Order
            {
                Id = 1,
                Amount = 100
            };

            IPayment payment = new CreditCardPayment();
            payment.ProcessPayment(order);
            

            OrderRepository orderRepository = new OrderRepository();
            orderRepository.SaveToDatabase(order);
            orderRepository.LoadFromDatabase(1);

        }
      

    }
}
