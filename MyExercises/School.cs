namespace MyExercises;

public class School
{
    public List<Student> listStudents = [];
    public void RegisterStudent(string name, int age)
    {
        listStudents.Add(new Student(name, age));
    }

    public (string, Dictionary<string, int>) GetStudentNameAndScores(string name)
    {
        foreach (var student in listStudents)
        {
            if (student.Name == name)
            {
                if (student.CoursesAndScoresDict.Count == 0) throw new Exception($"Student {name} heeft nog geen scores");
                return (name, student.CoursesAndScoresDict);
            }

        }
        throw new IndexOutOfRangeException("Student niet geregistreerd");
    }

    public double MeanScore(string name)
    {
        int total = 0;
        foreach (var student in listStudents)
        {
            if (student.Name == name)
            {
                foreach (var key in student.CoursesAndScoresDict.Keys)
                {
                    total += student.CoursesAndScoresDict[key];
                }
            }
            return total / student.CoursesAndScoresDict.Count;
        }
        throw new Exception("Student not in list)");

    }
}