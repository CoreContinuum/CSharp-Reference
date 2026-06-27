using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExample
{
  // Abstraction
  public class Animal
  {
    // Encapsulation
    private string name;

    // Property
    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    // Virtual method for polymorphism
    public virtual void Speak()
    {
      Console.WriteLine("The animal makes a sound.");
    }
  }
}