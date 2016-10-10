using System;
using System.Globalization;

namespace lab_01
{
    public class Task2
    {
        public static void Run()
        {
            var name = ReadName();
            var birthday = ReadBirthday();

            Console.WriteLine($"{name}, you've lived {GetYearsFromToday(birthday)} years so far");
            Console.WriteLine($"{name}, you've lived {GetMonthFromToday(birthday)} months so far");
            Console.WriteLine($"{name}, you've lived {GetDaysFromToday(birthday)} days so far");
            Console.WriteLine($"{name}, you've lived {GetHoursFromToday(birthday)} hours so far");
            Console.WriteLine($"{name}, you've lived {GetMinutesFromToday(birthday)} minutes so far");
        }

        private static string ReadName()
        {
            Console.WriteLine("Please enter your name");

            var name = Console.ReadLine();
            if (name.Length < 1)
            {
                Console.WriteLine("Name is too short");
                return ReadName();
            }

            return name;
        }

        private static DateTime ReadBirthday()
        {
            Console.WriteLine("Please enter your birthday in format DD.MM.YYYY");

            DateTime birthday;
            var birthdayString = Console.ReadLine();

            try
            {
                birthday = ParseBirthday(birthdayString);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid date format. Try again");
                return ReadBirthday();
            }

            return birthday;
        }

        private static DateTime ParseBirthday(string birthdayString)
        {
            return DateTime.ParseExact(birthdayString, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }

        private static int GetYearsFromToday(DateTime date)
        {
            var todayDate = DateTime.Today;
            return todayDate.Year - date.Year;
        }

        private static int GetMonthFromToday(DateTime date)
        {
            var years = GetYearsFromToday(date);
            return years * 12 + (date.Month - date.Month);
        }

        private static int GetDaysFromToday(DateTime date)
        {
            var todayDate = DateTime.Today;
            return (todayDate - date).Days;
        }

        private static int GetHoursFromToday(DateTime date)
        {
            var todayDate = DateTime.Today;
            return (int) (todayDate - date).TotalHours;
        }

        private static int GetMinutesFromToday(DateTime date)
        {
            var todayDate = DateTime.Today;
            return (int) (todayDate - date).TotalMinutes;
        }
    }
}