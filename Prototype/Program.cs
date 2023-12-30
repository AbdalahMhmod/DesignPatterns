using Prototype;

var tempEmployee = new TempEmployee
{
    Id = 1,
    Name = "Test",
    Address = new Address
    {
        City = "City",
        Building = "Building",
        StreetName = "StreetName",
    },
};

var newTemp = tempEmployee.ShalowCopy();

newTemp.Address.City = "Old City";

Console.WriteLine(tempEmployee.ToString());
Console.WriteLine(newTemp.ToString());

var newTemp1 = tempEmployee.DeepCopy();
newTemp1.Address.City = "new City";

Console.WriteLine(tempEmployee.ToString());
Console.WriteLine(newTemp1.ToString());