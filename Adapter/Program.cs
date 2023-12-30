using Adapter;

var employee = new Employee { basicSalary = 1000 };
var machineOperator = new MachineOperator { basicSalary = 2000 };
var salaryCalculator = new SalaryAdapter();

var salary = salaryCalculator.CalcSalary(machineOperator);
Console.WriteLine($"Total salary : {salary}");

/*
 * The Adapter Pattern is a design pattern in software engineering that allows incompatible interfaces of classes to work together.
 * It acts as a bridge between two interfaces, converting the interface of one class into an interface that a client expects.

 *The Adapter Pattern is particularly useful when you have existing classes with incompatible interfaces
 *(perhaps from different libraries or systems) that you want to reuse or integrate into your application without modifying their source code.
 */