using System.Text;

namespace Builder
{
    public class Product
    {
        private readonly LinkedList<string> parts = new LinkedList<string>();

        public Product()
        {
        }

        public void Add(string part)
        {
            parts.AddLast(part);
        }

        public string Show()
        {
            var result = new StringBuilder();
            result.AppendLine("Product components are: ");
            foreach(var part in parts)
            {
                result.AppendLine(part);
            }

            return result.ToString();
        }
    }

    public interface IBuilder
    {
        void StartupOperations();
        void BuildBody();
        void InsertWheels();
        void AddHeadlights();
        void EndOperations();
        Product GetProduct();
    }

    public class CarBuilder : IBuilder
    {
        private readonly Product _carProduct;
        private readonly string _brand;

        public CarBuilder(string brand)
        {
            _carProduct = new Product();
            _brand = brand;
        }

        public void StartupOperations()
        {
            _carProduct.Add($"Car model name :{_brand}");
        }

        public void AddHeadlights()
        {
            _carProduct.Add("Headlights are added");
        }

        public void BuildBody()
        {
            _carProduct.Add("Body of the car was Added");
        }

        public void EndOperations()
        {
            _carProduct.Add("Body of the car was Added");
        }

        public Product GetProduct()
        {
            return _carProduct;
        }

        public void InsertWheels()
        {
            _carProduct.Add("Wheels was Added");
        }
    }

    public class MotorCycleBuilder : IBuilder
    {
        private readonly Product _motorCycleProduct;
        private readonly string _brand;

        public MotorCycleBuilder(string brand)
        {
            _motorCycleProduct = new Product();
            _brand = brand;
        }

        public void StartupOperations()
        {
            _motorCycleProduct.Add($"Motor model name :{_brand}");
        }

        public void AddHeadlights()
        {
            _motorCycleProduct.Add("Headlights are added");
        }

        public void BuildBody()
        {
            _motorCycleProduct.Add("Body of the Motor was Added");
        }

        public void EndOperations()
        {
            _motorCycleProduct.Add("Body of the Motor was Added");
        }

        public Product GetProduct()
        {
            return _motorCycleProduct;
        }

        public void InsertWheels()
        {
            _motorCycleProduct.Add("Wheels was Added");
        }
    }

    public class Director
    {
        private IBuilder _builder;

        public void Construct(IBuilder builder)
        {
            _builder = builder;
            _builder.StartupOperations();
            _builder.BuildBody();
            _builder.InsertWheels();
            _builder.AddHeadlights();
            _builder.EndOperations();
        }
    }
}
