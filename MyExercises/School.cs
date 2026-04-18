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

    public List<(Student, double)> MeanScoreStudentsList = [];
    public List<(Student, double)> HonoraryList(List<Student> listStudents, int amount)
    {
        foreach (var student in listStudents)
        {
            var mean = student.MeanScore();
            MeanScoreStudentsList.Add((student, mean));
        }
        MeanScoreStudentsList.Sort((a, b) => b.CompareTo(a));
        return MeanScoreStudentsList.GetRange(0, amount);

    }
}