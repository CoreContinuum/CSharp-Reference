using System;

namespace OOPExample
{
  class Program
  {
    static void Main(string[] args)
    {
      // Create Dog object
      Dog myDog = new Dog();

      // Encapsulation through property
      myDog.Name = "Buddy";

      // Call method
      myDog.Speak();

      Console.ReadLine();
    }
  }
}