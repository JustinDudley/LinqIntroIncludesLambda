using System;
using System.Linq;
using System.Collections.Generic;

// new comment
namespace LINQIntroIncludesLambdaConsole {

    // NEW CLASS (created for FIRST example)
    class User {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
    }

    // REGULAR CLASS
    class Program {

        static void Main(string[] args) {

            // FIRST EXAMPLE:  INSTANCES OF "USER" CLASS, ORGANIZED USING BOTH QUERY AND METHOD SYNTAX.
            var users = new User[] {
                new User() { Name = "Adam", IsAdmin= false },
                new User() { Name = "Barb", IsAdmin = true },
                new User() { Name = "Chris", IsAdmin = false },
                new User() { Name = "Donna", IsAdmin = true },
                new User() { Name = "Ed", IsAdmin = false },
                new User() { Name = "Faith", IsAdmin = true }
            };      //defining data.  semicolon AFTER curly brace

            // (1) METHOD SYNTAX:  (ALWAYS start with variable name for the collection)
            var admins = users.Where(u => u.IsAdmin).OrderByDescending(u => u.Name);    //...u.IsAdmin == true

           // (2) QUERY SYNTAX: --3 lines--
             admins = from usr in users
                         where usr.IsAdmin          // where usr.IsAdmin == true, newbie-style
                         orderby usr.Name descending               // OrderBy?  Need capitals??  
                         select usr;

            foreach (var user in admins) {
                Console.WriteLine($"Name is {user.Name} is an admin.");
            }





            // SECOND EXAMPLE:  INTEGER ARRAY, ORGANIZED USING BOTH QUERY AND METHOD SYNTAX.
            int[] ints = { 2, 4, 6, 8, 7, 5, 3, 1 };         // want to put into sequence
            var ascInts = (from i in ints                    // reminiscent of SQL. This doesn't look like C# code, this is new.  It's a DECLARATIVE language, right here in the midst of C#.  Just say what you want done, don't specify how.  "We've defined a query AGAINST our collection"
                           where i % 2 == 1 && i < 7        
                           orderby i   //descending              
                           select i);
            foreach (var i in ascInts) {                 // NOW the query gets executed. Defining a query doesn't execute it. Execution is delayed until something in the code references it. 
                Console.Write($"{i} ");                 // "interpolated string"
            }
            Console.WriteLine();

            // IF WANT AVERAGE:  CAN'T DO WITH QUERY SYNTAX, NEED METHOD SYNTAX
            //  => "the fat arrow"   'such that'  // lambda (fred => fred.Firstname == "Greg"  sim. to foreach(var fred in ints), also see H-W notes 


            var avg = ascInts.Average(i => i); // this line is the method syntax.  And /(or?) Lambda syntax.  COULD do the above 4 lines in method syntax.  "Chaining them together".  Query syntax not good for aggreagate functions  // not going to exclude any.   i=> i  get ALL in the collection  //WEIRD SYNTAX.  LAMBDA SYNTAX.  (comes from functional programming)
            var simpAvg = ascInts.Average();  //same thing, just eliminating the i => i part.  It's ... implied?
            Console.WriteLine($"\nAverage of odds LT 7 is {avg}");
            Console.WriteLine($"\nAverage of odds LT 7 is {simpAvg}");

            var evenInts = ints.Sum(i => i);
            Console.Write(evenInts);

            // int[] ints = { 2, 4, 6, 8, 7, 5, 3, 1 }; 
            //.Where, .Sum, .Average, .Min, .Max, .Contains, .All, .First, .Join, .OrderBy, .ToList

            var thing1 = ints.Where(i => i % 3 == 1);
            var thing2 = ints.Sum(i => i + 3);
            var thing3 = ints.Average(i => i);
            var thing4 = ints.Min(i => i + 10);
            var thing5 = ints.Max(i => i / 2);
            var thing6 = ints.Contains(4);
            var thing7 = ints.All(i => i % 1 == 0);
            var thing8 = ints.First(i => i == 6);
            var thing9 = ints.OrderBy(i => i);
            var thing10 = ints.ToList();

            Console.WriteLine(thing1);
            Console.WriteLine(thing2);
            Console.WriteLine(thing3);
            Console.WriteLine(thing4);
            Console.WriteLine(thing5);
            Console.WriteLine(thing6);
            Console.WriteLine(thing7);
            Console.WriteLine(thing8);
            Console.WriteLine(thing9);
            Console.WriteLine(thing10);

            // NOTES:

            //In LINQ,  Eexist 2 syntaxes you can use
            //  - Query syntax (recommended)
            //  - Method syntax (for the few things you can't do with Query syntax.  Method syntax is
            //    more cryptic.  Greg likes Method syntax)


            // we'll be working mostly with class intances, not just lists of numbers. . instance.subcolumn, most of the 
            // time.  Not just sorting integers.
            // query syntax more readable, but doesn't do everything you need. Doesn't handle aggregate functions


            // also can be used in generic collections (List<>, etc.)
            //lambda is used in method syntax. 
            //don't be scared of lambda.  Some people are.
            // JD find more tutorials:  suss out 'linq', 'method', 'lambda', 'query'  --and how are they used?


            //LINQ SYNTAX great to subset the data.
            //in users, we have no wayto   search the data.  "Bring me back all the admins".  THEN go through a foreach 
            // loop, get all the admins
            //with linq syntax, you get the admins right away.  With just a couple of lines of code.  


            //(this is an inline query"  -what does that mean?
            //Query syntax:  Query the array. output the results


        }
    }
}
