using System;
using System.Linq;


namespace MyList
{
   public static class MyStringExtension
   {
      public static int[] ToArray(this string str, string enumerable)
      {
         if (ContainsDigitsAndCommas(enumerable))
         {
            string[] splittedArray = enumerable.Split(',');
            int[] resultArray = new int[splittedArray.Length];

            for (int i = 0; i < resultArray.Length; i++)
            {
               resultArray[i] = int.Parse(splittedArray[i]);
            }

            return resultArray;
         }

         throw new FormatException("Wrong string");
      }

      public static bool ContainsDigitsAndCommas(string enumerable)
      {
         return (!string.IsNullOrEmpty(enumerable))
             && (enumerable.Contains(','));
      }
   }
}
