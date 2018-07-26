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

            string UserChoice = "y";
            while (UserChoice == "y" || UserChoice =="yes")
            {
                PrintArray(Students);

                int x = GetValidIndex();

                string FoodOrHome = GetValidFoodOrHome(Students, x);

                Output(Students, FavoriteFood, Hometown, FoodOrHome, x);

                UserChoice = ContinueLoop();
                Console.Clear();
            }

            Console.WriteLine("Thanks! Press any key to exit");
            Console.ReadKey();
        }

        private static string ContinueLoop()
        {
            string UserChoice;
            Console.WriteLine("Would you like to know about someone else? (Type y to open main menu)");
            UserChoice = Console.ReadLine();
            UserChoice = ValidateString(UserChoice);
            return UserChoice;
        }

        private static string GetValidFoodOrHome(string[] Students, int x)
        {
            Console.WriteLine($"That is {Students[x - 1]}. What would you like to know about {Students[x - 1]}? (Favorite Food or Hometown?)");

            string FoodOrHome = Console.ReadLine();

            FoodOrHome = ValidateString(FoodOrHome); //Catches Drew's ctrl+Z trick & returns conversion to lowercase
            FoodOrHome = ValidateFoodHome(FoodOrHome);
            return FoodOrHome;
        }

        private static int GetValidIndex()
        {
            Console.WriteLine("Which student would you like to know more about? (enter a number 1-5)");
            string UserInput = Console.ReadLine();

            int UserInputVal = Validate(UserInput);
            int x = IsOption(UserInputVal);
            return x;
        }

        public static int Validate(string UserInput1)
        {
            try
            {
                int.Parse(UserInput1);
                return (int.Parse(UserInput1));
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
            catch (Exception f)
            {
                Console.WriteLine(f.Message);
                return 0;
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
        public static void Output(string[] stud, string[] food, string[] home, string input, int x)
        {
            if (input == "food")
            {
                Console.WriteLine($"{stud [x-1]}'s favorite food is {food[x - 1]}.");
            }
            else if (input == "home")
            {
                Console.WriteLine($"{stud[x - 1]}'s hometown is {home[x - 1]}.");
            }
            else
            {
                Console.WriteLine("Fatal Error"); //Cathes potential logical errors and allows user to restart
            }
        }
                
        public static string ValidateString(string UserInput)
        {//Catches Hackers
            try
            {
                UserInput = UserInput.ToLower();
                return (UserInput);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return "0";
            }
            catch (Exception f)
            {
                Console.WriteLine(f.Message);
                return "0";
            }
        }
        public static int IsOption(int validatedInput)
        {
            while (validatedInput <= 0 || validatedInput >= 6)
            {
                Console.WriteLine("That is not an option- Please enter a valid number/option");
                string UserInput = Console.ReadLine();
                validatedInput = Validate(UserInput);
            }
            return validatedInput;
        }
        public static void PrintArray(string[] list)
        {
            foreach ( string item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
