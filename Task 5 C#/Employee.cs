namespace prog;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal BasicSalary { get; set; }
    public decimal Bonus { get; set; }
    public decimal Deductions { get; set; }
    public decimal NetSalary => BasicSalary + Bonus - Deductions;
    public override string ToString()
    {
        return $"[ID: {Id}] {Name,-12} | Basic: {BasicSalary,6:C0} | Net:{ NetSalary,6:C0}";
    }
}