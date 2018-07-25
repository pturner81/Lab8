using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Students = { "Student1", "Student2", "Student3", "Student4", "Student5" };
            string[] FavoriteFood = { "Food1", "Food2", "Food3", "Food4", "Food5"};
            string[] Hometown = { "Hometown1", "Hometown2", "Hometown3", "Hometown4", "Hometown5"};

            //process
            string UserChoice = "y";
            while (UserChoice == "y" || UserChoice =="yes")
            {
                Console.WriteLine("Which student would you like to know more about? (enter a number 1-5)");
                string UserInput = Console.ReadLine();

                UserInput = Validate(UserInput);

                while (int.Parse(UserInput) <= 0 || int.Parse(UserInput) >= 6)
                {
                    Console.WriteLine("That is not an option- Please enter a valid number/option");
                    UserInput = Console.ReadLine();
                    UserInput = Validate(UserInput);
                }

                int x = int.Parse(UserInput);

                Console.WriteLine($"That is {Students[x - 1]}. What would you like to know about {Students[x - 1]}? (Favorite Food or Hometown?)");
                string FoodOrHome = Console.ReadLine();
                FoodOrHome = ValidateString(FoodOrHome); //Catches Drew's ctrl+Z trick & returns conversion to lowercase
                FoodOrHome = ValidateFoodHome(FoodOrHome);



                if (FoodOrHome == "food")
                {
                    Console.WriteLine($"{Students[x-1]}'s favorite food is {FavoriteFood[x - 1]}.");
                }
                else if (FoodOrHome == "home")
                {
                    Console.WriteLine($"{Students[x-1]}'s hometown is {Hometown[x - 1]}.");
                }
                else
                {
                    Console.WriteLine("Fatal Error"); //Cathes potential logical errors and allows user to restart
                }

                Console.WriteLine("Would you like to know about someone else? (Type y to open main menu)");
                UserChoice = Console.ReadLine();
                UserChoice = ValidateString(UserChoice);
            }

            Console.WriteLine("Thanks! Press any key to exit");
            Console.ReadKey();
        }
        public static string Validate(string UserInput1)
        {
            try
            {
                int.Parse(UserInput1);
                return (UserInput1);
            }
            catch (Exception)
            {
                return "0";
            }
        }
        public static string ValidateFoodHome(string UserInput2)
        {
            while (UserInput2 != "food" && UserInput2 != "favorite food" && UserInput2 != "hometown" && UserInput2 != "home")
            {
                Console.WriteLine("That is not an option - Please select a valid option");
                UserInput2 = Console.ReadLine();
                UserInput2 = ValidateString(UserInput2);
            }
            if (UserInput2 == "food" || UserInput2 == "favorite food")
            {
                return "food";
            }
            return "home";
        }
                
        public static string ValidateString(string UserInput)
        {//Catches Hackers
            try
            {
                UserInput = UserInput.ToLower();
                return (UserInput);
            }
            catch (Exception)
            {
                return "0";
            }
        }
    }
}
