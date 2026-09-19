using static System.Net.WebRequestMethods;

namespace prog;

internal class Program
{
    private static void Main(string[] args)
    {
        //List<int> numbers = new List<int> { 1, 4, 7, 10, 15, 20 };
        //List<int> evens = numbers.Filter(n => n % 2 == 0);
        //foreach (var item in evens)
        //{
        //    Console.WriteLine(item);
        //}

        //List<string> names = staff.Transform(e => e.Name);
        //foreach (var item in names)
        //{
        //    Console.WriteLine(item);
        //}

        //var sortedBySalary = staff.SortBy(e => e.BasicSalary);
        //foreach (var item in sortedBySalary)
        //{
        //    Console.WriteLine(item.Name);
        //}
        //var sortedByName = staff.SortBy(e => e.Name);
        //foreach (var item in sortedByName)
        //{
        //    Console.WriteLine(item.Name);
        //}
        //--------------------------------------------------------------
        //1. Initialize a List<Employee>
        List<Employee> staff = GetEmployees();
        //2. Chain the extension methods into a single pipeline:
        var Result = staff
            .Filter(e => e.NetSalary >= 3500)
            .SortBy(e => e.NetSalary)
            .Transform(e => $"Employee: {e.Name} | Net: {e.NetSalary}")
            .ToFreshList();
        //3. Print each formatted string in the resulting list.
        foreach (var item in Result)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("==--==--==--==--==--==--==--==--==--==--==--/");
        //4. Call and print the results of:
        bool HasAnyBonus = staff.HasAny(e => e.Bonus > 1000);
        Console.WriteLine($"1. Any Employees Has Bonus > 1000 : {HasAnyBonus}");

        bool HasChekSalary = staff.MatchAll(e => e.BasicSalary >= 2000);
        Console.WriteLine($"2. All Employees Have Basic Salary >= 2000 : {HasChekSalary}");

        int Count = staff.CountWhere(e => e.Deductions == 0);
        Console.WriteLine($"3. Count Employees with Deduction = 0  : {Count}");

        var find = staff.FindFirst(e => e.Name[0] == 'M');
        Console.WriteLine($"4. First Employee starting with 'M': {find?.Name}");


        Console.WriteLine("=====================================================================");
        var sort = staff.SortByDescending(e => e.NetSalary);
        foreach (var emp in sort)
        {
            Console.WriteLine($"[ID: {emp.Id}] {emp.Name} | Net Salary: {emp.NetSalary}");
        }

        Console.WriteLine("==--==--==--==--==--==--==--==--==--==--==--/");
        var takeFirst = staff.TakeFirst(5);
        foreach (var emp in takeFirst)
        {
            Console.WriteLine($"[ID: {emp.Id}] {emp.Name} | Net Salary: {emp.NetSalary}");

        }
    }
    public static List<Employee> GetEmployees()
    {
        return new List<Employee>
    {
        new Employee { Id = 1, Name = "Mona Zaki", BasicSalary = 3000, Bonus = 800, Deductions = 200 },     // Net = 3600
        new Employee { Id = 2, Name = "Ahmed Hassan", BasicSalary = 4000, Bonus = 700, Deductions = 200 },  // Net = 4500
        new Employee { Id = 3, Name = "Sarah Tarek", BasicSalary = 4500, Bonus = 900, Deductions = 300 },   // Net = 5100
        new Employee { Id = 4, Name = "Omar Sherif", BasicSalary = 6000, Bonus = 1200, Deductions = 400 },  // Net = 6800
        new Employee { Id = 5, Name = "Mohamed Ali", BasicSalary = 2500, Bonus = 300, Deductions = 0 },     // Net = 2800 (Deductions = 0)
        new Employee { Id = 6, Name = "Mahmoud Nour", BasicSalary = 1800, Bonus = 200, Deductions = 100 },  // Net = 1900 (Basic < 2000)
        new Employee { Id = 7, Name = "Khaled Amr", BasicSalary = 3200, Bonus = 500, Deductions = 0 },      // Net = 3700 (Deductions = 0)
        new Employee { Id = 8, Name = "Mostafa Reda", BasicSalary = 5000, Bonus = 1500, Deductions = 500 }, // Net = 6000 (Bonus > 1000)
        new Employee { Id = 9, Name = "Mariam Said", BasicSalary = 2200, Bonus = 400, Deductions = 100 },   // Net = 2500
        new Employee { Id = 10, Name = "Nader Youssef", BasicSalary = 2900, Bonus = 300, Deductions = 200 } // Net = 3000
    };
    }
}
