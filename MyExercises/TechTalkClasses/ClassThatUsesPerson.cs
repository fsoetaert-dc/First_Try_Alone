using System.Runtime.CompilerServices;

namespace MyExercises.TechTalkClasses;

public class Hospital
{
    private List<Person> ListOfPersons = []; // a field can also be a list

    public void AddPersonToListOfPersons(Person person) // method of the class Hospital
    // Person is the type of what parameter the constructor wants,
    // and person is the parameter that the constructor uses
    // person could've also been named human or animal or whatever. 
    // person was just the most obvious name in this context. it doesn't have to have the same name of the type.
    // if you call the methode eg: var person1 = new Person("Sarah", 50)
    // Sarah and 60 are called arguments
    // person1 is called an object (can also be called an instance ><not to be confused with instanced members of a class)
    {
        ListOfPersons.Add(person); // adds the person to the list
        return;
    }

    public void SickScore(Person person, int score) // also a methode, gives a person a score of how sick they are
    {
        person.sickScore = score;
    }

    public void RankLeastSickPersonFirst() // also a method, ranks the persons in the list from least sick to most sick
    // a method doesn't have to have a parameter to execute something 
    {
        ListOfPersons.Sort((a, b) => a.sickScore.CompareTo(b.sickScore));
    }

    public List<Person> GetList() // returns the list with persons (can be empty)
    {
        return ListOfPersons;
    }
}