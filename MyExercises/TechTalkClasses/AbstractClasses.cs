namespace MyExercises.TechTalkClasses;

public abstract class Animal
// Cannot be instantiated directly: you can't do var animal = new Animal()
// Useful for shared base behavior and polymorphism.
{
    public abstract void Speak();            // abstract means it must be implemented by a subclass
    // if you want to give a default use: public virtual void speak() => console.WriteLine("Animalnoise")
    public void Eat() => Console.WriteLine("Eating"); // shared implementation

}

public class Dog : Animal
{
    public override void Speak() => Console.WriteLine("Woof"); // override means that the Dog class gets to implement Speak()
}

// inheritance lets one class (the derived/subclass) reuse and extend another class’s (the base/superclass) members (like properties/fields/methods...)
// here is Animal the superclass and Dog the subclass, a class can only have 1 superclass 
