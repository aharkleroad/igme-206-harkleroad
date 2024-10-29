/*
 * Aizlynn Harkleroad
 * 
 * Homework 3 - Gradebook
 * No known bugs or errors
 */

namespace HW3_Gradebook_AHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variable declaration
            bool isParsable;
            int numberOfGrades;
            string[] assignmentNames;
            double[] assignmentGrades;
            double averageScore = 0;
            int gradeToReplace;
            int aboveAverageGrades = 0;
            double highestGrade = -1;
            double lowestGrade = 101;
            bool areThereDuplicates = false;

            // prompts user to enter the number of assignments they are saving
            Console.Write("How many assignments are you saving? ");
            isParsable = int.TryParse(Console.ReadLine(), out numberOfGrades);
            //  continues to prompt the user until a valid input is given
            while (numberOfGrades <= 0 || !isParsable)
            {
                Console.Write("That is not a valid number. Enter the number of assignments: ");
                isParsable = int.TryParse(Console.ReadLine(), out numberOfGrades);
            }

            // prints the number of assignments being saved and initializes the assignment arrays
            // the size is the same as the number of assignments
            Console.WriteLine("You are saving " + numberOfGrades + " assignments.");
            assignmentNames = new string[numberOfGrades];
            assignmentGrades = new double[numberOfGrades];
            Console.WriteLine();

            // for all of the assignments, prompt the user to enter a name and grade
            for (int i = 0; i < numberOfGrades; i++)
            {
                Console.Write("Enter the name for assignment #" + (i + 1) + ": ");
                // initialize the corresponding index of assignmentNames
                assignmentNames[i] = Console.ReadLine().Trim();
                // if the name is 0 non-whitespace characters, prompt them again until a valid input is given
                // update the corresponding index of assignmentNames
                while (assignmentNames[i].Length == 0)
                {
                    Console.Write("That is not a valid name. Enter the name for assignment #" + (i + 1) + ": ");
                    assignmentNames[i] = Console.ReadLine().Trim();
                }
                Console.Write("Enter the grade for " + assignmentNames[i] + ": ");
                // initialize the corresponding index of assignmentGrades
                isParsable = double.TryParse(Console.ReadLine(), out assignmentGrades[i]);
                // if the assignment grade is outside the range of 0-100 or is not an integer, prompt again until a valid input is given
                // update the corresponding index of assignmentGrades
                while (assignmentGrades[i] < 0 || !isParsable || assignmentGrades[i] > 100)
                {
                    Console.Write("Grade must be between 0 and 100. Enter grade: ");
                    isParsable = double.TryParse(Console.ReadLine(), out assignmentGrades[i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("All grades are entered!");
            Console.WriteLine();

            // print a list of the assignments and grades in order
            // add the grade for each assignment to averageScore for future use
            Console.WriteLine("Grade Report:");
            for (int i = 0; i < numberOfGrades; i++)
            {
                Console.WriteLine("  " + (i + 1) + ". " + assignmentNames[i] + ": " + assignmentGrades[i]);
                averageScore += assignmentGrades[i];
            }
            Console.WriteLine("-----------------------------");
            // calculate and print the average score
            averageScore /= numberOfGrades;
            Console.WriteLine("Average: {0:F2}", averageScore);
            Console.WriteLine();

            // prompts the user to enter what grade value they want to replace
            Console.Write("Which number grade do you want to replace? ");
            isParsable = int.TryParse(Console.ReadLine(), out gradeToReplace);
            // prompts the user again if the assignment number does not exist or is not an integer
            while (gradeToReplace <= 0 || gradeToReplace > numberOfGrades || !isParsable)
            {
                Console.WriteLine("Index must be a number between 1 and " + numberOfGrades + ". Try again.");
                Console.Write("Which number grade do you want to replace? ");
                isParsable = int.TryParse(Console.ReadLine(), out gradeToReplace);
            }
            Console.WriteLine();

            // prompt the user to enter a new grade for the given assignment and updates the corresponding value in the grades array
            Console.Write("What is the new grade for " + assignmentNames[gradeToReplace - 1] + "? ");
            isParsable = double.TryParse(Console.ReadLine(), out assignmentGrades[gradeToReplace - 1]);
            // prompts the user again if the grade number is outside the 0-100 range or is not a double
            // updates the grade array at the given index
            while (assignmentGrades[gradeToReplace - 1] < 0 || assignmentGrades[gradeToReplace - 1] > 100 || !isParsable)
            {
                Console.Write("Grade must be between 0 and 100. Enter grade: ");
                isParsable = double.TryParse(Console.ReadLine(), out assignmentGrades[gradeToReplace - 1]);
            }
            Console.WriteLine();
            Console.WriteLine("Replacing the grade at index " + gradeToReplace + " with " + assignmentGrades[gradeToReplace - 1]);
            // resets the average to 0 to allow us to find the new average score
            averageScore = 0;
            Console.WriteLine();

            // print a list of the assignments and grades in order
            // add the grade for each assignment to averageScore for future use
            Console.WriteLine("Final Grade Report:");
            for (int i = 0; i < numberOfGrades; i++)
            {
                Console.WriteLine("  " + (i + 1) + ". " + assignmentNames[i] + ": " + assignmentGrades[i]);
                averageScore += assignmentGrades[i];
            }
            Console.WriteLine("-----------------------------");
            // calculate and print the average score
            averageScore /= numberOfGrades;
            Console.WriteLine("Final Average: {0:F2}", averageScore);
            Console.WriteLine();

            // check and track if each assignment's grade is greater than the average score
            // find the lowest and highest grade
            // check if there are any duplicates
            for (int i = 0; i < numberOfGrades; i++)
            {
                if (assignmentGrades[i] > averageScore)
                {
                    aboveAverageGrades++;
                }
                if (assignmentGrades[i] > highestGrade)
                {
                    highestGrade = assignmentGrades[i];
                }
                if (assignmentGrades[i] < lowestGrade)
                {
                    lowestGrade = assignmentGrades[i];
                }
                // only runs this code for an assignment if we haven't found a duplicate score yet
                if (!areThereDuplicates)
                {
                    // checks if the grade at the index we are at matches any future grades
                    for (int j = i + 1; j < numberOfGrades; j++)
                    {
                        if (assignmentGrades[j] == assignmentGrades[i])
                        {
                            areThereDuplicates = true;
                        }
                    }
                }
            }

            // prints the number of grades that have above average scores, the highest and lowest score, and if there are any duplicates
            Console.WriteLine(aboveAverageGrades + " grades are above average.");
            Console.WriteLine();
            Console.WriteLine("The highest grade is " + highestGrade);
            Console.WriteLine("The lowest grade is " + lowestGrade);
            Console.WriteLine();
            if (areThereDuplicates)
            {
                Console.WriteLine("A grade appears more than once in this set of grades.");
            }
            else
            {
                Console.WriteLine("All grades are unique.");
            }
        }
    }
}
