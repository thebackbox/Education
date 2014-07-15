using System;

namespace CreationalPatterns {
    class Program {
        static void Main(string[] args) {
            var c = new Creator();

            for (int i = 1; i <= 12; i++) {
                IProduct product = c.FactoryMethod(i);
                Console.WriteLine("Avocados " + product.ShipFrom());
            }
        }
    }
    
    interface IProduct {
        string ShipFrom();
    }

    class ProductA : IProduct {
        public string ShipFrom() {
            return " from South Africa";
        }
    }

    class ProductB : IProduct {
        public string ShipFrom() {
            return "from Spain";
        }
    }

    class DefaultProduct : IProduct {
        public string ShipFrom() {
            return "not available";
        }
    }

    class Creator {
        public IProduct FactoryMethod(int month) {
            if (month >= 4 && month <= 11)
                return new ProductA();
            else
                if (month == 1 || month == 2 || month == 12)
                    return new ProductB();
                else return new DefaultProduct();
        }
    }

}
