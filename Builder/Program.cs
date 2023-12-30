using Builder;

var director = new Director();
var carBuilder = new CarBuilder("Toyota");
director.Construct(carBuilder);
var car = carBuilder.GetProduct();


var motorCycleBuilder = new MotorCycleBuilder("Honada");
director.Construct(motorCycleBuilder);
var motorCycle = motorCycleBuilder.GetProduct();

Console.WriteLine($"Car {car.Show()}");
Console.WriteLine($"MotorCycle {motorCycle.Show()}");