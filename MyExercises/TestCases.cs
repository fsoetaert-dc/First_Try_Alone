namespace MyExercises;

public class TestCases
{
    [Fact]
    public void CheckStudent()
    {
        var student = new Student("Patrick", 5);
        Assert.Equal("Patrick", student.Name);
        Assert.Equal(5, student.Age);
    }

    [Fact]
    public void CheckStudentEmptyName()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => new Student("", 5));
        Assert.Equal("Name cannot be empty", ex.Message);
    }

    [Fact]
    public void CheckStudentInvalidAge()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => new Student("Patrick", 1));
        Assert.Equal("Age must be 3 or above", ex.Message);
    }

    [Fact]
    public void CheckStudentHasTwoCourseWithCorrectScores()
    {
        var student = new Student("Patrick", 5);
        student.AddCourseWithScore("Wiskunde", 60);
        student.AddCourseWithScore("Frans", 80);
        Assert.Equal(60, student.CoursesAndScoresDict["Wiskunde"]);
        Assert.Equal(80, student.CoursesAndScoresDict["Frans"]);
    }

    [Fact]
    public void CheckInvalidCourse()
    {
        var student = new Student("Patrick", 5);
        var ex = Assert.Throws<InvalidOperationException>(() => student.AddCourseWithScore("", 60));
        Assert.Equal("Course cannot be empty", ex.Message);
    }

    [Fact]
    public void CheckInvalidScore()
    {
        var student = new Student("Patrick", 5);
        var ex = Assert.Throws<InvalidOperationException>(() => student.AddCourseWithScore("Wiskunde", 1000));
        Assert.Equal("Invalid score", ex.Message);
    }

    [Fact]
    public void CheckCorrectScoreWhenCourseAlreadyExists()
    {
        var student = new Student("Patrick", 5);
        student.AddCourseWithScore("Wiskunde", 60);
        student.AddCourseWithScore("Wiskunde", 80);
        Assert.Equal(80, student.CoursesAndScoresDict["Wiskunde"]);
    }

    [Fact]
    public void CheckStudentScores()
    {
        var school = new School();
        school.RegisterStudent("Patrick", 5);
        var student = school.listStudents.First();
        student.AddCourseWithScore("Wiskunde", 60);
        student.AddCourseWithScore("Frans", 80);
        var (naam, dict) = school.GetStudentNameAndScores(student.Name);
        var dictexpected = new Dictionary<string, int> { ["Wiskunde"] = 60, ["Frans"] = 80 };
        Assert.Equal("Patrick", naam);
        Assert.Equal(dictexpected, dict);
    }


    [Fact]
    public void CheckStudentWithoutScores()
    {
        var school = new School();
        school.RegisterStudent("Patrick", 5);
        var student = school.listStudents.First();
        var ex = Assert.Throws<Exception>(() => school.GetStudentNameAndScores(student.Name));
        Assert.Equal("Student Patrick heeft nog geen scores", ex.Message);
    }
}