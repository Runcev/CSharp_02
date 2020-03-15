using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Keneyz_02.Model
{
    class Person
    {
        public DateTime DateOfBirth { set; get; }

        public int Age { set; get; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Chinese { get; private set; }

        public string Western { get; private set; }

        public string IsBirthday { get; set; }

        public string IsAdult { get; internal set; }

        public void Calculator()
        {
            Age = AgeCount();
            IsBirthday = CheckBirthday();
            IsAdult = CheckAdult();
            Chinese = ChineseCount();
            Western = WesternCount();

        }

        private int AgeCount()
        {

            var dateNow = DateTime.Now;
            var year = dateNow.Year - DateOfBirth.Year;

            if (dateNow.Month < DateOfBirth.Month || (dateNow.Month == DateOfBirth.Month && dateNow.Day < DateOfBirth.Day))
            {
                year--;
            }

            Age = year;

            return Age;
        }

        private string CheckBirthday()
        {
            return DateOfBirth == default ? "" : ((DateOfBirth.Day == DateTime.Now.Day) && (DateOfBirth.Month == DateTime.Now.Month)).ToString();
        }

        private string CheckAdult()
        {
            return DateOfBirth == default ? "" : (Age >= 18).ToString();
        }

        private string WesternCount()
        {
            switch (DateOfBirth.Month)
            {
                case 1:
                    return (DateOfBirth.Day < 20) ? "Capricorn" : "Aquarius";
                case 2:
                    return (DateOfBirth.Day < 19) ? "Aquarius" : "Pisces";
                case 3:
                    return (DateOfBirth.Day < 21) ? "Pisces" : "Aries";
                case 4:
                    return (DateOfBirth.Day < 20) ? "Aries" : "Taurus";
                case 5:
                    return (DateOfBirth.Day < 21) ? "Taurus" : "Gemini";
                case 6:
                    return (DateOfBirth.Day < 21) ? "Gemini" : "Cancer";
                case 7:
                    return (DateOfBirth.Day < 23) ? "Cancer" : "Leo";
                case 8:
                    return (DateOfBirth.Day < 23) ? "Leo" : "Virgo";
                case 9:
                    return (DateOfBirth.Day < 23) ? "Virgo" : "Libra";
                case 10:
                    return (DateOfBirth.Day < 23) ? "Libra" : "Scorpio";
                case 11:
                    return (DateOfBirth.Day < 22) ? "Scorpio" : "Sagittarius";
                default:
                    return (DateOfBirth.Day < 22) ? "Sagittarius" : "Capricorn";
            }
        }

        private string ChineseCount()
        {
            string[] chineseName =
            {
                "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake",
                "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig"
            };

            var index = Math.Abs(DateOfBirth.Year - 1900) % 12;

            return chineseName[index];
        }

        public Person(string name, string surname, string email, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public Person(string name, string surname, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = birthday;
        }
    }
}