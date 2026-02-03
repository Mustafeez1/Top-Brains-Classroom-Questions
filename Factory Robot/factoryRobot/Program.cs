using System;
class Program
{
    public static void Main(String[] args){
        try
        {
            Console.WriteLine("Enter Arm Precision (0.0 - 1.0)");
            double armPrecision = double.Parse(Console.ReadLine());
    
            Console.WriteLine("Enter Worker Density (1 - 20)");
            int workerDensity = int.Parse(Console.ReadLine());
    
            Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
            string machineryState = Console.ReadLine();
    
            RobotHazardAuditor robot = new RobotHazardAuditor();
            double risk = robot.CalculateHazardRisk(armPrecision, workerDensity, machineryState);
            Console.WriteLine($"Robot Hazard Risk Score: {risk}");
        }
        catch (RobotSafetyException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}