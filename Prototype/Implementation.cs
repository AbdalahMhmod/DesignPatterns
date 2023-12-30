namespace Prototype
{
    public abstract class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public abstract Employee DeepCopy();

        public Employee ShalowCopy()
        {
            return (Employee)MemberwiseClone();
        }

        public override string ToString()
        {
            return $@"
                      Id: {Id}
                      Name: {Name}
                      Address: {Address.City}, {Address.StreetName}, {Address.Building}
            ";
        }
    }

    public class RegEmployee : Employee
    {
        public override Employee DeepCopy()
        {
            var empCopy = (RegEmployee)MemberwiseClone();
            empCopy.Address = new Address
            {
                City = Address.City,
                Building = Address.Building,
                StreetName = Address.StreetName,
            };

            return empCopy;
        }
    }

    public class TempEmployee : Employee
    {
        public override Employee DeepCopy()
        {
            var empCopy = (TempEmployee)MemberwiseClone();
            empCopy.Address = new Address
            {
                City = Address.City,
                Building = Address.Building,
                StreetName = Address.StreetName,
            };

            return empCopy;
        }
    }

    public class Address
    {
        public string City { get; set; }
        public string Building { get; set; }
        public string StreetName { get; set; }
    }
}
