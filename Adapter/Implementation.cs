namespace Adapter
{
    public class Employee
    {
        public double basicSalary { get; set; }
    }

    public class MachineOperator
    {
        public double basicSalary { get; set; }
    }

    public class SalaryCalculator
    {
        public double CalcSalary(Employee employee)
        {
            return employee.basicSalary * 1.5;
        }
    }

    class SalaryAdapter : SalaryCalculator
    {
        private Employee _employee;

        public double CalcSalary(MachineOperator machineOperator)
        {
            _employee = new Employee { basicSalary = machineOperator.basicSalary };
            return base.CalcSalary(_employee);
        }
    }
}
