using Microsoft.Data.SqlClient;
using System;
using System.Linq.Expressions;


namespace Dictionary
{
  internal class Dictionary
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Dictionary Demo, Loading via database or programmaticaly");
      Console.WriteLine("");

      // initialize variables, data structures, objects
      string? inputLDP = null;
      bool errorBln = false;
      Dictionary<int, string> Dict = new Dictionary<int, string>();

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
        errorBln = true;
        return;
      }

      if (errorBln == false && inputLDP == "0")
      {
        try
        {
          #region Load Dictionary via Database
          // String initializations
          string ConnStr = "Server=localhost;Database=C#Exercises;Trusted_Connection=True; TrustServerCertificate=True; User ID='czachariou'; password='picnic-coals-gourmet'";
          string sSQLStr = "SELECT ID, Name FROM CSharp_Exercises_1 ORDER BY ID";

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
            Dict.Add(reader.GetInt32(0), reader.GetString(1));
          }

          Console.WriteLine("Loaded Dictionary via the database...");
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
        try
        {
          #region Load Dictionary via Program
          // Initializing the dictionary
          Dict = new Dictionary<int, string>()
          {
            {0, "None"},
            {1, "Costa"},
            {2, "Maria"},
            {3, "Raphael"},
            {4, "Katerina"},
            {5, "Aris"},
            {6, "Lina"},
            {7, "Nikki"},
            {8, "Pana"},
            {9, "Kirsten"},
            {10,  "Angeliki"},
            {11,  "Manolis"},
            {12,  "Konstantinos"},
            {13,  "Nina"},
            {14,  "Panayiota"},
            {15,  "Costantina"},
            {16,  "Yiannis"},
            {17,  "David"},
            {18,  "Joseph"},
            {19,  "Anna"},
            {20,  "Katerina"},
            {21,  "Marianthi"},
            {22,  "Manolis"}
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

      if (errorBln == false)
      {
        try
        {
          #region Display Dictionary Key and Value unsorted (original)
          // Display all of the Dictionary Key and Value unsorted (original)
          Console.WriteLine("Start of Dictionary Key and Values unsorted (original)...");

          foreach (KeyValuePair<int, string> kvp in Dict)
          {
            Console.WriteLine(kvp.Key.ToString() + ", " + kvp.Value.ToString());
          }
          Console.WriteLine("End of Dictionary Key and Values unsorted (original)...");

          Console.WriteLine("");
          Console.WriteLine("");
          Console.WriteLine("");
          Console.WriteLine("");
          #endregion

          #region Request to sort the Dictionary
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
                  var ascDict = Dict
                    .OrderBy(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);
                  Dict = ascDict;

                }
                else
                  if (inputSort == "D")
                {
                  // order in descending order. 1st sort in ascending then reverse otherwise it just reverses the original order
                  //ListT.Sort();
                  //ListT.Reverse();
                  //or
                  var descDict = Dict
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);
                  Dict = descDict;
                }
                else
                {
                  errorBln = true;
                  throw new Exception("Invalid sellection was made...");
                }

                #region Display Dictionary Key and Values sorted
                if (inputSort == "A" || inputSort == "D")
                {
                  // Display all of the Dictionary Key and Values sorted
                  Console.WriteLine("Start of Dictionary Key and Values sorted...");

                  foreach (var item in Dict)
                  {
                    Console.WriteLine($"{item.Key.ToString()}, {item.Value}");
                  }
                  Console.WriteLine("End of Dictionary Key and Values sorted...");

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

          // Find all duplicate kvp values and display the key and the value
          var dups = Dict.GroupBy(x => x.Value)
                          .Where(g => g.Count() > 1);

          Console.WriteLine("Start of duplicates...");
          Console.WriteLine("");

          // Display all the duplicate key, value pairs.
          foreach (var dupGroup in dups)
          {
            foreach (var dupItem in dupGroup)
            {
              Console.WriteLine($"{dupItem.Key}, {dupItem.Value}");
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

          // Display all the duplicate key, value pairs.
          var items = Dict.ToList();

          for (int i = 0; i < items.Count; i++)
          {
            for (int j = i + 1; j < items.Count; j++)
            {
              if (items[i].Value == items[j].Value)
              {
                Console.WriteLine($"{items[i].Key}, {items[i].Value}");
                Console.WriteLine($"{items[j].Key}, {items[j].Value}");
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

      if (errorBln == false)
      {
        try
        {
          // Get a reading from the console, search via ID or search via Name
          Console.Write("Enter 0 to search via ID, and, 1 to search via Name: ");
          string? inputSIN = Console.ReadLine();

          if (inputSIN == "")
          {
            errorBln = true;
            throw new Exception("No sellection was made...");
          }

          if (inputSIN == "0")
          {
            #region Search via ID
            // Get a reading from the console, enter ID
            Console.Write("Enter ID:");
            string? inputID = Console.ReadLine();

            if (int.TryParse(inputID, out int id))
            {
              if (Dict.ContainsKey(id))
              {
                Console.WriteLine($"{id}, {Dict[id]}");
              }
              else
              {
                Console.WriteLine($"The ID was not found...");

              }
            }
            #endregion
          }
          else
          {
            #region Search via Name
            // Get a reading from the console, enter Name
            Console.Write("Enter Name:");
            string? inputName = Console.ReadLine();
            int itemCnt = 0;

            foreach (var item in Dict)
            {
              if (item.Value.Contains(inputName))
              {
                Console.WriteLine($"{item.Key}, {item.Value}");
                itemCnt++;
              }
            }

            if (itemCnt == 0)
            {
              Console.WriteLine($"The Name was not found...");
            }
            #endregion
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine($"There was an error: {ex.Message}");
          errorBln = true;
          return;
        }
      }
    }
  }
}
