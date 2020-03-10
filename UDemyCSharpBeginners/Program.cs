using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UDemyCSharpBeginners
{
    class Program
    {
        // NOTES
        // For all these exercises, ignore input validation unless otherwise specified. 
        // Assume the user provides input in the format that the program expects. 

        public enum ImageOrientation
        {
            Landscape,
            Portrait
        }

        static void Main(string[] args)
        {
            string input;
            var textPath = "";
            int inputValue;
            int value1;
            int value2;
            int count;
            int min;
            int max;
            var builder = new StringBuilder();
            var numbers = new List<int>();
            var inputValues = new string[1];

            /*EXERCISE 1
            Write a program and ask the user to enter a number. 
            The number should be between 1 to 10. If the user enters a valid number,
            display "Valid" on the console.Otherwise, display "Invalid".
            (This logic is used a lot in applications where values entered into 
            input boxes need to be validated.)
            */

            min = 1;
            max = 10;
            Console.WriteLine("Enter a number between 1-10:");
            input = Console.ReadLine();
            inputValue = Convert.ToInt32(input);
            if (min <= inputValue && inputValue <= max)
                Console.WriteLine("Valid");
            else
                Console.WriteLine("Invalid");

            Console.WriteLine();
            /*EXERCISE 2
            Write a program which takes two numbers from the console and
            displays the maximum of the two.
            */

            Console.WriteLine("Enter two numbers:");
            value1 = Convert.ToInt32(Console.ReadLine());
            value2 = Convert.ToInt32(Console.ReadLine());
            if (value1 == value2)
                Console.WriteLine("The values are the same.");
            else
            {
                max = value1 > value2 ? value1 : value2;
                Console.WriteLine("The max input is: " + max);
            }

            Console.WriteLine();
            /*EXERCISE 3
            Write a program and ask the user to enter the width and height of an image.
            Then tell if the image is landscape or portrait.
            */

            Console.WriteLine("Enter the width and then height of the picture.");
            value1 = Convert.ToInt32(Console.ReadLine());
            value2 = Convert.ToInt32(Console.ReadLine());
            var orientation = value1 > value2 ? ImageOrientation.Landscape : ImageOrientation.Portrait;
            Console.WriteLine("The image orientation is " + orientation);

            Console.WriteLine();
            /*EXERCISE 4
            Your job is to write a program for a speed camera. For simplicity, 
            ignore the details such as camera, sensors, etc and focus purely on the logic.
            Write a program that asks the user to enter the speed limit.
            Once set, the program asks for the speed of a car. If the user enters a value 
            less than the speed limit, program should display Ok on the console.
            If the value is above the speed limit, the program should calculate the number of 
            demerit points. For every 5km/hr above the speed limit, 1 demerit points should be
            incurred and displayed on the console. If the number of demerit points is above 12,
            the program should display License Suspended.
            */

            Console.WriteLine("Please enter the speed limit:");
            int speedLimit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the speed of the car:");
            int carSpeed = Convert.ToInt32(Console.ReadLine());
            if (carSpeed < speedLimit)
                Console.WriteLine("Ok");
            else
            {
                int demeritFactor = 5;
                int demeritSuspensionFactor = 12;
                int demerits = (carSpeed - speedLimit) / demeritFactor;
                Console.WriteLine("Total Deremits: {0}", demerits);
                if (demerits > demeritSuspensionFactor)
                    Console.WriteLine("License Suspended.");
            }

            Console.WriteLine();
            /*EXERCISE 5
            Write a program to count how many numbers between 1 and 100 are divisible
            by 3 with no remainder. Display the count on the console.
            */

            int divisible = 3;
            count = 0;
            for (int i = 0; i <= 100; i++)
            {
                if (i % divisible == 0)
                    count++;
            }
            Console.WriteLine("{0} numbers are divisible by {1} between 1 and 100", count, divisible);

            Console.WriteLine();
            /*EXERCISE 6
            Write a program and continuously ask the user to enter a number or "ok" to exit.
            Calculate the sum of all the previously entered numbers and display it on the console.
            */

            int runningSum = 0;
            string terminationString = "ok";
            Console.WriteLine("Enter numbers: (Enter \"ok\" to quit.)");
            while (true)
            {
                input = Console.ReadLine();
                if (input.ToLower() == terminationString)
                    break;
                runningSum += Convert.ToInt32(input);
            }
            Console.WriteLine("The total of the numbers enter is {0}", runningSum);

            Console.WriteLine();
            /*EXERCISE 7
            Write a program and ask the user to enter a number.
            Compute the factorial of the number and print it on the console.
            For example, if the user enters 5, the program should calculate 5 x 4 x 3 x 2 x 1
            and display it as 5! = 120.
            */

            Console.WriteLine("Enter a number:");
            inputValue = Convert.ToInt32(Console.ReadLine());
            int factorialSum = 1;
            for (int i = 1; i <= inputValue; i++)
                factorialSum *= i;
            Console.WriteLine("{0}! = {1}", inputValue, factorialSum);

            Console.WriteLine();
            /*EXERCISE 8
            Write a program that picks a random number between 1 and 10.
            Give the user 4 chances to guess the number. If the user guesses the number,
            display “You won"; otherwise, display “You lost".
            (To make sure the program is behaving correctly, you can display the secret number
            on the console first.)
            */

            min = 1;
            max = 10;
            var random = new Random();
            var randomNumber = random.Next(min, max);
            var numberOfGuesses = 4;
            bool won = false;
            Console.WriteLine("Secret Number is : " + randomNumber);
            for (int i = 0; i < numberOfGuesses; i++)
            {
                Console.WriteLine("Guess the secret number:");
                if (Convert.ToInt32(Console.ReadLine()) == randomNumber)
                {
                    Console.WriteLine("You win!");
                    won = true;
                    break;
                }
                Console.WriteLine("Try Again.");
            }
            if (!won)
                Console.WriteLine("You lose!");

            Console.WriteLine();
            /*EXERCISE 9
            Write a program and ask the user to enter a series of numbers separated by comma.
            Find the maximum of the numbers and display it on the console.
            For example, if the user enters “5, 3, 8, 1, 4", the program should display 8.
            */

            Console.WriteLine("Enter a series of comma-separated numbers:");
            input = Console.ReadLine();
            var inputArray = input.Split(",");
            max = Convert.ToInt32(inputArray[0]);
            foreach (var str in inputArray)
            {
                var number = Convert.ToInt32(str);
                if (max < number)
                    max = Convert.ToInt32(number);
            }
            Console.WriteLine("Max number entered is " + max);

            Console.WriteLine();
            /*EXERCISE 10
            When you post a message on Facebook, depending on the number of people who like your post,
            Facebook displays different information.
                -If no one likes your post, it doesn't display anything.
                -If only one person likes your post, it displays: [Friend's Name] likes your post.
                -If two people like your post, it displays: [Friend 1] and [Friend 2] like your post.
                -If more than two people like your post, it displays: [Friend 1], [Friend 2] and [Number of Other People] others like your post.
            Write a program and continuously ask the user to enter different names,
            until the user presses Enter (without supplying a name).
            Depending on the number of names provided, display a message based on the above pattern.
            */

            var names = new List<string>();
            Console.WriteLine("Enter names: (Press enter to quit)");
            while (true)
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;
                names.Add(input);
            }
            if (names.Count == 0)
                Console.WriteLine("No one linked the post.");
            else if (names.Count == 1)
                Console.WriteLine("{0} likes your post.", names[0]);
            else if (names.Count == 2)
                Console.WriteLine("{0} and {1} like your post.", names[0], names[1]);
            else
                Console.WriteLine("{0}, {1}, and others like your post.", names[0], names[1]);

            Console.WriteLine();
            /*EXERCISE 11
            Write a program and ask the user to enter their name.
            Use an array to reverse the name and then store the result in a new string.
            Display the reversed name on the console.
            */

            Console.WriteLine("Enter your name:");
            input = Console.ReadLine();
            var nameArray = new List<Char>(input.ToCharArray());
            nameArray.Reverse();
            builder.Clear();
            foreach (char c in nameArray)
                builder.Append(c);
            Console.WriteLine("Your name reversed is " + builder.ToString());

            Console.WriteLine();
            /*EXERCISE 12
            Write a program and ask the user to enter 5 numbers.
            If a number has been previously entered, display an error message and ask the user to re-try.
            Once the user successfully enters 5 unique numbers,
            sort them and display the result on the console.
            */

            int numbersWanted = 5;
            Console.WriteLine("Please enter " + numbersWanted + " unique numbers:");
            numbers.Clear();
            while (true)
            {
                if (numbers.Count == numbersWanted)
                    break;
                inputValue = Convert.ToInt32(Console.ReadLine());
                if (!numbers.Contains(inputValue))
                {
                    numbers.Add(inputValue);
                    continue;
                }
                Console.WriteLine("That number was entered already.");
            }
            numbers.Sort();
            builder.Clear();
            foreach (int num in numbers)
                builder.Append(num + " ");
            Console.WriteLine("Your numbers sorted are: " + builder.ToString());

            Console.WriteLine();
            /*EXERCISE 13
            Write a program and ask the user to continuously enter a number or type "Quit" to exit.
            The list of numbers may include duplicates.
            Display the unique numbers that the user has entered.
            */

            numbers.Clear();
            Console.WriteLine("Continuosuly enter numbers: (Enter \"Quit\" to exit.");
            while (true)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    break;
                numbers.Add(Convert.ToInt32(input));
            }
            var uniques = new List<int>();
            foreach (var num in numbers)
                if (!uniques.Contains(num))
                    uniques.Add(num);
            builder.Clear();
            foreach (var num in uniques)
                builder.Append(num + " ");
            Console.WriteLine("Unique numbers entered are: " + builder.ToString());

            Console.WriteLine();
            /*EXERCISE 14
            Write a program and ask the user to supply a list of comma separated numbers
            (e.g 5, 1, 9, 2, 10). If the list is empty or includes less than 5 numbers,
            display "Invalid List" and ask the user to re-try;
            otherwise, display the 3 smallest numbers in the list. 
            */

            Console.WriteLine("Enter a list of comma-separated numbers:");
            numbers.Clear();
            while (numbers.Count < 5)
            {
                input = Console.ReadLine();
                inputValues = input.Split(",");
                if (inputValues.Length < 5)
                    Console.WriteLine("Invalid list. Enter a list of comma-separated numbers(at least 5 numbers):");
                else break;
            }
            foreach (var str in inputValues)
                numbers.Add(Convert.ToInt32(str));
            var smallests = new List<int>();
            while (smallests.Count < 3)
            {
                min = numbers[0];
                foreach (var number in numbers)
                {
                    if (number < min)
                        min = number;
                }
                smallests.Add(min);
                numbers.Remove(min);
            }
            builder.Clear();
            foreach (var num in smallests)
                builder.Append(num + " ");
            Console.WriteLine("The 3 smallest numbers are: " + builder.ToString());

            Console.WriteLine();
            /*EXERCISE 15
            Write a program and ask the user to enter a few numbers separated by a hyphen.
            Work out if the numbers are consecutive. 
            For example, if the input is "5-6-7-8-9" or "20-19-18-17-16",
            display a message: "Consecutive"; otherwise, display "Not Consecutive".
            */

            Console.WriteLine("Enter a group of numbers separated by hyphens.");
            input = Console.ReadLine();
            inputValues = input.Split("-");
            numbers.Clear();
            foreach (var str in inputValues)
                numbers.Add(Convert.ToInt32(str));
            bool consecutive = true;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] + 1 == numbers[i + 1] || numbers[i] - 1 == numbers[i + 1])
                {
                    continue;
                }
                consecutive = false;
                break;
            }
            Console.WriteLine(consecutive ? "Consecutive numbers." : "Not consecutive numbers.");

            Console.WriteLine();
            /*EXERCISE 16
            Write a program and ask the user to enter a few numbers separated by a hyphen.
            If the user simply presses Enter, without supplying an input, exit immediately; otherwise,
            check to see if there are duplicates. If so, display "Duplicate" on the console.
            */

            Console.WriteLine("Enter a group of numbers separated by hyphens.");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                bool containsDuplicates = false;
                inputValues = input.Split("-");
                numbers.Clear();
                foreach (var str in inputValues)
                {
                    if (numbers.Contains(Convert.ToInt32(str)))
                        containsDuplicates = true;
                    numbers.Add(Convert.ToInt32(str));
                }
                Console.WriteLine(containsDuplicates ? "Contains duplicate numbers." : "Does not contain duplicate numbers.");
            }

            Console.WriteLine();
            /*EXERCISE 17
            Write a program and ask the user to enter a time value in the 24-hour time format (e.g. 19:00).
            A valid time should be between 00:00 and 23:59. If the time is valid, display "Ok";
            otherwise, display "Invalid Time". If the user doesn't provide any values, consider
            it as invalid time. 
            */

            {
                Console.WriteLine("Enter a time value in the 24-hour time format(e.g 19:00):");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid Time");
                    return;
                }
                inputValues = input.Split(":");
                if (inputValues.Length != 2)
                {
                    Console.WriteLine("Invalid Time");
                    return;
                }
                var hour = Convert.ToInt32(inputValues[0]);
                var minute = Convert.ToInt32(inputValues[1]);
                if (hour >= 0 && hour <= 23 && minute >= 0 && minute <= 59)
                    Console.WriteLine("Valid Time");
                else
                    Console.WriteLine("Invalid Time");
            }

            Console.WriteLine();
            /*EXERCISE 18
            Write a program and ask the user to enter a few words separated by a space.
            Use the words to create a variable name with PascalCase. For example, if the user types:
            "number of students", display "NumberOfStudents". Make sure that the program is not dependent
            on the input. So, if the user types "NUMBER OF STUDENTS",
            the program should still display "NumberOfStudents". 
            */

            Console.WriteLine("Enter words separated by space:");
            input = Console.ReadLine();
            inputValues = input.Split(" ");
            var variableName = "";
            foreach (var str in inputValues)
            {
                var firstChar = str[0];
                variableName += str.ToLower().Replace(firstChar.ToString().ToLower(), firstChar.ToString().ToUpper());
            }
            Console.WriteLine(variableName);

            Console.WriteLine();
            /*EXERCISE 19
            Write a program and ask the user to enter an English word.
            Count the number of vowels (a, e, o, u, i) in the word.
            So, if the user enters "inadequate", the program should display 6 on the console.
            */

            Console.WriteLine("Enter a word:");
            input = Console.ReadLine();
            var vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            var vowelCount = 0;
            foreach (var str in input.ToLower())
            {
                if (vowels.Contains(str))
                    vowelCount++;
            }
            Console.WriteLine(input + " contains {0} vowels.", vowelCount);

            Console.WriteLine();
            /*EXERCISE 20
            Write a program that reads a text file and displays the number of words.
            */

            textPath = @"D:\Projects\CSharpBeginnerUDemy\CSharpBeginnersUDemy\TextFile.txt"; // NOTE dynamic path construction was part of this course. Thus this will likely cause an exception on your PC.
            File.SetAttributes(textPath, FileAttributes.Normal);
            input = File.ReadAllText(textPath);
            inputValues = input.Replace("\n", " ").Split(" ");
            foreach (var str in inputValues)
                Console.WriteLine(str);
            Console.WriteLine("Number of words is " + inputValues.Length);

            Console.WriteLine();
            /*EXERCISE 21
            Write a program that reads a text file and displays the longest word in the file. 
            */

            textPath = @"D:\Projects\CSharpBeginnerUDemy\CSharpBeginnersUDemy\TextFile.txt"; // NOTE dynamic path construction was part of this course. Thus this will likely cause an exception on your PC.
            File.SetAttributes(textPath, FileAttributes.Normal);
            input = File.ReadAllText(textPath);
            inputValues = input.Replace("\n", " ").Split(" ");
            var longestString = "";
            foreach (var str in inputValues)
            {
                if (str.Length > longestString.Length)
                    longestString = str;
            }
            Console.WriteLine("Longest string is " + longestString);
        }
    }
}