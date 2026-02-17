public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> Tasks = new List<string>();
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
}