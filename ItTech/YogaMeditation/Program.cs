using System;
using System.Collections;

class Program
{
    // Keeping your ArrayList exactly as requested
    public static ArrayList member = new ArrayList();

    public void AddMember(int id, int age, double weight, double height, string goal, double bmi)
    {
        MeditationCenter meditationCenter = new MeditationCenter
        {
            MemberId = id,
            Age = age,    // Fixed: C# is case-sensitive (Age, not age)
            Weight = weight,
            Height = height,
            Goal = goal,  // Fixed: C# is case-sensitive (Goal, not goal)
            BMI = bmi
        };
        member.Add(meditationCenter);
    }

    public double CalculateBMI(int memberId)
    {
        foreach (object obj in member)
        {
            
            MeditationCenter item = (MeditationCenter)obj;

            if (item.MemberId == memberId)
            {
                double bmi = item.Weight / (item.Height * item.Height);
                bmi = Math.Floor(bmi * 100) / 100;
                item.BMI = bmi;
                return bmi; 
            }
        }
        return 0.0;
    }

    public int CalculateYogaFee(int memberId)
    {
        foreach (object obj in member)
        {
            
            MeditationCenter item = (MeditationCenter)obj;

            if (item.MemberId == memberId)
            {
                if (item.BMI == 0)
                {
                    CalculateBMI(memberId);
                }

                if (item.Goal == "Weight Gain")
                {
                    return 2500;
                }
                
                if (item.Goal == "Weight Loss")
                {
                    if (item.BMI >= 25 && item.BMI < 30) return 2000;
                    else if (item.BMI >= 30 && item.BMI < 35) return 2500;
                    else if (item.BMI >= 35) return 3000;
                }
                return 0;
            }
        }
        return 0;
    }

    public static void Main(string[] args)
    {
        Program p = new Program();

        // Pass 0 for BMI initially as it will be calculated
        p.AddMember(101, 26, 78, 1.68, "Weight Loss", 0);
        p.AddMember(102, 30, 55, 1.64, "Weight Gain", 0);

        Console.Write("Enter MemberId: ");
        string input = Console.ReadLine() ?? "";
        
        if (int.TryParse(input, out int id))
        {
            double bmi = p.CalculateBMI(id);
            if (bmi == 0)
            {
                Console.WriteLine($"MemberId '{id}' is not present");
                return;
            }

            Console.WriteLine($"BMI: {bmi}");
            int fee = p.CalculateYogaFee(id);
            Console.WriteLine($"Yoga Fee: {fee}");
        }
    }
}