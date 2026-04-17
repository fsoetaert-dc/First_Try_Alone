using Xunit.Sdk;

namespace MyExercises;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Student(string name, int age)    //maakt een student aan met een naam en leeftijd
    {
        if (name == "") throw new InvalidOperationException("Name cannot be empty");
        if (age < 3) throw new InvalidOperationException("Age must be 3 or above");
        Name = name;
        Age = age;
    }

    public Dictionary<string, int> CoursesAndScoresDict = [];   //maakt een lege dict aan die gebruikt wordt voor de vakken en scores op te slaan

    public void AddCourseWithScore(string course, int score) // add een vak en een score of past een score aan
    {
        if (course == "") throw new InvalidOperationException("Course cannot be empty");
        if ((score < 0) || (score > 100)) throw new InvalidOperationException("Invalid score");
        foreach (var key in CoursesAndScoresDict.Keys)
        {
            if (key == course)
            {
                CoursesAndScoresDict[course] = score;
                return;
            }
        }
        CoursesAndScoresDict.Add(course, score);
    }

    public double MeanScore()
    {
        double totalScore = 0;

        if (CoursesAndScoresDict.Count == 0) throw new Exception("Student has no scores");

        foreach (var key in CoursesAndScoresDict.Keys) totalScore += CoursesAndScoresDict[key];
        return totalScore / CoursesAndScoresDict.Count;
    }

}