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
          Console.WriteLine("Reverse the value of the string. Enter nothing to exit or 0 for next category.");
          Console.WriteLine("");

          // Read the word
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

        #region Check for Palindrome
        do
        {
          // Display the category of the game
          Console.WriteLine("Check to see if a word is a Palindrome. Enter nothing to exit or 0 for next category");
          Console.WriteLine("");
          
          // Read the word
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
          Console.WriteLine("Count all the vowels of the string entered. Enter nothing to exit or 0 for next category.");
          Console.WriteLine("");
          
          // Read the word
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
          Console.WriteLine("Count all the words of the sentence. Enter nothing to exit or 0 for next category.");
          Console.WriteLine("");

          // Read the word
          Console.Write("Enter a word or sentence:");
          strValue = Console.ReadLine();

          if (strValue == "")
          {
            throw new Exception("No string was entered. You must enter a string...");
          }
          else if (strValue != "0")
          {
            int iWordCnt = 0;

            for (int i = 0; i < strValue.Length; i++)
            {
              if (strValue[i].ToString() == " " ||
                  strValue[i].ToString() == ". " ||
                  strValue[i].ToString() == ".  ")
              {
                iWordCnt++;
              }
            }

            iWordCnt += 1;
            Console.WriteLine($"The word or sentence \"{strValue}\" contains {iWordCnt.ToString()} word(s).");
          }
        } while (strValue != "0");
        #endregion

        #region Remove all duplicate characters
        do
        {
          // Display the category of the game
          Console.WriteLine("Remove all duplicate characters. Enter nothing to exit or 0 for next category.");
          Console.WriteLine("");

          // Read the word
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

        #region Count all occurances of a substring within a string
        do
        {
          // Display the category of the game
          Console.WriteLine("Count all occurances of a substring within a string.  Enter nothing to exit or 0 for next category.");
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

            // Read the occurance
            Console.Write("Enter occurance:");
            string? strOccurance = Console.ReadLine();

            int iOccCnt = 0;
            int index = 0;

            while ((index = strValue.IndexOf(strOccurance, index)) != -1)
            {
              iOccCnt++;
              index += strOccurance.Length;
            }

            Console.WriteLine($"The occurance \"{strOccurance}\" in the string \"{strValue}\" appears {iOccCnt.ToString()} times.");
          }
        } while (strValue != "0");
        #endregion

        #region Show first non-repeated character
        do
        {
          // Display the category of the game
          Console.WriteLine("Show first non-repeated character. Enter nothing to exit or 0 for next category.");
          Console.WriteLine("");

          // Read the word
          Console.Write("Enter a word:");
          strValue = Console.ReadLine();

          if (strValue == "")
          {
            throw new Exception("No string was entered. You must enter a string...");
          }
          else if (strValue != "0")
          {
            int index = -1;
            int idx = 0;

            while ((strValue.IndexOf(strValue[idx], idx + 1)) != -1)
            {
              index = strValue.IndexOf(strValue[idx], idx + 1);
              idx++;
            }

            if (index > 0)
            {
              Console.WriteLine($"The first non-repeating character of \"{strValue}\" is \"{strValue[idx]}\" character.");
            }
            else
            {
              Console.WriteLine($"The were no repeating characters for string \"{strValue}\".");
            }
          }
        } while (strValue != "0");
        #endregion

        #region Check two words and see if they are Anagrams
        // Display the category of the game
        Console.WriteLine("Check two words and see if they are Anagrams. Enter nothing to exit or 0 for next category.");
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

            // Read the word 2
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

        #region Capitolize the word or each word a sentence
        do
        {
          // Display the category of the game
          Console.WriteLine("Capitolize the word or each word a sentence. Enter nothing to exit or 0 for next category.");
          Console.WriteLine("");

          // Read the word
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

            Console.WriteLine($"The 1st character capitalization sentence is \"{strValue}\".");
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
