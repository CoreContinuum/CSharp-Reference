using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExample
{
  // Inheritance
  public class Dog : Animal
  {
    // Polymorphism
    public override void Speak()
    {
      Console.WriteLine(Name + " says: Bark!");
    }
  }
}