using System;

namespace MyList
{
   class Program
   {
      static void Main(string[] args)
      {
         var list = new MyList<string>();

         list.Add("Good");
         list.Add("Bad");
         list.Add("Ugly");

         list.Insert(3, "Terrible");
         
         Console.WriteLine(list[3]);
         Console.WriteLine();
         Console.WriteLine(list.Count);

         list.Reverse();
         Console.WriteLine(list.Contains("Bad"));
         Array.ForEach(list.ToArray(), Console.WriteLine);

         var list2 = new MyList<int> { 1,2,3,4,5};
         list2.Reverse();


      }
   }
}
