class Program
{
    public static void Main(string[] args)
    {
        TaskManager tm = new TaskManager();
        tm.AddEmplpoyee(1, "Khan");
        tm.AddEmplpoyee(2, "Musta");
        tm.AssignTask(1, "Prepare report");
        tm.AssignTask(2, "Fix bug");
        tm.AssignTask(1, "Client meeting");
        var tasks = tm.SearchTasks("report");

        Console.WriteLine("Matched Tasks:");
        foreach (var t in tasks)
            Console.WriteLine(t);
    }
}