namespace OrderProcessing
{
    class Order
    {
        private int _orderId;
        private string _customerName;
        private decimal _totalAmount;
        private string _status;
        private bool _discountApplied;

        public Order()
        {
            _status = "NEW";
            _totalAmount = 0;
            _discountApplied = false;
        }

        public Order(int orderId, string customerName)
        {
            _orderId = orderId;
            _customerName = customerName;
            _status = "NEW";
            _discountApplied = false;

        }
         public int order
        {
            get { return _orderId; } 
        }

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (value != "")
                    _customerName = value;
            }
        }

        public decimal TotalAmount
        {
            get { return _totalAmount; }
        }

        public void AddItem(decimal price)
        {
            if (price > 0)
                _totalAmount = _totalAmount + price;
        }

        public void AppliedDiscount(decimal percentage)
        {
            if (_discountApplied == false && percentage >= 1 && percentage <= 30)
            {
                decimal discount = _totalAmount * percentage / 100;
                _totalAmount = _totalAmount - discount;
                _discountApplied = true;
            }
            else
            {
                Console.WriteLine("Discount already applied");
            }
        }
        public string GetOrderSummary()
        {
            return "Order Id: " + _orderId +
                   "\nCustomer: " + _customerName +
                   "\nTotal Amount: " + _totalAmount +
                   "\nStatus: " + _status;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order(101, "Tushar");
            Console.WriteLine(order.GetOrderSummary());
            order.AddItem(500);
            order.AddItem(300);
            order.AppliedDiscount(10);
            order.AppliedDiscount(10);
            Console.WriteLine(order.GetOrderSummary());
        }
    }

}
