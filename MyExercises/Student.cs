namespace MyExercises;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public Dictionary<string, int> CoursesAndScoresDict = [];

    public void AddResults(string course, int score)
    {
        CoursesAndScoresDict.Add(course, score);
    }

}