namespace MyExercises;

public class Human(string name, int age) // chose another name because you can't have 2 classes with the same name
{
    public string Name { get; } = name; // Name is here only readonly (get), not writable
    public int Age { get; set; } = age; // Age is read and writable
}