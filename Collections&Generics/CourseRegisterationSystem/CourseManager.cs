using System.Collections.Generic;
using System.Linq;

// public class Student
// {
//     // STEP 1:
//     // Create properties:
//     // int Id
//     // string Name
//     // string Department

//     // STEP 2:
//     // Create constructor:
//     // Assign parameters to properties
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public string Department { get; set; }

//     public Student(int id, string name, string dept)
//     {
//         Id = id;
//         Name = name;
//         Department = dept;
//     }
// }

public class CourseManager
{
    private Dictionary<int, Student> _students = new();
    private Dictionary<string, List<Student>> _courseEnrollments = new();
    private Dictionary<string, Queue<Student>> _waitingLists = new Dictionary<string, Queue<Student>>();

    public void RegisterStudent(int id, string name, string dept)
    {
        /*
        STEPS:

        1. Check if student already exists:
           _students.ContainsKey(id)
        

        2. If exists → stop method.

        3. Create Student object.

        4. Add student to dictionary:
           _students.Add(id, student)
        */
        if (_students.ContainsKey(id))
        {
            return;
        }
        _students[id] = new Student(id, name, dept);
    }

    public void EnrollCourse(int studentId, string courseName)
    {
        /*
        STEPS:

        1. Check student exists in dictionary.
           If not → stop.
        

        2. If course not in _courseEnrollments:
           Create new List<Student>.

        3. If enrolled students < 3:
           Add student to list.

        4. Else (course full):
           - Create Queue if not exists.
           - Add student to waiting list queue.
        */
        if (!_students.ContainsKey(studentId))
        {
            return;
        }
        if (!_courseEnrollments.ContainsKey(courseName))
        {
            _courseEnrollments[courseName] = new List<Student>();
        }
        if (_courseEnrollments[courseName].Count < 3)
        {
            _courseEnrollments[courseName].Add(_students[studentId]);
        }
        else
        {
            if (!_waitingLists.ContainsKey(courseName))
            {
                _waitingLists[courseName] = new Queue<Student>();
            }
            _waitingLists[courseName].Enqueue(_students[studentId]);
        }
    }

    public List<Student> GetStudentsInCourse(string courseName)
    {
        /*
        STEPS:

        1. Check course exists.
        2. If yes → return list.
        3. Otherwise return empty List<Student>.
        */
        return _courseEnrollments.ContainsKey(courseName) ? _courseEnrollments[courseName]: new List<Student>();
    }
}