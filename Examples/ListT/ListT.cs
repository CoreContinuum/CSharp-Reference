using Microsoft.Data.SqlClient;

namespace ListT
{
    internal class Program
    {
    static void Main(string[] args)
    {
      try
      {
        Console.WriteLine("List<T> Demo, Loading via database or programmaticaly");
        Console.WriteLine("");

        // initialize variables, data structures, objects
        string? inputLDP = null;
        bool errorBln = false;
        List<string> ListT = new List<string>();

        try
        {
          // Get a reading from the console, database or program
          Console.Write("Enter 0 to load from database, and, 1 to load programaticaly (0/1): ");
          inputLDP = Console.ReadLine();

          if (inputLDP == "")
          {
            errorBln = true;
            throw new Exception("No sellection was made...");
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine($"There was an error. {ex.Message}");
          return;
        }

        if (inputLDP == "0")
        {
          try
          {
            #region Load List<T> via Database
            // String initializations
            string ConnStr = "Server=localhost;Database=C#Exercises;Trusted_Connection=True; TrustServerCertificate=True; User ID='czachariou'; password='picnic-coals-gourmet'";
            string sSQLStr = "SELECT Name FROM CSharp_Exercises_1";

            // Creating the SQL Connection using the connection string 
            using SqlConnection conn = new SqlConnection(ConnStr);

            // Opening the connection
            conn.Open();

            Console.WriteLine("Connected to the database!");

            // Creating the SQLCommand and SQLReader objects to read the data from the database 
            using SqlCommand cmd = new SqlCommand(sSQLStr, conn);
            using SqlDataReader reader = cmd.ExecuteReader();

            // Reading each row from the database table
            while (reader.Read())
            {
              // Adding into the Dictionary the Key (ID) and Value (Name)
              ListT.Add(reader.GetString(0));
            }

            Console.WriteLine("Loaded List<T> via the database...");
            #endregion
          }
          catch (Exception ex)
          {
            Console.WriteLine($"There was an error: {ex.Message}");
            return;
          }
        }
        else if (inputLDP == "1")
        {
          try
          {
            #region Load List<T> via Program
            // Initializing the dictionary
            ListT = new List<string>()
                      {
                        {"None"},
                        {"Costa"},
                        {"Maria"},
                        {"Raphael"},
                        {"Katerina"},
                        {"Aris"},
                        {"Lina"},
                        {"Nikki"},
                        {"Pana"},
                        {"Kirsten"},
                        {"Angeliki"},
                        {"Manolis"},
                        {"Konstantinos"},
                        {"Nina"},
                        {"Panayiota"},
                        {"Costantina"},
                        {"Yiannis"},
                        {"David"},
                        {"Joseph"},
                        {"Anna"},
                        {"Katerina"},
                        {"Marianthi"},
                        {"Manolis"}
                      };
            #endregion
          }
          catch (Exception ex)
          {
            Console.WriteLine($"There was an error: {ex.Message}");
            errorBln = true;
            return;
          }
        }
        else
        {
          errorBln = true;
          throw new Exception("Invalid sellection was made...");
        }

        if (errorBln == false)
        {
          try
          {
            #region Display List<T> values unsorted (original)
            // Display all of the List<T> values
            Console.WriteLine("Start of List<T> values unsorted (original)...");

            foreach (var item in ListT)
            {
              Console.WriteLine(item);
            }
            Console.WriteLine("End of List<T> values unsorted (original)...");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            #endregion

            #region Request to sort the list
            if (errorBln == false)
            {
              try
              {
                // Get a reading from the console, enter Name
                Console.Write("To sort the list, A = Ascending order, D = Descending order, N = No sorting:");
                string? inputSort = Console.ReadLine();

                if (inputSort != null)
                {
                  if (inputSort == "A")
                  {
                    ListT.Sort();
                  }
                  else
                    if (inputSort == "D")
                  {
                    // order in descending order. 1st sort in ascending then reverse otherwise it just reverses the original order
                    //ListT.Sort();
                    //ListT.Reverse();
                    //or
                    var descList = ListT.OrderByDescending(x => x);
                    ListT = descList.ToList();
                  }
                  else
                  {
                    errorBln = true;
                    throw new Exception("Invalid sellection was made...");
                  }

                  #region Display List<T> values sorted
                  if (inputSort == "A" || inputSort == "D")
                  {
                    // Display all of the List<T> values sorted
                    Console.WriteLine("Start of List<T> values sorted...");

                    foreach (var item in ListT)
                    {
                      Console.WriteLine(item);
                    }
                    Console.WriteLine("End of List<T> values sorted...");

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                  }
                  #endregion
                }
                else
                {
                  errorBln = true;
                  throw new Exception("No sellection was made...");
                }
              }
              catch (Exception ex)
              {
                Console.WriteLine($"There was an error: {ex.Message}");
                return;
              }
            }
            #endregion

            #region Search duplicates using LINQ and Lambda
            Console.WriteLine("Searching for all duplicates using LINQ and Lambda...");
            Console.WriteLine("");

            // Find all duplicate items and display the value
            var dups = ListT.GroupBy(x => x)
                            .Where(g => g.Count() > 1);

            Console.WriteLine("Start of duplicates...");
            Console.WriteLine("");

            // Display all the duplicate item pairs.
            foreach (var dupGroup in dups)
            {
              foreach (var dupItem in dupGroup)
              {
                Console.WriteLine($"{dupItem}");
              }
            }

            Console.WriteLine("");
            Console.WriteLine("End of duplicates using LINQ and Lambda...");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            #endregion

            #region Search duplicates via standard list object
            Console.WriteLine("Searching for all duplicates standard...");
            Console.WriteLine("");
            Console.WriteLine("Start of duplicates...");
            Console.WriteLine("");

            // Display all the duplicate List item pairs.
            var items = ListT.ToList();

            for (int i = 0; i < items.Count; i++)
            {
              for (int j = i + 1; j < items.Count; j++)
              {
                if (items[i] == items[j])
                {
                  Console.WriteLine($"{items[i]}");
                  Console.WriteLine($"{items[j]}");
                }
              }
            }

            Console.WriteLine("");
            Console.WriteLine("End of duplicates...");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            #endregion
          }
          catch (Exception ex)
          {
            Console.WriteLine($"There was an error: {ex.Message}");
            errorBln = true;
            return;
          }
        }

        #region Search via Name
        if (errorBln == false)
        {
          try
          {
            // Get a reading from the console, enter Name
            Console.Write("Enter the Name you wish to search for:");
            string? inputName = Console.ReadLine();
            int itemCnt = 0;

            if (inputName != null)
            {
              foreach (var item in ListT)
              {
                if (item.Contains(inputName))
                {
                  Console.WriteLine($"{item}");
                  itemCnt++;
                }
              }
            }

            if (itemCnt == 0)
            {
              Console.WriteLine($"The Name was not found...");
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine($"There was an error: {ex.Message}");
            errorBln = true;
            return;
          }
        }
        #endregion
      }
      catch (Exception ex)
      {
        Console.WriteLine($"There was an error: {ex.Message}");
        return;
      }
    }
  }
}
