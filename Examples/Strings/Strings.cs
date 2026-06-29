namespace Strings
{
  internal class Strings
  {
    static void Main(string[] args)
    {
      //bool blnError = false;

      try
      {
        Console.WriteLine("String manipulation exercises...");
        Console.WriteLine("");

        string? strValue = null;

        #region Reverse the value of the string
        do
        {
          // Display the category of the game
          Console.WriteLine("Reverse the value of the string. Press Enter to quit or 0 for next category.");
          Console.WriteLine("");

          // Get the users input
          Console.Write("Enter a word:");
          strValue = Console.ReadLine();

          if (strValue == "")
          {
            throw new Exception("No string was entered. You must enter a string...");
          }
          else if (strValue != "0")
          {
            string strWordRL = new string(strValue.Reverse().ToArray());

            Console.WriteLine($"The word \"{strValue}\" reversed is \"{strWordRL}\"");
          }
        } while (strValue != "0");
        #endregion

        #region Check for Palindrome (a word read, left to right, or right to left, reads the same)
        do
        {
          // Display the category of the game
          Console.WriteLine("Check to see if a word is a Palindrome (a word read, left to right, or right to left, reads the same). Press Enter to quit or 0 for next category.");
          Console.WriteLine("");
          
          // Get the users input
          Console.Write("Enter a word:");
          strValue = Console.ReadLine();

          if (strValue == "")
          {
            throw new Exception("No string was entered. You must enter a string...");
          }
          else if (strValue != "0")
          {
            string strWordRL = new string(strValue.Reverse().ToArray());

            if (strValue == strWordRL)
            {
              Console.WriteLine($"The word \"{strValue}\" is a Palindrome.");
            }
            else
            {
              Console.WriteLine($"The word \"{strValue}\" is not a Palindrome.");
            }
          }
        } while (strValue != "0");
        #endregion
        
        #region Count all the vowels of the string entered
        do
        {
          // Display the category of the game
          Console.WriteLine("Count all the vowels of the string entered. Press Enter to quit or 0 for next category.");
          Console.WriteLine("");
          
          // Get the users input
          Console.Write("Enter a word:");
          strValue = Console.ReadLine();

          if (strValue == "")
          {
            throw new Exception("No string was entered. You must enter a string...");
          }
          else if (strValue != "0")
          {
            int iVowelCnt = 0;

            for (int i = 0; i < strValue.Length; i++)
            {
              if (char.ToLower(strValue[i]) == 'a' || 
                  char.ToLower(strValue[i]) == 'e' || 
                  char.ToLower(strValue[i]) == 'i' || 
                  char.ToLower(strValue[i]) == 'o' || 
                  char.ToLower(strValue[i]) == 'u')
              {
                iVowelCnt++;
              }
            }

            Console.WriteLine($"The word \"{strValue}\" contains {iVowelCnt.ToString()} vowel(s).");
          }
        } while (strValue != "0");
        #endregion

        #region Count all the words in the sentence
        do
        {
          // Display the category of the game
          Console.WriteLine("Count all the words of the sentence. Press Enter to quit or 0 for next category.");
          Console.WriteLine("");

          // Get the users input
          Console.Write("Enter a word or sentence:");
          strValue = Console.ReadLine();

          if (strValue == "")
          {
            throw new Exception("No string was entered. You must enter a string...");
          }
          else if (strValue != "0")
          {
            string[] words = strValue.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int iWordCnt = words.Length;

            Console.WriteLine($"The word or sentence \"{strValue}\" contains {iWordCnt.ToString()} word(s).");
          }
        } while (strValue != "0");
        #endregion

        #region Remove all duplicate characters
        do
        {
          // Display the category of the game
          Console.WriteLine("Remove all duplicate characters. Press Enter to quit or 0 for next category.");
          Console.WriteLine("");

          // Get the users input
          Console.Write("Enter a word:");
          strValue = Console.ReadLine();

          if (strValue == "")
          {
            throw new Exception("No string was entered. You must enter a string...");
          }
          else if (strValue != "0")
          {
            HashSet<char> seen = new();
            string strNoDups = "";

            foreach (char ch in strValue)
            {
              if (seen.Add(ch))
              {
                strNoDups += ch;
              }
            }

            Console.WriteLine($"The word \"{strValue}\" without duplicate characters is \"{strNoDups}\".");
          }
        } while (strValue != "0");
        #endregion

        #region Count all occurrences of a substring within a string
        do
        {
          // Display the category of the game
          Console.WriteLine("Count all occurrences of a substring within a string.  Press Enter to quit or 0 for next category.");
          Console.WriteLine("");

          // Read the string
          Console.Write("Enter a word:");
          strValue = Console.ReadLine();

          if (strValue == "")
          {
            throw new Exception("No string was entered. You must enter a string...");
          }
          else if (strValue != "0")
          {
            if (strValue == "0")
            {
              return;
            }

            // Read the occurrence
            Console.Write("Enter occurrence:");
            string? stroccurrence = Console.ReadLine();

            int iOccCnt = 0;
            int index = 0;

            while ((index = strValue.IndexOf(stroccurrence, index)) != -1)
            {
              iOccCnt++;
              index += stroccurrence.Length;
            }

            Console.WriteLine($"The occurrence \"{stroccurrence}\" in the string \"{strValue}\" appears {iOccCnt.ToString()} times.");
          }
        } while (strValue != "0");
        #endregion

        #region Show first non-repeated character
        do
        {
          // Display the category of the game
          Console.WriteLine("Show first non-repeated character. Press Enter to quit or 0 for next category.");
          Console.WriteLine("");

          // Get the users input
          Console.Write("Enter a word:");
          strValue = Console.ReadLine();

          if (strValue == "")
          {
            throw new Exception("No string was entered. You must enter a string...");
          }
          else if (strValue != "0")
          {
            char? cFirstNonRepChar = null;

            foreach (char c in strValue)
            {
              if (strValue.Count(x => x == c) == 1)
              {
                cFirstNonRepChar = c;
                break;
              }
            }

            if (cFirstNonRepChar != null)
            {
              Console.WriteLine($"The first non-repeating character of \"{strValue}\" is \"{cFirstNonRepChar}\" character.");
            }
            else
            {
              Console.WriteLine($"The were no non-repeating characters in the string \"{strValue}\".");
            }
          }
        } while (strValue != "0");
        #endregion

        #region Check two words and see if they are Anagrams
        // Display the category of the game
        Console.WriteLine("Check two words and see if they are Anagrams. Press Enter to quit or 0 for next category.");
        Console.WriteLine("");

        // Read the string
        Console.Write("Enter word 1:");
        string? strWord1 = Console.ReadLine();

        if (strWord1 != "0")
        {
          if (strWord1 == "")
          {
            throw new Exception("No string was entered. You must enter a string...");
          }
          else if (strWord1 != "0")
          {
            if (strWord1 == "0")
            {
              return;
            }

            // Get the users input for word 2
            Console.Write("Enter word 2:");
            string? strWord2 = Console.ReadLine();

            // Convert the two words to lower case
            string strWord1_tolower = strWord1.Trim().ToLower();
            string strWord2_tolower = strWord2.Trim().ToLower();

            int iCharMatchCnt = 0;


            // Check length of each word
            if ( strWord1_tolower.Length == strWord2_tolower.Length ) 
            {
              foreach (char c in strWord1_tolower)
              {
                if (strWord2_tolower.Contains(c))
                {
                  iCharMatchCnt++;
                }
              }

              if (iCharMatchCnt == strWord2_tolower.Length)
              {
                Console.WriteLine($"The two words \"{strWord1}\" and \"{strWord2}\" are Anagrams.");
              }
            }
            else
            {
              Console.WriteLine($"The two words \"{strWord1}\" and \"{strWord2}\" are not Anagrams as they are of different length.");
            }
          }
        }
        #endregion

        #region Capitalize the word or each word in a sentence
        do
        {
          // Display the category of the game
          Console.WriteLine("Capitalize the word or each word in a sentence. Press Enter to quit or 0 for next category.");
          Console.WriteLine("");

          // Get the users input
          Console.Write("Enter a word or sentence:");
          strValue = Console.ReadLine();

          if (strValue == "")
          {
            throw new Exception("No string was entered. You must enter a string...");
          }
          else if (strValue != "0")
          {
            int iWordCnt = 0;

            // Split the word or words into string array
            string[] saSentence = strValue.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Capitalize the first character of each word in the string array
            foreach (string strWords in saSentence)
            {
              saSentence[iWordCnt] = char.ToUpper(strWords[0]) + strWords.Substring(1);
              iWordCnt++;
            }

            // Join the string back together and display it
            strValue = string.Join(' ', saSentence);

            Console.WriteLine($"The 1st character of each word capitalization sentence is \"{strValue}\".");
          }
        } while (strValue != "0");
        #endregion

        #region Remove all spaces from a sentence
        do
        {
          // Display the category of the game
          Console.WriteLine("Remove all spaces from a sentence. Press Enter to quit or 0 for next category.");
          Console.WriteLine("");

          // Get the users input
          Console.Write("Enter a word or sentence:");
          strValue = Console.ReadLine();

          if (strValue == "")
          {
            throw new Exception("No string was entered. You must enter a string...");
          }
          else if (strValue != "0")
          {
            // Split the word or words into string array
            string[] saSentence = strValue.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Join the string back together without the spaces
            strValue = string.Join("", saSentence);

            // Display the sentence without the spaces
            Console.WriteLine($"Removed the spaces from the sentence.  The amended sentence is \"{strValue}\".");
          }
        } while (strValue != "0");
        #endregion

        #region Split a CSV comma delimited string and display its contents one below the other 
        do
        {
          // Display the category of the game
          Console.WriteLine("Split a CSV comma delimited string and display its contents one below the other. Press Enter to quit or 0 for next category.");
          Console.WriteLine("");

          // Get the users input
          Console.Write("Enter a word or sentence:");
          strValue = Console.ReadLine();

          if (strValue == "")
          {
            throw new Exception("No string was entered. You must enter a string...");
          }
          else if (strValue != "0")
          {
            // Split the word or words into string array
            string[] saCSVLine = strValue.Split(',', StringSplitOptions.RemoveEmptyEntries);

            // Empty the string value to hold the new string
            string strValue2 = "";

            // Build a multi-line string from the CSV values
            foreach (string strWord in saCSVLine)
            {
              strValue2 += strWord.Trim().ToString();
              strValue2 += Environment.NewLine;

              // I also could of done it this way:
              //strValue2 += strWord.Trim().ToString() + Environment.NewLine;
            }
            
            // Display the CSV comma delimited line and each word extracted from the CSV line
            Console.WriteLine($"The CSV comma delimited line is \"{strValue}\".");
            Console.WriteLine($"The data from splitting the CSV line is:");
            Console.WriteLine($"{strValue2}");
          }
        } while (strValue != "0");
        #endregion
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }
  }
}
