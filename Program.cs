public class Program
{
    public static void Main()
    {
        var employeeDetailsModified = new EmployeeDetailsModified(new SalaryCalculatorModified());
        employeeDetailsModified.HourlyRate = 50;
        employeeDetailsModified.HoursWorked = 150;
        Console.WriteLine($"The Total Pay is {employeeDetailsModified.GetSalary()}");
    }
}
// Following the Dependency Inversion Principle
public interface ISalaryCalculator
{
    float CalculateSalary(int hoursWorked, float hourlyRate);
}
public class SalaryCalculatorModified : ISalaryCalculator
{
    public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;
}
public class EmployeeDetailsModified
{
    private readonly ISalaryCalculator _salaryCalculator;

    public int HoursWorked { get; set; }
    public int HourlyRate { get; set; }
    public EmployeeDetailsModified(ISalaryCalculator salaryCalculator)
    {
        _salaryCalculator = salaryCalculator;
    }
    public float GetSalary()
    {
        return _salaryCalculator.CalculateSalary(HoursWorked, HourlyRate);
    }
}

