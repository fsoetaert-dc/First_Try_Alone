using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace MyExercises.TechTalkClasses;

public class Person // name of the class
{
    private string species = "Homo Sapiens"; // private field (field is just a term for something you give a value inside a class)
    // private can only be accessed by the class itself 
    // the convention is that fields have a low case letter

    public string job = "programmer"; // public field
    // public can also be accessed by other classes

    public int sickScore = 0;

    public string Name { get; private set; } = ""; // public property (a property is something you can call on (get) and give a value(set))
    // =""; means that Name gets a empty string as a default value
    // the convention is that properties have a Capital case
    public int Age { get; private set; } = 0; // Age gets a default value of 0

    public Person(string name, int age) // example of a normal/traditional constructor
    //  name and age are parameters of the constructor
    // string and int are the types of the parameters
    {
        Name = name;
        Age = age;
    }
}