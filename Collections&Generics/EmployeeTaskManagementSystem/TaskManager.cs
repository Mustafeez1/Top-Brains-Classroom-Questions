public class TaskManager
{
    private Dictionary<int, Employee> _employees = new Dictionary<int, Employee>();
    private Queue<string> _pendingtasks = new Queue<string>();
    public void AddEmplpoyee(int id, string name)
    {
        if (!_employees.ContainsKey(id))
        {
            _employees[id] = new Employee(id, name);
            Console.WriteLine($"Employee {name} added.");
        }
    }
    public void AssignTask(int empId, string task)
    {
        if (_employees.ContainsKey(empId))
        {
            _employees[empId].Tasks.Add(task);
            _pendingtasks.Enqueue(task);
            Console.WriteLine($"{task} assigned");
        }
    }
    public IEnumerable<string> SearchTasks(string keyword)
    {
        return _employees.Values.SelectMany(k => k.Tasks).Where(t => t.Contains(keyword));
    }
}